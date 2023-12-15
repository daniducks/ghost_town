using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{

    public GameObject HighScore;
    public GameObject startBtn;


    // Start is called before the first frame update
    void Start()
    {
        
        startBtn.GetComponent<Button>().onClick.AddListener(startGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
