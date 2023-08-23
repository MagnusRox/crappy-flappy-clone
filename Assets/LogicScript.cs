using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LogicScript : MonoBehaviour
{

    // Start is called before the first frame update

    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    private int currentHighScore;

    public TMP_Text diveCounterText;
    public GameObject gameOverObject;
    private float timeRan;

    public void Start()
    {
        PlayerPrefs.SetInt("DiveCount", 0);
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
        if(gameOverObject != null) {
            gameOverObject.SetActive(true);
        }
        if(playerScore > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
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

    public void Update() {
        timeRan += Time.deltaTime;
        if (timeRan > 5) {
            int diveCount = PlayerPrefs.GetInt("DiveCount", 0);
            if (diveCount < 3) {
                diveCount += 1;
                diveCounterText.text = $"Dives : {diveCount}";
                PlayerPrefs.SetInt("DiveCount", diveCount);
                timeRan = 0;

            }
                
        }
            
            


    }

}
