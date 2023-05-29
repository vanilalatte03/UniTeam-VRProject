using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMonsterHealth : MonoBehaviour
{
    public int maxHealth = 100;    //�ִ�ü��
    private int currentHealth;    //����ü��

    CapsuleCollider capCollider;

    SlimeHPSlider slimeHPSlider;

    [SerializeField]
    private ParticleSystem monsterDieEffect;

    [SerializeField]
    private AudioSource audioDie;

    private void Awake()
    {
        capCollider = GetComponent<CapsuleCollider>();
        slimeHPSlider = GetComponent<SlimeHPSlider>();
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
            slimeHPSlider.SlimeHPSliderUpdate(currentHealth, maxHealth);
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
        monsterDieEffect.Play();
        monsterDieEffect.transform.SetParent(null);
        Destroy(gameObject, 0.5f);
        gameObject.SetActive(false);

        ScoreManager.Instance.PlusScore("Type_A");
        audioDie.Play();
    }
}
