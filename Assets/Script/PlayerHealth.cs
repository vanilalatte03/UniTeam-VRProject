using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 100;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            // 캐릭터가 사망한 경우 처리
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;

        if (health > 100)
        {
            health = 100;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
