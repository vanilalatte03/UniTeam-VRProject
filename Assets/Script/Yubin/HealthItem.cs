using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthAmount = 30; // 회복할 체력량

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 충돌 대상이 Player인 경우
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>(); // 충돌 대상에서 PlayerHealth 컴포넌트를 가져옴
            if (playerHealth != null) // PlayerHealth 컴포넌트가 존재하는 경우
            {
                playerHealth.Heal(healthAmount); // 플레이어 체력 회복
                Destroy(gameObject); // 아이템 파괴
            }
        }
    }
}

