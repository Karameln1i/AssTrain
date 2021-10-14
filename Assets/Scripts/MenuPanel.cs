using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuPanel : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Shopp _shopp;
    [SerializeField] private Player _player;

    public event UnityAction Closed;

    public void Close()
    {
        Closed?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_shopp.IsOpened==false)
        {
            StartLevel();
        }
    }

    private void StartLevel()
    {
        gameObject.SetActive(false);
        _player.GetComponent<PlayerMove>().enabled=true;
        Closed?.Invoke();
    }
}
