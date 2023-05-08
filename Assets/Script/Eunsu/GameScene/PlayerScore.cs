using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI textScore;

    private int currentScore;
     

    // 스코어 점수 초마다 올라가기
    public IEnumerator Start()
    {
        while(GameManager.Instance.IsGameActive)
        {
            currentScore += 10;

            textScore.text = $"{currentScore}";

            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 몬스터 닿았을때 점수 감소 
        if (other.tag == "Monster")
        {
            currentScore -= 30;
        }
    }

    public void PlusScore(string monsterType)
    {
        switch(monsterType)
        {
            case "Type A":
                
                /* 점수 증가 단계별로 */
                break;

            case "Type B":

                /* 점수 증가 단계별로 */
                break;

            case "Type C":

                /* 점수 증가 단계별로 */
                break;

            default:
                Debug.Log("디폴트값 입니다");
                break;
        }
    }
}
