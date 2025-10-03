using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject display;
    GameObject graphics;
    GameObject sounds;
    GameObject controls;
    // Start is called before the first frame update
    void Start()
    {
        Transform panel = transform.Find("SettingsMenu/Panels");

        display = panel.Find("DisplayPanel").gameObject;
        graphics = panel.Find("GraphicsPanel").gameObject;
        sounds = panel.Find("SoundsPanel").gameObject;
        controls = panel.Find("ControlsPanel").gameObject;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Credits()
    {

    }

    public void ShowPanel(GameObject panel)
    {
        display.SetActive(false);
        graphics.SetActive(false);
        sounds.SetActive(false);
        controls.SetActive(false);

        panel.SetActive(true);
    }


}
