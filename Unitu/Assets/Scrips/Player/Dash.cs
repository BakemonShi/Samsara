using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    public Rigidbody dashRigibody;
    public float rango;
    public Vector3 forceXYZ;
    public int dashCount;
    public float dashCounterTime;
    public float coldownDash;



    void Start ()
    {
        dashRigibody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        coldownDash = 10;
    }
	
	void Update ()
    {
      //contador del dash y cooldown
        dashCounterTime += Time.deltaTime;
        if(dashCounterTime>=coldownDash)
        {
            dashCounterTime = 0;
            dashCount++;
        }
	}

   public void DashSpeed()
    {
        if (dashCount > 0)
        {
            dashCount--;
            dashRigibody.AddForce(forceXYZ, ForceMode.Impulse);//fuerza para el dash le da un impulso
        }
    }
}
