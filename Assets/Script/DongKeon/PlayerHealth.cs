using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;                     
    public int curHealth;

    [SerializeField]
    private Image panelPlayerBlood;                                     // �÷��̾� Ÿ�ݽ� ���� ����Ʈ�� ���� �̹��� UI (���� �ۼ�)

    [SerializeField]
    private float bloodScreenCoolTime;                                  // ���� �̹����� �ݺ� �ֱ� (���� �ۼ�)

    private void Awake()
    {
        curHealth = maxHealth;        
    }

    private void Start()
    {  
        GameManager.Instance.PlayerHPUIUpdate(curHealth, maxHealth);    
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

    // �ʵ� ���� ���Խ� Ÿ�� ȿ�� (���� �ۼ�)
    public void FieldDamage(int damage)
    {
        curHealth -= damage;
        GameManager.Instance.PlayerHPUIUpdate(curHealth, maxHealth);
        StartCoroutine("FielPanelDamageEffect");

        if (curHealth <= 0)
        {
            curHealth = 0;
            ScoreManager.Instance.SetScore();
            GameManager.Instance.GameFail();           
            return;
        }
    }

    // �÷��̾� ���� �ǳ� ȿ�� (���� �ۼ�)
    public IEnumerator FielPanelDamageEffect()
    {
        yield return new WaitForSeconds(1f);

        StartCoroutine("PanelDamageEffect");
    }

    // �÷��̾� ���� �ǳ� ȿ�� (���� �ۼ�)
    private IEnumerator PanelDamageEffect()
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        float redAlpha = 0.6f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / bloodScreenCoolTime;

            float alpha = percent > redAlpha ? redAlpha : percent;

            panelPlayerBlood.color = new Color(255, 0, 0, redAlpha - alpha);

            yield return null;
        }
    }

    // �÷��̾� �ǰ� ȿ�� (���� �ۼ�)
    public void TakeDamage(int damageAmount)
    {
        curHealth -= damageAmount;
        GameManager.Instance.PlayerHPUIUpdate(curHealth, maxHealth);
        StartCoroutine("PanelDamageEffect");
        if (curHealth <= 0)
        {
            curHealth = 0;
            ScoreManager.Instance.SetScore();
            GameManager.Instance.GameFail();
        }
    }
}
