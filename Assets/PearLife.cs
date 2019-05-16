using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearLife : MonoBehaviour {

    private string status;
    private int lifeTimer;
    public GameObject score;
    public int fall = 100;
    private int die = 50;

    // Use this for initialization
    void Start () {
        status = "growing";
        lifeTimer = 0;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        score = GameObject.Find("Score");
}
	
	// Update is called once per frame
	void Update () {
        if ("growing".Equals(status)) {
            lifeTimer += 1;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, lifeTimer / (float)fall);
            if (lifeTimer >= fall) {
                GetComponent<Rigidbody2D>().gravityScale = 0.2f;
                status = "falling";
                lifeTimer = 0;
            }
        } else if ("dying".Equals(status)) {
            lifeTimer += 1;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1 - lifeTimer / (float)die);
            if (lifeTimer >= die) {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if ("falling".Equals(status))  {
            if (col.gameObject.name == "Floor") {
                status = "dying";
            } else if (col.gameObject.name == "Target") {
                status = "dying";
                int newScore = System.Convert.ToInt32(score.GetComponent<UnityEngine.UI.Text>().text) + 1;
                MonoBehaviour.print(newScore);
                score.GetComponent<UnityEngine.UI.Text>().text = System.Convert.ToString(newScore);
            }
        }
    }

}
