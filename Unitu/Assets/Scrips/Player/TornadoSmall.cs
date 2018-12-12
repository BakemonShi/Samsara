using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSmall : MonoBehaviour
{

    public Vector3 speed;

    public float power;

    public float radius;

    public YakuzaDebil yakuzaDebil;

   


    void Start()
    {
     


    }

    void Update()
    {


        transform.Translate(speed * Time.deltaTime);


    }

    
    private void DesapareceAire()
    {

        Destroy(this.gameObject);

    }

    public void OnTriggerEnter (Collider collider)
    {
        
            if (collider.tag == "EnemyYakzuzaDebil")
            {
            yakuzaDebil.isExplosion = true;
                Debug.Log("PruebaSmall");
            DesapareceAire();

        }
    }
}