using UnityEngine;

public class GravityInput : MonoBehaviour
{
    public float gravityChangeCooldown = 0.25f;

    private float cooldownTimer;

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0)
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeGravity(
                GravityManager.GravityDirection.Up
            );
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeGravity(
                GravityManager.GravityDirection.Down
            );
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeGravity(
                GravityManager.GravityDirection.Left
            );
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeGravity(
                GravityManager.GravityDirection.Right
            );
        }
    }

    private void ChangeGravity(
        GravityManager.GravityDirection direction)
    {
        GravityManager.Instance.SetGravity(direction);

        cooldownTimer = gravityChangeCooldown;
    }
}