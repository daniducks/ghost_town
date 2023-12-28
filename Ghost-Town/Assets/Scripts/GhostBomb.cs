using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GhostBomb : MonoBehaviour
{
    // in the future, make the default up time shorter based on their current score so mb turn into static var
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject bomb; 
    [SerializeField] private Animator ghostAnim;
    [SerializeField] private Animator bombAnim;
    public static float timer;
    public static int highScoreValue;
    [SerializeField] private Vector3 DownPos = new Vector3(0.29031f, 0.45f, -1.3362f);
    [SerializeField] private Vector3 UpPos = new Vector3(0.29031f, 3.38f, -1.3362f);
    private int decider;
    [SerializeField] private float speed = 70f;
    [SerializeField] private float hittableTime = 3f;
    [SerializeField] private float defaultUpTime = 1.5f;

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
        upTimer = defaultUpTime;
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
                            upTimer = defaultUpTime;
                        }

                    }
                    
                }
                else if (decider == 2 && bombCanMove)
                {

                    ghostCanMove = false;
                    bombAnim.Play("bombUp");
                    if (bomb.transform.position == UpPos) 
                    {
                        upTimer -= Time.deltaTime;
                        if (upTimer <= 0)
                        {                     
                            print("whatup");
                            bombAnim.Play("bombDown");
                                
                            timerReached = false;
                            ghostTimer = 0;
                            decider = Random.Range(1,3);
                            gapTime = Random.Range(2,5);
                            Debug.Log(gapTime);
                            ghostCanMove = true;
                            upTimer = defaultUpTime;
                        }

                    }
                }
 

            }
        }


    }
}

