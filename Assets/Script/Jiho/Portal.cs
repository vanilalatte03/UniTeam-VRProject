using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string Map2; //�̵��� �� �̸�

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) //�浹�� ��ü�� �÷��̾��� ���
        {
            SceneManager.LoadScene("Map2");
        }
    }
}
