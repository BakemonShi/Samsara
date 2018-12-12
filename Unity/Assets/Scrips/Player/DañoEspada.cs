using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEspada : MonoBehaviour {


 

    public  YakuzaDebil yakuzaDebil;
    public TorretaMonoBehaviour torreta;
    public YakuzaGordo yakuzaGordo;

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyTorreta")
        {

            torreta.RecivedDamageTurret();
           
            Debug.Log("EnemyTorreta");
        }
         if (other.tag == "EnemyYakuzaDebil")
        {
            yakuzaDebil.lifeYakuzaDebil--;
            
         

            Debug.Log("EnemyYakuzaDebil");
        }
         if (other.tag == "EnemyYakuzaGordo")
        {
            yakuzaGordo.RecivedDamage();
            Debug.Log("EnemyYakuzaGordo");
        }
    }
    
}
