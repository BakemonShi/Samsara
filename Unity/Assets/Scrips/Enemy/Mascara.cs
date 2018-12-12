using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mascara : EnemigoBase 


    

        {

        [Header("Enemy Properties")]
        
           
            public float radiusAttack;
            public LayerMask targetMaskAttack;
            public float power = 10;
            public float upforce=1;
            public float lifeMascara;



            protected override void Start()
            {
                
                base.Start();
            

            }
            protected override  void Update()
            {
                base.Update();
                Explosion();
            
                if (lifeMascara == 0)
                {
                    Invoke("DeadEnemy",0.5f);
                    
                }

            }
            protected void Explosion()
            {
                    
                Vector3 explosionPosition =transform.position;
                
                Collider[] hitColliders = Physics.OverlapSphere(explosionPosition, radiusAttack, targetMaskAttack);
                //foreach es un for que gasta mes memoria pero a vegades es mes util
                
            foreach(Collider hit in hitColliders)
                {
                        
                   Rigidbody rb=hit.GetComponent<Rigidbody>();

                   if(  rb!=null)
                   {
                       
                       player.lifePlayer--;
                       player.lifePlayer--;

                       rb.AddExplosionForce(power,explosionPosition,radiusAttack,upforce,ForceMode.Impulse);
                    lifeMascara = 0;
                       
                   }
                    
                    

                }

            }

            protected override void OnDrawGizmos()
            {
                base.OnDrawGizmos();
                
                Gizmos.color = Color.green;
                    Gizmos.DrawSphere(transform.position, radiusAttack);
                

            }

            


        }
