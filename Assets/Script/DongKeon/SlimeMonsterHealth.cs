using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMonsterHealth : MonoBehaviour
{
    public int maxHealth = 100;    //최대체력
    private int currentHealth;    //현재체력

    CapsuleCollider capCollider;

    private void Awake()
    {
        capCollider = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();
            TakeDamage(bullet.damage);
            Debug.Log("Bullet 맞음 , 남은피:" + currentHealth + "총알 대미지:" + bullet.damage);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // 공격에 의한 체력감소

        if (currentHealth <= 0)
        {
            Die(); // 체력이 0 이하이면 사망 처리
        }
    }


    private void Die()
    {
        // 사망연출
        //사망처리

        Destroy(gameObject, 0.5f);
        gameObject.SetActive(false);

    }
}
