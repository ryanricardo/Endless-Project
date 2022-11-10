using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector] protected Rigidbody2D rb2;

    [Header("Bullet Atributtes")]
    [SerializeField] protected float speedBullet;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        BulletController();
    }

    protected void BulletController()
    {
        rb2.AddForce(new Vector2(rb2.velocity.x + speedBullet * Time.deltaTime, 0), ForceMode2D.Impulse);
    }
}
