using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Droppable : MonoBehaviour
{
    public SpriteRenderer Renderer { get; private set; }
    public Collider2D DragCollider { get; private set; }
    public DragController DragController { get; private set; }

    public bool IsDragging { get; set; }

    public RepairItem RepairItem;

    private void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        DragCollider = GetComponent<Collider2D>();
        DragController = FindObjectOfType<DragController>();
    }

    private void OnMouseDown()
    {
        IsDragging = true;
        DragController.SelectedItem = this;
    }

    public void Drop()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Recepticle")))
        {
            Debug.Log("Received Item");
            IRecepticle recepticle = hit.collider.GetComponent<IRecepticle>();
            recepticle.ReceiveItem(RepairItem);
        }
    }
}
