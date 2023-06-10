using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlimeHPSlider : MonoBehaviour
{
    [SerializeField]
    private GameObject slimeHpPanel;                                            // ������ hp �ǳ� �θ� ������Ʈ

    [SerializeField]
    private Slider slimeHpSlider;                                               // ������ hp Slider UI

    [SerializeField]
    private TextMeshProUGUI textMonsterHP;                                      // ������ hp text UI

    // ������(������ �÷��̾ ���� Ÿ���� �Ծ��� �� ȣ��Ǵ� �Լ�
    public void SlimeHPSliderUpdate(int currentHealth, int maxHealth)
    {
        if (slimeHpPanel.activeSelf == false)
        {
            slimeHpPanel.SetActive(true);
        }

        slimeHpSlider.value = (float)currentHealth / maxHealth;
        textMonsterHP.text = $"{currentHealth} / {maxHealth}";       

        if (currentHealth <= 0)
        {
            slimeHpPanel.SetActive(false); 
        }
    }

    // UI ������Ʈ �Լ�
    public void MonsterHPUIClose()
    {
        slimeHpPanel.SetActive(false);
    }
}
