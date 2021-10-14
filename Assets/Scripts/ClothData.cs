using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

[Serializable]
public class ClothData : MonoBehaviour
{
   [SerializeField] private int _guid;
   [SerializeField] private Sprite _preview;
   [SerializeField] private int _price;
   [SerializeField] private Material _material;
   [SerializeField] private bool _isBued=false;
   [SerializeField] private SkinnedMeshRenderer _meshRenderer;

   public SkinnedMeshRenderer MeshRenderer => _meshRenderer;
   public bool IsBued => _isBued;
   public int GUID => _guid;
   public Sprite Preview => _preview;
   public int Price => _price;
   public Material Material=>_material;
}
