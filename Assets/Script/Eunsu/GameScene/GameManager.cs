using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // 다른 스크립트에서 호출 가능하게 하도록 싱글톤
    [HideInInspector]
    public static GameManager Instance; 

    [HideInInspector]
    public bool IsGameActive = true;            // 게임 승,패등의 진행상황을 결정하는 변수
    [HideInInspector]
    public bool IsGamePause = false;            // 게임이 퍼즈상황인지 아닌지대한 변수

    [SerializeField]
    private TextMeshProUGUI txtTimer;
    private float time = 600f;

    [SerializeField]
    private TextMeshProUGUI txtGunState;

    [SerializeField]
    private Slider playerHPSlider;

    [SerializeField]
    private TextMeshProUGUI txtPlayerHP;

    [SerializeField]
    private GameObject panelGame;
    [SerializeField]
    private GameObject panelPause;

    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
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

    public void PauseGame(bool isPause)
    {
        IsGamePause = isPause;
        panelPause.SetActive(isPause);
        
        Time.timeScale = isPause ? 0 : 1;
        Cursor.lockState = isPause ? CursorLockMode.None : CursorLockMode.Locked;       
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    } 

    public void ShootingUIUpdate(int curAmmo, int maxAmmo)
    {
        txtGunState.text = $"{curAmmo} / {maxAmmo}";
    }

    public void ReloadUIUpdate()
    {
        txtGunState.text = "장전 중...";
    }   

    public void PlayerHPUIUpdate(int curHp, int maxHp)
    {
        playerHPSlider.value = curHp / maxHp;
        txtPlayerHP.text = $"{curHp} / {maxHp}";
    }  
}
