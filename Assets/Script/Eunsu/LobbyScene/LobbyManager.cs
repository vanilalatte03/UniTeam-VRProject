using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txtTime;                                    // �ְ� �ð� �ؽ�Ʈ UI

    [SerializeField]
    private TextMeshProUGUI txtScore;                                   // �ְ� ���� �ؽ�Ʈ UI

    private void Awake()
    {
        UpdateScore();
        UpdateTime();
    }

    // ���� ���� ��ư
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // ���� ���� ��ư
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }    

    // �ֽ� ���� ������Ʈ
    public void UpdateScore()
    {
        int score = PlayerPrefs.GetInt("BestScore");

        if (score != 0)
        {
            txtScore.text = $"{score}��";
        } 
        
        else
        {
            txtScore.text = "00��";
        }       
    }

    // �ֽ� Ŭ���� �ð� ������Ʈ
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
