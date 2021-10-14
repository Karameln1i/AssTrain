using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DetectSwipe : MonoBehaviour,IDragHandler,IBeginDragHandler
{
    public event UnityAction SwipedLeft;
    public event UnityAction SwipedRight;
    public event UnityAction SwipedDown;
    
    public void OnDrag(PointerEventData eventData)
    { }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if (eventData.delta.y<0)
        {
            SwipedDown?.Invoke();
        }
        
        else if (eventData.delta.x > 0)
        {
            SwipedRight?.Invoke();
        }
        else if (eventData.delta.x < 0)
        {
            SwipedLeft?.Invoke();
        }
    }
    
}
