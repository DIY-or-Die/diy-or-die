using System;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public Droppable Target { get; set; }

    private void Update()
    {
        if (Target && Input.GetMouseButtonUp(0))
        {
            Target.IsReleased = true;
            Target = null;
        }
        else if (Target && Input.GetMouseButton(0))
        {
            Drag();
        }
    }

    private void Drag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Target != null)
        {
            if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("HitScreen")))
            {
                Target.transform.position = hit.point;
            }
        }
    }
}
