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
    [SerializeField] protected Button buttonQuitTutorial;
    [SerializeField] protected TextMeshProUGUI textProScore;
    [SerializeField] protected TextMeshProUGUI textProButtonPause;
    [SerializeField] protected TextMeshProUGUI textProTutorial;
    [SerializeField] protected TextMeshProUGUI textProNewScore;
    [SerializeField] protected GameObject panelTutorial;
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
                GameManager.instance.FunctionControlMySource(0);
                Time.timeScale = 0;
                panelPause.gameObject.SetActive(true);
                textProButtonPause.text = ">";
            }else 
            {
                GameManager.instance.FunctionControlMySource(1);
                panelPause.gameObject.SetActive(false);
                textProButtonPause.text = "I I";
                Time.timeScale = 1;

            }
        });

        buttonContinue[0].onClick.AddListener(delegate
        {
            GameManager.instance.FunctionControlMySource(1);
            panelPause.gameObject.SetActive(false);
            textProButtonPause.text = "I I";
            Time.timeScale = 1;
        });

        buttonContinue[1].onClick.AddListener(delegate
        {
            SceneManager.LoadScene(1);
        });

        buttonQuitTutorial.onClick.AddListener(delegate
        {
            GameManager.instance.FunctionControlMySource(1);
            Time.timeScale = 1;
            panelTutorial.SetActive(false);
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
        textProScore.text = Mathf.FloorToInt(PlayerController.instance.currentScore).ToString() + "(" + Mathf.FloorToInt(PlayerPrefs.GetFloat("recordScore")) + ")";
    }

    public void FunctionGameOver()
    {
        GameManager.instance.FunctionControlMySource(0);
        buttonPause.interactable = false;
        Time.timeScale = 0;
        textProNewScore.text = "You make " + $"<color=green>{Mathf.FloorToInt(PlayerController.instance.currentScore)}</color>" +  
        $"<color=green>{" score"}</color>" +  " and you score record is " + $"<color=green>{Mathf.FloorToInt(PlayerPrefs.GetFloat("recordScore"))}</color>";
        panelGameOver.gameObject.SetActive(true);
    }

    public IEnumerator FunctionShowTutorial(string text, bool active, int time, float timeToStart, bool toFinish)
    {
        GameManager.instance.FunctionControlMySource(0);
        yield return new WaitForSeconds(timeToStart);
        Time.timeScale = time;
        panelTutorial.SetActive(active);
        textProTutorial.text = text;
        
        if(toFinish)
            PlayerPrefs.SetInt("completedTutorial", 1);

    }

}
