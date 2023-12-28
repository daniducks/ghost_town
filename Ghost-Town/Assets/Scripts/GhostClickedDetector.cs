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
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {
        isHit = false;
    }
    void Update()
    {
        if (gameObject.transform.position.y <= 0.6)
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
            print("point??");
            GameLogic.score += 1;
            isHit = true;
            print(GameLogic.score);
            GhostBomb.upTimer = 0;
        }
    }

}
