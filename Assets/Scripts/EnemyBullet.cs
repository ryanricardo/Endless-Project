using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector] protected Rigidbody2D rb2;

    [Header("Bullet Atributtes")]
    [SerializeField] protected float speedBullet;

    void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
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
