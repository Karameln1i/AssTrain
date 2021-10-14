using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public  class PutOnClothes :MonoBehaviour
{
    [SerializeField] private  SkinnedMeshRenderer _hat;
    [SerializeField] private  SkinnedMeshRenderer _tShirt;
    [SerializeField] private  SkinnedMeshRenderer _legs;
    [SerializeField] private  SkinnedMeshRenderer _feets;
    [SerializeField] private  ClothDataBase _clothDataBase;
    

    public  void PutOnInLoadScene(List<int> selectedCloths)
    {
        for (int i = 0; i < selectedCloths.Capacity; i++)
        {
            PutOn(_clothDataBase.Data[(selectedCloths[i])]);
        }
    }

    public  void PutOnInClick(ClothData clothData)
    {
       PutOn(clothData);
    }

    private void PutOn(ClothData cloth)
    {
        if (cloth.gameObject.tag == "Hat")
        {
            _hat.material =cloth.Material;
        }
        if (cloth.gameObject.tag == "Tshirt")
        {
            _tShirt.material = cloth.Material;
        }
        else if (cloth.gameObject.tag == "Legs")
        {
            _legs.material = cloth.Material;
        }
        else if (cloth.gameObject.tag == "Feets")
        {
            _feets.material =cloth.Material;
        }
    }
    
}
