using UnityEngine;

public class Raycaster : MonoBehaviour
{
    Vector3 clickPosition;
    GameObject _clickedObject;
    private static bool _isGameContinue = true;
    private static int _costDeleting = 0; 
    void moveChip()
    {
        Point lastClick = new Point((int)clickPosition.x, (int)clickPosition.z);
        CurrentPlayer.MovementChip.Move(lastClick);
    }
    void buyObject()
    {
        Vector3 place = new Vector3(clickPosition.x, 1, clickPosition.z);

        Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];
        Point p = new Point((int)place.x, (int)place.z);

        if (!player.CanBuyObject(CurrentPlayer.TypePurchasedObject, p))
        {
            return;
        }

        Field.DeleteCoin(p);

        GameObject spawnedObject = ObjectSpawner.SpawnObject(CurrentPlayer.TypePurchasedObject, CurrentPlayer.PurchasedObject, place, Quaternion.identity);

        if (CurrentPlayer.TypePurchasedObject.Type != "turret")
        {
            CurrentPlayer.NextPlayer();
        }
        if (CurrentPlayer.MovementChip != null)
        {
            Highlighter.HiglightPossiblePlacesToMove(CurrentPlayer.MovementChip.chipNumber, false);
            Highlighter.HighlightOff(CurrentPlayer.MovementChip.gameObject);
        }
        CurrentPlayer.OperatingMode = "expectation";
        CurrentPlayer.TypePurchasedObject = null;
        CurrentPlayer.PurchasedObject = null;
    }

    public void DeleteObjectOnClick()
    {
        Point click = new((int)clickPosition.x, (int) clickPosition.z);
        GameObject obj = _clickedObject;
        if (MapObject.GetObject(click) == null || PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber].CountCoins < _costDeleting)
            return;
        else
        {
            PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber].CountCoins -= _costDeleting;
            ObjectDestroyer1.DeleteObject(obj, click);
        }

    }
    void OnClick()
    {
        switch (CurrentPlayer.OperatingMode)
        {
            case "movement_chip":
                moveChip();
                break;

            case "buy_object":
                buyObject();
                break;
            case "":
                if (_clickedObject != null)
                {
                    DeleteObjectOnClick();
                }
                break;

        }
        _clickedObject = null;
    }

    public static void OffGame() 
    {
        _isGameContinue = false;
    }


    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && _isGameContinue)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject click = hit.collider.gameObject;

                if ((CurrentPlayer.PurchasedObject != null & CurrentPlayer.TypePurchasedObject != null) || CurrentPlayer.MovementChip != null)
                {
                    if (click.transform.position != clickPosition)
                    {
                        if (click.tag == "Cell")
                        {
                            clickPosition = click.transform.position;
                            _clickedObject = click;
                            OnClick();
                        }
                    }
                }
            }
        }
    }

}
