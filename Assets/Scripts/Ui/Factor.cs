using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Factor : MonoBehaviour
{
    private TMP_Text _text;
    private int _value;


    public int Value => _value;
   

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void ChangeValue(int value)
    {
        _value = value;
        _text.text = "x"+_value;
    }
    
    
    public void Nulify()
    {
        _text.text = null;
        _value = 0;
    }
}