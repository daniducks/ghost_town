using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GhostClickedDetector : MonoBehaviour
{
    private bool clickable;
    public static bool isHit;
    private int highScoreValue = GhostBomb.highScoreValue;
    void Start()
    {
        isHit = false;
    }
    void Update()
    {
        if (gameObject.transform.position.y <= 0.45 && isHit)
        {
            //Debug.Log("ghost is down");
            isHit = false;
        }
    }
    void OnMouseDown()
    {
        Debug.Log("owie ");
        Debug.Log(isHit);
        
        if (!isHit)
        {
            if (gameObject.tag == "Ghost") {GameLogic.score += 1;}
            else {GameLogic.score -= 1;}
            print("point??");
            isHit = true;
            print(GameLogic.score);
            GhostBomb.upTimer = 0;
        }
    }

}
