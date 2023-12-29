using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GhostBomb : MonoBehaviour
{
    // in the future, make the default up time shorter based on their current score so mb turn into static var and also add a static var fo is hittable :0
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject bomb; 
    [SerializeField] private Animator ghostAnim;
    [SerializeField] private Animator bombAnim;
    public static float timer;
    private bool isHit;
    private int decider;

    [SerializeField] private float defaultUpTime = 1.5f;

    private bool timerReached = false;
    public float ghostTimer = 0;
    private bool bombCanMove;
    private bool ghostCanMove;
    private float gapTime;
    public float upTimer;


    // Start is called before the first frame update
    void Start()
    {   
        // make the ghost and bomb position to somewhere u cant see 
        decider = Random.Range(1,3);
        timerReached = false;
        upTimer = defaultUpTime;
        ghostTimer = 0;
        gapTime = Random.Range(0f, 4f);
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
                    ghostAnim.Play("ghostUp"); //ghost goes up
                    ghost.GetComponent<BoxCollider>().enabled = true;
                    upTimer -= Time.deltaTime;
                    if (upTimer <= 0 || isHit || ghost.GetComponent<BoxCollider>().enabled == false)
                    {                 
                        ghost.GetComponent<BoxCollider>().enabled = false;    
                        ghostAnim.Play("ghostDown");
                        
                        timerReached = false;
                        ghostTimer = 0;
                        decider = Random.Range(1,3);
                        gapTime = Random.Range(2,5);
                        bombCanMove = true;
                        upTimer = defaultUpTime;

                    }
                }
                else if (decider == 2 && bombCanMove)
                {

                    ghostCanMove = false;
                    bombAnim.Play("bombUp");
                    bomb.GetComponent<BoxCollider>().enabled = true;
                    upTimer -= Time.deltaTime;
                    if (upTimer <= 0 || isHit || bomb.GetComponent<BoxCollider>().enabled == false)
                    {            
                        bomb.GetComponent<BoxCollider>().enabled = false;         
                        bombAnim.Play("bombDown");
                                
                        timerReached = false;
                        ghostTimer = 0;
                        decider = Random.Range(1,3);
                        gapTime = Random.Range(2,5);
                        ghostCanMove = true;
                        upTimer = defaultUpTime;
                    }

                    
                }
 

            }
        }


    }
}

