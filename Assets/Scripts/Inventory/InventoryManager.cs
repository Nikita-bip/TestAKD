using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private Transform _itemContent;
    [SerializeField] private GameObject _inventoryItem;

    [SerializeField] private Transform _chestContent;
    [SerializeField] private GameObject _chestItem;
    [SerializeField] private CarInventory _chestInventory;

    private List<Item> Items = new List<Item>();
    private InventoryItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        _chestInventory.Items.Add(item);
        ListChestItems();
        Items.Remove(item);
    }

    public void ListItems()
    {
        ListItems(Items, _itemContent, _inventoryItem);
        SetInventoryItems();
    }

    public void ListChestItems()
    {
        ListItems(_chestInventory.Items, _chestContent, _chestItem);
        SetChestItems();
    }

    private void ListItems(List<Item> itemList, Transform content, GameObject itemPrefab)
    {
        foreach (Transform item in content)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in itemList)
        {
            GameObject obj = Instantiate(itemPrefab, content);
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            itemIcon.sprite = item.icon;
        }
    }

    private void SetInventoryItems()
    {
        InventoryItems = _itemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }

    private void SetChestItems()
    {
        var chestItems = _chestContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < _chestInventory.Items.Count; i++)
        {
            chestItems[i].AddItem(_chestInventory.Items[i]);
        }
    }
}