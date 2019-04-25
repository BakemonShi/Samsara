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

    public GameObject damageFX;
    public Vector3 transformFX;
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
    public float contadorDash;
    public bool canDash;
  

    [Header("Stats")]
    public int lifePlayer;
    public Animator anim;
 


    [Header("Arma")]
      
    public AttackSword attackSword;


    [Header("Ataque")]

    public int attackType;
    public float animationAttack;



    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        rb = GetComponent<Rigidbody>();

      

        speed.x = 10;
       
       
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

        contadorDash += Time.deltaTime;
        if (contadorDash > 1)
        {
            canDash = true;
            contadorDash = 0;

        }

        if (isFly)
        {
            anim.SetBool("isFly", true);
        }
        else  if (!isFly)
        {
            anim.SetBool("isFly", false);
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            Instantiate(damageFX, transform.position,Quaternion.identity);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
         //   anim.SetTrigger("Fall");
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
           
        }

            if (Input.GetKey(KeyCode.Space) && isJumping == true)
            {
         //   anim.SetTrigger("isFall");

            if (jumpTimeCounter > 0)

                {
                jumpForce = 14;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
                jumpTimeCounter -= Time.deltaTime;

                }
                else 
                {
                    jumpForce = 0;
                    jumpTime = 0;

              //      anim.SetTrigger("isFall");
                    isGrounded = false;
               
                }
             
            }
        
        if((isWalking)&&(isGrounded)) anim.SetBool("isRunning", true);

        else if ((!isWalking) && (isGrounded)) anim.SetBool("isRunning", false);



    }
    public void SetHorizontalRight()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        isFacingRight = true;
        speed.x = -7;
        anim.SetBool("isRunning", true);


        transform.Translate(speed * Time.deltaTime);

    }
    public void SetHorizontalLeft()
    {
        anim.SetBool("isRunning", true);
        transform.rotation = Quaternion.Euler(0, 0, 0);


        isFacingRight = false;
        speed.x = 7;
        transform.Translate(speed*-1 * Time.deltaTime);
        

    }

       

public void Dash()
    {
        if (canDash)
        {
            canDash = false;

            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
            rb.useGravity = false;

            isWalking = false;
            SetDash();
        }
        else
            return;
        
        
    }
    
    public void DashUpdate()
    {

        isFly = false;
        
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
        Instantiate(damageFX, (new Vector3 (transform.position.x,transform.position.y+0.8f,transform.position.z)), Quaternion.identity);

    }
    public void DeathUpdate()
    {
        lifePlayer = 0;
    }

     
    

      

    #region Sets

    void SetWalk()
    {
       // isWalking = true;

       
        state = State.Default;

    }
   
    public void SetDash()
    {
        anim.SetTrigger("Dash");
        state = State.Dash;
    }


  

    #endregion
   
   
    
   
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
