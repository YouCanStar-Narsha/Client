using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeInOut : MonoBehaviour
{
    public enum FadeInOut
    {
        FadeIn,
        FadeOut
    }

    [Header("Value")]
    [SerializeField] private FadeInOut fadeInOut;
    public bool jobCompleate;

    [Header("Cashing")]
    [SerializeField] private GameObject blackScreen;

    private Image blackScreenImage = null;

    private void Start()
    {
        blackScreenImage = Instantiate(blackScreen, FindObjectOfType<Canvas>().transform).GetComponent<Image>();

        switch (fadeInOut)
        {
            case FadeInOut.FadeIn:
                SetColorA(0);
                StartCoroutine(FadeIn());
                break;
            case FadeInOut.FadeOut:
                StartCoroutine(FadeOut());
                break;
        }
    }

    private IEnumerator FadeIn()
    {
        for (int count = 1; count <= 255; count += 3)
        {
            SetColorA(count / 255f);
            yield return null;
        }

        jobCompleate = true;
    }

    private IEnumerator FadeOut()
    {
        for (int count = 255; count > 0; count -= 3)
        {
            SetColorA(count / 255f);
            yield return null;
        }

        blackScreenImage.gameObject.SetActive(false);
        jobCompleate = true;
    }

    private void SetColorA(float value)
    {
        if (blackScreenImage == null) return;

        blackScreenImage.color = new Color(blackScreenImage.color.r, blackScreenImage.color.g, blackScreenImage.color.b, value);
    }
}
