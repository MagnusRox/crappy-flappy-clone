using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{

    // Start is called before the first frame update

    public int playerScore;
    public Text scoreText;
    public Text gameOverText;
    public Button restartButton;

    public float incrementSpeedAndSpawnBy = 5;


    public PipeMoveScript pipe;
    public PipeSpawnerPrefab pipeSpawn;


    private void Start()
    {
        pipeSpawn = GameObject.FindGameObjectWithTag("Finish").GetComponent<PipeSpawnerPrefab>();
        pipe = GameObject.FindGameObjectWithTag("Pipe").GetComponent<PipeMoveScript>();
        
        //Debug.Log(pipeSpawn.spawnRate);
    }

    [ContextMenu("Increase Score")]
    public void incrementScore(int scoreToAdd) { 
        playerScore+=scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

}
