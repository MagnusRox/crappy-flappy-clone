using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{

    // Start is called before the first frame update

    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    private int currentHighScore;

    public GameObject gameOverObject;

    public void Start()
    {
        currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        updateHighScore(currentHighScore);
    }

    //[ContextMenu("Increase Score")]
    public void incrementScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        checkHighScore(playerScore);

    }

    public void gameOver()
    {
        gameOverObject.SetActive(true);
    }

    public void checkHighScore(int playerScore) {

        if (playerScore > currentHighScore) {
            updateHighScore(playerScore);
        }   
    }

    public void updateHighScore(int scoreToUpdate)
    {
        highScoreText.text = $"High Score: {scoreToUpdate}";
    }

}
