using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector] protected Rigidbody2D rb2;
    [HideInInspector] public Enemy enemy;

    [Header("Bullet Atributtes")]
    [SerializeField] protected float speedBullet;
    [HideInInspector] protected bool isRight;

    void Start()
    {
        Destroy(gameObject, 10);

        if(PlayerController.instance.transform.position.x < enemy.transform.position.x)
            isRight = false;
        else if(PlayerController.instance.transform.position.x > enemy.transform.position.x)
            isRight = true;

    }

    void Update()
    {
        if(isRight)
            transform.position = new Vector2(transform.position.x + speedBullet * Time.deltaTime, transform.position.y);
        else    
            transform.position = new Vector2(transform.position.x - speedBullet * Time.deltaTime, transform.position.y);


            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.FunctionGameOver();
        }
    }
}
