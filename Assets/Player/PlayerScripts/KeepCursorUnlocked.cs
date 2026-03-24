using UnityEngine;

public class KeepCursorUnlocked : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure the cursor is always unlocked and visible
        if (Cursor.lockState != CursorLockMode.None)
            Cursor.lockState = CursorLockMode.None;

        if (!Cursor.visible)
            Cursor.visible = true;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        //re-apply if page is clsoed and opened again
        if (hasFocus)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            //pause if window is minimized (might work idk Ill check on build)
            Time.timeScale = 0;
        }
    }
}
