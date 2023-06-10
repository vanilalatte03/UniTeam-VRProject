using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject gametitle;                                       // 사이즈 조정 함수를 적용할 오브젝트 (게임 타이틀 이미지)

    [SerializeField]
    private float repeatTime = 2f;                                      // 반복 주기 시간

    [SerializeField]
    private float sizeRate = 1.5f;                                      // 크기 비율

    private Vector3 titleSize;                                          // 이미지 사이즈 저장 벡터
  

    private void Awake()
    {
        titleSize = gametitle.transform.localScale;
        StartCoroutine(StartSize());
    }

    // 초기에 호출되는 반복 코루틴의 시작 코루틴
    private IEnumerator StartSize()
    {
        while (true)
        {
            yield return StartCoroutine(Zoom(titleSize, titleSize * sizeRate));

            yield return StartCoroutine(Zoom(sizeRate * titleSize, titleSize));
        }
    }

    // 실질적인 사이즈 이펙트 코루틴
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
