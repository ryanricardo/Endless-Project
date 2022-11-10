using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] protected  Transform     transformCheckGround;
    [HideInInspector] protected Rigidbody2D rb2;
    [HideInInspector] private Vector3       startPos;
    [HideInInspector] private Vector3       endPos;
    [HideInInspector] public static PlayerController instance;
    

    [Header("Moviment Atributtes")]
    [SerializeField] protected float speedMoviment;
    [SerializeField] protected float forceJump;
    [SerializeField] protected bool checkGround;

    [Header("Weapon Atributtes")]
    [SerializeField] protected float countDownToShoot;
    [SerializeField] protected bool freeToShoot;
    

    [Header("Touch Atributtes")]
    [HideInInspector] public bool touchOne;

    void Awake()
    {
        instance = this;
    }
    
    void Start()    
    {
        rb2 = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        MovimentController();
    }

    protected void MovimentController()
    {
        rb2.velocity = new Vector2(rb2.velocity.x + speedMoviment * Time.deltaTime, rb2.velocity.y);
        checkGround = Physics2D.Linecast(transform.position, transformCheckGround.transform.position, 1 << LayerMask.NameToLayer("Ground"));

        if(Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if(t.phase == TouchPhase.Began)
            {
                startPos = t.position;
            }

            if(t.phase == TouchPhase.Ended)
            {
                endPos = t.position;
                Calcular();
            }
        }
    }

    private void Calcular()
    {
        Vector3 diference = endPos - startPos;

        if(diference.y > diference.x && checkGround)
        {
            FunctionJump();
        }

        if(diference.y == diference.x 
        && freeToShoot)
        {
            Weapon.instance.FunctionShoot();
            freeToShoot = false;
            Invoke("FunctionRestoreTime", countDownToShoot);
        }

    }

    protected void FunctionJump()
    {
        rb2.AddForce(new Vector2(0, forceJump), ForceMode2D.Impulse);
    }

    public void FunctionImpulseToBack()
    {
        rb2.AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
    }

    protected void FunctionRestoreTime()
    {
        freeToShoot = true;
    }
}


