using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static InventoryManager Instance;

    public List<AllItems> _inventoryItems = new List<AllItems>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(AllItems item)
    {
        if(!_inventoryItems.Contains(item))
        {
            _inventoryItems.Add(item);
        }

    }

    public void RemoveItem(AllItems item)
    {
        if(_inventoryItems.Contains(item))
        {
            _inventoryItems.Remove(item);
        }

    }

    public enum AllItems
    {
        KeyRed,
        KeyProta,
        KeyProdo
    }
}
