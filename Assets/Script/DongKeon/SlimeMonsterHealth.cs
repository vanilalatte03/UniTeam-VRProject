using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMonsterHealth : MonoBehaviour
{
    public int maxHealth = 100;    //�ִ�ü��
    private int currentHealth;    //����ü��

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // ���ݿ� ���� ü�°���

        if (currentHealth <= 0)
        {
            Die(); // ü���� 0 �����̸� ��� ó��
        }
    }

    private void Die()
    {
        // �������
        //���ó��

        Destroy(gameObject, 0.5f);
        gameObject.SetActive(false);

    }
}
