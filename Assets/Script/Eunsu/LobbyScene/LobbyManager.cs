using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txtTime;                                    // 최고 시간 텍스트 UI

    [SerializeField]
    private TextMeshProUGUI txtScore;                                   // 최고 점수 텍스트 UI

    private void Awake()
    {
        UpdateScore();
        UpdateTime();
    }

    // 게임 시작 버튼
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // 게임 종료 버튼
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }    

    // 최신 점수 업데이트
    public void UpdateScore()
    {
        int score = PlayerPrefs.GetInt("BestScore");

        if (score != 0)
        {
            txtScore.text = $"{score}점";
        } 
        
        else
        {
            txtScore.text = "00점";
        }       
    }

    // 최신 클리어 시간 업데이트
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
