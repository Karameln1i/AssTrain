using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCreator : MonoBehaviour
{
    [SerializeField] private List <ParticleSystem>  _effects;
    [SerializeField] private GameObject _placeOfAppearance;
    
    public void CreateEffect()
    {
        Instantiate(_effects[Random.Range(0, _effects.Count)], _placeOfAppearance.transform);
    }
}