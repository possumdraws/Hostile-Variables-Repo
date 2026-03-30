using UnityEngine;
using TMPro;

public class DisplayEnemyProblemOnHover : MonoBehaviour
{
    [Header("Problems")]
    public TextMeshProUGUI calculatorPlaceholder;

    public DetectEnemy detectEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //keep it visible
        calculatorPlaceholder.gameObject.SetActive(true);

        if (detectEnemy == null)
        {
            detectEnemy = Object.FindFirstObjectByType<DetectEnemy>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (detectEnemy == null)
        {return;}

        Ray ray = detectEnemy.CalibrateRayCast();
        if(Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("enemy"))
        {
            EnemyProblem enemyProblem = hit.collider.GetComponent<EnemyProblem>();
            
            if (enemyProblem != null)
            {
                calculatorPlaceholder.text = enemyProblem.problemText.text;
            }
            else
            {
                calculatorPlaceholder.text = "No problem to display";
            }
        }
        else
        {
            calculatorPlaceholder.text = "No Enemy Detected...";
        }

    }
}
