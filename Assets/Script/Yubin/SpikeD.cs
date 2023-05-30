using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeD : MonoBehaviour
{
    private int damageAmount = 30; // ������ �ε����� �� ������ ü�� ��

    // �÷��̾�� �浹�� ��� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �÷��̾��� ���
        if (other.CompareTag("Player"))
        {
            // �÷��̾��� PlayerHealth ��ũ��Ʈ ��������
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // �÷��̾��� ü�� ����
            if (playerHealth != null)
            {
                AudioSource audioSource = other.GetComponent<AudioSource>();
                audioSource.Play();
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
