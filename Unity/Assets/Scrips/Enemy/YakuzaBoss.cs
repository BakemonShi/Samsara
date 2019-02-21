using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class YakuzaBoss : MonoBehaviour
{

    private Player player;
    public enum State {Walk, Attack, Dead }; 
    public State state;
  
    [Header("StatsYakuza")]
    private float hit;
    public float life;
    public Animator anim;
    public Collider colliderBoss;
    public float counteCollider=2;

    [Header("Attack state")]
    public int typeAttack;
    public float coldownAttack;
    public bool isAttack;
    [Header("Attack Jump")]
    private Rigidbody rb;
    public Transform playerTransform;
    public float jumpPower;
    public int numJumps;
    public float durationJump;
    public GameObject golpeSuelo;
   

    void Start()
    {
        isAttack = false;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      

    }


    public void Update()
    {
       
        switch (state)
        {
            case State.Walk:
                WalkUpdate();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Dead:
                DeadUpdate();
                break;
            default:
                break;
        }
        if (life <= 0) SetDead();
        if (isAttack)
        {
            counteCollider -= Time.deltaTime;
            colliderBoss.enabled = true;

        }
        if (counteCollider<0)
        {
            isAttack = false;
            counteCollider = 3;
            colliderBoss.enabled = false;

        }

    }
    public void WalkUpdate()
    {
        coldownAttack += Time.deltaTime;
        
       if (coldownAttack>=3)
        {
            SetAttack();

        }
      
    }
    public void DeadUpdate()
    {
        //animacion de muerte
        Debug.Log("Muere");

    }

    void Attack()
    {
       
        
        if (typeAttack == 1) AttackJump();
        if (typeAttack == 2) AttackB();
        if (typeAttack == 3) AttackC();

        SetWalk();
        Debug.Log("Deja de descansar");

    }
    public void AttackJump()
    {
        colliderBoss.enabled = true;
        anim.SetTrigger("Salto");
        rb.DOJump(playerTransform.transform.position, jumpPower, numJumps, durationJump, false);//pasar a VEctoe 3 es un tranform
        

    }
    public  void AttackB() 
    {
        GameObject obj = Instantiate(golpeSuelo);


        obj.transform.rotation = Quaternion.Euler(0, 0, 0);
        obj.transform.position = transform.position;
       


        // if (player.isFacingRight) tornado.speed.x = 8;
        //else tornado.speed.x = -8;
    }
    void AttackC() 
    {
        colliderBoss.enabled = true;
        anim.SetTrigger("Combo");


    }

    #region Sets
    void SetWalk()
    {
      
        anim.SetTrigger("Cansado");

        coldownAttack = 0;
        Debug.Log("Esta descandando");
      state = State.Walk;
    }
    public void SetAttack()
    {
        counteCollider = 2;

        isAttack = true;
        typeAttack = Random.Range(1, 4);

        // sonidios, animaciones, etceteetc
        state = State.Attack;
        //StartCoroutine(CooldownAttack());
    }
    public void SetDead()
    {
        Destroy(this.gameObject);
        state = State.Dead;
    }
    #endregion

    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Damage();
            player.lifePlayer--;
        
            Debug.Log("pruebaDamage");
        }
    }
}