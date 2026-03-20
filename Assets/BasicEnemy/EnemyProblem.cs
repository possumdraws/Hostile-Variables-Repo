using TMPro;
using UnityEngine;

public class EnemyProblem : MonoBehaviour
{
    [Header("VARIABLES")]
    public int a, b;
    public int answer;

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
            problemText.text = $"{a} {operationTypeSymbol} {b} = {answer}?";
        }
    }


    //================> PROBLEM GENERATION <================\\
    
    //==> ADDITION <==\\
    public void GenerateAddProblem()
    {
        //generate random numbers
        a = Random.Range(1, 101);
        b = Random.Range(1, 101);

        //calculate answer
        answer = a + b;
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

        //calculate
        answer = a - b;
    }

    //==> MULTIPLICATION <==\\
    public void GenerateMultiProblem()
    {
        //lower numbers to keep the multiplication fair
        a = Random.Range(1, 15);
        b = Random.Range(1, 15);

        answer = a * b;
    }

    //==> DIVISION <==\\
    public void GenerateDivProblem()
    {
        //divisor
        b = Random.Range(1, 20);

        //make -a- (the dividend) a multiple of -b- (divisor)
        int sureIntQuotient = Random.Range(1, 10);
        a = b * sureIntQuotient;

        answer = a / b;
    }

}
