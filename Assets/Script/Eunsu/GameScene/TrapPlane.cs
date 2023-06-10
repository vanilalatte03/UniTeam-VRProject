using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject wallHpPanel;                             // 벽 HP 판넬

    [SerializeField]
    private int poisonFieldDamage = 1;                          // 불 공격 데미지
    [SerializeField]
    private float poisionFieldTime = 0.5f;                      // 불 공격 주기

    [SerializeField]
    private ParticleSystem gasEffect;                           // 독가스 파티클

    private Coroutine fireFieldCor;                             // 코루틴을 저장하는 객체
  
    // 플레이어에 닿았을 시
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TrapWall trapWall = transform.GetChild(0).GetComponent<TrapWall>();

            if (trapWall != null)
            {
                Debug.Log("플레인에 플레이어가 닿았고, trapwall이 감지되었다");
                trapWall.FadeOnStart();
                fireFieldCor = StartCoroutine(FireField(other.transform));

                gasEffect.Play();
            } 
        }
    }

    // 주기적으로 플레이어에게 필드 데미지 입히는 코루틴
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
    
    // 벗어났을 시 피격 데미지 / 이펙트 종료
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(fireFieldCor);
            gasEffect.Stop();
        }
    }
}
