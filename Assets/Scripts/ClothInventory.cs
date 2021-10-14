using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ClothInventory 
{
    [SerializeField] private List<int> _buyedGuid = new List<int>();
    [SerializeField] private List<int> _selectedGuid=new List<int>();

    private const string ClothInventoryKey = nameof(ClothInventoryKey);
    
    public List<int> SelectedGuid => _selectedGuid;

    private void Start()
    {
        for (int i = 0; i < _selectedGuid.Capacity; i++)
        {
            Debug.Log(_selectedGuid[i]);
        }
    }
    
    public void Add(ClothData data)
    {
        _buyedGuid.Add(data.GUID);
  
    }

    public void SelectCloth(ClothData cloth)
    {
        _selectedGuid.Add(cloth.GUID);
    }

    public static ClothInventory Load()
    {
        if (PlayerPrefs.HasKey(ClothInventoryKey) == false) 
        return new ClothInventory();
        
        var jsonString = PlayerPrefs.GetString(ClothInventoryKey);
        return JsonUtility.FromJson<ClothInventory>(jsonString);
    }

    public void Save()
    {
        var jsonString = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(ClothInventoryKey, jsonString);
    }

    public bool Contains(ClothData cloth)
    {
        bool result = _buyedGuid.Contains(cloth.GUID);
        return result;
    }
}
