using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateCamera : MonoBehaviour {


    public float timeCounter;
    public float time;
    public Vector3 speed;
    public bool ismove;
	void Start () {
        ismove = false;

    }
	
	// Update is called once per frame
	void Update ()
    {

        if(ismove) transform.Translate(speed * Time.deltaTime);
        timeCounter += Time.deltaTime;
        if (time < timeCounter)
        {
            ismove = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
            {
            ismove = true;
            timeCounter = 0;
            
            
          
        }

	}
}
