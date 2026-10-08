using UnityEngine;

public class GravityAffected : MonoBehaviour
{
    public float gravityStrength = 20f;
    public float maxFallSpeed = 12f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (GravityManager.Instance == null)
            return;

        Vector2 gravityDirection =
            GravityManager.Instance.GravityVector;

        // Apply custom gravity
        rb.AddForce(gravityDirection * gravityStrength);

        // Find velocity in gravity direction
        float gravityVelocity =
            Vector2.Dot(rb.linearVelocity, gravityDirection);

        gravityVelocity =
            Mathf.Clamp(
                gravityVelocity,
                -maxFallSpeed,
                maxFallSpeed
            );

        // Keep sideways velocity
        Vector2 sidewaysVelocity =
            rb.linearVelocity -
            gravityDirection *
            Vector2.Dot(rb.linearVelocity, gravityDirection);

        // Rebuild final velocity
        rb.linearVelocity =
            sidewaysVelocity +
            gravityDirection * gravityVelocity;
    }
}