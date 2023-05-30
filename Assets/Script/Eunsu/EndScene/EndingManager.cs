using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class EndingManager : MonoBehaviour
{
    private int curScore;
    private int bestScore;
    private float time;

    [SerializeField]
    private TextMeshProUGUI textCurScore;

    [SerializeField]
    private TextMeshProUGUI textBestScore;

    [SerializeField]
    private TextMeshProUGUI textTime;

    public void Start()
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

    public void GameReStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }
}
