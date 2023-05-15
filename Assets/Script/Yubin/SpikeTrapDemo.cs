using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour
{
    public Animator spikeTrapAnim; // 함정의 Animator 컴포넌트
    public int damageAmount = 10; // 함정에 부딪쳤을 때 감소할 체력 양
    private bool trapActive = false; // 함정이 활성화되었는지 여부를 나타내는 플래그

    void Awake()
    {
        spikeTrapAnim = GetComponent<Animator>();
        StartCoroutine(TrapSequence());
    }

    IEnumerator TrapSequence()
    {
        while (true)
        {
            // 함정 활성화 상태일 때만 플레이어의 체력 감소
            if (trapActive)
            {
                // 플레이어의 PlayerHealth 스크립트 가져오기
                PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

                // 플레이어의 체력 감소
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                }
            }

            spikeTrapAnim.SetTrigger("open"); // 함정 열기 애니메이션 실행
            yield return new WaitForSeconds(2); // 2초 대기

            spikeTrapAnim.SetTrigger("close"); // 함정 닫기 애니메이션 실행

            yield return new WaitForSeconds(2); // 2초 대기
        }
    }

    // 플레이어와 충돌한 경우 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 플레이어인 경우 함정 활성화
        if (other.CompareTag("Player"))
        {
            trapActive = true;
        }
    }

    // 플레이어와 충돌이 끝난 경우 호출되는 함수
    private void OnTriggerExit(Collider other)
    {
        // 충돌이 끝난 오브젝트가 플레이어인 경우 함정 비활성화
        if (other.CompareTag("Player"))
        {
            trapActive = false;
        }
    }
}



