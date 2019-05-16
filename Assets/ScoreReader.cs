using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReader : MonoBehaviour
{
    public GameObject score;
    
    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader(Application.persistentDataPath + "score.txt");
        string scoreText = reader.ReadLine();
        score.GetComponent<Text>().text = scoreText;
        reader.Close();
        File.Delete(Application.persistentDataPath + "score.txt");
    }
}
