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
    [SerializeField] private Animator ghostAnim;
    public static float timer;
    public static int highScoreValue;
    [SerializeField] private Vector3 DownPos = new Vector3(0.29031f, 0.45f, -1.3362f);
    [SerializeField] private Vector3 UpPos = new Vector3(0.29031f, 3.38f, -1.3362f);
    private int decider;
    [SerializeField] private float speed = 70f;
    [SerializeField] private float hittableTime = 3f;

    private bool timerReached = false;
    private float ghostTimer = 0;
    private float elapsedTime;
    private float elapsedTime2;
    private bool bombCanMove;
    private bool ghostCanMove;
    private float gapTime;
    private float upTimer;
    private float percentageComplete;

    // Start is called before the first frame update
    void Start()
    {   
        ghost.transform.position = DownPos;
        bomb.transform.position = DownPos;
        decider = 1;
        timerReached = false;
        upTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameLogic.isPlaying)
        {
            if (!timerReached) //if the timer hasnt been reached yet
                ghostTimer += Time.deltaTime;
                ghostCanMove = true;
                bombCanMove = true;

            if (!timerReached && ghostTimer >= gapTime) // if tmer had reached the given gap time
            {
                timerReached = true; 
            }

            if (timerReached)
            {
                if (decider == 1 && ghostCanMove) // if the decider chooses ghost (1 = ghost, 2 = bomb)
                {
                    //elapsedTime2 = 0;
                    bombCanMove = false;

                    ghostAnim.Play("ghostUp");
                    print("its da ghost not going up...");
                    if (ghost.transform.position == UpPos) 
                    {
                        upTimer -= Time.deltaTime;
                        if (upTimer <= 0)
                        {                     
                            print("whatup");
                            ghostAnim.Play("ghostDown");
                                
                            timerReached = false;
                            ghostTimer = 0;
                            decider = Random.Range(1,3);
                            gapTime = Random.Range(2,5);
                            Debug.Log(gapTime);
                            bombCanMove = true;
                        }

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
                        gapTime = Random.Range(3,7);
                        decider = Random.Range(1,3);
                        ghostCanMove = true;
                        Debug.Log(decider + " chosen by bomb");

                    }
                }
 

            }
        }


    }
}

