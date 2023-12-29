using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TryAgainBtn : MonoBehaviour
{
    [SerializeField] private GameObject Btn;
    // Start is called before the first frame update
    void Start()
    {
        Btn.GetComponent<Button>().onClick.AddListener(TryAgain);
    }

    void TryAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
