using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Timer;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private float timeRemaining;
    [SerializeField] private float readyTimeRemaining;

    private float delay;
    public static int score;
    public static bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false;
        timeRemaining = 60;
        readyTimeRemaining = 6;
        score = 0;
        delay = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();

        if (!isPlaying)
        {
            if (readyTimeRemaining >= 4)
            {
                Timer.text = "READY";
                readyTimeRemaining -= Time.deltaTime;
            }

            else if (readyTimeRemaining >= 3)
            {
                Timer.text = "SET";
                readyTimeRemaining -= Time.deltaTime;
            }

            else if (readyTimeRemaining >= 2) 
            {
                Timer.text = "GO";
                readyTimeRemaining -= Time.deltaTime;
            }
            else {isPlaying = true;}

        }
   

        if (isPlaying && timeRemaining > 0)
        {
            float timeToDisplay = Mathf.FloorToInt(timeRemaining % 60);
            Timer.text = timeToDisplay.ToString();
            timeRemaining -= Time.deltaTime;
        }

        else if (isPlaying && timeRemaining < 0)
        {
            isPlaying = false;
            delay -= Time.deltaTime;
            if (delay < 0)
            {
                SceneManager.LoadScene("EndScene");                
            }

        }
    }
}
