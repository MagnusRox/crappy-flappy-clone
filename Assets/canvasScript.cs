using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class canvasScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject gameOver;

    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
       pause.SetActive(false);
       gameOver.SetActive(false);
    }

    // Update is called once per frame
    public void onResumeButtonClick(){
        isPaused = false;
        Time.timeScale = 1f;
        pause.SetActive(false);
    }


    public void onMainMenuClick() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");   
    }

    public void onQuitButtonClick()
    {
        Application.Quit();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0f;
                pause.SetActive(true);
            }
            else {
                onResumeButtonClick();
            }
        }
    }

    public void onRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
