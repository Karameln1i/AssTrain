using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private HumanCollisionHnadler _collisionHandler;

    private const float _maxAudioPitch = 1;
    private const float _minAudioPitch = 0.8f;

    private void OnEnable()
    {
        _collisionHandler.PlayerHandTouched += OnPlayerTouchedAss;
    }

    private void OnDisable()
    {
        _collisionHandler.PlayerHandTouched -= OnPlayerTouchedAss;
    }

    private void OnPlayerTouchedAss()
    {
        _audioSource.pitch=Random.Range(_minAudioPitch,_maxAudioPitch);
        _audioSource.Play();
    }
}
