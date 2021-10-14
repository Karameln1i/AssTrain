using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private CountingMoney _countingMoney;
    [SerializeField] private TMP_Text _text;

    private int reward;
    
    private void OnEnable()
    {
        StartCoroutine(DispalyMoney());
    }

    private IEnumerator DispalyMoney()
    {
        reward = 1;
        for (int i = 0; i < _countingMoney.CountUp(); i++)
        {
            _text.text =reward.ToString();
            reward += 1;
            yield return null;
        }
    }
}
