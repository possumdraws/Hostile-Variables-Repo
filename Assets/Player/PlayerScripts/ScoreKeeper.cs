using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    //public TMP_Text scorePlusMinusText;
    public TMP_Text scoreText;

    public int multiplier;
    public TMP_Text multiplierText;
    public int consec_Kills; //consecutive

    //keep streak if there are kills within 10 seconds
    public float streakTimer = 0f;
    public float streakWearOffTimer = 15f;

    public int kills = 0;
    public TMP_Text killsText;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set base text
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        //count down timer
        if (consec_Kills > 0)
        {
            streakTimer -= Time.deltaTime;

            //streak text flashes when it's about to run out
            if (streakTimer < 3f)
            {
                float t = Mathf.PingPong(Time.time * 5f, 1f);
                multiplierText.color = Color.Lerp(Color.red, Color.white, t);
            }

            if (streakTimer <= 0f)
            {
                // streak expired
                consec_Kills = 0;
                multiplier = 1;
                UpdateScoreText();
            }
        }

        /*if (Input.GetKeyDown(KeyCode.W))
        {
            AddScore(1, true);
        }*/
    }

    public void AddScore(int point, bool streakIncreased)
    {
        score += point*multiplier;//add

        //set consecutive kill count
        if (streakIncreased)
        {
            consec_Kills += 1;
            streakTimer = streakWearOffTimer; //reset streak
        }
        else
        {
            consec_Kills = 0;
            streakTimer = 0f;//kill the streak
        }

        UpdateScoreText();//update
    }
    void UpdateScoreText() 
    {
        scoreText.text = $"Score: {score}";

        //killstreak set
        if (consec_Kills >= 8)
            multiplier = 5;
        else if (consec_Kills >= 6)
            multiplier = 4;
        else if (consec_Kills >= 4)
            multiplier = 3;
        else if (consec_Kills >= 2)
            multiplier = 2;
        else
            multiplier = 1;

        //multiplier 1-5 color
        switch (multiplier)
        {
            case 1:
                multiplierText.color = Color.green;
                break;
            case 2:
                multiplierText.color = Color.yellow;
                break;
            case 3:
                multiplierText.color = new Color(1f, 0.5f, 0f); // orange
                break;
            case 4:
                multiplierText.color = Color.red;
                break;
            case 5:
                multiplierText.color = new Color(0.5f, 0f, 0.5f); // purple
                break;
        }
        multiplierText.text = $"{multiplier}x";

        killsText.text = $"{kills}";
    }
}