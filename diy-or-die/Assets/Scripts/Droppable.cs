using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Droppable : MonoBehaviour
{
    public SpriteRenderer Renderer { get; private set; }
    public Collider2D DragCollider { get; private set; }
    public DragController DragController { get; private set; }

    private bool _isDragging;
    public bool IsDragging
    {
        get
        {
            return _isDragging;
        }
        set
        {
            _isDragging = value;
            if (_isDragging && Recepticle != null)
            {
                Recepticle.ReleaseItem();
            }
        }
    }
    public IRecepticle Recepticle { get; set; }
    public RepairItem RepairItem;
    public float PartHealth;

    private float IdleTimer = 10;

    private void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        DragCollider = GetComponent<Collider2D>();
        DragController = FindObjectOfType<DragController>();

        Renderer.sprite = RepairItem.Sprite;
    }

    private void Update()
    {
        if (Recepticle != null && Recepticle.UsesPart)
        {
            PartHealth -= Time.deltaTime;
        }

        if (IsDragging || Recepticle != null)
        {
            IdleTimer = 10;
        }
        else
        {
            IdleTimer -= Time.deltaTime;
            if (IdleTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        Renderer.color = new Color(1, 1, 1, IdleTimer / 10);
    }

    private void OnMouseDown()
    {
        IsDragging = true;
        DragController.SelectedItem = this;
    }

    public void Drop()
    {
        IsDragging = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Recepticle")))
        {
            IRecepticle recepticle = hit.collider.GetComponent<IRecepticle>();
            recepticle.ReceiveItem(this);
        }
    }
}
