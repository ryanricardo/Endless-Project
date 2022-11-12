using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Transform posSpawnGrounds;
    [SerializeField] protected GameObject prefabGround;
    [SerializeField] protected GameObject prefabEnemy;
    [HideInInspector] public static GameManager instance;

    [Header("Grounds Atributtes")]
    [SerializeField] protected float distancePlayer;
    [SerializeField] protected float timeToSpawnGround;
    [HideInInspector] protected bool spawnGround;
    

    

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        PlayerPrefs.SetInt("firstPlayed", 1);
        spawnGround = true;
        Time.timeScale = 1;
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
            Instantiate(prefabGround, posSpawnGrounds.transform.position, Quaternion.identity);
            StartCoroutine(FuctionSpawnGround(timeToSpawnGround));
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

    protected IEnumerator FuctionSpawnGround(float time)
    {
        yield return new WaitForSeconds(time);
        spawnGround = true;
    }

}
