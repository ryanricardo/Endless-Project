using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Components")]
    [HideInInspector] protected Rigidbody2D rb2;

    [Header("Moviment Atributtes")]
    [SerializeField] protected float speedMoviment;


    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        MovimentController();
    }

    protected void MovimentController()
    {
        rb2.velocity = new Vector2(rb2.velocity.x + speedMoviment * Time.deltaTime, rb2.velocity.y);
    }
}
