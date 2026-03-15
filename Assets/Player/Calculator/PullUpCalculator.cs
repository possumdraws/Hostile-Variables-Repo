using UnityEngine;
using UnityEngine.UI;

public class PullUpCalculator : MonoBehaviour
{
    /*quick heads up about conditional statements and ternary operators that I used here
     * int? age = null; means that age can be an int or be null
     * : just adds onto that
     * condition ? ifTrue : ifFalse
     * bool isActive = true;
     * string str = isActive ? "Active!" : "Inactive."
     * basically, Is this true? Yes or No
    */

    #region HEADERS
    [Header("References")]
    public MonoBehaviour cameraLook;// FPcam object with camera movement script
    public Canvas calculatorCanvas;//calculator canvas

    [Header("Offhand Positions/Rotations")]
    public Vector3 offhandPosition = new Vector3(0.35f, -0.3f, 0.5f);
    public Vector3 offhandRotation = new Vector3(0, 30, 0); // no rotation when resting

    [Header("ADS Positions/Rotations")]
    public Vector3 pulledUpPosition = new Vector3(0.21f, 0, 0.34f);//world position relative to camera when right click
    private Vector3 pulledUpRotation = Vector3.zero;//set all to 0 so it's parallel with camera. set to priv cause we don't have to touch

    [Header("ADS Speed")]
    public float moveSpeed;//pull up speed
    #endregion

    private GraphicRaycaster raycaster;

    void Start()
    {
        //get raycaster for the canvas
        raycaster = calculatorCanvas.GetComponent<GraphicRaycaster>();

        //calculator UI is always on
        calculatorCanvas.gameObject.SetActive(true);


        transform.localPosition = offhandPosition;
        SetInteractable(false);
    }

    void Update()
    {
        if (CheckIsPaused.paused) 
        { 
            return; 
        }
        //bool is attached to if we are holding right click
        bool holdingRightClick = Input.GetMouseButton(1);

        //movement&rotation of calculator
        MoveCalcPos(holdingRightClick);
        RotateCalcPos(holdingRightClick);

        //interaction is attached to holdingRightClick bool
        SetInteractable(holdingRightClick);
    }
    void MoveCalcPos(bool hrc)
    {
        //smoothly move calculator
        Vector3 targetPos = hrc ? pulledUpPosition : offhandPosition;
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * moveSpeed);
    }
    void RotateCalcPos(bool hrc)
    {
        //smoothly rotate calculator
        Vector3 targetEuler = hrc ? pulledUpRotation : offhandRotation;
        transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, targetEuler, Time.deltaTime * moveSpeed);
    }
    void SetInteractable(bool hrc)//hrc = holdingRightCLick
    {
        //if raycaster is active, hrc is true
        if (raycaster != null)
            raycaster.enabled = hrc;

        //if cameraLook is active, hrc is false
        if (cameraLook != null)
            cameraLook.enabled = !hrc;

        Cursor.visible = hrc;//cursor visibility is attached to the 
        Cursor.lockState = hrc ? CursorLockMode.Confined : CursorLockMode.Locked;
    }
}