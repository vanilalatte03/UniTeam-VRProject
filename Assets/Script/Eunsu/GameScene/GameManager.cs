using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // �ٸ� ��ũ��Ʈ���� ȣ�� �����ϰ� �ϵ��� �̱���
    [HideInInspector]
    public static GameManager Instance; 

    [HideInInspector]
    public bool IsGameActive = true;            // ���� ��,�е��� �����Ȳ�� �����ϴ� ����
    [HideInInspector]
    public bool IsGamePause = false;            // ������ �����Ȳ���� �ƴ������� ����

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
        // ESC���� �� ���� �Ͻ�����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(!IsGamePause);        
        }

        StartTimer();
    }

    // 10�� Ÿ�̸�
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
        txtGunState.text = "���� ��...";
    }   

    public void PlayerHPUIUpdate(int curHp, int maxHp)
    {
        playerHPSlider.value = curHp / maxHp;
        txtPlayerHP.text = $"{curHp} / {maxHp}";
    }  
}
