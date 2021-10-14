using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeMoney : MonoBehaviour
{
   [SerializeField] private EndLevel _endLevel;
   [SerializeField] private GameMoney _money;
   [SerializeField] private CountingMoney _countingMoney;

   private void OnEnable()
   {
      _endLevel.LevelPassed += OnLevelPassed;
   }

   private void OnDisable()
   {
      _endLevel.LevelPassed -= OnLevelPassed;
   }

   private void OnLevelPassed()
   {
      GameMoney money = _money.Load();
      money.Add(_countingMoney.CountUp());
      money.Save();
   }
}
