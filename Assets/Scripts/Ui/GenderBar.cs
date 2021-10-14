using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GenderBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private MenuPanel _menuPanel;
    [SerializeField] private Animator _animator;
  //  [SerializeField] private GameObject _canvas;
    
    private float _endValue;
    private RectTransform _rectTransform;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        transform.LeanScale(Vector2.zero, 0.001f).setEaseInBack();
    }

    private void OnEnable()
    {
        _menuPanel.Closed += OnMenuClosed;
    }

    private void OnDisable()
    {
        _menuPanel.Closed -= OnMenuClosed;
    }
    
    public void ChangeGenderBarValue (float value)
    {
        StartCoroutine(ChangeValue(value));
    }
    
    private IEnumerator ChangeValue(float value)
    {
        if (_slider.value+value>_slider.maxValue)
        {
            _endValue = _slider.maxValue;
        }
        else if (_slider.value+value<_slider.minValue)
        {
            _endValue = _slider.minValue;
        }
        else
        {
            _endValue = _slider.value += value;
        }

        while (_slider.value!=_endValue)
        {
            _slider.value += Mathf.MoveTowards(_slider.value, _endValue, 0.001f);
        }

        yield return null;
    }

    private void OnMenuClosed()
    {
        transform.LeanScale(Vector2.one, 0.7f).setEaseInBack();;
    }
    
}
