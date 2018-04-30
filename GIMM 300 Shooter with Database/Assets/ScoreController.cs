using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public int newScore = 0;
    private ScoreController scoreController;
    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(this);
    }

    public int GetNewScore()
    {
        
       // GameObject scoreControllerObject = GameObject.FindWithTag("ScoreController");
        //scoreController = scoreControllerObject.GetComponent<ScoreController>();
        return newScore;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
