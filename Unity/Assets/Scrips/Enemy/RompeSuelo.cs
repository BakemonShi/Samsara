using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RompeSuelo : MonoBehaviour
{
    private Player player;
    public Vector3 speed;

    public float lifeBullet;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        lifeBullet += Time.deltaTime;
        transform.Translate(Time.deltaTime * speed);

        if (lifeBullet >= 3)
        {
            Destroy(this.gameObject);

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Damage();
            player.lifePlayer--;

            Destroy(this.gameObject);
            Debug.Log("pruebaDamage");
        }
    }


}

