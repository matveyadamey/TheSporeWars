using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Win : MonoBehaviour
{
    [SerializeField] private static GameObject _winScreen;

    public static void SetWinScreen(GameObject winScreen)
    {
        _winScreen = winScreen;
        
    }

    public static void ShowWinScreen()
    {
        print("Win");
        _winScreen.SetActive(true);
        _winScreen.transform.Find("PlayerNumber").GetComponent<TMP_Text>().text = "победил игрок " + NumberWinningPlayer().ToString();
        Raycaster.OffGame();
    }

    public static int NumberWinningPlayer()
    {
        for (int i = 0; i < PlayersContainer.Players.Length; i++)
        {
            if (PlayersContainer.Players[i].IsChipsInCenter())
            {
                return i + 1;
            }
        }
        return 0;
    }


}
