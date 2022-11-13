using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected float speedMoviment;
    [SerializeField] protected GameObject prefabEnemy;
    [SerializeField] public Transform[] posEnemys;


    void Start()
    {
        if(prefabEnemy != null)
            Instantiate(prefabEnemy, posEnemys[Random.Range(0, posEnemys.Length)].transform.position, Quaternion.identity);
            
        Invoke("DestroyMe", 15);
    }

    void Update()
    {
        //transform.position = new Vector2(transform.position.x - speedMoviment * Time.deltaTime, transform.position.y);
    }

    protected void DestroyMe()
    {
        Destroy(gameObject, 0);
    }
}
