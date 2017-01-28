using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPouch : MonoBehaviour {
    public int maxItemSize = 10;
    Dictionary<string, ItemNode> pouch;

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

    public class ItemNode
    {
        public Item item;
        public int quantity;

    }
}
