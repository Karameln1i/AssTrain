using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ClothDataBase",fileName = "CreateClothDataBase")]
public class ClothDataBase : ScriptableObject
{
    [SerializeField] private int _defaultClothIndex;
    [SerializeField] private List<ClothData> _data=new List<ClothData>();

    public List<ClothData> Data => _data;
}
