using System.Collections.Generic;
using UnityEngine;
public class Highlighter : MonoBehaviour
{
    public static void HighlightOn(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }
    public static void HighlightOff(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
    public static void HiglightPossiblePlacesToMove(int chipIndex, bool isActive)
    {
        Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];
        List<Point> possiblePlacesToMove = player.GetPossiblePlacesMoveTo(chipIndex);

        foreach (Point possiblePlaceMoveTo in possiblePlacesToMove)
        {
            Field.SetCellMaterial(possiblePlaceMoveTo, isActive);
        }
    }
}
