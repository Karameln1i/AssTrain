using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClothInitializer : MonoBehaviour
{
    [SerializeField] private ClothDataBase _dataBase;
    [SerializeField] private PutOnClothes _putOnClothes;
    [SerializeField] private GameMoney _money;

        private void Awake()
        {
            var inventory = ClothInventory.Load();
           _putOnClothes.PutOnInLoadScene(inventory.SelectedGuid);
        }
}

