using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Menu _menu;
    [SerializeField] private PointScore _pointScore;

    public event UnityAction LevelPassed;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _pointScore.ChangeHealthBarValue();
            LevelPassed?.Invoke();
            _menu.OpenPanel(_panel);
        }
    }
}
