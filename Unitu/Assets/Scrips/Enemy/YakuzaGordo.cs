using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuzaGordo : EnemigoBase

{
 [Header("Enemy Properties")]
   
	public float counterAttack;
    public float radiusAttack;
    public LayerMask targetMaskAttack;

    public bool isBlocking;

    public Transform transformGordo;

    public float lifeYakuzaGordo;




    protected override void Start()
    {
        base.Start();
        counterAttack=0;
        agent.speed=1;
        

    }
    protected override  void Update()
    {
        base.Update();
        Attack();
        counterAttack += Time.deltaTime;

        isBlocking=false;

        if (lifeYakuzaGordo == 0)
        {

            DeadEnemy();
        }

        if(targetTransform.transform.position.x>transformGordo.transform.position.x)
        {
            isFacingRight=true;
        }
         else if(targetTransform.transform.position.x<transformGordo.transform.position.x)
        {
            isFacingRight=false;
        }

    }

    private void Attack()
    {
               

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusAttack, targetMaskAttack);
       
       isBlocking=false;
        
       for(int i =0; i<=1; i++)
        {
                   
            if(i< hitColliders.Length)
            {
                if(counterAttack>=5)
                {
                    Debug.Log("yay");
                    player.lifePlayer--;
                    Debug.Log("works");
                    counterAttack = 0;
                }
              
            }

        }

    }
   
   public  void RecivedDamage()
   {
      
            lifeYakuzaGordo--;
    
   }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;    
        Gizmos.DrawSphere(transform.position, radiusAttack);
       

    }

    


}
