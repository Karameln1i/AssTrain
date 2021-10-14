using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   [SerializeField] private LeanFingerSwipe _leanFingerSwipe;

   private void OnEnable()
   {
     // _leanFingerSwipe.ON
   }
}
