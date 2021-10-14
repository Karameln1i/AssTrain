using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimation : MonoBehaviour
{
    [SerializeField] private HumanCollisionHnadler _collisionHnadler;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _collisionHnadler.PlayerHandTouched += OnPlayerHandTouched;
    }

    private void OnDisable()
    {
        _collisionHnadler.PlayerHandTouched -= OnPlayerHandTouched;
    }

    private void OnPlayerHandTouched()
    {
        _animator.Play("TPF_idleafraid");
    }
}
