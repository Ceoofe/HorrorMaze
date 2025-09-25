using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Button play;
    Button exit;

    // Start is called before the first frame update
    void Start()
    {
        play = transform.Find("Panel/Play").GetComponent<Button>();
        exit = transform.Find("Panel/Exit").GetComponent<Button>();

        play.onClick.AddListener(Play);
        exit.onClick.AddListener(Exit);
    }

    void Play()
    {
        SceneManager.LoadScene(1);
    }
    void Exit()
    {
        Application.Quit();
    }
}
