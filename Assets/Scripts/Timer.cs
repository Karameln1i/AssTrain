using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private bool _isWorking;
    private float _time;
    private bool _bool;

    private float _currentTine;
    
    public bool Isworking => _isWorking;

    public event UnityAction TimeIsUp;

    public event UnityAction TimeIsUpRight;
    public event UnityAction TimeIsUpLeft;

    private IEnumerator corutine;

    private void Update()
    {
        _currentTine += Time.deltaTime;
    }


    public void StartTimer(float time)
    {
        _isWorking = true;
        _currentTine = 0;
        _time = time;
        corutine = CountDown(time);
        StartCoroutine(corutine);
    }

    public void Stop()
    {
        StopCoroutine(corutine);
    }

    public void RestartTimer(float time=3)
    {
        StopCoroutine(corutine);
        _time = time;
        StartTimer(_time);
    }
    
     private IEnumerator CountDown(float time)
    {
        yield return new WaitForSeconds(time);
        TimeIsUp?.Invoke();
    }
}
