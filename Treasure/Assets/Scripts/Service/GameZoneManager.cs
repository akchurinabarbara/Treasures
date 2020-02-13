using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Хранение информации о клетках игрового поля
public class GameZoneManager
{

 #region field
    //Массив клеток игровой зоны
    private GameObject[,] _cells;

    //Цетр игрового пространства
    private Vector3 _gameZoneCenter;
#endregion

#region properties
    public GameObject[,] Cells
    {
        get { return _cells; }
        set { _cells = value; }
    }

    public Vector3 GameZoneCenter
    {
        get { return _gameZoneCenter; }
        set { _gameZoneCenter = value; }
    }
#endregion

}
