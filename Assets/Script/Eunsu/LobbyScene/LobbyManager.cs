using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{  

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }    
}
