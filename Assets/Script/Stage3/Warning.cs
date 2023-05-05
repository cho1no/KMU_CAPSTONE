using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject alertLine;
    float fadeTime = 0.01f;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("TwinkleLoop");
        StartCoroutine("SpawnAlertLine");
    }
    IEnumerator TwinkleLoop()
    {
        while (true)
        {
            //Alpha 값을 1에서 0으로 :Fade out
            yield return StartCoroutine(FadeEffect(1, 0));
            //Alpha 값을 1에서 0으로 :Fade in
            yield return StartCoroutine(FadeEffect(0, 1));
        }
    }
    IEnumerator FadeEffect(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        while (percent < 1)
        {
            currentTime = Time.deltaTime;
            percent = currentTime / fadeTime;
            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(start, end, percent);
            spriteRenderer.color = color;
            yield return null;
        }
    }
    IEnumerator SpawnAlertLine()
    {
        while (true)
        {
            GameObject alertLinePrefab = Instantiate(alertLine, new Vector3(0, 0, 0), Quaternion.identity);
            alertLinePrefab.transform.position = new Vector3(2, gameObject.transform.position.y, 0);
            yield return new WaitForSeconds(1.0f);
            Destroy(alertLinePrefab);
        }
    }
}
