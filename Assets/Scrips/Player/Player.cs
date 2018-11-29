 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhysicsCollision {
    [Header("Properties")]
    public float jumpForce = 5.0f;
    public float speed = 5;
    public bool isRunning=false;
    private float hAxis;
    private float hVelocity;
    [Header("Permissions")]
    public bool jump;
    public int jumpChances = 2;
    [Header("Dash")]
    public Rigidbody dashRigibody;
    public float rango;
    public Vector3 forceXYZ;
    public int dashCount;
    public float dashCounterTime;
    public float coldownDash;

    [Header("Stats")]
    public int lifePlayer;
    public Renderer rend;
    public Material damageMaterial;

    public Animator anim;

    void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        lifePlayer = 5;
    }



    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (jump)
        {
            jumpChances--;
            jump = false;
            //para que siempre salte lo mismo;
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        rb.velocity = new Vector3(hVelocity, rb.velocity.y, 0);

    }

    private void Update()
    {
        if ((isFacingRight && hAxis < 0) || (!isFacingRight && hAxis > 0)) Flip();


        hVelocity = hAxis * speed;
        if (isTouchingWall)
        {
            //al tocar una pared se detiene;
            if ((isFacingRight && hAxis > 0) || (!isFacingRight && hAxis < 0)) hVelocity = 0;

        }

        //correr
        if (!isRunning) speed = 5;
        if (isRunning) speed = 10;

        

            //contador del dash y cooldown
        dashCounterTime += Time.deltaTime;
        if (dashCounterTime >= coldownDash)
        {
            dashCounterTime = 0;
            dashCount++;
        }
    }

    public void StartJump()
    {
        anim.SetTrigger("Jump");
        if (isGrounded) jumpChances=2;
        if (jumpChances > 0)
        {
            jump = true;
        }
    }
 

    public void SetHorizontalAxis(float h)
    {
        hAxis = h;
       // anim.SetTrigger("Running");

    }

    public void DashSpeed()
    {
        if (!isFacingRight) 
        {
            forceXYZ = new Vector3(-150, 0, 0);
        }
        if (isFacingRight)
        {
            forceXYZ = new Vector3(150, 0, 0);
        }

        if (dashCount > 0)
        {
            dashCount--;
            dashRigibody.AddForce(forceXYZ, ForceMode.Impulse);//fuerza para el dash le da un impulso
        }
    }
    public void Damage()
    {
        lifePlayer--;
        rend.material = damageMaterial;

    }
    public void StateDeath()
    {
        lifePlayer = 0;
    }

    public void Healing()
    {
       

        if(lifePlayer<=4)

        {
             lifePlayer++;
        }

    }
}
