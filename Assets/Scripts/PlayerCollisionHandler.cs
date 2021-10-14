using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionHandler :  MonoBehaviour
{
    public event UnityAction TouchedAssRightHand; 
    public event UnityAction TouchedAssLeftHand;
    public event UnityAction TouchedWomanAss;
    public event UnityAction TouchedManAss;
    
     private void OnTriggerEnter(Collider collision)
     {
         if (collision.TryGetComponent<RightHumanAss>(out RightHumanAss rightHumanAss))
         {
             TouchedAssRightHand?.Invoke();
         }

         else if (collision.TryGetComponent<LeftHumanAss>(out LeftHumanAss leftHumanAss))
         {
             TouchedAssLeftHand.Invoke();
         }

         if (collision.TryGetComponent<WomanAss>(out WomanAss womanAss))
         {
             TouchedWomanAss?.Invoke();
         }
         else if (collision.TryGetComponent<ManAss>(out ManAss manAss))
         {
             TouchedManAss?.Invoke();
         }
     }
}
