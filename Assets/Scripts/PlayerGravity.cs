using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Gravity")]
    public float gravityStrength = 20f;

    [Header("Rotation")]
    public float rotationSpeed = 720f;
    public float maxFallSpeed = 15f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        RotatePlayer();
    }

    private void ApplyGravity()
    {
        Vector2 gravityDirection =
            GravityManager.Instance.GravityVector;

        rb.AddForce(
            gravityDirection * gravityStrength
        );

        float gravityVelocity =
            Vector2.Dot(
                rb.linearVelocity,
                gravityDirection
            );

        gravityVelocity =
            Mathf.Clamp(
                gravityVelocity,
                -maxFallSpeed,
                maxFallSpeed
            );

        Vector2 sidewaysVelocity =
            rb.linearVelocity -
            gravityDirection * Vector2.Dot(
                rb.linearVelocity,
                gravityDirection
            );

        rb.linearVelocity =
            sidewaysVelocity +
            gravityDirection * gravityVelocity;
    }

    private void RotatePlayer()
    {
        Vector2 gravity =
            GravityManager.Instance.GravityVector;

        float targetAngle =
            Mathf.Atan2(gravity.y, gravity.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation =
            Quaternion.Euler(0, 0, targetAngle);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.fixedDeltaTime
        );
    }
}