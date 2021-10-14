using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootSceneAnalytic : MonoBehaviour
{
    private const string SAVED_REG_DAY = "RegDay";
    private const string SAVED_REG_DAY_FULL = "RegDayFull";
    private const string SAVED_SESSION_ID = "SessionID";
    private const string IsLaunchedKey = nameof(IsLaunchedKey);
   
    [SerializeField] private bool _isLaunched=false;
    [SerializeField] private BootScene _bootScene;
    [SerializeField] private GameMoney _money;
    
    private Amplitude _amplitude;
    private int _daysInGame;
    
    private string _regDay
    {
        get { return PlayerPrefs.GetString(SAVED_REG_DAY, DateTime.Today.ToString("dd/MM/yy")); }
        set { PlayerPrefs.SetString(SAVED_REG_DAY, value); }
    }

    private int _sessionCount
    {
        get { return PlayerPrefs.GetInt(SAVED_SESSION_ID, 0); }
        set { PlayerPrefs.SetInt(SAVED_SESSION_ID, value); }
    }

    private void OnEnable()
    {
        _bootScene.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        _bootScene.GameStarted -= OnGameStarted;
    }

    private void Awake()
    {
        if (Load())
        {
            _regDay = DateTime.Today.ToString("dd/MM/yy");
        }

        _sessionCount++;
        _amplitude = Amplitude.Instance;
        _amplitude.logging = true;
        _amplitude.init("985422298a924a3439a63a5ce313822f");
    }
    
    private void OnGameStarted(int numberOfLaunches)
    {
        if (_bootScene.LevelIndex == 0)
        {
            _amplitude.setOnceUserProperty("reg_day", _regDay);
            SettingUserProperties();
            FireEvent("game_start",numberOfLaunches);
        }
    }

    private void FireEvent(string eventName,int value)
    {
        SettingUserProperties();
        _amplitude.setUserProperty(eventName,value);
    }

    private void SettingUserProperties()
    {
        int lastLevel = _bootScene.LevelIndex;
        _amplitude.setUserProperty("level_last", lastLevel);
        
        GameMoney money = _money.Load();
        _amplitude.setUserProperty("current_soft", money.Value);
        
        _amplitude.setUserProperty("session_count", _sessionCount);

        _daysInGame = DateTime.Today.Subtract(DateTime.Parse(_regDay)).Days;
        _amplitude.setUserProperty("days_in_ame", _daysInGame);
        
        _amplitude.setUserProperty("reg_day",_regDay);
    }
    
    private  bool Load()
    {
        if (PlayerPrefs.HasKey(IsLaunchedKey) == false)
        {
            return false;
        }
        
        var jsonString = PlayerPrefs.GetString(IsLaunchedKey);
        return JsonUtility.FromJson<bool>(jsonString);
    }

    private void Save()
    {
        var jsonString = JsonUtility.ToJson(_isLaunched);
        PlayerPrefs.SetString(IsLaunchedKey, jsonString);
    }
    
    public int GetDaysInGame()
    {
        return  DateTime.Today.Subtract(DateTime.Parse(_regDay)).Days;
    }
    
    public int GetSessionCount()
    {
        return _sessionCount;
    }

    public string GetRegDay()
    {
        return _regDay;
    }
}
