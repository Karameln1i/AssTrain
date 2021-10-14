using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickReciver : MonoBehaviour,IPointerClickHandler
{
   [SerializeField] private Animator _animator;
   [SerializeField] private Shopp _shopp;
   
   public void OnPointerClick(PointerEventData eventData)
   {
      if (_shopp.IsOpened==false)
      {
         _animator.Play("MenuPanelClose"); 
      }
   }
}
