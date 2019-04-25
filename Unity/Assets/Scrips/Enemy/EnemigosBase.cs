using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoBase : MonoBehaviour {

    public enum State { Idle, Patrol, Chase, Attack, Death };
    public State state;
    protected Player player;
    protected NavMeshAgent agent;
   
    private float timeCounter;
    public float idleTime;
    public float counterAttackYakuza;
    public Animator anim;


    [Header("Enemies Properties")]
    
    public bool isFacingRight;
    protected bool isAttack;    
    [Header("Path Properties")]
    public Transform[] nodes;
    public bool stopAtEachNode;
    public int currentNode;
    public float reachDistance=10f;

    [Header("Target Properties")]
    public LayerMask targetMask;
    public float radius;
    public bool targetDetected;
    public Transform targetTransform;
  

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        agent = GetComponent<NavMeshAgent>();
     
        agent.stoppingDistance=2;
        //AGENT:Destino Punto mas cercano
        GoNearNode();

      SetPatrol();
    }
    protected virtual  void FixedUpdate()
    {
        //IMPORTANTE
        targetDetected = false;
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, radius, targetMask);
        if(hitcolliders.Length !=0)
        {
            targetDetected = true;
           // targetTransform = hitcolliders[0].transform;
        }
    }
    protected virtual void Update()
    {
        agent.stoppingDistance = 2;
        switch (state)
        {
            case State.Idle:
                IdleUpdate();
                break;
            case State.Patrol:
                PatrolUpdate();
                break;
            case State.Chase:
                ChaseUpdate();
                break;
            default:
                break;
        }
    }
    void IdleUpdate()
    {
        //IDLE --> PATROL condition
        if(timeCounter >= idleTime)
        {
            SetPatrol();
        }
        else timeCounter += Time.deltaTime;

        //IDLE --> CHASE conditon: tener target
        if(targetDetected) SetChase();
    }
    void PatrolUpdate()
    {
        if(Vector3.Distance(transform.position,nodes[currentNode].position)<reachDistance)
        {
            //ir al siguiente nodo
            GoNextNode();
            
         
        }
        //PATROL --> CHASE conditon: tener target
        if(targetDetected) SetChase();

    }
    void ChaseUpdate()
    {
        if(!targetDetected)
        {
            GoNearNode();
            SetIdle();
            return;
        }
        counterAttackYakuza += Time.deltaTime;
        agent.SetDestination(targetTransform.position);
        
    }
    

    #region Sets
    void SetIdle()
    {
        timeCounter = 0;
     
        agent.isStopped = true;
        radius = 5;
        int r = Random.Range(1, 5);

        anim.SetBool("isWalk", false);
        
        state = State.Idle;
    }
    void SetPatrol()
    {
        anim.SetBool("isWalk", true);

        agent.isStopped = false;
        agent.stoppingDistance = 0;
        
        state = State.Patrol;
    }
    void SetChase()
    {
        anim.SetBool("isWalk", true);

        agent.isStopped = false;
      
      
        radius = 10;
        state = State.Chase;
    }
     void SetAttack()
    {
        

        agent.isStopped = true;
        //sound.Play(9, 1);
        isAttack = true;

        state = State.Attack;
    }
    void SetDeath()
    {
        Destroy(this.gameObject);
        state = State.Death;

    }
    #endregion
    void GoNextNode()
    {
        //CLosed PATH
        currentNode++;
        if(currentNode >= nodes.Length) currentNode = 0;
        agent.SetDestination(nodes[currentNode].position);
    }
    void GoNearNode()
    {
        float minDistance = Mathf.Infinity;
        for(int i =0; i<nodes.Length;++i)
        {
            float dist = Vector3.Distance(transform.position, nodes[i].position);
            if(dist<minDistance)
            {
                minDistance = dist;
                currentNode = i;
            }
        }
        agent.SetDestination(nodes[currentNode].position);
    }

    protected virtual void DeadEnemy()
    {
        //Animacion
        Destroy(this.gameObject);
    }

    

    protected virtual void OnDrawGizmos()
    {
        Color color = Color.red;
        color.a = 0.1f;
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
        Gizmos.color = Color.blue;

    }

  
    
   
}
