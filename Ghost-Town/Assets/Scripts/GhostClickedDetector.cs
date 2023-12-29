using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GhostClickedDetector : MonoBehaviour
{
    private GhostBomb parentScript;
    private bool clickable;
    public static bool isHit;
    private int highScoreValue = GhostBomb.highScoreValue;
    void Start()
    {
        isHit = false;
        parentScript = gameObject.transform.parent.GetComponent<GhostBomb>();
    }
    void Update()
    {
        
        if (parentScript.ghostTimer <= 1 && parentScript.ghostTimer > 0 && isHit)
        {
            //Debug.Log("ghost is down");
            isHit = false;
        }
                        
    }
    void OnMouseUp()
    {
        Debug.Log("owie ");
        Debug.Log(isHit);

        if (!isHit) // if object was clicked on and hasnt already gotten or lost a point 
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            isHit = true;
            
            if (gameObject.tag == "Ghost") {GameLogic.score += 1;}
            else {GameLogic.score -= 1;}
            print("point??");

            gameObject.GetComponent<BoxCollider>().enabled = false;
            
            print(GameLogic.score);
            
            parentScript.upTimer = 0;
            
        }
    }
}
