using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public static GravityManager Instance;

    public enum GravityDirection
    {
        Down,
        Up,
        Left,
        Right
    }

    [Header("Gravity Settings")]
    public GravityDirection currentDirection = GravityDirection.Down;
    public float gravityStrength = 20f;

    public Vector2 GravityVector
    {
        get
        {
            switch (currentDirection)
            {
                case GravityDirection.Down:
                    return Vector2.down;

                case GravityDirection.Up:
                    return Vector2.up;

                case GravityDirection.Left:
                    return Vector2.left;

                case GravityDirection.Right:
                    return Vector2.right;
            }

            return Vector2.down;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetGravity(GravityDirection newDirection)
    {
        currentDirection = newDirection;
    }

    public void SetGravityUp()
    {
        SetGravity(GravityDirection.Up);
    }

    public void SetGravityDown()
    {
        SetGravity(GravityDirection.Down);
    }

    public void SetGravityLeft()
    {
        SetGravity(GravityDirection.Left);
    }

    public void SetGravityRight()
    {
        SetGravity(GravityDirection.Right);
    }
}