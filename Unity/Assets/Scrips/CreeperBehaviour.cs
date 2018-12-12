using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreeperBehaviour : MonoBehaviour {

/*    public enum State { Idle, Patrol, Chase, Explosion, Death };
    public State state;

    private Animator anim;
    private NavMeshAgent agent;
    private SoundPlayer sound;

    public PlayerControler playerControler;

    private float timeCounter;
    public float idleTime;

    [Header("Enemy Properties")]
    public float life = 50;
    [Header("Path Properties")]
    public Transform[] nodes;
    public bool stopAtEachNode;
    public int currentNode;
    public float reachDistance= 0.1f;

    [Header("Target Properties")]
    public LayerMask targetMask;
    public float radius;
    public bool targetDetected;
    public Transform targetTransform;

    [Header("Explosion Properties")]
    public float explosionDistance = 3;
    public ParticleSystem explosionPS;
    public float explosionForce = 10;
    public bool isExploding = false;

    public AudioSource explosionFX;

    private void Start()
    {
        playerControler = GameObject.Find("Player").GetComponent<PlayerControler>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        sound = GetComponentInChildren<SoundPlayer>();
        isExploding = false;
        life = 50;
        //AGENT:Destino Punto mas cercano
        GoNearNode();

        SetIdle();
    }
    private void FixedUpdate()
    {
        //IMPORTANTE
        targetDetected = false;
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, radius, targetMask);
        if(hitcolliders.Length !=0)
        {
            targetDetected = true;
            targetTransform = hitcolliders[0].transform;
        }
    }
    private void Update()
    {
        switch(state)
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
            if(stopAtEachNode) SetIdle();
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

        if(Vector3.Distance(transform.position,targetTransform.position)<= 3)
        {
            SetExplosion();

        }
        agent.SetDestination(targetTransform.position);
    }
    

    #region Sets
    void SetIdle()
    {
        timeCounter = 0;
        anim.SetBool("isMoving", false);
        agent.isStopped = true;
        radius = 10;
        int r = Random.Range(1, 5);
        //sound.Play(r, 1);
        

        state = State.Idle;
    }
    void SetPatrol()
    {
        anim.SetBool("isMoving",true);
        agent.isStopped = false;
        agent.stoppingDistance = 0;
        
        state = State.Patrol;
    }
    void SetChase()
    {
        anim.SetBool("isMoving", true);
        agent.isStopped = false;
        agent.stoppingDistance = 2;
        radius = 20;
        state = State.Chase;
    }
    void SetExplosion()
    {
        anim.SetTrigger("Explode");
        agent.isStopped = true;
        //sound.Play(9, 1);
        isExploding = true;

        state = State.Explosion;
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
    public void Explode()
    {
        
        explosionPS.Play();
        explosionPS.transform.parent = null;
        SetDeath();

        int r = Random.Range(5, 9);
        //sound.Play(r, 1);
        explosionFX.Play(1);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionDistance + 1.0f);
        //foreach es un for que gasta mes memoria pero a vegades es mes util
        foreach(Collider c in hitColliders)
        {
            if(c.transform.name==("Player"))
            {
                Debug.Log("yay");
                DamagePlayer();
                Debug.Log("works");
            }
            
        }
        
    }
    private void OnDrawGizmos()
    {
        Color color = Color.red;
        color.a = 0.1f;
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explosionDistance + 1f);
    }
    public void ReceiveDamage(float amount)
    {
        life -= amount;
        if (life<=0)
        {
            SetDeath();
        }
    }
    public void DamagePlayer()
    {
        
        playerControler.Damage(50);
        

    }
   */
}
