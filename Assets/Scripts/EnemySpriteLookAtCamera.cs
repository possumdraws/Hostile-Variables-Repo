using UnityEngine;

public class EnemySpriteLookAtCamera : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        transform.rotation = Quaternion.LookRotation(direction);
    }
}
