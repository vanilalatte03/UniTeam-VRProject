using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI textScore;                                          // ���� �ؽ�Ʈ UI

    private int currentScore;                                                   // ���� ����

    public static ScoreManager Instance = null;                                 // ScoreManager�� �̱����� ���� �ν��Ͻ�

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // �÷��̾ ���� ������� ���� ���� 
    private void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Monster")
        {
            currentScore -= 20;

            if (currentScore <= 0)
            {
                currentScore = 0;
            }
        }
    }

    // ������ Ÿ�Ժ��� ���� ����
    public void PlusScore(string monsterType)
    {
        switch (monsterType)
        {
            case "Type_A":
                currentScore += 100;
                /* ���� ���� �ܰ躰�� */
                break;

            case "Type_B":

                /* ���� ���� �ܰ躰�� */
                break;

            case "Type_C":

                /* ���� ���� �ܰ躰�� */
                break;

            default:
                Debug.Log("����Ʈ�� �Դϴ�");
                break;
        }
        textScore.text = $"{currentScore}��";
    }

    // ���� ����
    public void SetScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");

        Debug.Log(bestScore);

        if (bestScore < currentScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
        } 

        else
        {
            PlayerPrefs.SetInt("CurScore", currentScore);
        }        
    }
}
