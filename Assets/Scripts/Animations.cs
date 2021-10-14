using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private DetectSwipe _detectSwipe;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _timePositionHandInAir;
    [SerializeField] private Timer _timerForLeftHand;
    [SerializeField] private Timer _timerForRightHand;
    
    private Coroutine _countDown;

    private void OnEnable()
    {
        _timerForLeftHand.TimeIsUp += OnLeftHandTimeIsUp;
        _timerForRightHand.TimeIsUp += OnRightHandTimeIsUp;
        _detectSwipe.SwipedDown += OnDownSwiped;
        _collisionHandler.TouchedAssRightHand += OnTouchedRightHand;
        _collisionHandler.TouchedAssLeftHand += OnTouchedLeftHand;
        
        _detectSwipe.SwipedRight += SwipedRight;
        _detectSwipe.SwipedLeft += SwipedLeft;
    }

    private void OnDisable()
    {
        _timerForLeftHand.TimeIsUp -= OnLeftHandTimeIsUp;
        _timerForRightHand.TimeIsUp -= OnRightHandTimeIsUp;
        _detectSwipe.SwipedDown -= OnDownSwiped;
        _collisionHandler.TouchedAssRightHand -= OnTouchedRightHand;
        _collisionHandler.TouchedAssLeftHand -= OnTouchedLeftHand;

        _detectSwipe.SwipedRight -= SwipedRight;
        _detectSwipe.SwipedLeft -= SwipedLeft;
    }

    private void SwipedRight()
    {
       if (_timerForRightHand.Isworking)
        {
            _timerForRightHand.RestartTimer(_timePositionHandInAir);
        }
        else
        {
            _timerForRightHand.StartTimer(_timePositionHandInAir);
        }
        _animator.SetTrigger("RightHandSwipedUp");
        _animator.SetBool("RightHandUp",true);
    }
    
    private void SwipedLeft()
    {
        if (_timerForLeftHand.Isworking)
        {
            _timerForLeftHand.RestartTimer(_timePositionHandInAir);
        }
        else
        {
            _timerForLeftHand.StartTimer(_timePositionHandInAir);
        }
             
        _animator.SetTrigger("LeftHandSwipedUp");
        _animator.SetBool("LeftHandUp",true);
    }

  
     
     private void OnDownSwiped()
     {
         if (_animator.GetBool("RightHandUp"))
         {
             _animator.SetTrigger("RightHandSwipedDown");
             _animator.SetBool("RightHandUp",false);
         }
         else if (_animator.GetBool("LeftHandUp"))
         {
             _animator.SetTrigger("LeftHandSwipedDown");
             _animator.SetBool("LeftHandUp",false);
         }
         
         Debug.Log("down");
     }
 
     private void OnTouchedLeftHand()
     {
         if (_animator.GetBool("LeftHandUp"))
         {
             _animator.SetTrigger("TouchedLeftAss");
             _timerForLeftHand.RestartTimer(_timePositionHandInAir);
         }
     }
 
     private void OnTouchedRightHand()
     {
         if (_animator.GetBool("RightHandUp"))
         {
             _animator.SetTrigger("TouchedRightAss");
             _timerForRightHand.RestartTimer(_timePositionHandInAir);
         }
     }
 
     private void OnLeftHandTimeIsUp()
     {
         if (_animator.GetBool("LeftHandUp"))
         {
             _animator.SetTrigger("LeftHandSwipedDown");
             _animator.SetBool("LeftHandUp",false);
         }
     }
     
     private void OnRightHandTimeIsUp()
     {
         if (_animator.GetBool("RightHandUp"))
         {
             _animator.SetTrigger("RightHandSwipedDown");
             _animator.SetBool("RightHandUp",false);
         }
     }
}



