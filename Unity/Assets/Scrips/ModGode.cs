using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModGode : MonoBehaviour
{
    private Player player;
    public bool modGode;
    public GameObject inputManager;
    public Vector3 speedVertical;
    public Vector3 speedHorizontal;
    private Rigidbody rb;
    public Collider colldierSam;
    // Start is called before the first frame update
    void Start()
    {
        modGode = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(modGode)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(speedVertical * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(speedVertical * -1* Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(speedHorizontal * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(speedHorizontal * -1 * Time.deltaTime);

            }
        }
    
       
        if (Input.GetButtonDown("Select") || (Input.GetKeyDown(KeyCode.F10)) && modGode == false)
        {
            colldierSam.enabled = false;
            rb.useGravity = false;
            modGode = true;
            player.GodModeHack();
            Debug.Log("GodMode");
            inputManager.SetActive(false);
            
        }
        else if  (Input.GetButtonDown("Select") || (Input.GetKeyDown(KeyCode.F10)) && modGode == true)
        {
            inputManager.SetActive(true);
            rb.useGravity = true;

            colldierSam.enabled = true;

            modGode = false;
            player.lifePlayer= 5;
        }
    }
}
