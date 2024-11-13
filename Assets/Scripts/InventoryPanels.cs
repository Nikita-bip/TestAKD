using UnityEngine;

public class InventoryPanels : MonoBehaviour
{
    [SerializeField] private CameraController _controller;

    private void OnEnable()
    {
        _controller.enabled = false ;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        _controller.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}