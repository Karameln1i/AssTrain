using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public  class GameMoney
{
    [SerializeField] private int _value;

    private const string GameMoneyKey = nameof(GameMoneyKey);

    public int Value => _value;

    public event UnityAction MoneyChanged;

    public void Add(int money)
    {
        _value += money;
    }

    public void Spend(int value)
    {
        _value -= value;
        MoneyChanged?.Invoke();
    }

    public  GameMoney Load()
    {
      
        
        if (PlayerPrefs.HasKey(GameMoneyKey) == false)
        {
            return new GameMoney();
        }
 
        
       
        var jsonString = PlayerPrefs.GetString(GameMoneyKey);
        return JsonUtility.FromJson<GameMoney>(jsonString);
    }

    public void Save()
    {
        var jsonString = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(GameMoneyKey, jsonString);
    }
}
