using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoBig : MonoBehaviour {


    public GameObject yakuzaDebil;

    public float radius = 5.0F;
    public float power = 10.0F;

    public float upForce=1.0f;

    private float lifeCounter;




    void Start()
    {
        
        lifeCounter = 0;
       
    }

    void Update()
    {
        lifeCounter += Time.deltaTime;

        if (lifeCounter >= 5) Destroy(this.gameObject);
     
        
     Explode();

               
       
    }
   

    void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, upForce, ForceMode.Impulse);
        }
    }
    







}
