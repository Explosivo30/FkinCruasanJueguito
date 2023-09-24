using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    [SerializeField] float force = 8f;
    [SerializeField] Rigidbody rb;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce (transform.right * force);
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            rb.AddForce(-transform.right * force);
        }
    }
}
