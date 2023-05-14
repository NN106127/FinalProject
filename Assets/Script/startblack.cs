using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class startblack : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    private Coroutine vignetteCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out vignette);
        if (vignetteCoroutine != null)
        {
            StopCoroutine(vignetteCoroutine);
        }

        vignetteCoroutine = StartCoroutine(ChangeVignetteIntensity());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator ChangeVignetteIntensity()
    {
        float time = 1f;
        float duration = 1f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = time / duration;
            float intensity = Mathf.Lerp(0f, 1f, t);

            vignette.intensity.value = intensity;

            yield return null;
        }

        time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = time / duration;
            float intensity = Mathf.Lerp(1f, 0f, t);

            vignette.intensity.value = intensity;

            yield return null;
        }

        vignette.intensity.value = 0f;
    }
}
