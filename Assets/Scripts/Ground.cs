using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected float speedMoviment;

    void Start()
    {
        Invoke("DestroyMe", 15);
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x - speedMoviment * Time.deltaTime, transform.position.y);
    }

    protected void DestroyMe()
    {
        Destroy(gameObject, 0);
    }
}
