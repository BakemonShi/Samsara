using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuzaDebil : EnemigoBase

{
    [Header("Enemy Properties")]

   // public float counterAttack;
    public float radiusAttack;
    public LayerMask targetMaskAttack;
    public float lifeYakuzaDebil;


    public bool isExplosion;
    public bool isStun;
    public float counterStun;

    public GameObject deathFX;


    protected override void Start()
    {
        base.Start();
        counterAttackYakuza = 0;


    }

    protected override void Update()
    {
        base.Update();
        Attack();
        

        if (lifeYakuzaDebil <= 0)
        {
            lifeYakuzaDebil = 0;
            DeadEnemy();
        }
        if (isStun)
        {
            counterStun += Time.deltaTime;
            agent.enabled = false;
            if (counterStun >= 1)
            {
                isStun = false;
                counterStun = 0;
            }

        }
        if (!isStun) agent.enabled = true;

    }
    private void Attack()
    {
        

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusAttack, targetMaskAttack);


        for (int i = 0; i <= 1; i++)
        {
            if (i < hitColliders.Length)
            {

                if (counterAttackYakuza >= 1)
                {
                    anim.SetTrigger("isAttack");

                    Debug.Log("yay");
                    player.Damage();
                    Debug.Log("works");
                    counterAttackYakuza = 0;
                }

            }

        }

    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawSphere(transform.position, radiusAttack);
        Gizmos.color = Color.green;

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Espada")
        {
            Instantiate(deathFX, (new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z)), Quaternion.identity);
            Destroy(this.gameObject);

        }
    }
}