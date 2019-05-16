using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    public GameObject remainingTime;
    public GameObject timeBomb = null;
    public GameObject score1 = null;
    public GameObject score2 = null;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("remaining: " + remainingTime.GetComponent<TextMesh>().text);
        if (remainingTime.GetComponent<TextMesh>().text == "00:00" ||
            (timeBomb != null && timeBomb.GetComponent<TextMesh>().text == "Game \nOver!"))
        {
            remainingTime.GetComponent<TextMesh>().text = "Time's up!";
            System.Threading.Thread.Sleep(1500);

            // calculate score
            int score = 0;
            if (score1 != null) score += System.Convert.ToInt32(score1.GetComponent<Text>().text);
            if (score2 != null) score += System.Convert.ToInt32(score2.GetComponent<Text>().text);

            // write score
            StreamWriter writer = new StreamWriter(Application.persistentDataPath + "score.txt", true);
            writer.Write(score.ToString());
            writer.Close();

            SceneManager.LoadScene(5);
        }
    }

    public void scene_select(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
