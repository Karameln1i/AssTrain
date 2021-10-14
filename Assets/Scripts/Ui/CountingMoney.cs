using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountingMoney : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private Slider _genderBar;
    
    private int _money;

   public int CountUp()
    {
        _money =Mathf.CeilToInt(_level.Reward + _genderBar.value);
        return _money;
    }
   
   
}
