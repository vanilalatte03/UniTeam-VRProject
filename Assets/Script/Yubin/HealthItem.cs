using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthAmount = 30; // ȸ���� ü�·�

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �浹 ����� Player�� ���
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>(); // �浹 ��󿡼� PlayerHealth ������Ʈ�� ������
            if (playerHealth != null) // PlayerHealth ������Ʈ�� �����ϴ� ���
            {
                playerHealth.Heal(healthAmount); // �÷��̾� ü�� ȸ��
                Destroy(gameObject); // ������ �ı�
            }
        }
    }
}

