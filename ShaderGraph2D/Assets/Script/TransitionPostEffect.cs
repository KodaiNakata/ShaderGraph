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

    private void Start()
    {
        if (postEffectMaterial != null)
        {
            StartCoroutine(Transition());
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
}
