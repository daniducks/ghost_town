using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GhostBomb : MonoBehaviour
{
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject bomb; 
    [SerializeField] private GameObject timerText;
    public static float timer;
    public static int highScoreValue;
    [SerializeField] private Vector3 DownPos = new Vector3(0.29031f, 0.45f, -1.3362f);
    [SerializeField] private Vector3 UpPos = new Vector3(0.29031f, 3.38f, -1.3362f);
    private int decider;
    private float curr;
    [SerializeField] private float speed = 70f;

    private bool timerReached = false;
    private float ghostTimer = 0;
    private float elapsedTime;
    private float elapsedTime2;
    private bool bombCanMove;
    private bool ghostCanMove;

    // Start is called before the first frame update
    void Start()
    {   
        ghost.transform.position = DownPos;
        bomb.transform.position = DownPos;
        decider = 2;

        timerReached = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!timerReached)
            ghostTimer += Time.deltaTime;
            ghostCanMove = true;
            bombCanMove = true;

        if (!timerReached && ghostTimer >= Random.Range(7,12))
        {
            timerReached = true;
        }

        if (timerReached)
        {
            if (decider == 1 && ghostCanMove)
            {
                elapsedTime2 = 0;
                bombCanMove = false;
                //makes the ghost move up :D
                elapsedTime += Time.deltaTime;
                float percentComplete = elapsedTime / speed;
                ghost.transform.position = Vector3.Lerp(DownPos, UpPos, percentComplete);

                if (ghost.transform.position == UpPos) 
                {
                    elapsedTime = 0;
                    print("ghost Up");

                    elapsedTime2 += Time.deltaTime;
                    float percentageComplete = elapsedTime2 / speed;
                    ghost.transform.position = Vector3.Lerp(UpPos, DownPos, percentageComplete);

                    timerReached = false;
                    ghostTimer = 0;
                    decider = Random.Range(1,3);
                }
                    
            }
            else if (decider == 2 && bombCanMove)
            {
                elapsedTime2 = 0;
                ghostCanMove = false;
                //makes the ghost move up :D
                elapsedTime += Time.deltaTime;
                float percentComplete = elapsedTime / speed;
                bomb.transform.position = Vector3.Lerp(DownPos, UpPos, percentComplete);
                
                if (bomb.transform.position == UpPos) 
                {
                    elapsedTime = 0;
                    print("bomb up");

                    elapsedTime2 += Time.deltaTime;
                    float percentageComplete = elapsedTime2 / speed;
                    bomb.transform.position = Vector3.Lerp(UpPos, DownPos, percentageComplete);
                    
                    timerReached = false;
                    ghostTimer = 0;
                    decider = Random.Range(1,3);
                }
            }
 

        }

    }
}

