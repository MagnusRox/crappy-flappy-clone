using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void onPlayButtonClick() {
        Debug.Log("Clicking the Play Button");
        SceneManager.LoadScene("Game");
    }
    public void onQuitButtonClick() { 
        Application.Quit();
   }
}
