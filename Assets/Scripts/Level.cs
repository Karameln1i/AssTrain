using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
  [SerializeField] private int _reward;
  [SerializeField] private int _levelIndex;
  [SerializeField] private EndLevel _endLevel;
  [SerializeField] private Button _restartButton;
  
  public int Reward => _reward;
  public int LevelIndex => _levelIndex;

  public event UnityAction <int> LevelStarted;
  public event UnityAction LevelCompleted; 
  public event UnityAction <int> LevelRestartetd;
  
 

  private void OnEnable()
  {
    _restartButton.onClick.AddListener(OnRestartButtonClicked);
    _endLevel.LevelPassed += OnLevelCompleted;
  }

  private void OnDisable()
  {
    _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    _endLevel.LevelPassed += OnLevelCompleted;
  }
  
  private void Start()
  {
    LevelStarted?.Invoke(_levelIndex);
  }
  
  private void OnRestartButtonClicked()
  {
    LevelRestartetd?.Invoke(_levelIndex);
  }
  
  private void OnLevelCompleted()
  {
    LevelCompleted?.Invoke();
  }
}
