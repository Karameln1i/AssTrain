using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Shopp : MonoBehaviour
    {
        [SerializeField] private GameMoney _money;
        [SerializeField] private Animator _animator;
        [SerializeField] private ClothDataBase _dataBase;
        [SerializeField] private ClothListView _listView;

        private bool _isOpened = false;
        
        private List<ClothPresenter> _presenters;

        public bool IsOpened => _isOpened;
        public ClothDataBase DataBase => _dataBase;

        public event UnityAction Opened;

        private void Start()
        {
            _presenters = _listView.Render(_dataBase.Data);
            CheckBuiedClothes();

            foreach (var presenter in _presenters)
            {
                presenter.SellButtonClick += OnSellButtonClick;
            }
        }

        private void OnDestroy()
        {
            foreach (var presenter in _presenters)
            {
                presenter.SellButtonClick -= OnSellButtonClick;
            }
        }

        private void CheckBuiedClothes()
        {
            var inventory = ClothInventory.Load();
            for (int i = 0; i < _presenters.Capacity; i++)
            {
                if (inventory.Contains(_presenters[i].Data))
                {
                    _presenters[i].Bued();
                }
            }
        }
        
        private void OnSellButtonClick(ClothData cloth, ClothPresenter clothView)
        {
          
            var inventory = ClothInventory.Load();

            TrySellWeapon(cloth, clothView);
        }

        private void TrySellWeapon(ClothData cloth, ClothPresenter clothView)
        {
            GameMoney money = _money.Load();

            if (money.Value >= cloth.Price)
            {
                ClothInventory inventory = ClothInventory.Load();
                money.Spend(cloth.Price);
                money.Save();
                inventory.Add(cloth);
                inventory.Save();
                clothView.Bued();
            }
        }
        

        public void Open()
        {
            TurnOn();
            _animator.Play("ShopPanelOpen");
            Opened?.Invoke();
            _isOpened = true;
        }

        public void Close()
        {
            _animator.Play("ShopPanelClose");
            _isOpened = false;
        }

        public void Fade()
        {
            gameObject.SetActive(false);
        }

        public void TurnOff()
        {
            gameObject.SetActive(false);
        }

        public void TurnOn()
        {
            gameObject.SetActive(true);
        }
    }

