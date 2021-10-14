using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HumanCollisionHnadler : MonoBehaviour
{
    [SerializeField] private EffectCreator _effectCreator;

    public event UnityAction PlayerHandTouched;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerHand>(out PlayerHand player))
        {
           
            PlayerHandTouched?.Invoke();
            _effectCreator.CreateEffect();
        }
    }
}
