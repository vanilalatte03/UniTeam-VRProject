using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string Map2; //�̵��� �� �̸�


    // ��Ż�� ���� Ŭ�����Ҷ� �Ѵٰ� �ؼ� ����
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) //�浹�� ��ü�� �÷��̾��� ���
        {
            SceneManager.LoadScene("Map2");
        }
    }*/

    // ��ī�̹ڽ� ���� �Ҷ� �̰� ���
/*    [SerializeField]
    private Skybox[] skyboxes;*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) //�浹�� ��ü�� �÷��̾��� ���
        {
            Debug.Log("���� Ŭ���� ����!");
        }
    }
}
