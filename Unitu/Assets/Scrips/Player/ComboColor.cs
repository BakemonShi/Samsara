using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboColor : MonoBehaviour {

   
	public int animationAttack = 0;
	public float timeColdownAuto;
    [Header("SwordClosseAttack")]
   
    public bool isAttack;
    public Vector3 origin;

    public Animator anim;
  

  


    void Start () 
	{
        anim = GetComponentInParent<Animator>();
      
        isAttack = false;
       
    }


    void Update()
    {
        AnimatorAttack();

            
    }

   

    public void AnimatorAttack()
    {
         if (timeColdownAuto >= 1)
         {
           
             timeColdownAuto = 0;
             animationAttack = 0;
            anim.SetTrigger("Iddle");
            
            isAttack = false;

        }
                    

    }


    public void AttackSwordWeak()
    {
                     
        timeColdownAuto = 0;
        anim.SetTrigger("Golpe");
        isAttack = true;
       
     }

    public void AttackSwordStrong()
    {
        timeColdownAuto = 0;

        isAttack = true;
    } 
}






