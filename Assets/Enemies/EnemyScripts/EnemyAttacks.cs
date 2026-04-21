using NUnit.Framework;
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



    Attack BasicAttack()
    {
        return new Attack { damage = 5, range = 2 };
    }

    Attack HeavyAttack()
    {
        return new Attack { damage = 10, range = 2 };
    }

    Attack RangedAttack()
    {
        return new Attack { damage = 3, range = 5 };
    }

    Attack SpecialAttack()
    {
        return new Attack { damage = 1, range = 2 };
    }
}
