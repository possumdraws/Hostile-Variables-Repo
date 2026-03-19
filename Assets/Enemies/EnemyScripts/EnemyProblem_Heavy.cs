using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnemyProblem_Heavy : MonoBehaviour
{
    [Header("VARIABLES")]
    public int a, b, c;
    public int answer;
    private int firstAnswer;

    [Header("OPERATOR ASSIGNMENT\n0 = + | 1 = - | 2 = ×|3 = ÷")]
    public int operationTypeNum;
    /* NUMBER INDEX CODES FOR OPERATORS
     * 0 => Addition
     * 1 => Subtraction
     * 2 => Multiplication
     * 3 => Division
     */
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
        if (problemText != null)
        {
            problemText.text = $"{a} {operationTypeSymbol} {b} {operationTypeSymbol} {c} = {answer}?";
        }
    }


    //================> PROBLEM GENERATION <================\\

    //==> ADDITION <==\\
    public void GenerateAddProblem()
    {
        //generate random numbers
        a = Random.Range(1, 76);
        b = Random.Range(1, 76);
        c = Random.Range(1, 76);

        //calculate answer
        answer = a + b + c;
    }

    //==> SUBTRACTION <==\\
    public void GenerateSubProblem()
    {
        a = Random.Range(1, 76);
        b = Random.Range(1, 76);

        //ensure that there aren't negative numbers
        if (b > a)
        {
            int temp = a;
            a = b;
            b = temp;
            //b and a have been swapped.
        }

        //set temp answer to make sure that c is lower than it
        firstAnswer = a - b;
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

    //==> MULTIPLICATION <==\\
    public void GenerateMultiProblem()
    {
        //lower numbers to keep the multiplication fair
        a = Random.Range(1, 6);
        b = Random.Range(1, 6);
        c = Random.Range(1, 6);

        answer = a * b * c;
    }

    //==> DIVISION <==\\
    //it works, but just because of how math works, it usually will have an answer that is <5
    //pretty boring for gameplay, so we can hold off for the heavy division enemy maybe?
    public void GenerateDivProblem()
    {
        //divisor
        b = Random.Range(2, 6);

        //make -a- (the dividend) a multiple of -b- (divisor)
        int sureIntQuotient = Random.Range(1, 10);
        a = b * sureIntQuotient * 2;

        //check first calculation
        firstAnswer = a / b;

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

