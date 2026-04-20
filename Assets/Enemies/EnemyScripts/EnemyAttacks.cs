using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    /* 
     * SPAWNERS
     * ROW 0
     * ROW 1 (ranger)
     * ROW 2 (basic)
     * 
     * PLAYER
     */

    EnemyProblem enemyProblem;
    public Transform playerTarget;

    [Header("Animator")]
    public Animator animator;

    struct Attack
    {
        public int damage;
        public int range;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BasicAttack()
    {
        Attack attack = new Attack();
        attack.damage = 5;
        attack.range = 2;
    }

    void HeavyAttack()
    {
        Attack attack = new Attack();
        attack.damage = 10;
        attack.range = 2;
    }

    void RangedAttack()
    {
        Attack attack = new Attack();
        attack.damage = 3;
        attack.range = 1;
    }

    void SpecialAttack()
    {
        Attack attack = new Attack();
        attack.damage = 1;
        attack.range = 2;
    }
}
