using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private GameObject _playerInventory;
    [SerializeField] private GameObject _chestInventory;

    private void OnMouseDown()
    {
        _chestInventory.SetActive(true);
        _playerInventory.SetActive(true);
        _inventoryManager.ListItems();
        _inventoryManager.ListChestItems();
    }
}