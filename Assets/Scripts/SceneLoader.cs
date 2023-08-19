using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadAR(){
        Debug.Log("Scene Loaded?");
        SceneManager.LoadScene("Scenes/ElementsScene");
        
    }

    public void loadMenu(){
        Debug.Log("Scene Loaded?");
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = false;
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
