using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class select_Diff_Mode : MonoBehaviour {
	
    void Start()
    {

    }

	public void difficulty_Page (int SceneIndex){

        SceneManager.LoadScene(SceneIndex);
		
	}
		
	public void Mute(){
		AudioListener.pause = !AudioListener.pause;
	}

}
