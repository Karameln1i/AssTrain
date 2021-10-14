using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BootScene : MonoBehaviour
{
    [SerializeField] private int _levelIndex;

    private int _numberOfLaunches;
    private const string Session_Count = "sessionCount";
    
    private int _session_count
    {
        get { return PlayerPrefs.GetInt(Session_Count, 0); }
        set { PlayerPrefs.SetInt(Session_Count, value); }
    }
    
    public int LevelIndex => _levelIndex;

    public event UnityAction <int> GameStarted;

   
    
    private void Awake()
    {
        _session_count++;
        GameStarted?.Invoke(_session_count);
    }
}
