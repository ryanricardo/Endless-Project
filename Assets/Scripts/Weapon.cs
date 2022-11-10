using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Transform exitBullet;
    [SerializeField] protected GameObject prefabBullet;
    [HideInInspector] public static Weapon instance;

    [Header("Weapon Atributtes")]
    [SerializeField] protected float countDownToShoot;
    [HideInInspector] protected float timerToShoot;
    
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

    public void FunctionShoot()
    {
        Instantiate(prefabBullet, exitBullet.transform.position, Quaternion.identity);
        PlayerController.instance.FunctionImpulseToBack();
    }
}
