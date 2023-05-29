using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI textScore;

    private int currentScore;

    public static ScoreManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void LateUpdate()
    {
       
    }

    // ���ھ� ���� �ʸ��� �ö󰡱� ������ �ϴ� ����
/*    private IEnumerator Start()
    {
        while(GameManager.Instance.IsGameActive)
        {
            currentScore += 5;
            textScore.text = $"{currentScore}��";
            yield return new WaitForSeconds(1f);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        // ���� ������� ���� ���� 
        if (other.tag == "Monster")
        {
            currentScore -= 20;

            if (currentScore <= 0)
            {
                currentScore = 0;
            }
        }
    }

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
}
