 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhysicsCollision {
    /*Sergio los cambios de estados entre caminar y iddle para que funcione bien
     * Mirar el Dash
     * Cuando golpeo a los enemigos desactivar quete sigan no el navMesh
     * Que el tornado solo va en una direcion(No lo e probado)
     * */

    public enum State {Default, Dash, Death }; // Default, Dash, Healing, Death
    public State state;

  
    [Header("Properties")]
    public GameObject inputManager;
    public Vector3 speed;
    public bool isWalking = false;
    public float counterDissable=0;

    [Header("Jump")]
    public bool jump;
    public bool isJumping;
    public float jumpForce;
    public float jumpTimeCounter;
    public float jumpTime;
    
   
    [Header("Dash")]
    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
  

    [Header("Stats")]
    public int lifePlayer;
    public Animator anim;
 


    [Header("Arma")]
    public GameObject espadaAbanico;
    public Animator animSword;
    public Abanico abanico;
    public AttackSword attackSword;


    [Header("Ataque")]

    public int attackType;
    public float animationAttack;




    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        rb = GetComponent<Rigidbody>();

        lifePlayer = 5;

        speed.x = 10;
       
        abanico.Initialize();

    }


    public override void MyFixedUpdate()
    {
        base.MyFixedUpdate();
        
    }

    public void MyUpdate()
    {
        
        switch (state)
        {
            case State.Default:
                DefaultUpdate();
                break;
          
            case State.Dash:
                DashUpdate();
                break;
           
            case State.Death:
                DeathUpdate();
                break;
            default:
                break;
        }
    
    }

   
    void DefaultUpdate()
    {
       animationAttack+=Time.deltaTime;


        if (animationAttack>1)
        {
                  
            anim.SetBool("Running",true);
        
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetTrigger("Fall");
            isJumping = false;
            jumpForce = 0;
            jumpTime = 0;
        }
      
    
        if (isGrounded==true && Input.GetKeyDown(KeyCode.Space))
            {
            jumpForce = 6;
            jumpTime = 0.25f;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("isJump");
        }

            if (Input.GetKey(KeyCode.Space) && isJumping == true)
            {
            anim.SetTrigger("isFall");

            if (jumpTimeCounter > 0)

                {
                jumpForce = 30;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
                jumpTimeCounter -= Time.deltaTime;

                }
                else 
                {
                    jumpForce = 0;
                    jumpTime = 0;

                    anim.SetTrigger("isFall");
                    isGrounded = false;
               
                }
             
            }
        

       
        if(!isWalking)

        {
            anim.SetBool("isRunning",false);
        }

              
    }
    public void SetHorizontalRight()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        isFacingRight = true;
        speed.x = 5;
        anim.SetBool("isRunning", true);


        transform.Translate(speed * Time.deltaTime);

    }
    public void SetHorizontalLeft()
    {
        anim.SetBool("isRunning", true);
        transform.rotation = Quaternion.Euler(0, 180, 0);


        isFacingRight = false;
        speed.x = -5;
        transform.Translate(speed*-1 * Time.deltaTime);
        

    }

       

public void Dash()
    {
       
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
            rb.useGravity = false;

            isWalking = false;
            SetDash();
        
    }
    
    public void DashUpdate()
    {

        
            if (dashTime < 1)
            {
           
                   if (isFacingRight)
            {
                rb.velocity = Vector2.right * dashSpeed;
            }
                   else 
                rb.velocity = Vector2.left * dashSpeed;

            dashTime += Time.deltaTime;
            }
        
        else
        {
            dashTime = 0;
            rb.useGravity = true;
            SetWalk();
        }


        
        
    }
    public void Damage()
    {
        lifePlayer--;
        anim.SetTrigger("Damage");

    }
    public void DeathUpdate()
    {
        lifePlayer = 0;
    }

     
    

    public void AttackBasic()
    {
        anim.SetBool("Running", false);
        
        if (attackType==1)
        {
            attackType=2;
            attackSword.espadaCollider();
            anim.SetInteger("Attack",1);
           

        }
        else if(attackType==2)
        {
            attackType=3;
            attackSword.espadaCollider();
            anim.SetInteger("Attack",2);
            

        }
        else if(attackType==3)
        {
            attackType=1;
            attackSword.espadaCollider();
            anim.SetInteger("Attack",3);
            

        }
       
    }
   

    #region Sets

    void SetWalk()
    {
        isWalking = true;

        anim.SetBool("Running",true);
        state = State.Default;

    }
   
    public void SetDash()
    {
        anim.SetBool("Running", false);

        anim.SetTrigger("Dash");
        state = State.Dash;
    }


  

    #endregion
    public void DissabledController()
    {
        counterDissable = 0;
        inputManager.SetActive(false);

       

    }
   
    
   
    public void GodModeHack()
    {
        lifePlayer = 999;
        
    }
    public void ArreglarAnimacion ()
    {

        anim.SetBool("Running", true);
        anim.SetInteger("Attack", 0);
        anim.SetTrigger("Fall");


    }
}
