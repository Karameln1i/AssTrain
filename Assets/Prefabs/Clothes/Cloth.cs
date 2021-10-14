using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cloth : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private bool _isBued=false;
    [SerializeField] private Material _material;
    [SerializeField] private Sprite _icon;
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;
    [SerializeField] private bool _isPutOn=false;

    public int Price => _price;
    public bool IsBued => _isBued;
    public Sprite Icon => _icon;
    public Material Material => _material;
    public SkinnedMeshRenderer MeshRenderer => _meshRenderer;
    public bool IsPutOn => _isPutOn;

    
    
    public void Buy()
    {
        _isBued = true;
    }

   public void PutOn()
    {
        _meshRenderer.material = _material;
        _isPutOn = true;
        Debug.Log("odeta");
    }
}
