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
    [SerializeField] protected float forceJumpUp;
    [SerializeField] protected float forceJumpFront;
    [SerializeField] protected bool checkGround;

    [Header("Weapon Atributtes")]
    [SerializeField] protected float countDownToShoot;
    [SerializeField] protected bool freeToShoot;
    
    [Header("Touch Atributtes")]
    [HideInInspector] public bool touchOne;

    [Header("Status Atributtes")]
    [SerializeField] public float currentScore;

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
        
        currentScore += Time.deltaTime;
    }

    /*void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.FunctionGameOver();
        }
    }*/
    
    protected void MovimentController()
    {
        checkGround = Physics2D.Linecast(transform.position, transformCheckGround.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        transform.position = new Vector2(transform.position.x + speedMoviment * Time.deltaTime, transform.position.y);
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

        if(diference.y < 0)
        {
            FunctionDownImpulse();
        }

        if(diference.y == diference.x 
        && freeToShoot)
        {
            Weapon.instance.FunctionShoot();
            freeToShoot = false;
            Invoke("FunctionRestoreTime", countDownToShoot);
        }

    }

    public void FunctionIncreaseScore(float newScore)
    {
        currentScore += newScore;
    }

    protected void FunctionJump()
    {
        rb2.AddForce(new Vector2(forceJumpFront, forceJumpUp), ForceMode2D.Impulse);
    }

    protected void FunctionDownImpulse()
    {
        rb2.AddForce(new Vector2(0, -forceJumpUp), ForceMode2D.Impulse);
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


