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
    private int decider = 1;
    private float curr;
    [SerializeField] private float speed = 70f;

       private bool timerReached = false;
       private float ghostTimer = 0;

    // Start is called before the first frame update
    void Start()
    {   
        ghost.transform.position = DownPos;
        bomb.transform.position = DownPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(decider == 1)
        {
            if (!timerReached)
                ghostTimer += Time.deltaTime;
            if (!timerReached && ghostTimer > 5)
            {
                print("Ghost");
                timerReached = true;
            }

        }
    }

    void spawnGhost()
    {

    }

    void spawnBomb()
    {

    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
    }
}
