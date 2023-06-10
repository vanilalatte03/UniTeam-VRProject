using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject wallHpPanel;                             // �� HP �ǳ�

    [SerializeField]
    private int poisonFieldDamage = 1;                          // �� ���� ������
    [SerializeField]
    private float poisionFieldTime = 0.5f;                      // �� ���� �ֱ�

    [SerializeField]
    private ParticleSystem gasEffect;                           // ������ ��ƼŬ

    private Coroutine fireFieldCor;                             // �ڷ�ƾ�� �����ϴ� ��ü
  
    // �÷��̾ ����� ��
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TrapWall trapWall = transform.GetChild(0).GetComponent<TrapWall>();

            if (trapWall != null)
            {
                Debug.Log("�÷��ο� �÷��̾ ��Ұ�, trapwall�� �����Ǿ���");
                trapWall.FadeOnStart();
                fireFieldCor = StartCoroutine(FireField(other.transform));

                gasEffect.Play();
            } 
        }
    }

    // �ֱ������� �÷��̾�� �ʵ� ������ ������ �ڷ�ƾ
    private IEnumerator FireField(Transform player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            while (true)
            {
                playerHealth.FieldDamage(poisonFieldDamage + 1);
                yield return new WaitForSeconds(poisionFieldTime + 0.5f);
            }
        }      
    }
    
    // ����� �� �ǰ� ������ / ����Ʈ ����
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(fireFieldCor);
            gasEffect.Stop();
        }
    }
}
