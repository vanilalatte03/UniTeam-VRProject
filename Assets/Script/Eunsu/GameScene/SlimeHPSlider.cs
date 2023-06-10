using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlimeHPSlider : MonoBehaviour
{
    [SerializeField]
    private GameObject slimeHpPanel;                                            // 슬라임 hp 판넬 부모 오브젝트

    [SerializeField]
    private Slider slimeHpSlider;                                               // 슬라임 hp Slider UI

    [SerializeField]
    private TextMeshProUGUI textMonsterHP;                                      // 슬라임 hp text UI

    // 슬라임(몬스터이 플레이어에 의해 타격을 입었을 시 호출되는 함수
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

    // UI 업데이트 함수
    public void MonsterHPUIClose()
    {
        slimeHpPanel.SetActive(false);
    }
}
