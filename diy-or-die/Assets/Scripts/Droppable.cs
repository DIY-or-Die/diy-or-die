using System;
using UnityEngine;

[RequireComponent(typeof(RepairItem))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Droppable : MonoBehaviour
{
    public RepairItem RepairItem { get; private set; }
    public SpriteRenderer Renderer { get; private set; }
    public Collider2D DragCollider { get; private set; }

    public bool IsDragging { get; set; }
    public bool IsReleased { get; set; }

    private void Start()
    {
        RepairItem = GetComponent<RepairItem>();
        Renderer = GetComponent<SpriteRenderer>();
        DragCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        
    }

    public void Drop()
    {

    }
}
