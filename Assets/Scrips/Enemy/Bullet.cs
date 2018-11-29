using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player player;
    public Vector3 speed;


    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * speed);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            player.Damage();
            Destroy(this.gameObject);

        }
    }
}
