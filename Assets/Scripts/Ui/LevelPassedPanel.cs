using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelPassedPanel : MonoBehaviour
{
   [SerializeField] private CountingMoney _countingMoney;
   [SerializeField] private Player _player;

   private void OnEnable()
    {
        _player.AddMoney(_countingMoney.CountUp());
    }

    public void Stop()
    {
        Time.timeScale = 0;
    }
}
