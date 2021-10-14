using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMoney:MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Shopp _shop;
    [SerializeField] private GameMoney _money;

    private void OnEnable()
    {
        _shop.Opened+= OnShopOpened;
    }

    private void OnDisable()
    {
        _shop.Opened-= OnShopOpened;
    }

    private void OnShopOpened()
    {
        var money = _money.Load();
        _text.text = money.Value.ToString();
    }
}
