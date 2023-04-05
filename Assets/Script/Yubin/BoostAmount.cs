
using UnityEngine;

public class BoostAmount : MonoBehaviour
{
    public float speedBoostAmount = 2.0f; // 이속 증가량
    public float duration = 5.0f; // 이속 증가 지속 시간

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어와 충돌했을 경우
        {
            // 플레이어의 Rigidbody 컴포넌트를 가져옴
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                // 플레이어의 이속을 증가시킴
                playerRigidbody.velocity *= speedBoostAmount;

                // 일정 시간 후에 이속을 원래대로 복구하는 코루틴 실행
                StartCoroutine(ResetSpeedBoost(playerRigidbody));

                // 아이템을 비활성화하여 사라지게 함
                gameObject.SetActive(false);
            }
        }
    }

    private System.Collections.IEnumerator ResetSpeedBoost(Rigidbody playerRigidbody)
    {
        yield return new WaitForSeconds(duration); // 일정 시간 대기

        // 이속을 원래대로 복구
        playerRigidbody.velocity /= speedBoostAmount;
    }
}