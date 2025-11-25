using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public class ItemUnitInfo
{
    public readonly int id;
    public readonly string name;

    public ItemUnitInfo(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}



public class ItemController : MonoBehaviour
{
    private List<ItemUnitInfo> itemInfos = new List<ItemUnitInfo>();

    [SerializeField] private GameObject itemPrefab;
    private List<ItemScript> itemUnits = new List<ItemScript>();


    void Start()
    {
        itemInfos.Add(new ItemUnitInfo(1, "normal sword"));
        itemInfos.Add(new ItemUnitInfo(2, "rare sword"));
        itemInfos.Add(new ItemUnitInfo(3, "unique sword"));

        foreach (var unit in itemInfos)
        {
            GameObject itemObj = Instantiate(itemPrefab, this.transform);
            ItemScript itemScript = itemObj.GetComponent<ItemScript>();
            itemScript.SetInit(unit, RemoveItem);
            itemUnits.Add(itemScript);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveItem(ItemScript item)
    {
        itemUnits.Remove(item);
        Destroy(item.gameObject);
    }
}
