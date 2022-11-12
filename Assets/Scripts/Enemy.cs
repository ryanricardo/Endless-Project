using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] protected GameObject prefabBullet;
    [SerializeField] protected Transform bulletOut;

    [Header("Moviment Atributtes")]
    [SerializeField] protected float speedMoviment;

    [Header("Atributtes Weapon")]
    [SerializeField] protected float countDownToShoot;
    [SerializeField] protected float timerToShoot;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x - speedMoviment * Time.deltaTime, transform.position.y);

        float distancePlayer = Vector2.Distance(transform.position, PlayerController.instance.transform.position);
        if(distancePlayer <= 4)
        {
            if(timerToShoot >= countDownToShoot)
            {
                FunctionShoot();
                timerToShoot = 0;
            }
        }else 
        {
            timerToShoot += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject, 0);
        }
    }

    protected void FunctionShoot()
    {
        Instantiate(prefabBullet, bulletOut.transform.position, Quaternion.identity);
    }
}
