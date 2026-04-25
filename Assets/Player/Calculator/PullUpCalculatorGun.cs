using UnityEngine;
using UnityEngine.UI;

public class PullUpCalculatorGun : MonoBehaviour
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
    public Canvas rotationButtons; //rotationButtons canvas

    [Header("Offhand Positions/Rotations")]
    //public Vector3 offhandPosition = new Vector3(0.35f, -0.3f, 0.5f);
    //public Vector3 offhandRotation = new Vector3(0, 30, 0); // no rotation when resting
    public Vector3 offhandPosition = new Vector3();
    public Vector3 offhandRotation = new Vector3(); // no rotation when resting

    [Header("ADS Positions/Rotations")]
    public Vector3 pulledUpPosition = new Vector3(0.21f, 0, 0.34f);//world position relative to camera when right click
    private Vector3 pulledUpRotation = Vector3.zero;//set all to 0 so it's parallel with camera. set to priv cause we don't have to touch

    [Header("ADS Speed")]
    public float moveSpeed;//pull up speed

    bool calcUp = false;
    #endregion

    private GraphicRaycaster raycaster;

    void Start()
    {
        //get raycaster for the canvas
        raycaster = calculatorCanvas.GetComponent<GraphicRaycaster>();

        //calculator UI is always on
        calculatorCanvas.gameObject.SetActive(true);

        //rotationButtons
        rotationButtons.gameObject.SetActive(true);

        //base positioning
        transform.localPosition = offhandPosition;

        //cannot interact in offhand
        SetInteractable(false);
    }

    void Update()
    {
        if (CheckIsPaused.paused) 
        { 
            return; 
        }

        //bool is attached right click
        if (Input.GetMouseButtonDown(1))
        {
            FlipCalc();
        }

        //movement&rotation of calculator
        MoveCalcPos(calcUp);
        RotateCalcPos(calcUp);

        //interaction is attached to holdingRightClick bool
        SetInteractable(calcUp);
    }
    public void FlipCalc()
    {
        //flip to true, and then back on another press
        calcUp = !calcUp;
        rotationButtons.gameObject.SetActive(!calcUp);
    }
    void MoveCalcPos(bool rc)
    {
        //smoothly move calculator
        Vector3 targetPos = rc ? pulledUpPosition : offhandPosition;
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * moveSpeed);
    }
    void RotateCalcPos(bool rc)
    {
        //smoothly rotate calculator
        Vector3 targetEuler = rc ? pulledUpRotation : offhandRotation;
        transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, targetEuler, Time.deltaTime * moveSpeed);
    }
    void SetInteractable(bool rc)//hrc = holdingRightCLick
    {
        //if raycaster is active, hrc is true
        if (raycaster != null)
            raycaster.enabled = rc;

        //if cameraLook is active, hrc is false
        if (cameraLook != null)
            cameraLook.enabled = !rc;

        //Cursor.visible = hrc;//cursor visibility is attached to the 
        //Cursor.lockState = hrc ? CursorLockMode.Confined : CursorLockMode.Locked;
    }
}