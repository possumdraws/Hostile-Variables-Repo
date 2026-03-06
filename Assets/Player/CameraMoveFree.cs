using UnityEngine;

public class CameraMoveFree : MonoBehaviour
{
    public float sensitivity; //sens
    public Transform playerBody; // player model ref

    public float xRotation = 0f; // no y bc we're only looking left and right

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//lock the cursor on the screen
    }

    // Update is called once per frame
    void Update()
    {
        //mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //adjust Y if needed
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //apply rotations
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//rotate camera vertically

        playerBody.Rotate(Vector3.up * mouseX);//rotate player model horizontally
    }
}
