using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Transform exitBullet;
    [SerializeField] protected GameObject prefabBullet;

    [Header("Weapon Atributtes")]
    [SerializeField] protected float countDownToShoot;
    [HideInInspector] protected float timerToShoot;

    void Start()
    {
        
    }

    void Update()
    {
        WeaponController();
    }

    protected void WeaponController()
    {
        if(PlayerController.instance.touchOne && timerToShoot >= countDownToShoot)
        {
            FunctionShoot();
            timerToShoot = 0;
        }else 
        {
            timerToShoot += Time.deltaTime;
        }
    }

    protected void FunctionShoot()
    {
        Instantiate(prefabBullet, exitBullet.transform.position, Quaternion.identity);
    }
}
