using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour {

    private YakuzaBoss yakuzaBoss;
    public YakuzaDebil[]  yakuzaDebil;
    
    public Collider colliderSword;
    protected bool isAttack;
    public float counterEspada;
    public float timeAttack;
    private void Start()
    {
 

        colliderSword.enabled=false;
        isAttack=false;
    }
    void Update ()

    {
         if(isAttack)
        {
            colliderSword.enabled=true;
            counterEspada += Time.deltaTime;
        }
         else
            counterEspada = 0;


        if (counterEspada > timeAttack)
        {
            colliderSword.enabled = false;
            isAttack = false;
            counterEspada = 0;
        }

    }
    public void espadaCollider()
    {
       
         isAttack=true;

       
    }

    public void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "YakuzaBoss")
        {
           yakuzaBoss.life--;
            Debug.Log("Te reviento inutil");
           
        }
          if (other.name == "YakuzaDebil1")
        {
            yakuzaDebil[0].lifeYakuzaDebil--;
            Debug.Log("Te reviento inutil");
        }
          else if (other.name == "YakuzaDebil2")
        {
            yakuzaDebil[1].lifeYakuzaDebil--;
            Debug.Log("Te reviento inutil");
        }
        else if (other.name == "YakuzaDebil3")
        {
            yakuzaDebil[2].lifeYakuzaDebil--;
            Debug.Log("Te reviento inutil");
        }
    }

}
