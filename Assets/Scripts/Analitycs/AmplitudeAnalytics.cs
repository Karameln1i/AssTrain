using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmplitudeAnalytics : MonoBehaviour
{
    private const string SAVED_REG_DAY = "RegDay";
    private const string SAVED_REG_DAY_FULL = "RegDayFull";
    private const string SAVED_SESSION_ID = "SessionID";

    [SerializeField] private Level _level;
    [SerializeField] private GameMoney _money;
    [SerializeField] private BootSceneAnalytic _bootSceneAnalytic;

    private const string LastPassedLevelIndexKey = nameof(LastPassedLevelIndexKey);
    
    private bool _levelPassed;
    private Amplitude _amplitude;
    private float _timeToPassLevel;
    private Coroutine _timer;
    private int _lastPassedLevelIndex;
    
    private string _regDay
    {
        get { return PlayerPrefs.GetString(SAVED_REG_DAY, DateTime.Today.ToString("dd/MM/yy")); }
        set { PlayerPrefs.SetString(SAVED_REG_DAY, value); }
    }

    private string _regDayFull
    {
        get { return PlayerPrefs.GetString(SAVED_REG_DAY_FULL, DateTime.Today.ToString()); }
        set { PlayerPrefs.SetString(SAVED_REG_DAY_FULL, value); }
    }

    private int _sessionID
    {
        get { return PlayerPrefs.GetInt(SAVED_SESSION_ID, 0); }
        set { PlayerPrefs.SetInt(SAVED_SESSION_ID, value); }
    }

    private void Awake()
    {
        _timer = StartCoroutine(Timer());

            _amplitude = Amplitude.Instance;
            _amplitude.logging = true;
            _amplitude.init("985422298a924a3439a63a5ce313822f");

    }

    private void OnEnable()
    {
        _level.LevelStarted += OnLevelStarted;
        _level.LevelCompleted += OnLevelCompleted;
       _level.LevelRestartetd += OnLevelRestarted;
    }

    private void OnDisable()
    {
        _level.LevelStarted -= OnLevelStarted;
        _level.LevelCompleted -= OnLevelCompleted;
        _level.LevelRestartetd -= OnLevelRestarted;
    }

    public void GameStart()
    {
        if (_level.LevelIndex == 0)
        {
            _regDay = DateTime.Today.ToString("dd/MM/yy");
            _regDayFull = DateTime.Today.ToString();
            _amplitude.setOnceUserProperty("reg_day", _regDay);
            SetBasicProperty();
            FireEvent("game_start");
        }
    }

    private void OnLevelRestarted(int levelIndex)
    {
        FireEvent("restart", levelIndex);
    }

    private void OnLevelCompleted()
    {
        StopCoroutine(_timer);
        FireEvent("level_complete",Convert.ToInt32(_timeToPassLevel));
    }

    private void OnLevelStarted(int levelIndex)
    {
        _lastPassedLevelIndex = Load();

        if (_lastPassedLevelIndex<levelIndex)
        {
            _lastPassedLevelIndex = levelIndex;
            Save();
        }
        
        FireEvent("level_start",_lastPassedLevelIndex);
    }

    private void SetBasicProperty()
    {
        _sessionID = _sessionID + 1;
        _amplitude.setUserProperty("session_id", _sessionID);

        int daysAfter = DateTime.Today.Subtract(DateTime.Parse(_regDayFull)).Days;
        _amplitude.setUserProperty("days_after", daysAfter);
    }

    private void FireEvent(string eventName)
    {
        SettingUserProperties();
        _amplitude.logEvent(eventName);
    }
    
    private void FireEvent(string eventName,int value)
    {
        SettingUserProperties();
        _amplitude.setUserProperty(eventName,value);
    }

    private void SettingUserProperties()
    {
        _amplitude.setUserProperty("days_in_game", _bootSceneAnalytic.GetDaysInGame());
        
        _amplitude.setUserProperty("sesion count", _bootSceneAnalytic.GetSessionCount());
        
        _amplitude.setUserProperty("reg_day", _bootSceneAnalytic.GetRegDay());

        int lastLevel = _level.LevelIndex;
       _amplitude.setUserProperty("level_last", lastLevel);
        
        GameMoney money = _money.Load();
        _amplitude.setUserProperty("current_soft", money.Value);
    }

    private IEnumerator Timer()
    {
        while (!_levelPassed)
        {
            _timeToPassLevel += Time.deltaTime;

            yield return null;
        }
    }
    
    private  int Load()
    {
        if (PlayerPrefs.HasKey(LastPassedLevelIndexKey) == false)
        {
            return 0;
        }
        
        var jsonString = PlayerPrefs.GetString(LastPassedLevelIndexKey);
        return JsonUtility.FromJson<int>(jsonString);
    }

    private void Save()
    {
        var jsonString = JsonUtility.ToJson(_lastPassedLevelIndex);
        PlayerPrefs.SetString(LastPassedLevelIndexKey, jsonString);
    }

}