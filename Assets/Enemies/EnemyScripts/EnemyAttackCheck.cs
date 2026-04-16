using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    /* 
     * SPAWNERS
     * ROW 0
     * ROW 1 (ranger)
     * ROW 2 (basic)
     * 
     * PLAYER
     */

    //damage number from enemy
    public int damage;
    public bool inRange;

    EnemyProblem enemyProblem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //check enemy type
        switch(enemyProblem.enemyBasicHeavyAssignment)
        {
            case 0://basic
                damage = 5;
                break;
            case 1://heavy
                damage = 10;
                break;
            case 2://ranged
                damage = 5;
                break;
            case 3://special
                damage = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
