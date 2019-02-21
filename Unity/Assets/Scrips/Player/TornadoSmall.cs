using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TornadoSmall : MonoBehaviour
{

    public Vector3 speed;
    public float lifeShot;

    public float radius = 5.0F;
    public float power = 10.0F;
    public float upForce = 1.0f;

    private Player player;
    private Rigidbody rb;
    private YakuzaDebil yakuzaDebil;


    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("EnemyYakuzaDebil").GetComponent<Rigidbody>();
        yakuzaDebil = GameObject.FindGameObjectWithTag("EnemyYakuzaDebil").GetComponent<YakuzaDebil>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


    }

    void Update()
    {

        transform.Translate(speed * Time.deltaTime);

        lifeShot += Time.deltaTime;
        if (lifeShot >= 2) DesapareceAire();


    }


    private void DesapareceAire()
    {

        Destroy(this.gameObject);

    }

    public void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "EnemyYakuzaDebil")
        {
            Explode();
            Debug.Log("PruebaSmall");
            DesapareceAire();
            yakuzaDebil.isStun = true;

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