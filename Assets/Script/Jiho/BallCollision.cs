using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public int damageAmount = 10; // 입힐 데미지량

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}