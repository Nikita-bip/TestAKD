using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    private Item _item;
    private Buttons _removeButton;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(_item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        _item = newItem;
    }
}