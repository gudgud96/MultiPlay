using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePosition : MonoBehaviour
{
    public GameObject player;
    public GameObject timeObject;
    public float x_pos = 52.5f;
    public float y_pos = 191.1f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("z position: " + player.transform.position.z);
        timeObject.transform.position = new Vector3(52.5f, 191.1f, player.transform.position.z + 493f);
    }
}
