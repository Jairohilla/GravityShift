using UnityEngine;

public class Switch : MonoBehaviour
{
    [Header("Door")]
    public Door targetDoor;

    [Header("Activation Settings")]
    public bool boxOnly = false;

    [Header("Optional")]
    public Sprite activatedSprite;

    private SpriteRenderer spriteRenderer;
    private bool activated = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
            return;

        // BOX ONLY mode
        if (boxOnly)
        {
            if (!other.CompareTag("Pushable"))
                return;
        }
        // NORMAL mode
        else
        {
            if (!other.CompareTag("Player") &&
                !other.CompareTag("Pushable"))
                return;
        }

        activated = true;

        // Open door
        if (targetDoor != null)
            targetDoor.Open();

        // Change switch sprite
        if (activatedSprite != null)
            spriteRenderer.sprite = activatedSprite;
    }
}