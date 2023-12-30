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
    public static int highScoreValue;
    void Start()
    {
        PlayerPrefs.GetInt("HighScore", 0);
        isHit = false;
        parentScript = gameObject.transform.parent.GetComponent<GhostBomb>();
    }
    void Update()
    {
        
        if (parentScript.ghostTimer <= 1 && parentScript.ghostTimer > 0 && isHit)
        {
            isHit = false;
        }

        if(GameLogic.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            highScoreValue = GameLogic.score;
            PlayerPrefs.SetInt("HighScore", highScoreValue);
        }
                        
    }
    void OnMouseUp()
    {

        if (!isHit) // if object was clicked on and hasnt already gotten or lost a point 
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            isHit = true;
            
            if (gameObject.tag == "Ghost") {GameLogic.score += 1;}
            else {GameLogic.score -= 1;}

            gameObject.GetComponent<BoxCollider>().enabled = false;
            
            parentScript.upTimer = 0;
            
        }
    }
}
