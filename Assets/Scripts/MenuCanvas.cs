using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] protected Button buttonContinue;
    [SerializeField] protected Button buttonNewGame;
    [SerializeField] protected Button buttonQuit;

    void Start()
    {
        if(PlayerPrefs.GetInt("firstPlayed") == 0)
        {
            buttonContinue.interactable = false;
        }else 
        {
            buttonContinue.interactable = true;
        }

        buttonContinue.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("SampleScene");
        });

        buttonNewGame.onClick.AddListener(delegate
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("SampleScene");
        });

        buttonQuit.onClick.AddListener(delegate
        {
            Application.Quit();
        });
        
    }

    void Update()
    {
        
    }
}
