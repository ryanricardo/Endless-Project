using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Transform posSpawnGrounds;
    [SerializeField] protected GameObject prefabGround;
    [HideInInspector] public static GameManager instance;

    [Header("Grounds Atributtes")]
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
    }

    protected void SpawnGroundController()
    {
        if(spawnGround)
        {
            Instantiate(prefabGround, posSpawnGrounds.transform.position, Quaternion.identity);
            float randomNumber = Random.Range(6f, 7.8f);
            Debug.Log(randomNumber);
            StartCoroutine(FuctionSpawnGround(randomNumber));
            spawnGround = false;
        }
    }

    protected void GameOverPlayerController()
    {
        if(CODeathPlayer.instance.collisionPlayer)
        {
            if(PlayerController.instance.currentScore > PlayerPrefs.GetFloat("recordScore"))
                PlayerPrefs.SetFloat("recordScore", PlayerController.instance.currentScore);

            GameCanvas.instance.FunctionGameOver();
        }
    }

    protected IEnumerator FuctionSpawnGround(float time)
    {
        yield return new WaitForSeconds(time);
        spawnGround = true;
    }

}
