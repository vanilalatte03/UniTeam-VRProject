using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeD : MonoBehaviour
{
    private int damageAmount = 30; // 함정에 부딪쳤을 때 감소할 체력 양

    // 플레이어와 충돌한 경우 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 플레이어인 경우
        if (other.CompareTag("Player"))
        {
            // 플레이어의 PlayerHealth 스크립트 가져오기
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // 플레이어의 체력 감소
            if (playerHealth != null)
            {
                AudioSource audioSource = other.GetComponent<AudioSource>();
                audioSource.Play();
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
