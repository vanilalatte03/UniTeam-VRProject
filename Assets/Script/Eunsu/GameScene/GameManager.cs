using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    [HideInInspector]   
    public static GameManager Instance;                     // 다른 스크립트에서 호출 가능하게 하도록 싱글톤    

    [HideInInspector]
    public bool IsGameActive = true;                        // 게임 승,패등의 진행상황을 결정하는 변수
    [HideInInspector]
    public bool IsGamePause = false;                        // 게임이 퍼즈상황인지 아닌지대한 변수

    [SerializeField]
    private TextMeshProUGUI txtTimer;                       // 타이머 텍스트
    private float time = 1800;                              // 30분
        
    [SerializeField]
    private TextMeshProUGUI txtGunState;                    // 총 상태 텍스트

    [SerializeField]
    private Slider playerHPSlider;                          // 플레이어 hp Slider  

    [SerializeField]
    private TextMeshProUGUI txtPlayerHP;                    // 플레이어 hp 텍스트

    [SerializeField]
    private GameObject panelGame;                           // 게임관련 부모 판넬
    [SerializeField]
    private GameObject panelPause;                          // 일시정지 관련 부모 판넬

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }       
    }

    private void Update()
    {
        // ESC누를 시 게임 일시정지
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(!IsGamePause);        
        }

        StartTimer();
    }

    // 10분 타이머
    private void StartTimer()
    {
        if (IsGameActive && !IsGamePause)
        {
            time -= Time.deltaTime;

            int min = (int)time / 60;
            int sec = (int)time % 60;

            string minFormat = min < 10 ? $"0{min}" : min.ToString();
            string secFormat = sec < 10 ? $"0{sec}" : sec.ToString();

            txtTimer.text = $"{minFormat}:{secFormat}";

            if (time == 0f)
            {
                IsGameActive = false;
            }
        }
    }

    // 게임 일시정지
    public void PauseGame(bool isPause)
    {
        IsGamePause = isPause;
        panelPause.SetActive(isPause);
        
        Time.timeScale = isPause ? 0 : 1;
        Cursor.lockState = isPause ? CursorLockMode.None : CursorLockMode.Locked;       
    }

    // 게임 종료
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    } 

    // 슈팅시 UI 표시
    public void ShootingUIUpdate(int curAmmo, int maxAmmo)
    {
        txtGunState.text = $"{curAmmo} / {maxAmmo}";
    }

    // 재장전 시 UI 표시
    public void ReloadUIUpdate()
    {
        txtGunState.text = "장전 중...";
    }   

    // 플레이어 체력 회복시 UI 표시
    public void PlayerHPUIUpdate(int curHp, int maxHp)
    {
        playerHPSlider.value = (float) curHp / maxHp;
        txtPlayerHP.text = $"{curHp} / {maxHp}";
    }  

    // 게임 클리어시 호출
    public void GameClear()
    {
        SetReachTime();
        SceneManager.LoadScene(2);
    }

    // 게임 실패시 호출
    public void GameFail()
    {
        SetReachTime();
        SceneManager.LoadScene(3);
    }

    // 시간 설정
    private void SetReachTime()
    {
        PlayerPrefs.SetFloat("Time", time);
    }
}
