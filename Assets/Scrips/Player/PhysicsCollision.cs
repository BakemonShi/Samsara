using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollision : MonoBehaviour {
    //
    protected Rigidbody rb;

    [Header("Physics properties")]
    public float gravityMagnitude = 1;
    protected Rigidbody rbb;

    [Header("Ground Checker")]
    public Vector3 groundOrigin;
    public Vector3 groundDirection;
    public float groundMaxDistance;
    public LayerMask groundMask;
    public float groundDistBtRay;
    public int groundNumRay;
    int i;

    [Header("Wall Checker")]
    public Vector3 wallOrigin;
    public Vector3 wallDirection;
    public float wallMaxDistance;
    public LayerMask wallMask;
    public float wallDistBtRay;
    public int wallNumRay;

    [Header("Ground")]
    public bool isGrounded;
    public bool justGrounded;
    public bool wasGrounded;
    public bool justNotGrounded;

    [Header("Wall")]
    public bool isTouchingWall;
    public bool justTouchWall;
    public bool wasTouchingWall;
    public bool justNotTouchWall;
    public bool isFacingRight;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        isFacingRight = true;
    }
    protected virtual void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * gravityMagnitude, ForceMode.Acceleration);
        //aplica gravedad
        CheckGround();
        CheckWall();
    }

    void CheckGround()
    {
        wasGrounded = isGrounded;
        isGrounded = false;
        justGrounded = false;
        justNotGrounded = false;

        Vector3 rayPos = transform.position + groundOrigin;
        int sing = 1;

        for (i = 0; i <= groundNumRay; i++)
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
    void CheckWall()
    {
        wasTouchingWall = isTouchingWall;
        isTouchingWall = false;
        justTouchWall = false;
        justNotTouchWall = false;

        Vector3 rayPos = transform.position + wallOrigin;
        int sing = 1;

        for (i = 0; i <= wallNumRay; i++)
        {
            RaycastHit hit;
            Ray ray = new Ray(rayPos, wallDirection);
            if (Physics.Raycast(ray, out hit, wallMaxDistance, wallMask))
            {
                if (Mathf.Abs(hit.normal.x) >= 0.85f)
                {
                    isTouchingWall = true;
                    if (!wasTouchingWall) justTouchWall = true;
                    break;
                }

            }

            rayPos.y += sing * ((i + 1) * wallDistBtRay);
            sing *= -1;
        }

        if (wasTouchingWall && !isTouchingWall) justNotTouchWall = true;
    }

    protected void Flip()
    {
        isFacingRight = !isFacingRight;

        if (isFacingRight) wallDirection.x = 1;
        else wallDirection.x = -1;

    }

    private void OnDrawGizmos()
    {
        DrawRayGround();
        DrawRayWall();
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
    void DrawRayWall()
    {
        if (!isTouchingWall) Gizmos.color = Color.red;
        else Gizmos.color = Color.green;
        Vector3 rayPos = transform.position + groundOrigin;
        int sing = 1;

        for (i = 0; i <= wallNumRay; i++)
        {

            Gizmos.DrawRay(rayPos, wallDirection * wallMaxDistance);
            rayPos.y += sing * ((i + 1) * wallDistBtRay);
            sing *= -1;
        }
    }
}
