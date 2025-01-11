using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manage : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GameReadyAPI();

    [SerializeField] bool isYandex;

    [SerializeField] GameObject ExitButton;
    [SerializeField] GameObject Yandex;
    [SerializeField] GameObject AntiAliasing;
    [SerializeField] GameObject PostProcessing;

    private void Start()
    {
        if (isYandex)
        {
            ExitButton.SetActive(false);
            Yandex.SetActive(true);
            AntiAliasing.SetActive(false);
            PostProcessing.SetActive(false);
            GameReadyAPI();
        }
    }

    public void LoadScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Telegram()
    {
        Application.OpenURL("https://t.me/Yuhgames");
    }
}
