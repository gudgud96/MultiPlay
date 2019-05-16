using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewayForce = 500f;
    public float jumpForce = 2000f;
    
    // Start is called before the first frame update
    /*void Start()
    {
        Debug.Log("Hello World");
        // rb.useGravity = false;
        rb.AddForce(0, 200, 500);
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
#if UNITY_EDITOR
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);     // move right
        }
        else if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);    // move left
        }
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        var touch = Input.GetTouch(0);
        if (touch.position.x > Screen.width * 1 / 4 && touch.position.x  <= Screen.width * 1 / 2)
        {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);     // move right
        }
        else if (touch.position.x <= Screen.width * 1 / 4)
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);    // move left
        }
#endif
    }
}
