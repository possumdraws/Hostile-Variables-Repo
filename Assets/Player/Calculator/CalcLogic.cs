using UnityEngine;
using TMPro;
public class CalcLogic : MonoBehaviour
{
    //so we can't shoot while using the menu
    public bool canBlast = true;

    //SFX
    public AudioSource laserBlast;

    //OOP Refs
    private DetectEnemy detectEnemy;
    private CalculatorUI calculatorUI;
    private PullUpCalculator pullUpCalculator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        detectEnemy = GameObject.FindFirstObjectByType<DetectEnemy>();
        calculatorUI = GameObject.FindFirstObjectByType<CalculatorUI>();
        pullUpCalculator = GameObject.FindFirstObjectByType<PullUpCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckIsPaused.paused)
        {
            return;
        }

        //cannot shoot while calculator is toggled
        if (Input.GetMouseButtonDown(1))
        {
            //flip to true, and then back on another press
            canBlast = !canBlast;
        }

        
        if (Input.GetMouseButtonDown(0) && canBlast)
        {
            laserBlast.Play();

            Blast();
        }
    }

    public void FlipCalcAll()
    {
        canBlast = !canBlast;
        pullUpCalculator.FlipCalc();
    }

    void Blast()
    {
        //cast a ray to see which enemy was clicked
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("enemy"))
        {
            EnemyProblem enemyProblem = hit.collider.GetComponent<EnemyProblem>();
            if (enemyProblem != null && calculatorUI.enteredValue == enemyProblem.answer.ToString())
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
