using System;
using TMPro;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private TMP_Text name;
    private ItemUnitInfo item;
    private Action<ItemScript> removeAction;

    public void SetInit(ItemUnitInfo item, Action<ItemScript> removeAction)
    {
        this.item = item;
        this.removeAction = removeAction;
        name.text = item.name;
    }

    public void OnClick_remove()
    {
        Debug.Log($"click, {item.name} ");
        removeAction.Invoke(this);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
