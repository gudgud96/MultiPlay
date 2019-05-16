using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBasket : MonoBehaviour
{

    public float speed = 1.0f;
    public float threshold = Screen.width / 4;
    public bool isLeft = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        //Debug.Log("horizontal: " + Input.GetAxis("Horizontal"));
        //var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        var move = new Vector3(0, 0, 0);
        transform.position += move * speed * Time.deltaTime;

#if UNITY_EDITOR
        if (Input.GetKey("j")) {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey("l")) {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        var touch = Input.GetTouch(0);
        bool touchLeftSide = false;
        bool touchRightSide = false;
        if (isLeft) {
            touchLeftSide = (touch.position.x <= Screen.width * 1 / 4);
            touchRightSide = (touch.position.x > Screen.width * 1 / 4 && touch.position.x  <= Screen.width * 1 / 2);
        }
        else {
            touchLeftSide = (touch.position.x  > Screen.width * 1 / 2 && touch.position.x <= Screen.width * 3 / 4);
            touchRightSide = (touch.position.x > Screen.width * 3 / 4);
        }
        if (touchLeftSide) {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (touchRightSide) {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
#endif
    }
}


