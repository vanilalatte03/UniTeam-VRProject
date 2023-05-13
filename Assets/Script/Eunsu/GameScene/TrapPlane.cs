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

    private Coroutine fireFieldCor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform trapWall = transform.GetChild(0);

            if (trapWall != null)
            {
                trapWall.gameObject.SetActive(true);
                wallHpPanel.SetActive(true);
                fireFieldCor = StartCoroutine(FireField(collision.transform));
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

    private void OnCollisionExit(Collision collision)
    {   
        if(collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(fireFieldCor);
        }        
    }
}
