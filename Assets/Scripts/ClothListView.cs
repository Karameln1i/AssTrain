using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothListView:MonoBehaviour
{
    [SerializeField] private ClothPresenter _template;
    [SerializeField] private Transform _container;

    public List<ClothPresenter> Render(List<ClothData> renderData)
    {
        var list =new List<ClothPresenter>();

        foreach (var item in renderData)
        {
            var inst = Instantiate(_template, _container);
            if (item.IsBued)
            {
               // _template.RenderSelected();
            }
            inst.Render(item);
            list.Add(inst);
        }

        return list;
    }
}