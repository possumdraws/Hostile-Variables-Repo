using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackCheck : MonoBehaviour
{
    [Header("===SET ENEMY TYPE===\n0: Basic\n1: Heavy\n2: Ranged\n3: Specialist")]
    public int EnemyType;

    [Header("Timer Between Attacks")]
    public float baseTimerDelay = 3f;
    float delay;

    [Header("Enemy Stats")]
    public int damage;
    public int range;

    [Header("Attack Attributes")]
    public Animator animator;
    public AudioSource AttackSound;

    bool attackChance;

    EnemyMovement enemyMovement;
    PlayerHealth playerHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set timer
        delay = baseTimerDelay;

        enemyMovement = GetComponent<EnemyMovement>();
        playerHealth = FindFirstObjectByType<PlayerHealth>();

        //set stats
        damage = SetDamage();
        range = SetRange();

        //directional audio setup
        if (AttackSound != null)
        {
            AttackSound.spatialBlend = 1f;
            AttackSound.rolloffMode = AudioRolloffMode.Logarithmic;
            AttackSound.minDistance = 1f;
            AttackSound.maxDistance = 15f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyMovement == null)
        { return; }

        //check after # seconds
        delay -= Time.deltaTime;

        //timer hits 0
        if (delay <= 0f)
        {
            //% chance of attacking
            attackChance = Random.value < 0.3f;

            //attackChance = true && timer hit 0 && enemy is not moving && in range
            if (attackChance && !enemyMovement.isMoving && enemyMovement.currentRow >= range)
            {
                Attack();
            }
            //reset timer
            delay = baseTimerDelay;
        }
    }


    void Attack()
    {
        AttackSound.Play();
        PlayAttackAnimation();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
        //log
        Debug.Log($"{name} attacked ({attackChance} chance) for {damage} at row {range}");
    }

    int SetDamage()
    {
        //check enemy type
        switch(EnemyType)
        {
            case 0://basic
                return 5;
            case 1://heavy
                return 10;
            case 2://ranged
                return 3;
            case 3://special
                return 1;
            default://backup
                return 0;
        }
    }
    int SetRange()
    {
        /* 
         * SPAWNERS
         * ROW 0
         * ROW 1 (ranger)
         * ROW 2 (basic)
         * 
         * PLAYER
         */

        //if ranged
        if(EnemyType == 2)
        {
            return 1;
        }
        else//not ranged
        {
            return 2;
        }
    }

    //animator func when the time comes
    void PlayAttackAnimation()
    {
        //animator.SetTrigger("Attack");
    }

}
