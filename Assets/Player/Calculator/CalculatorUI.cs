using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CalculatorUI : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField inputField;// TMP input field
    public TMP_InputField storedInputField;// store input to keep in on screen
    public Button[] numberButtons;// Buttons 0-9
    public Button enterButton;
    public Button deleteButton;

    [Header("Entered Value")]
    public string enteredValue;

    //SFX
    public AudioSource ButtonClick;

    PullUpCalculator pullUpCalculator;
    CalcLogic calcLogic;

    void Start()
    {
        calcLogic = GameObject.FindFirstObjectByType<CalcLogic>();

        if (inputField == null)
        {
            Debug.LogError("InputField is not assigned!");
            return;
        }

        //assign number button listeners
        for (int i = 0; i < numberButtons.Length; i++)
        {
            int num = i; //capture loop variable
            if (numberButtons[i] != null)
                numberButtons[i].onClick.AddListener(() => AppendNumber(num));
        }

        //assign enter button listener
        if (enterButton != null)
        {
            enterButton.onClick.AddListener(OnEnterPressed);
        }

        //assign delete button listener
        if (deleteButton != null)
        {
            deleteButton.onClick.AddListener(OnDeletePressed);
        }
    }

    //append a number to the input field text
    private void AppendNumber(int number)
    {
        //make sure that someone cant enter 1476532413247564321574641534534534...
        if (inputField.text.Length < 4) 
        {
            storedInputField.text = "";
            ButtonClick.Play();
            inputField.text += number.ToString();
        }
    }

    //handle enter button click
    public void OnEnterPressed()
    {
        ButtonClick.Play();
        string value = inputField.text.Trim();

        if (string.IsNullOrEmpty(value))
        {
            Debug.Log("No input to process.");
            return;
        }

        //log the value in debug menu
        Debug.Log("Entered value: " + value);

        //assign value to public string
        enteredValue = value;

        //put the entered value on the right before clearing
        storedInputField.text = inputField.text;

        //clear after enter
        inputField.text = "";
    }

    //deletes the last character from the input field
    private void OnDeletePressed()
    {
        ButtonClick.Play();
        if (!string.IsNullOrEmpty(inputField.text))
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }
}
