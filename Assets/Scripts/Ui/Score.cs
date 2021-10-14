using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour
{
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;
    [SerializeField] private Color32 _colorToNegativeNumber;
    [SerializeField] private Color32 _colorToPositiveNumber;
    [SerializeField] private int _womanSpakingScores;
    [SerializeField] private int _manSpakingScores;
    [SerializeField] private TMP_Text _text;

    private int _value;
    private int _valueToText;
    public int Value => _value;


    private void OnEnable()
    {
        //_playerCollisionHandler.TouchedManAss += OnTouchedManAss;
       // _playerCollisionHandler.TouchedWomanAss += OnTouchedWomanAss;
    }

    private void OnDisable()
    {
        //_playerCollisionHandler.TouchedManAss -= OnTouchedManAss;
       // _playerCollisionHandler.TouchedWomanAss -= OnTouchedWomanAss;
    }

    private void OnTouchedManAss()
    {
        _value = _manSpakingScores;
       _text.color = _colorToPositiveNumber;
       ShowText();
        Debug.Log("man");
    }

    private void OnTouchedWomanAss()
    {
        _text.color =_colorToPositiveNumber;
        _value += _womanSpakingScores;
        ShowText();
        Debug.Log("poc");
    }

    private void ShowText()
    {
        if (_value>0)
        {
            _text.text ="+"+_value;
        }
        else
            _text.text =_value.ToString();
    }


    public void ChangeValue(int value)
    {
        if (value>0)
        {
            _text.color =_colorToPositiveNumber;
            _value +=_womanSpakingScores;
            ShowText();
        }
        else if (value<0)
        {
            _value = _manSpakingScores;
            _text.color = _colorToNegativeNumber;
       
            ShowText();
        }
    }
    
    
   public void Nulify()
    {
        _text.text = null;
        _value = 0;
    }
    
    
    
}
