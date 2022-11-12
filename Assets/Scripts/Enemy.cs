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
    [SerializeField] protected float distanceToShoot;
    [SerializeField] protected float countDownToShoot;
    [SerializeField] protected float timerToShoot;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x - speedMoviment * Time.deltaTime, transform.position.y);

        if(PlayerController.instance.transform.position.x < transform.position.x)
            transform.localScale = new Vector2(-1, transform.localScale.y);
        else if(PlayerController.instance.transform.position.x > transform.position.x)
            transform.localScale = new Vector2(1, transform.localScale.y);

        timerToShoot += Time.deltaTime;

        float distancePlayer = Vector2.Distance(transform.position, PlayerController.instance.transform.position);
        if(distancePlayer <= distanceToShoot)
        {
            if(timerToShoot >= countDownToShoot)
            {
                FunctionShoot();
                timerToShoot = 0;
            }
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
        prefabBullet.GetComponent<EnemyBullet>().enemy = gameObject.GetComponent<Enemy>();
        Instantiate(prefabBullet, bulletOut.transform.position, Quaternion.identity);
    }
}
