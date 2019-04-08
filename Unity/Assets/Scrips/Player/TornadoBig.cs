using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TornadoBig : MonoBehaviour
{

    public float radius = 5.0F;
    public float power = 10.0F;

    public float upForce = 1.0f;

    private float lifeCounter;
    private Rigidbody rb;
    private YakuzaDebil yakuzaDebil;




    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("EnemyYakuzaDebil").GetComponent<Rigidbody>();
        yakuzaDebil = GameObject.FindGameObjectWithTag("EnemyYakuzaDebil").GetComponent<YakuzaDebil>();


        lifeCounter = 0;

    }

    void Update()
    {
        lifeCounter += Time.deltaTime;

        if (lifeCounter >= 5) Destroy(this.gameObject);

    }

    public void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "EnemyYakuzaDebil")
        {
            Explode();
            Debug.Log("PruebaSmall");
            yakuzaDebil.isStun = true;
            yakuzaDebil.lifeYakuzaDebil--;

        }
    }
    void Explode()
    {
        Debug.Log("PruebaExplode");

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);


        rb.AddExplosionForce(power, explosionPos, radius, upForce, ForceMode.Impulse);


    }

}



