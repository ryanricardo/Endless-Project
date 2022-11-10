using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameCanvas : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Button buttonPause;
    [SerializeField] protected Button[] buttonContinue;
    [SerializeField] protected Button[] buttonMenu;
    [SerializeField] protected Button[] buttonQuit;
    [SerializeField] protected TextMeshProUGUI textProScore;
    [SerializeField] protected TextMeshProUGUI textProButtonPause;
    [SerializeField] protected GameObject panelPause;
    [SerializeField] protected GameObject panelGameOver;
    [HideInInspector] public static GameCanvas instance;

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        buttonPause.onClick.AddListener(delegate
        {
            if(!panelPause.activeSelf)
            {
                Time.timeScale = 0;
                panelPause.gameObject.SetActive(true);
                textProButtonPause.text = ">";
            }else 
            {
                panelPause.gameObject.SetActive(false);
                textProButtonPause.text = "I I";
                Time.timeScale = 1;

            }
        });

        buttonContinue[0].onClick.AddListener(delegate
        {
            panelPause.gameObject.SetActive(false);
            textProButtonPause.text = "I I";
            Time.timeScale = 1;
        });

        buttonContinue[1].onClick.AddListener(delegate
        {
            SceneManager.LoadScene(1);
        });

        

        for(int i = 0; i < buttonMenu.Length; i++)
        {
            buttonMenu[i].onClick.AddListener(delegate
            {
                SceneManager.LoadScene("Menu");
            });
        }

        for(int i = 0; i < buttonQuit.Length; i++)
        {
            buttonQuit[i].onClick.AddListener(delegate
            {
                Application.Quit();
            });
        }
    }

    void Update()
    {
        CanvasController();
    }

    protected void CanvasController()
    {
        textProScore.text = Mathf.FloorToInt(PlayerController.instance.currentScore).ToString() + "(" + PlayerPrefs.GetFloat("recordScore") + ")";
    }

    public void FunctionGameOver()
    {
        Time.timeScale = 0;
        panelGameOver.gameObject.SetActive(true);
    }
}
