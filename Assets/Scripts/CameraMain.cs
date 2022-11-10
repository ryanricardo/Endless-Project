using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    [Header("Components")]
    [HideInInspector] public static CameraMain instance;

    [Header("Atributtes Moviment")]
    [SerializeField] protected float maxPosX;
    [SerializeField] protected float speedCamera;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        transform.position = new Vector3(PlayerController.instance.transform.position.x, 0, -10);
    }

    void Update()
    {
        ControllerMovimentCamera();
    }
    
    protected void ControllerMovimentCamera()
    {
        Vector3 currentPos = new Vector3(transform.position.x, 0, -10);
        Vector3 newPos = new Vector3(PlayerController.instance.transform.position.x, 0, -10);

        transform.position = Vector3.MoveTowards(currentPos, newPos, speedCamera * Time.deltaTime);


    }
}
