using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool IsGameActive = true;
    public static bool IsGamePause = false;

    [SerializeField]
    private TextMeshProUGUI txtTimer;
    private float time = 600f;

    [SerializeField]
    private GameObject panelGame;
    [SerializeField]
    private GameObject panelPause;


    private void Update()
    {
        // ESC���� �� ���� �Ͻ�����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause(!IsGamePause);        
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

    private void GamePause(bool isPause)
    {
        IsGamePause = isPause;
        panelPause.SetActive(isPause);     
    } 
}
