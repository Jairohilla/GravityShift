using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door Sprites")]
    public Sprite closedSprite;
    public Sprite openSprite;

    private SpriteRenderer spriteRenderer;
    private Collider2D doorCollider;

    private bool isOpen = false;

    public bool IsOpen => isOpen;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        // Start with closed door
        spriteRenderer.sprite = closedSprite;
    }

    public void Open()
    {
        if (isOpen) return;

        isOpen = true;

        // Change visual
        spriteRenderer.sprite = openSprite;

        // Allow player to pass through the door
        if (doorCollider != null)
        {
            doorCollider.enabled = false;
        }
    }
}