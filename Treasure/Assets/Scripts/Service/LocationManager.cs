using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Хранит данные для синхронизации расположения объектов
public class LocationManager
{
    #region fields
    //Цетр игрового пространства
    private Vector3 _gameZoneCenter;
    #endregion

    #region properties
    public Vector3 GameZoneCenter
    {
        get { return _gameZoneCenter; }
        set { _gameZoneCenter = value; }
    }
    #endregion
}
