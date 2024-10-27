using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject pause;
    private float initTimeScale;
    void Start()
    {
        initTimeScale = Time.timeScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Pause();
    }
    private void Pause()
    {
        initTimeScale = Time.timeScale;

        Time.timeScale = 0f;
        pause.SetActive(true);
    }
    public void Continue()
    {
        pause.SetActive(false);
        Time.timeScale = initTimeScale;
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = initTimeScale;
    }
}
