using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuzaDebil : EnemigoBase

{
 [Header("Enemy Properties")]
   
	public float counterAttack;
    public float radiusAttack;
    public LayerMask targetMaskAttack;
    public float lifeYakuzaDebil;
    [Header("Explosion Force")]
    public Rigidbody rb;
    public float power;
    public Vector3 radiusforce;

    public bool isExplosion;
    


    protected override void Start()
    {
        base.Start();
        counterAttack=0;
        rb=GetComponent<Rigidbody>();

    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        {
            if (isExplosion)
            {
                rb.MovePosition(transform.position+ radiusforce);
              //  rb.AddForce(5, 0, 0, ForceMode.VelocityChange);
                //rb.AddForce(5,0,0, ForceMode.Impulse);//fuerza para el dash le da un impulso
                isExplosion = false;
               
            }

         
        }
    }
    protected override  void Update()
    {
        base.Update();
        Attack();
        counterAttack += Time.deltaTime;

        if (lifeYakuzaDebil == 0)
        {

            DeadEnemy();
        }

    }
    private void Attack()
    {
               

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusAttack, targetMaskAttack);
        //foreach es un for que gasta mes memoria pero a vegades es mes util
        
       for(int i =0; i<=1; i++)
        {
                   
            if(i< hitColliders.Length)
            {
                if(counterAttack>=3)
                {
                    Debug.Log("yay");
                    player.lifePlayer--;
                    Debug.Log("works");
                    counterAttack = 0;
                }
              
            }

        }

    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawSphere(transform.position, radiusAttack);
        Gizmos.color = Color.green;

    }

   



}
