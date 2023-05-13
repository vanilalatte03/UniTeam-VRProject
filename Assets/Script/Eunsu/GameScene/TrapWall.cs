using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrapWall : MonoBehaviour
{
    private int maxWallHP = 300;
    private int curWallHP;

    [SerializeField]
    private GameObject wallHpPanel;

    [SerializeField]
    private Slider wallHpSlider;

    [SerializeField]
    private TextMeshProUGUI textWallHp;

    private void Awake()
    {
        curWallHP = maxWallHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            curWallHP -= bullet.damage;
            Destroy(bullet.gameObject);
            wallHpSlider.value = (float) curWallHP / maxWallHP;
            textWallHp.text = $"{curWallHP} / {maxWallHP}";
            
            if (curWallHP <= 0)
            {
                InitializeTrapWall();
            }
        }
    }

    public void InitializeTrapWall()
    {
        curWallHP = maxWallHP;
        gameObject.SetActive(false);
        wallHpPanel.SetActive(false);
    }
}
