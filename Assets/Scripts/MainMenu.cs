using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Button play;
    Button exit;
    Button settings;
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = transform.Find("Panel").gameObject;
        play = panel.transform.Find("Play").GetComponent<Button>();
        exit = panel.transform.Find("Exit").GetComponent<Button>();
        settings = panel.transform.Find("Settings").GetComponent<Button>();


        play.onClick.AddListener(Play);
        exit.onClick.AddListener(Exit);
        settings.onClick.AddListener(Settings);
    }

    void Play()
    {
        SceneManager.LoadScene(1);
    }
    void Exit()
    {
        Application.Quit();
    }
    void Settings()
    {
        panel.SetActive(false);
    }
    void Credits()
    {

    }
}
