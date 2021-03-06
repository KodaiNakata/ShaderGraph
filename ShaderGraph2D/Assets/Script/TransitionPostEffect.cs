using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPostEffect : MonoBehaviour
{
    [SerializeField]
    private Material postEffectMaterial;

    [SerializeField]
    private float transitionTime;

    private readonly int _progress = Shader.PropertyToID("_Progress");

    private readonly int _direct = Shader.PropertyToID("_Direct");

    private readonly int _leftRight = Shader.PropertyToID("_LeftRight");

    private readonly int _rightLeft = Shader.PropertyToID("_RightLeft");

    private void Start()
    {
        if (postEffectMaterial != null)
        {
            StartCoroutine(Transition4());
        }
    }

    private IEnumerator Transition()
    {
        float t = 0f;
        while (t < transitionTime)
        {
            float progess = t / transitionTime;
            postEffectMaterial.SetFloat(_progress, progess);
            yield return null;
            t += Time.deltaTime;
        }
        postEffectMaterial.SetFloat(_progress, 2f);
    }

    private IEnumerator Transition1()
    {
        float t = -1f;
        while (t < transitionTime)
        {
            float progess = t / transitionTime;
            if (progess >= 0f)
            {
                break;
            }
            postEffectMaterial.SetFloat(_progress, -progess);
            yield return null;
            t += Time.deltaTime;
        }
        postEffectMaterial.SetFloat(_progress, -0.001f);
    }

    private IEnumerator Transition2()
    {
        float t = 0f;
        while (t < 17f)
        {
            float progess = t;
            postEffectMaterial.SetFloat(_progress, progess);
            yield return null;
            t += Time.deltaTime;
        }
        postEffectMaterial.SetFloat(_progress, 17f);
    }

    private IEnumerator Transition3()
    {
        float t = 0f;
        float d = 0f;
        while (d < 2f)
        {
            float progess = t;
            float direct = d;
            postEffectMaterial.SetFloat(_progress, progess);
            postEffectMaterial.SetFloat(_direct, direct);
            yield return null;
            t += Time.deltaTime;
            d += Time.deltaTime * 2f;
        }
        postEffectMaterial.SetFloat(_progress, 1f);
        postEffectMaterial.SetFloat(_direct, 2f);
    }

    private IEnumerator Transition4()
    {
        float t1 = 0f;
        float t2 = 1f;

        while (t1 < 1f)
        {
            float progress1 = t1;
            float progress2 = t2;
            postEffectMaterial.SetFloat(_leftRight, progress1);
            postEffectMaterial.SetFloat(_rightLeft, progress2);
            yield return null;
            t1 += Time.deltaTime;
            t2 -= Time.deltaTime;
        }
        postEffectMaterial.SetFloat(_leftRight, 1f);
        postEffectMaterial.SetFloat(_rightLeft, 0f);
    }
}
