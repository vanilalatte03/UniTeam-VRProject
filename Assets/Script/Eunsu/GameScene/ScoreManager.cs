using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI textScore;                                          // 점수 텍스트 UI

    private int currentScore;                                                   // 현재 점수

    public static ScoreManager Instance = null;                                 // ScoreManager의 싱글톤을 위한 인스턴스

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // 플레이어가 몬스터 닿았을때 점수 감소 
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

    // 몬스터의 타입별로 점수 증가
    public void PlusScore(string monsterType)
    {
        switch (monsterType)
        {
            case "Type_A":
                currentScore += 100;
                /* 점수 증가 단계별로 */
                break;

            case "Type_B":

                /* 점수 증가 단계별로 */
                break;

            case "Type_C":

                /* 점수 증가 단계별로 */
                break;

            default:
                Debug.Log("디폴트값 입니다");
                break;
        }
        textScore.text = $"{currentScore}점";
    }

    // 점수 세팅
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
