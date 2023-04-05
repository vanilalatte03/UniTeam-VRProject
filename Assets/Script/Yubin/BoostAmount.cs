
using UnityEngine;

public class BoostAmount : MonoBehaviour
{
    public float speedBoostAmount = 2.0f; // �̼� ������
    public float duration = 5.0f; // �̼� ���� ���� �ð�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾�� �浹���� ���
        {
            // �÷��̾��� Rigidbody ������Ʈ�� ������
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                // �÷��̾��� �̼��� ������Ŵ
                playerRigidbody.velocity *= speedBoostAmount;

                // ���� �ð� �Ŀ� �̼��� ������� �����ϴ� �ڷ�ƾ ����
                StartCoroutine(ResetSpeedBoost(playerRigidbody));

                // �������� ��Ȱ��ȭ�Ͽ� ������� ��
                gameObject.SetActive(false);
            }
        }
    }

    private System.Collections.IEnumerator ResetSpeedBoost(Rigidbody playerRigidbody)
    {
        yield return new WaitForSeconds(duration); // ���� �ð� ���

        // �̼��� ������� ����
        playerRigidbody.velocity /= speedBoostAmount;
    }
}