using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI textScore;

    private int currentScore;
     

    // ���ھ� ���� �ʸ��� �ö󰡱�
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
        // ���� ������� ���� ���� 
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
                
                /* ���� ���� �ܰ躰�� */
                break;

            case "Type B":

                /* ���� ���� �ܰ躰�� */
                break;

            case "Type C":

                /* ���� ���� �ܰ躰�� */
                break;

            default:
                Debug.Log("����Ʈ�� �Դϴ�");
                break;
        }
    }
}
