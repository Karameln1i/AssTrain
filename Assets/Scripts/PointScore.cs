using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointScore : MonoBehaviour
{
    [SerializeField] private int _womanSpakingScores;
    [SerializeField] private int _manSpakingScores;
    [SerializeField] private Score _score;
    [SerializeField] private Factor _factor;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private Timer _timer;
    [SerializeField] private GenderBar _genderBar;
    [SerializeField] private SetOffCombo _setOffCombo;

    private void start()
    {
        _genderBar.ChangeGenderBarValue(-1);
    }
    
    private void OnEnable()
    {
        _timer.TimeIsUp += OnTimeIsUp;
        _collisionHandler.TouchedManAss += OnTouchedManAss;
        _collisionHandler.TouchedWomanAss += OnTouchedWomanAss;
    }

    private void OnDisable()
    {
       _timer.TimeIsUp -= OnTimeIsUp;
       _collisionHandler.TouchedWomanAss -= OnTouchedWomanAss;
        _collisionHandler.TouchedManAss -= OnTouchedManAss;
    }

    private void OnTouchedWomanAss()
    {
        _score.ChangeValue(10);
    }
    
    private void OnTouchedManAss()
    {
        ChangeHealthBarValue();
        _score.ChangeValue(-10);
        InvokeRepeating("ChangeHealthBarValue",0.5f,0);
    }
    
   private void OnTimeIsUp()
    {
        ChangeHealthBarValue();
    }

   public void ChangeHealthBarValue()
    {
        if (_factor.Value !=0)
        {
            _genderBar.ChangeGenderBarValue(_score.Value*_factor.Value);
            _score.Nulify();
            _factor.Nulify();
        }
       
         if (_factor.Value == 0)
        {
           
            _genderBar.ChangeGenderBarValue(_score.Value);
            _score.Nulify();
            _factor.Nulify();
        }
        
         _score.Nulify();
        _factor.Nulify();
    }
}
