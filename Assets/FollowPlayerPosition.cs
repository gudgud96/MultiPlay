using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerPosition : MonoBehaviour
{
    public Transform player;
    public float x_pos = 52.5f;
    public float y_pos = 191.1f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("z position: " + player.transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 295f);
    }
}
