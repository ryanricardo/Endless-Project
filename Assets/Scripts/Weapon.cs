using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected AudioClip clipShoot;
    [SerializeField] protected Transform exitBullet;
    [SerializeField] protected GameObject prefabBullet;
    [HideInInspector] public static Weapon instance;
    [HideInInspector] protected AudioSource audioSource;

    [Header("Weapon Atributtes")]
    [SerializeField] protected float countDownToShoot;
    [HideInInspector] protected float timerToShoot;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position = new Vector2(PlayerController.instance.transform.position.x + 0.5f, PlayerController.instance.transform.position.y);
    }

    public void FunctionShoot()
    {
        Instantiate(prefabBullet, exitBullet.transform.position, Quaternion.identity);
        audioSource.PlayOneShot(clipShoot);
        //PlayerController.instance.FunctionImpulseToBack();
    }
}
