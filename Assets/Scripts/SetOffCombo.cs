using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SetOffCombo : MonoBehaviour
{
    [SerializeField] private float _maxDelayBetweenSpanks;
    [SerializeField] private Factor _factor;
    [SerializeField] private Timer _timer;
    [SerializeField] private int _numberofTouchesForX2;
    [SerializeField] private int _numberofTouchesForX3;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    
    private int _noumberOfTouch;

    private void OnEnable()
    {
        _collisionHandler.TouchedWomanAss += OnTouchedWomanAss;
        _collisionHandler.TouchedManAss += OnTouchedManAss;
        _timer.TimeIsUp += OnTimeIsUp;
    }

    private void OnDisable()
    {
        _collisionHandler.TouchedWomanAss -= OnTouchedWomanAss;
        _collisionHandler.TouchedManAss -= OnTouchedManAss;
        _timer.TimeIsUp -= OnTimeIsUp;
    }

    private void OnTouchedWomanAss()
    {
        if (_timer.Isworking)
        {
            _timer.RestartTimer();
            _noumberOfTouch++;
        }
        else
        {
            _timer.StartTimer(_maxDelayBetweenSpanks);
            _noumberOfTouch++;
        }
        
        if (_noumberOfTouch==_numberofTouchesForX2)
        {
            _factor.ChangeValue(2);
        }
        else if (_noumberOfTouch==_numberofTouchesForX3)
        {
            _factor.ChangeValue(3);
            _noumberOfTouch = 0;
        }
    }

    private void OnTouchedManAss()
    {
        _noumberOfTouch=0;
    }        

    private void OnTimeIsUp()
    {
        _noumberOfTouch=0;
    }
}
