using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject gametitle;                                       // ������ ���� �Լ��� ������ ������Ʈ (���� Ÿ��Ʋ �̹���)

    [SerializeField]
    private float repeatTime = 2f;                                      // �ݺ� �ֱ� �ð�

    [SerializeField]
    private float sizeRate = 1.5f;                                      // ũ�� ����

    private Vector3 titleSize;                                          // �̹��� ������ ���� ����
  

    private void Awake()
    {
        titleSize = gametitle.transform.localScale;
        StartCoroutine(StartSize());
    }

    // �ʱ⿡ ȣ��Ǵ� �ݺ� �ڷ�ƾ�� ���� �ڷ�ƾ
    private IEnumerator StartSize()
    {
        while (true)
        {
            yield return StartCoroutine(Zoom(titleSize, titleSize * sizeRate));

            yield return StartCoroutine(Zoom(sizeRate * titleSize, titleSize));
        }
    }

    // �������� ������ ����Ʈ �ڷ�ƾ
    private IEnumerator Zoom(Vector3 start, Vector3 end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / repeatTime;

            Vector3 curSize = Vector3.Lerp(start, end, percent);
            gametitle.transform.localScale = curSize;

            yield return null;
        }
    }
}
