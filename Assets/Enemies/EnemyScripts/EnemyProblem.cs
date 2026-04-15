using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class EnemyProblem : MonoBehaviour
{
    [Header("VARIABLES")]
    public int a, b, c;
    public int answer;

    [Header("OPERATOR ASSIGNMENT\n0 = + | 1 = - | 2 = ×|3 = ÷")]
    public int operationTypeNum;
    /* NUMBER INDEX CODES FOR OPERATORS
     * 0 => Addition
     * 1 => Subtraction
     * 2 => Multiplication
     * 3 => Division
     */

    [Header("ENEMY TYPE ASSIGNMENT\n0 = BASIC | 1 = HEAVY")]
    public int enemyBasicHeavyAssignment;

    string operationTypeSymbol;//is assigned in Start() switch

    public TextMeshProUGUI problemText; //ref to TMP text

    private void Start()
    {
        switch (operationTypeNum)
        {
            case 0://addition
                GenerateAddProblem();
                operationTypeSymbol = "+";
                break;
            case 1://subtraction
                GenerateSubProblem();
                operationTypeSymbol = "-";
                break;
            case 2://multiplication
                GenerateMultiProblem();
                operationTypeSymbol = "×";
                break;
            case 3://division
                GenerateDivProblem();
                operationTypeSymbol = "÷";
                break;
        }
        SetProblemTextAndOperator();
    }

    //================> SET TEXT <================\\
    void SetProblemTextAndOperator()
    {
        //if TMP text exists (assigned in inspector)
        if (enemyBasicHeavyAssignment == 0 && problemText != null)
        {
            problemText.text = $"{a} {operationTypeSymbol} {b} = {answer}?";
            //problemText.text = $"{a} {operationTypeSymbol} {b} = ?";
        }
        if (enemyBasicHeavyAssignment == 1 && problemText != null)
        {
            problemText.text = $"{a} {operationTypeSymbol} {b} {operationTypeSymbol} {c} = {answer}?";
            //problemText.text = $"{a} {operationTypeSymbol} {b} {operationTypeSymbol} {c} = ?";
        }
    }


    //================> PROBLEM GENERATION <================\\

        //==> ADDITION <==\\
    public void GenerateAddProblem()
    {
        //generate random numbers
        a = Random.Range(1, 101);
        b = Random.Range(1, 101);
        
        //basic gen
        if (enemyBasicHeavyAssignment == 0)
        {
            //calculate answer
            answer = a + b;
        }

        //heavy gen
        if(enemyBasicHeavyAssignment == 1)
        {
            //generate 3rd var for heavy enemies
            c = Random.Range(1, 101);
            
            //calculate heavy answer
            answer = a + b + c;
        }
    }

    //==> SUBTRACTION <==\\
    public void GenerateSubProblem()
    {
        a = Random.Range(1, 101);
        b = Random.Range(1, 101);

        //ensure that there aren't negative numbers
        if (b > a)
        {
            int temp = a;
            a = b;
            b = temp;
            //b and a have been swapped.
        }

        //basic gen
        if (enemyBasicHeavyAssignment == 0)
        {
            //calculate
            answer = a - b;
        }

        //heavy gen
        if (enemyBasicHeavyAssignment == 1)
        {
            //set temp answer to make sure that c is lower than it
            int firstAnswer = a - b;
            //handle firstAnswer being 0
            if (firstAnswer == 0)
            {
                c = 0;
            }
            else
            {
                //if firstAnswer = 12, answer will be between 0-12 
                c = Random.Range(1, firstAnswer + 1);
            }

            //calculate
            answer = a - b - c;
        }
    }

    //==> MULTIPLICATION <==\\
    public void GenerateMultiProblem()
    {
        //basic gen
        if (enemyBasicHeavyAssignment == 0)
        {
            //lower numbers to keep the multiplication fair
            a = Random.Range(1, 15);
            b = Random.Range(1, 15);

            //calculate
            answer = a * b;
        }

        //heavy gen
        if (enemyBasicHeavyAssignment == 1)
        {
            //lower numbers to keep the multiplication fair
            a = Random.Range(1, 6);
            b = Random.Range(1, 6);
            c = Random.Range(1, 6);

            answer = a * b * c;
        }
    }

    //==> DIVISION <==\\
    public void GenerateDivProblem()
    {
        //basic gen
        if (enemyBasicHeavyAssignment == 0)
        {
            //divisor
            b = Random.Range(1, 20);

            //make -a- (the dividend) a multiple of -b- (divisor)
            int sureIntQuotient = Random.Range(1, 10);
            a = b * sureIntQuotient;

            answer = a / b;
        }

        //heavy gen
        if(enemyBasicHeavyAssignment == 1)
        {
            //divisor
            b = Random.Range(2, 6);

            //make -a- (the dividend) a multiple of -b- (divisor)
            int sureIntQuotient = Random.Range(1, 10);
            a = b * sureIntQuotient * 2;

            //check first calculation
            int firstAnswer = a / b;

            //list to store good divisors
            List<int> divisors = new List<int>();

            //find divisors and add to the list
            for (int i = 1; i <= firstAnswer; i++)
            {
                if (firstAnswer % i == 0)
                { divisors.Add(i); }
            }

            //filter out EX: 5/5, 5/1, etc
            divisors = divisors.Where(x => x != 1 && x != firstAnswer).ToList();


            //if no divisors were found, c == 1
            if (divisors.Count == 0)
            {
                c = 1;
            }
            else
            {
                c = divisors[Random.Range(0, divisors.Count)];
            }

            //calculate final answer
            answer = firstAnswer / c;
        }
    }

}
