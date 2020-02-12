using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameZoneManager
{

    #region field
    //Массив клеток игровой зоны
    private GameObject[,] _cells;
    #endregion

    #region properties
    public GameObject[,] Cells
    {
        get { return _cells; }
        set { _cells = value; }
    }
    #endregion
}
