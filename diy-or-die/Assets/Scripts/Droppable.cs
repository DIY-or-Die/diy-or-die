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
    public SpriteRenderer Glow;

    public float OriginalPartHealth { get; set; }
    public float PartHealth;

    private float IdleTimer = 10;
    private Vector3 UnitVector;
    private float OriginalScale;
    private float MaxHealth;

    private void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        DragCollider = GetComponent<Collider2D>();
        DragController = FindObjectOfType<DragController>();

        Renderer.sprite = RepairItem.Sprite;
        OriginalPartHealth = PartHealth;
        MaxHealth = OriginalPartHealth;
        OriginalScale = Glow.transform.localScale.x;
        UnitVector = new Vector3(1, 1, 1);
    }

    private void Update()
    {
        if (Glow != null)
        {
            Glow.transform.localScale = UnitVector * OriginalScale * (.75f + .5f * Mathf.Abs(Mathf.Sin(Time.time * 3)));
        }

        if (Recepticle != null && Recepticle.UsesPart)
        {
            PartHealth -= Time.deltaTime;
            if (PartHealth < 0)
            {
                Destroy(gameObject);
            }
        }
        else if (Recepticle != null && PartHealth < MaxHealth)
        {
            PartHealth += Time.deltaTime;
        }

        if (IsDragging || Recepticle != null)
        {
            IdleTimer = 10;
            Renderer.color = new Color(1, 1, 1, 1);
        }
        else
        {
            IdleTimer -= Time.deltaTime;
            Renderer.color = new Color(1, 1, 1, IdleTimer / 10);
            if (IdleTimer <= 0)
            {
                Destroy(gameObject);
            }

            if (transform.position.y > -2)
            {
                transform.Translate(new Vector3(0, -.8f * Time.deltaTime));
            }
        }
        float healthVal = OriginalPartHealth == 0 ? 1 : PartHealth / OriginalPartHealth;
        Renderer.color = new Color(1, healthVal, healthVal, IdleTimer / 10);
        if (Glow != null)
        {
            Glow.color = new Color(1, 1, 1, IdleTimer / 10);
        }
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
