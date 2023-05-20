using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject wallHpPanel;

    [SerializeField]
    private int fireFieldDamage = 1;
    [SerializeField]
    private float fireFieldTime = 0.5f;

    [SerializeField]
    private ParticleSystem gasEffect;

    private Coroutine fireFieldCor;
  
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

    private IEnumerator FireField(Transform player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            while (true)
            {
                playerHealth.FieldDamage(fireFieldDamage);
                yield return new WaitForSeconds(fireFieldTime);
            }
        }      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(fireFieldCor);
            gasEffect.Stop();
        }
    }
}
