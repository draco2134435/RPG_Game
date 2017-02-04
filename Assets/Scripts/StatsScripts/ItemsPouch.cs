using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPouch : MonoBehaviour {
    public int maxItemSize = 10;
    public int currentItemSelected;
    public int maxActiveItems;
    public int maxPassiveItems;
    ItemNode[] currentActiveItems;
    PassiveItem[] currentPassiveItems;
    Dictionary<string, ItemNode> pouch;

    void Start()
    {
        currentActiveItems = new ItemNode[maxActiveItems];
    }

    public bool addItem(Item item)
    {
        if (pouch.ContainsKey(item.itemName))
        {
            pouch[item.itemName].quantity++;
        }
        return true;
    }

    public bool addItem(Item item, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (!addItem(item)) return false;
        }
        return true;
    }

    public void setActiveItem(ItemNode item, int slot)
    {
        currentActiveItems[slot % currentActiveItems.Length] = item;
    }

    public void setPassiveItem(PassiveItem item, int slot)
    {

    }

    public class ItemNode
    {
        public Item item;
        public int quantity;

    }
}
