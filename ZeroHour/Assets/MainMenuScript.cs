using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject buttons;
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Credits()
    {
        StartCoroutine(CreditsCoroutine());
    }
    private IEnumerator CreditsCoroutine()
    {
        yield return Fade(buttons, 0f, 0.7f);
        yield return Fade(credits, 1f, 0.7f);

        yield return new WaitForSeconds(4f);

        yield return Fade(credits, 0f, 0.7f);
        yield return Fade(buttons, 1f, 0.7f);
    }
    private IEnumerator Fade(GameObject panel, float targetAlpha, float duration)
    {
        if (targetAlpha > 0f) panel.SetActive(true);

        Graphic[] graphics = panel.GetComponentsInChildren<Graphic>();

        float[] startAlphas = new float[graphics.Length];
        
        for (int i = 0; i < graphics.Length; i++)
        {
            startAlphas[i] = graphics[i].color.a;
        }

        float timer = 0f;
        float newAlpha;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            for (int i = 0; i < graphics.Length; i++)
            {
                Color color = graphics[i].color;
                newAlpha = Mathf.Lerp(startAlphas[i], targetAlpha, timer / duration);
                color.a = newAlpha;
                graphics[i].color = color;
            }
            yield return null;
        }

        if (targetAlpha == 0f) panel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
