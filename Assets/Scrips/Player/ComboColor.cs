using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboColor : MonoBehaviour {

    public Material materialA;
	public Material materialB;
	public Material materialC;
	public Material standard;
	public Renderer rend;
	public int animationAttack = 0;
	public float timeColdownAuto;



    private Animator anim;

    public Vector3 origin;
    public Vector3 direction;
    public float maxDistance;
    public LayerMask mask;
    public float distBtRay;
    public int numRay;
    public bool isAttack;
    int i;

    public EnemigoBase enemyBase;
    public TorretaMonoBehaviour enemyTorret;


    void Start () 
	{
		rend=GetComponentInChildren<Renderer>();
        anim = GetComponent<Animator>();
        isAttack = false;

    }


    void Update()
    {
        AnimatorAttack();

    }

    private void FixedUpdate()
    {
        if (isAttack)
        {
            Vector3 rayPos = transform.position + origin;

            RaycastHit hit;
            Ray ray = new Ray(rayPos, direction);
            if (Physics.Raycast(ray, out hit, maxDistance, mask))
            {

                Debug.Log("Enemigo");
                DamageSword();
                isAttack = false;

            }
        }
           

    }

    public void AnimatorAttack()
    {
         if (timeColdownAuto >= 1)
         {
             rend.material = standard;
             timeColdownAuto = 0;
             animationAttack = 0;
            anim.SetTrigger("Iddle");

        }
        if ((animationAttack == 1) || (animationAttack == 2) || (animationAttack == 3))
    {
        timeColdownAuto += Time.deltaTime;

    }
                                  
            
      
             if (Input.GetButtonDown("Fire1") && (animationAttack == 2))
            {
              animationAttack=0;
                rend.material = materialC;
                timeColdownAuto = 0;
                    anim.SetTrigger("TercerGolpe");
          
            isAttack = true;

        }
             
       
            else if (Input.GetButtonDown("Fire1") && (animationAttack == 1))
            {
                animationAttack++;
                rend.material = materialB;
                timeColdownAuto = 0;
                    anim.SetTrigger("SegundoGolpe");
            isAttack = true;

        }
            
           else if (Input.GetButtonDown("Fire1") && (animationAttack == 0))
            {
                animationAttack++;
                rend.material = materialA;
                timeColdownAuto = 0;
                    anim.SetTrigger("PrimerGolpe");
            isAttack = true;

        }


    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 rayPos = transform.position + origin;
        int sing = 1;

        for (i = 0; i <= numRay; i++)
        {

            Gizmos.DrawRay(rayPos, direction * maxDistance);
            rayPos.x += sing * ((i + 1) * distBtRay);
            sing *= -1;
        }
    }


    public void DamageSword()
    {
        enemyBase.RecivedDamage();
       // enemyTorret.lifeTorret--;
    }
   
}

