using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ClothPresenter:MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Image _preview;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;
    [SerializeField] private PutOnClothes _putOnClothes;
    
    private ClothData _data;

    public ClothData Data => _data;
    
    public event UnityAction<ClothData,ClothPresenter> SellButtonClick;
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }
    
    public void Render(ClothData data)
    {
        _data = data;

        _preview.sprite = data.Preview;
        _text.text = data.Price.ToString();
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_data, this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClothInventory inventory=ClothInventory.Load();
        if (inventory.Contains(_data))
        {
            _putOnClothes.PutOnInClick(_data);
            inventory.SelectCloth(_data);
            inventory.Save();
        }
    }

    public void Bued()
    {
        _text.text = "Bought";
        _button.enabled = false;
    }
}