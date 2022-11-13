using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Transform posSpawnGrounds;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected GameObject prefabGround;
    [SerializeField] protected GameObject prefabEnemy;
    [HideInInspector] public static GameManager instance;

    [Header("Grounds Atributtes")]
    [SerializeField] protected float distancePlayer;
    [SerializeField] protected float timeToSpawnGround;
    [HideInInspector] protected bool spawnGround;
    [HideInInspector] protected bool firstGroud;
    

    

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        Time.timeScale = 1;
        if(PlayerPrefs.GetInt("firstPlayed") == 0)
        {
            StartCoroutine(GameCanvas.instance.FunctionShowTutorial("Inicialmente para você pular os obstaculos, deslize o dedo para cima.", true, 0, 0.5f));
            StartCoroutine(GameCanvas.instance.FunctionShowTutorial("Para atirar nos inimigos clica apenas uma vez sobre a tela.", true, 0, 3f));
            StartCoroutine(GameCanvas.instance.FunctionShowTutorial("Quando mais longe você for mais score você acumula. ", true, 0, 5f));
            PlayerPrefs.SetInt("firstPlayed", 1);

        }
        spawnGround = true;
        firstGroud = true;
    }

    void Update()
    {
        SpawnGroundController();
        GameOverPlayerController();

        transform.position = new Vector2(PlayerController.instance.transform.position.x + distancePlayer, transform.position.y);
    }

    protected void SpawnGroundController()
    {
        if(spawnGround)
        {
            if(firstGroud)
            {
                Instantiate(prefabGround, posSpawnGrounds.transform.position, Quaternion.identity);
                StartCoroutine(FuctionSpawnGround(3));
                firstGroud = false;
            }else 
            {
                Instantiate(prefabGround, posSpawnGrounds.transform.position, Quaternion.identity);
                StartCoroutine(FuctionSpawnGround(timeToSpawnGround));
            }

            spawnGround = false;

        }
    }

    protected void GameOverPlayerController()
    {
        if(CODeathPlayer.instance.collisionPlayer)
        {
            FunctionGameOver();
        }
    }

    public void FunctionGameOver()
    {
        if(PlayerController.instance.currentScore > PlayerPrefs.GetFloat("recordScore"))
            PlayerPrefs.SetFloat("recordScore", PlayerController.instance.currentScore);

        GameCanvas.instance.FunctionGameOver();
    }

    public void FunctionControlMySource(int command)
    {
        switch(command)
        {
            case 0:
                audioSource.Pause();
            break;

            case 1:
                audioSource.UnPause();
            break;
        }
    }

    protected IEnumerator FuctionSpawnGround(float time)
    {
        yield return new WaitForSeconds(time);
        spawnGround = true;
    }

}
