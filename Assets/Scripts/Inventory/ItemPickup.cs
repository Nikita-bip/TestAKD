using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    private void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}