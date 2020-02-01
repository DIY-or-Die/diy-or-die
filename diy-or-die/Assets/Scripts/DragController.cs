using System;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public Droppable SelectedItem { get; set; }

    private void Update()
    {
        if (SelectedItem && Input.GetMouseButtonUp(0))
        {
            SelectedItem.Drop();
            SelectedItem = null;
        }
        else if (SelectedItem && Input.GetMouseButton(0))
        {
            Drag();
        }
    }

    private void Drag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (SelectedItem != null)
        {
            if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("HitScreen")))
            {
                SelectedItem.transform.position = hit.point;
            }
        }
    }
}
