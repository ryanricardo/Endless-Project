using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CODeathPlayer : MonoBehaviour
{
    public static CODeathPlayer instance;
    public bool collisionPlayer;

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            collisionPlayer = true;
    }

    
}
