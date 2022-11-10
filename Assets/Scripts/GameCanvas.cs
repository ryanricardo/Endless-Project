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
    [SerializeField] protected Button buttonContinue;
    [SerializeField] protected Button buttonMenu;
    [SerializeField] protected Button buttonQuit;
    [SerializeField] protected TextMeshProUGUI textProButtonPause;
    [SerializeField] protected GameObject panelPause;

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

        buttonContinue.onClick.AddListener(delegate
        {
            panelPause.gameObject.SetActive(false);
            textProButtonPause.text = "I I";
            Time.timeScale = 1;
        });

        buttonMenu.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Menu");
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
