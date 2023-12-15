using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Timer; 
    [SerializeField] private TextMeshProUGUI Score; 
    [SerializeField] private float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0){
            Timer.text = timeRemaining.ToString();
            timeRemaining -= Time.deltaTime;
        }
    }
}
