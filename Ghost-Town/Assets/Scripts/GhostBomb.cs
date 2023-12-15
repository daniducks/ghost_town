using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GhostBomb : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject ghost;
    public GameObject bomb; 
    public GameObject timerText;
    public static float timer;
    public static int highScoreValue;
    public Vector3 DownPos = new Vector3(0.29031f, 0.28f, -1.3362f);
    public Vector3 UpPos = new Vector3(0.29031f, 3.38f, -1.3362f);
    private int decider = 1;
    private float curr;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {   

        ghost.transform.position = DownPos;
        bomb.transform.position = DownPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnGhost()
    {
        //yield return new WaitForSeconds(Random.Range(0.3f,3));
        // #curr = Mathf.MoveTowards(curr, UpPos, speed* Time.deltaTime);
        // #ghostTrans.localPosition = Vector3.lerp(DownPos, UpPos, curr);
    }

    void spawnBomb()
    {

    }
}
