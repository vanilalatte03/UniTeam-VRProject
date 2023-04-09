using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txtTime;

    [SerializeField]
    private TextMeshProUGUI txtScore;

    private void Awake()
    {
        UpdateScore();
        UpdateTime();
    }

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

    public void UpdateScore()
    {
        int score = PlayerPrefs.GetInt("BestTime");

        if (score != 0)
        {
            txtScore.text = $"{score}Á¡";
        } 
        
        else
        {
            txtScore.text = "00Á¡";
        }       
    }

    public void UpdateTime()
    {
        int time = PlayerPrefs.GetInt("BestTime");

        if (time != 0)
        {
            int min = (int)time / 60;
            int sec = (int)time % 60;

            string minFormat = min < 10 ? $"0{min}" : min.ToString();
            string secFormat = sec < 10 ? $"0{sec}" : sec.ToString();

            txtTime.text = $"{minFormat}:{secFormat}";        
        }

        else
        {
            txtTime.text = "00:00";
        }
    }
}
