 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhysicsCollision {
    /*Sergio los cambios de estados entre caminar y iddle para que funcione bien
     * Mirar el Dash
     * Cuando golpeo a los enemigos desactivar quete sigan no el navMesh
     * Que el tornado solo va en una direcion(No lo e probado)
     * */

    public enum State {Default, Dash,Healing, Death }; // Default, Dash, Healing, Death
    public State state;

    [Header("Energia")]
    public float manaYin=100;
    public float manaYang =30;

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
    public int dashCount;
    public float dashCounterTime;
    public float coldownDash;
    [Header("Healing")]
    public float counterTimeHealing=0;
    [Header("Stats")]
    public int lifePlayer;
    public Animator anim;
    public GameObject healingFx;


    [Header("Arma")]
    public GameObject espadaAbanico;
    public Animator animSword;
    public Abanico abanico;
    public AttackSword attackSword;

    [Header("CambioArma")]
    public float counterCambioArma;
    public bool cambioArma = false;
    public float couldownCambioArma;
    public bool isSword;
    [Header("CambioArma")]

    public int attackType;
    public float animationAttack;
    [Header("ModeEva")]
    public float timeModeEva;




    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        rb = GetComponent<Rigidbody>();

        lifePlayer = 5;
        isSword = true;
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
            case State.Healing:
                HealingUpdate();
                break;

            case State.Death:
                DeathUpdate();
                break;
            default:
                break;
        }
    
       // WalkUpdate();
        ContadoresTimes();
       
    }

   
    void DefaultUpdate()
    {
       animationAttack+=Time.deltaTime;
      if(Input.GetKey(KeyCode.L))
        {
            ArreglarAnimacion();
        }

        if (animationAttack>1)
        {
                   //  attackType = 0;
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
            anim.SetTrigger("Jump");
        }

            if (Input.GetKey(KeyCode.Space) && isJumping == true)
            {
               if(jumpTimeCounter > 0)

                {
                    jumpForce = 30;

                   // rb.velocity = new Vector3(rb.velocity.x, 0, 0);
                    //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
                        jumpTimeCounter -= Time.deltaTime;

                }
                else 
                {
                    jumpForce = 0;
                    jumpTime = 0;

                    anim.SetTrigger("Fall");
                    isGrounded = false;
               
                }
             
            }
        

       // if ((isFacingRight && hAxis < 0) || (!isFacingRight && hAxis > 0)) Flip();


       
        if(isWalking)

        {
          
        }

        if (!isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);


        
    }
    public void SetHorizontalRight()
    {
        isFacingRight = true;
        speed.x = 5;

        transform.Translate(speed * Time.deltaTime);

    }
    public void SetHorizontalLeft()
    {
        isFacingRight = false;
        speed.x = -5;
        transform.Translate(speed*-1 * Time.deltaTime);
        

    }

    public  void HealingUpdate()
    {
       
        Debug.Log("PruebaUpdateHealing");
        counterDissable += Time.deltaTime;
        if (counterDissable > 4)
        {
            inputManager.SetActive(true);
            state = State.Default;

        }

        counterTimeHealing += Time.deltaTime;
        if(counterTimeHealing>5)
        {
            state =State.Default;
        }
       
    }
   

public void Dash()
    {
        
        if (dashCount > 0)
        {
            dashCount--;
            dashTime = startDashTime;
            rb.velocity = Vector2.zero;
            rb.useGravity = false;

            isWalking = false;
            SetDash();


        }
        else
            state = State.Default;

        // Animaciones, sonidos, activar el estado dash

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

     
    public void CambioArma()
    {
       
        isSword = !isSword;
        if (isSword)
            {
            //animacion
            animSword.SetBool("isSword", true);
               
                
            }
             if (!isSword)
            {
            animSword.SetBool("isSword", false);
            //animacion
          
              
            }

        
       
    }

    public void AttackBasic()
    {
        anim.SetBool("Running", false);
        
        if ((isSword)&&(attackType==1))
        {
            attackType=2;
            attackSword.espadaCollider();
            anim.SetInteger("Attack",1);
           

        }
        else if((isSword)&&(attackType==2))
        {
            attackType=3;
            attackSword.espadaCollider();
            anim.SetInteger("Attack",2);
            

        }
        else if((isSword)&&(attackType==3))
        {
            attackType=1;
            attackSword.espadaCollider();
            anim.SetInteger("Attack",3);
            

        }
        if (!isSword)            
        {
            abanico.AutoAttack();
        }
    }
    public void AttackHeavy()
    {
        if (isSword) 
        {
           
            //golpe Fuerte
        }
        if (!isSword)

        {
           

            abanico.AttackBig();
        }
    }

    #region Sets

    void SetWalk()
    {
        isWalking = true;

        anim.SetBool("Running",true);
        state = State.Default;

    }
    public void SetHealing()
    {
        anim.SetBool("Running", false);

        if (lifePlayer == 5)
        {
            gm.Hud.OpenFullHP();
        }

        if (lifePlayer <= 4) 
        {
            //DissabledController();
        
            lifePlayer++;
            GameObject obj = Instantiate(healingFx);
            obj.transform.rotation = Quaternion.Euler(0, 0, 0);
            obj.transform.position = transform.position + (new Vector3(0, -0.5f, 0));
           
            anim.SetTrigger("Heal");


            
            state = State.Healing;
        }
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
   
    
    public void ContadoresTimes()
    {
        dashCounterTime += Time.deltaTime;//el coldown del dash 
        counterCambioArma += Time.deltaTime;//Contador para cambiar de arma 
        
        manaYin += Time.deltaTime*5;
        if (dashCounterTime >= coldownDash)//Preguntar a Sergio SI poner aqui
        {
            dashCounterTime = 0;
            dashCount++;
        }
       



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
