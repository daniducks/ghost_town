using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    public GameObject TitleScreenBtn;

    // Start is called before the first frame update
    void Start()
    {
     
        TitleScreenBtn.GetComponent<Button>().onClick.AddListener(TooTitleScreen);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void TooTitleScreen()
    {
        SceneManager.LoadScene("StartScene");
        print("bro huh");
    }
}
