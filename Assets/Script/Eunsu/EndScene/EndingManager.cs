using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class EndingManager : MonoBehaviour
{
    private int curScore;                                               // 현재 점수
    private int bestScore;                                              // 기존 최고 점수
    private float time;                                                 // 시간

    [SerializeField]
    private TextMeshProUGUI textCurScore;                               // 현재 점수 텍스트 UI

    [SerializeField]
    private TextMeshProUGUI textBestScore;                              // 최고 점수 텍스트 UI

    [SerializeField]
    private TextMeshProUGUI textTime;                                   // 시간 텍스트 UI

    public void Start()
    {
        SetScore();
    }

    // 점수 세팅
    private void SetScore()
    {
        curScore = PlayerPrefs.GetInt("CurScore");
        bestScore = PlayerPrefs.GetInt("BestScore");
        time = PlayerPrefs.GetFloat("Time");

        Debug.Log("최고점 : " + bestScore);
        textCurScore.text = $"{curScore}점";
        textBestScore.text = $"{bestScore}점";

        int min = (int)time / 60;
        int sec = (int)time % 60;

        string minFormat = min < 10 ? $"0{min}" : min.ToString();
        string secFormat = sec < 10 ? $"0{sec}" : sec.ToString();

        textTime.text = $"{minFormat}:{secFormat}분";
    }

    // 게임 재시작
    public void GameReStart()
    {
        SceneManager.LoadScene(1);
    }

    // 게임 종료
    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }
}
