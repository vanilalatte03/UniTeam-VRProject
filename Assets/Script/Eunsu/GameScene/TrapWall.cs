using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrapWall : MonoBehaviour
{
    [SerializeField]
    private int maxWallHP;
    private int curWallHP;

    [SerializeField]
    private GameObject wallHpPanel;

    [SerializeField]
    private Slider wallHpSlider;

    [SerializeField]
    private TextMeshProUGUI textWallHp;

    private MeshRenderer MeshRenderer;

    private void Awake()
    {
        curWallHP = maxWallHP;
        MeshRenderer = GetComponent<MeshRenderer>();
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
        textWallHp.text = $"{curWallHP} / {maxWallHP}";
        wallHpSlider.value = (float)curWallHP / maxWallHP;
    }

    public void FadeOnStart()
    {
        gameObject.SetActive(true);
        wallHpPanel.SetActive(true);
        StartCoroutine(FadeEffect());
    }

    private IEnumerator FadeEffect()
    {
        float curTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1f)
        {
            curTime += Time.deltaTime;
            percent = curTime / 1;
            
            Color color = MeshRenderer.materials[0].color;
            color.a = Mathf.Lerp(0, 1, percent);
            MeshRenderer.materials[0].color = color;

            yield return null;
        }
    }
}
