using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollision : MonoBehaviour {
    //
    protected GameManager gm;
    public Rigidbody rb;
    

    [Header("Physics properties")]
    public float gravityMagnitude = 1;
    public bool disable = false;

    [Header("Ground Checker")]
    public Vector3 groundOrigin;
    public Vector3 groundDirection;
    public float groundMaxDistance;
    public LayerMask groundMask;
    public float groundDistBtRay;
    public int groundNumRay;
    int i;
    public bool isFacingRight = true;

    [Header("Ground")]
    public bool isGrounded;
    public bool justGrounded;
    public bool wasGrounded;
    public bool justNotGrounded;
    public bool isFly;



    public virtual void Initialize(GameManager gameManager)
    {
        gm = gameManager;

        rb = GetComponent<Rigidbody>();
      
    }
    public virtual void MyFixedUpdate()
    {
        rb.AddForce(Physics.gravity * gravityMagnitude, ForceMode.Acceleration);
        //aplica gravedad

        if (disable) return;
        CheckGround();
       
    }

    void CheckGround()
    {
        if (!isGrounded) isFly = true;
        else if (isGrounded) isFly = false;
        wasGrounded = isGrounded;
        isGrounded = false;
        justGrounded = false;
        justNotGrounded = false;

        Vector3 rayPos = transform.position + groundOrigin;
        int sing = 1;

        for (i = 0; i <= groundNumRay-1; i++)
        {
            RaycastHit hit;
            Ray ray = new Ray(rayPos, groundDirection);
            if (Physics.Raycast(ray, out hit, groundMaxDistance, groundMask))
            {
                if (hit.normal.y >= 0.7f)
                {
                    isGrounded = true;
                    if (!wasGrounded) justGrounded = true;
                    break;
                }

            }

            rayPos.x += sing * ((i + 1) * groundDistBtRay);
            sing *= -1;
        }

        if (wasGrounded && !isGrounded) justNotGrounded = true;
    }
    

    protected void DisableChecker(float sec)
    {
        StartCoroutine(DisableCollisionDetection(sec));
    }

    private void OnDrawGizmos()
    {
        DrawRayGround();
    }
    void DrawRayGround()
    {
        if (!isGrounded) Gizmos.color = Color.red;
        else Gizmos.color = Color.green;
        Vector3 rayPos = transform.position + groundOrigin;
        int sing = 1;

        for (i = 0; i <= groundNumRay; i++)
        {

            Gizmos.DrawRay(rayPos, groundDirection * groundMaxDistance);
            rayPos.x += sing * ((i + 1) * groundDistBtRay);
            sing *= -1;
        }
    }
    
    
    IEnumerator DisableCollisionDetection(float time)
    {
        disable = true;
        yield return new WaitForSeconds(time);
        disable = false;
    }
}
