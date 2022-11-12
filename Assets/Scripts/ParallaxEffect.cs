using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [Header("Parallax Atributtes")]
    [SerializeField] protected float parallaxEffect;
    [HideInInspector] protected float length;
    [HideInInspector] protected float startPos;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        ControllerParallax();
    }

    protected void ControllerParallax()
    {
        float rePos = CameraMain.instance.transform.position.x * (1 - parallaxEffect);
        float distance = CameraMain.instance.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(rePos > startPos + length)
        {
            startPos += length;
        }else if(rePos < startPos - length)
        {
            startPos += length;
        }
        
    }
}
