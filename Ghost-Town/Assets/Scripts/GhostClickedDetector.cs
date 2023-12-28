using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GhostClickedDetector : MonoBehaviour
{
    private bool clickable;
    private int OGScore;
    public static bool isHit;
    private int highScoreValue = GhostBomb.highScoreValue;
    void Start()
    {
        isHit = false;
    }
    void Update()
    {//gameObject.transform.position.y <= 0.4
        if (GhostBomb.ghostTimer <= 1 && GhostBomb.ghostTimer > 0 && isHit)
        {
            //Debug.Log("ghost is down");
            isHit = false;
        }

        OGScore = GhostBomb.OGScore;                            
    }
    void OnMouseUp()
    {
        //gameObject.GetComponent<BoxCollider>().enabled = false;
        //StartCoroutine(allowClickAftDelay(1f));
        Debug.Log("owie ");
        Debug.Log(isHit);
        
        //int OGScoreAdd = OGScore + 1;
        //int OGScoreMinus = OGScore - 1;
        if (!isHit) // if object was clicked on and hasnt already gotten or lost a point 
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            isHit = true;
            
            if (gameObject.tag == "Ghost") {GameLogic.score += 1;}
            else {GameLogic.score -= 1;}
            print("point??");

            gameObject.GetComponent<BoxCollider>().enabled = false;
            
            print(GameLogic.score);
            GhostBomb.upTimer = 0;
            
        }
    }
    // IEnumerator allowClickAftDelay(float seconds) 
    // {
    //     yield return new WaitForSeconds(seconds);
    //     gameObject.GetComponent<BoxCollider>().enabled = true;
    // }

}
