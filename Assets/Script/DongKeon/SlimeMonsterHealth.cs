using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMonsterHealth : MonoBehaviour
{
    public int maxHealth = 100;    //�ִ�ü��
    private int currentHealth;    //����ü��

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
            Debug.Log("Bullet ���� , ������:" + currentHealth + "�Ѿ� �����:" + bullet.damage);
        }
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
