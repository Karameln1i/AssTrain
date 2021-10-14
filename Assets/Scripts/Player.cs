using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _money=500;

    public event UnityAction MoneyChanged;

    private void Start()
    {
        MoneyChanged?.Invoke();
    }
    
    public void AddMoney(int money)
    {
        _money += money;
        MoneyChanged?.Invoke();
    }

    public void BuyCloth(Cloth cloth)
    {
        Debug.Log("kuplenna");
        _money -= cloth.Price;
        MoneyChanged?.Invoke();
    }
}
