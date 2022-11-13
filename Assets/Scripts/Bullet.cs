using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector] protected Rigidbody2D rb2;

    [Header("Bullet Atributtes")]
    [SerializeField] protected float speedBullet;
    [SerializeField] protected float timeAlive;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeAlive);
    }

    void Update()
    {
        BulletController();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            PlayerController.instance.FunctionIncreaseScore(2);
            Destroy(gameObject, 0.1f);
        }
    }

    protected void BulletController()
    {
        rb2.AddForce(new Vector2(speedBullet, 0), ForceMode2D.Impulse);
    }
}
