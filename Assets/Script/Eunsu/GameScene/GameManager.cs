using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    [HideInInspector]   
    public static GameManager Instance;                     // �ٸ� ��ũ��Ʈ���� ȣ�� �����ϰ� �ϵ��� �̱���    

    [HideInInspector]
    public bool IsGameActive = true;                        // ���� ��,�е��� �����Ȳ�� �����ϴ� ����
    [HideInInspector]
    public bool IsGamePause = false;                        // ������ �����Ȳ���� �ƴ������� ����

    [SerializeField]
    private TextMeshProUGUI txtTimer;                       // Ÿ�̸� �ؽ�Ʈ
    private float time = 1800;                              // 30��
        
    [SerializeField]
    private TextMeshProUGUI txtGunState;                    // �� ���� �ؽ�Ʈ

    [SerializeField]
    private Slider playerHPSlider;                          // �÷��̾� hp Slider  

    [SerializeField]
    private TextMeshProUGUI txtPlayerHP;                    // �÷��̾� hp �ؽ�Ʈ

    [SerializeField]
    private GameObject panelGame;                           // ���Ӱ��� �θ� �ǳ�
    [SerializeField]
    private GameObject panelPause;                          // �Ͻ����� ���� �θ� �ǳ�

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

    // ���� �Ͻ�����
    public void PauseGame(bool isPause)
    {
        IsGamePause = isPause;
        panelPause.SetActive(isPause);
        
        Time.timeScale = isPause ? 0 : 1;
        Cursor.lockState = isPause ? CursorLockMode.None : CursorLockMode.Locked;       
    }

    // ���� ����
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    } 

    // ���ý� UI ǥ��
    public void ShootingUIUpdate(int curAmmo, int maxAmmo)
    {
        txtGunState.text = $"{curAmmo} / {maxAmmo}";
    }

    // ������ �� UI ǥ��
    public void ReloadUIUpdate()
    {
        txtGunState.text = "���� ��...";
    }   

    // �÷��̾� ü�� ȸ���� UI ǥ��
    public void PlayerHPUIUpdate(int curHp, int maxHp)
    {
        playerHPSlider.value = (float) curHp / maxHp;
        txtPlayerHP.text = $"{curHp} / {maxHp}";
    }  

    // ���� Ŭ����� ȣ��
    public void GameClear()
    {
        SetReachTime();
        SceneManager.LoadScene(2);
    }

    // ���� ���н� ȣ��
    public void GameFail()
    {
        SetReachTime();
        SceneManager.LoadScene(3);
    }

    // �ð� ����
    private void SetReachTime()
    {
        PlayerPrefs.SetFloat("Time", time);
    }
}
