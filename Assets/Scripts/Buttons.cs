using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject[] _panel;

    public void Close()
    {
        foreach (var panel in _panel)
        {
            panel.SetActive(false);

        }
    }
}