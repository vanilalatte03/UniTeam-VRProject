using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth;

    private void Awake()
    {
        curHealth = maxHealth;        
    }

    private void Start()
    {  
        GameManager.Instance.PlayerHPUIUpdate(curHealth, maxHealth);    
    }

    public void TakeDamage(int damageAmount)
    {
        curHealth -= damageAmount;
        GameManager.Instance.PlayerHPUIUpdate(curHealth, maxHealth);
        if (maxHealth <= 0)
        {
            curHealth = 0;
            // 캐릭터가 사망한 경우 처리
        }
    }

    public void Heal(int healAmount)
    {
        curHealth += healAmount;
        
        if (curHealth > 100)
        {
            curHealth = 100;
        }

        GameManager.Instance.PlayerHPUIUpdate(curHealth, maxHealth);
    }

    public void FieldDamage(int damage)
    {
        curHealth -= damage;
        GameManager.Instance.PlayerHPUIUpdate(curHealth, maxHealth);
    }
}
