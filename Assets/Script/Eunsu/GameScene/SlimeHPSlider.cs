using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlimeHPSlider : MonoBehaviour
{
    [SerializeField]
    private GameObject slimeHpPanel;

    [SerializeField]
    private Slider slimeHpSlider;

    [SerializeField]
    private TextMeshProUGUI textMonsterHP;

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

    public void MonsterHPUIClose()
    {
        slimeHpPanel.SetActive(false);
    }
}
