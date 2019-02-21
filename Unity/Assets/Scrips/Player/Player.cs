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
    public float speed;
    public bool isWalking = false;
    private float hAxis;
    private float hVelocity;
    public float counterDissable;

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
        speed = 10;
       
        abanico.Initialize();

    }



    public override void MyFixedUpdate()
    {
        base.MyFixedUpdate();
        
        if (isWalking)
        {
        
            rb.velocity = new Vector3(hVelocity, rb.velocity.y, 0);
        }

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
        if(animationAttack>1)
        {
          


          //  attackType = 0;
            anim.SetBool("Running",true);
        
        }
            if (isGrounded==true && Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = new Vector3(rb.velocity.x, 0, 0);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                anim.SetTrigger("Jump");
        }

            if (Input.GetKey(KeyCode.Space) && isJumping == true)
            {
               if(jumpTimeCounter>0)

                {
                    rb.velocity = new Vector3(rb.velocity.x, 0, 0);
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jumpTimeCounter -= Time.deltaTime;

                }
                else
                {
                anim.SetTrigger("Fall");

                isJumping = false;
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                anim.SetTrigger("Fall");

                isJumping = false;
                }

            }
        

        if ((isFacingRight && hAxis < 0) || (!isFacingRight && hAxis > 0)) Flip();


        hVelocity = hAxis * speed;
        if (isTouchingWall)
        {
            //al tocar una pared se detiene;
            if ((isFacingRight && hAxis > 0) || (!isFacingRight && hAxis < 0)) hVelocity = 0;

        }
             
        if (!isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);


        
    }
    public void SetHorizontalAxis(float h)
    {
        hAxis = h;
        // anim.SetTrigger("Running");

    }
  
   public  void HealingUpdate()
    {
        Debug.Log("PruebaUpdateHealing");
        counterDissable += Time.deltaTime;
        if (counterDissable >= 4)
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
                gm.Hud.OpenSwordPanel();
                
            }
             if (!isSword)
            {
            animSword.SetBool("isSword", false);
            //animacion
            gm.Hud.CloseSwordPanel();
              
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
        if ((!isSword)&& (manaYin >= 20))
            
        {
            manaYin= manaYin - 20;

            abanico.AutoAttack();
        }
    }
    public void AttackHeavy()
    {
        if ((isSword) && (manaYin >= 50))
        {
            manaYin = manaYin - 50;
            //golpe Fuerte
        }
        if ((!isSword) && (manaYin >= 70))

        {
            manaYin = manaYin - 70;

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

        if ((lifePlayer <= 4) && (manaYang >= 10))

        {
            DissabledController();
            manaYang -= 10;
            lifePlayer++;
            GameObject obj = Instantiate(healingFx);
            obj.transform.rotation = Quaternion.Euler(0, 0, 0);
            obj.transform.position = transform.position + (new Vector3(0, 0.5f, 0));
            state = State.Healing;
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
    public void ModeEva()//tengo que meterla en un estado
    {
        timeModeEva += Time.deltaTime;//Tiempo que drua el modo eva
        if (timeModeEva >= 10)
        {
            dashCount = 2;
            speed = 10;
        }
        timeModeEva = 0;
       
        dashCount = 3;
        speed = 20;
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
}
