using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject gametitle;

    [SerializeField]
    private float repeatTime = 2f;

    [SerializeField]
    private float sizeRate = 1.5f;

    private Vector3 titleSize;
  

    private void Awake()
    {
        titleSize = gametitle.transform.localScale;
        StartCoroutine(StartSize());
    }

    private IEnumerator StartSize()
    {
        while (true)
        {
            yield return StartCoroutine(Zoom(titleSize, titleSize * sizeRate));

            yield return StartCoroutine(Zoom(sizeRate * titleSize, titleSize));
        }
    }

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
