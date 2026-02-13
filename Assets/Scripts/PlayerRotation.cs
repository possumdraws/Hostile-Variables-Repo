using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{

    public float snapAngle = 90f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void OnLookLeft() => LookLeft();
    void OnLookRight() => LookRight();


    public void LookLeft() 
    {
        if (rb != null)
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, -snapAngle, 0f));
        else
            transform.Rotate(0f, -snapAngle, 0f);
    }

    public void LookRight()
    {
        if (rb != null)
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, snapAngle, 0f));
        else
            transform.Rotate(0f, snapAngle, 0f);
    }
}
