using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;                     
    public int curHealth;

    [SerializeField]
    private Image panelPlayerBlood;                                     // 플레이어 타격시 빨간 이펙트를 위한 이미지 UI (은수 작성)

    [SerializeField]
    private float bloodScreenCoolTime;                                  // 빨간 이미지의 반복 주기 (은수 작성)

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

    // 필드 함정 진입시 타격 효과 (은수 작성)
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

    // 플레이어 빨간 판넬 효과 (은수 작성)
    public IEnumerator FielPanelDamageEffect()
    {
        yield return new WaitForSeconds(1f);

        StartCoroutine("PanelDamageEffect");
    }

    // 플레이어 빨간 판넬 효과 (은수 작성)
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

    // 플레이어 피격 효과 (은수 작성)
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
