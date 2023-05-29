using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeD : MonoBehaviour
{
    public int damageAmount = 2; // ������ �ε����� �� ������ ü�� ��

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
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
