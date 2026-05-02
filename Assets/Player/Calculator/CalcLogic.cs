using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
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
    private ScoreKeeper scoreKeeper;
    private PlayerHealth playerHealth;
    private ProjectileBeam projectileBeam;


    public GameObject leftArrow;
    public GameObject rightArrow;


    float delayBeforeClearingText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        detectEnemy = GameObject.FindFirstObjectByType<DetectEnemy>();
        calculatorUI = GameObject.FindFirstObjectByType<CalculatorUI>();
        pullUpCalculator = GameObject.FindFirstObjectByType<PullUpCalculator>();
        scoreKeeper = GameObject.FindFirstObjectByType<ScoreKeeper>();
        playerHealth = GameObject.FindFirstObjectByType<PlayerHealth>();
        projectileBeam = GameObject.FindFirstObjectByType<ProjectileBeam>();
    }

    // Update is called once per frame
    void Update()
    {
        //countdown until getting rid of the green check
        if (delayBeforeClearingText > 0)
        {
            delayBeforeClearingText -= Time.deltaTime;

            if (delayBeforeClearingText <= 0)
            {
                calculatorUI.storedInputField.text = "";//clear after cooldown
            }
        }

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
            laserBlast.Play();

            EnemyProblem enemyProblem = hit.collider.GetComponent<EnemyProblem>();
            EnemyAttackCheck enemyAttackCheck = hit.collider.GetComponent<EnemyAttackCheck>();


            //SUCCESFUL KILL
            if (enemyProblem != null && calculatorUI.enteredValue == enemyProblem.answer.ToString())
            {
                calculatorUI.storedInputField.text = "<color=green>!</color>";//green check if correct ( \u2713 )
                delayBeforeClearingText = 2f;

                //shoot beam
                projectileBeam.ShootBeam();

                Destroy(hit.collider.gameObject);
  
                scoreKeeper.kills++; //log kills
                scoreKeeper.AddScore(enemyAttackCheck.damage / 2,true); //log score (scales with enemy damage)

                //add some health back to be nice, and it scales with your multiplier and the enemies damage! adds to the fun
                playerHealth.AddHealth(enemyAttackCheck.damage / 2 * scoreKeeper.multiplier / 2);

            }//FAILED KILL
            else if (enemyProblem != null && calculatorUI.enteredValue != enemyProblem.answer.ToString())
            {
                calculatorUI.storedInputField.text = "<color=red>×</color>";//red check if false
                delayBeforeClearingText = 2f;

                scoreKeeper.AddScore(0,false);//log score
            }
        }
    }
}