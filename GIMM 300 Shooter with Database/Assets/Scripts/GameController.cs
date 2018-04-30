using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
    //public GameObject endUI;
    /*public Text restartText;
	public RawImage gameOverText;*/
    public GameObject restartButton;

	private bool gameOver;
	private bool restart;
	private int score;
    private ScoreController scoreController;

    void Start ()
	{
        GameObject scoreControllerObject = GameObject.FindWithTag("ScoreController");
        scoreController = scoreControllerObject.GetComponent<ScoreController>();
  
		gameOver = false;
		restart = false;
        /*restartText.text = "";*/
        /*gameOverText.text = "";*/
        //endUI.SetActive(false);
        score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
                int index = Random.Range(0, hazards.Length);
				GameObject hazard = hazards[index];
                float zValue = spawnValues.z;
                /*Make Forward-Moving vehicles spawn at bottom*/
                if (index == 4)
                {
                    zValue = -7;
                }
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, zValue);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
				/*restartText.text = "Press 'R' for Restart";*/
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
        scoreController.newScore = score;
        UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
        
    }

    public void GetScore()
    {
        
    }

	public void GameOver ()
	{
        /*gameOverText.text = "Game Over!";*/
        //endUI.SetActive(true);
		gameOver = true;
        //GetComponent<AudioSource>().Play();
        Application.LoadLevel("scene_01");
    }


}