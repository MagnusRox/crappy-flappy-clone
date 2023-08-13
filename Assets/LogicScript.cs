using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{

    // Start is called before the first frame update

    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public Text gameOverText;
    public Button restartButton;
    public float incrementSpeedAndSpawnBy = 5;

    private int currentHighScore;

    public void Start()
    {
        currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log(currentHighScore);
        updateHighScore(currentHighScore);
    }

    //[ContextMenu("Increase Score")]
    public void incrementScore(int scoreToAdd) { 
        playerScore+=scoreToAdd;
        scoreText.text = playerScore.ToString();
        checkHighScore(playerScore);
        
    }

    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        if (playerScore >= currentHighScore) {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
    }

    public void checkHighScore(int playerScore) {

        if (playerScore > currentHighScore) {
            updateHighScore(playerScore);
        }   
    }

    public void updateHighScore(int scoreToUpdate) {
        highScoreText.text = $"High Score: {scoreToUpdate}";
    }

}
