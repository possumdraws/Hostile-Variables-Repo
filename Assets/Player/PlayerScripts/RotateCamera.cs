using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float rotationSnapAngle = 120f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LookLeft();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            LookRight();
        }
    }

    public void LookLeft()
    {
        if (rb != null)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, -rotationSnapAngle, 0f));
        }
        else
        {
            transform.Rotate(0f, -rotationSnapAngle, 0f);
        }
    }

    public void LookRight()
    {
        if (rb != null)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotationSnapAngle, 0f));
        }
        else
        {
            transform.Rotate(0f, rotationSnapAngle, 0f);

        }
    }
}

