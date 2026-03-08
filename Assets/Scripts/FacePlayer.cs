using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    // Reference to the player's transform
    public Transform player;

    // Optional: adjust rotation speed for smooth turning
    public float rotationSpeed = 5f;

    void Update()
    {
        if (player != null)
        {
            // 1. Calculate the direction to the target
            Vector3 directionToTarget = player.position - transform.position;

            // 2. Calculate the angle in degrees using Mathf.Atan2 for 2D
            // Atan2 returns the angle whose tangent is the quotient of two specified numbers (y and x)
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

            // 3. Create the target rotation quaternion
            // We rotate around the Vector3.forward (Z-axis in 2D)
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // 4. Apply the rotation smoothly using Quaternion.Slerp or instantly using transform.rotation
            // Smooth rotation:
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Instant rotation:
            // transform.rotation = targetRotation;
        }
    }
}
