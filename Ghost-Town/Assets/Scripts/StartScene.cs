using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartScene : MonoBehaviour
{

    public TextMeshProUGUI HighScore;
    public GameObject startBtn;
    private int highScoreValue = GhostClickedDetector.highScoreValue;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetSceneByName("SampleScene").isLoaded)
            SceneManager.LoadScene("StartScene");
        startBtn.GetComponent<Button>().onClick.AddListener(startGame);
        HighScore.text = highScoreValue.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void startGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
