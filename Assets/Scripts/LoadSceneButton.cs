using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private SceneReference _scene;
    [SerializeField]  private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(LoadScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(LoadScene);
    }

    private void LoadScene()
    {
       SceneManager.LoadScene(_scene);
        Time.timeScale = 1;
    }
}
