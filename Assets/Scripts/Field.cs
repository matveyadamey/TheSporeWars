using UnityEngine;
using System;

public static class Field
{
    private static int Size = StartGame.Size;
    private static GameObject[][] _coordNet = new GameObject[Size][];
    private static GameObject[][] _coinsCoordNet = new GameObject[Size][];


    public static int GetCellLayer(Point point)
    {
        return Mathf.Min(Mathf.Min(point.x, Size - point.x - 1), Mathf.Min(point.y, Size - point.y - 1));
    }

    public static void SetCellMaterial(Point point, bool isCellActive)
    {
        if (isCellActive)
        {
            _coordNet[point.x][point.y].GetComponent<Renderer>().enabled = isCellActive;
        }
        else
        {
            if (!Field.IsCentralCells(point.x, point.y))
            {
                _coordNet[point.x][point.y].GetComponent<Renderer>().enabled = isCellActive;
            }
        } 
    }

    public static bool IsCentralCells(double i, double j)
    {
        //MonoBehaviour.print(i.ToString() + " " + j.ToString());


        return (i == Math.Ceiling((double)Size/ 2)-1 | i == Math.Ceiling((double)Size / 2)) &
            (j == Math.Ceiling((double)Size / 2) -1 | j == Math.Ceiling((double)Size / 2));
    }



    public static void DeleteCoin(Point p)
    {
        if (_coinsCoordNet[p.x][p.y] != null)
        {
            MonoBehaviour.Destroy(_coinsCoordNet[p.x][p.y]);
            MapCoins.DeleteCoin(p);
        }
    }

    public static void FieldAndCoinsSpawn()
    {
        for (int i = 0; i < Size; i++)
        {
            _coordNet[i] = new GameObject[Size];
            _coinsCoordNet[i] = new GameObject[Size];

            for (int j = 0; j < Size; j++)
            {
                if (MapCoins.GetCoinValue(new Point(i, j)) > 0)
                {
                    GameObject coin = UnityEngine.Object.Instantiate(StartGame.CoinPrefab, new Vector3(i, 1, j), Quaternion.identity, StartGame.CoinParent);
                    _coinsCoordNet[i][j] = coin;
                }

                GameObject cube = UnityEngine.Object.Instantiate(StartGame.CellPrefab, new Vector3(i, 0, j), Quaternion.identity, StartGame.CellParent);
                _coordNet[i][j] = cube;
                if (IsCentralCells(i,j))
                {
                    SetCellMaterial(new Point(i, j), true);
                }
                //SetCellMaterial(new Point(i, j), StartGame.Materials[GetCellLayer(new Point(i, j))]);
            }
        }
    }
}