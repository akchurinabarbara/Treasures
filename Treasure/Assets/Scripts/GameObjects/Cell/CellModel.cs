using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Модель, хранящая все необхордимые данные об игровых ячейках
public class CellModel
{
    #region fields
    //Объект ячейки
    private GameObject _gameObject;
    //Имеет ли ячейка сокровище
    private bool _haveTreasure = false;
    private Location _location;
    #endregion

    #region properties
    public GameObject GameObject
    {
        get { return _gameObject; }
        set { _gameObject = value; }
    }

    public bool HaveTreasure
    {
        get { return _haveTreasure; }
        set { _haveTreasure = value; }
    }

    public Location Location
    {
        get { return _location; }
        set { _location = value; }
    }
    #endregion

    #region constructor
    public CellModel(int i, int j)
    {
        _location.i = i;
        _location.j = j;
    }
    #endregion
}

//Структура, хранящщая информацию об расположении клетки
#region Location
public struct Location
{
    #region fields
    //Расположение по i
    private int _i;
    //Расположение по J
    private int _j;
    #endregion
    #region properties
    public int i
    {
        get { return _i; }
        set { _i = value; }
    }

    public int j
    {
        get { return _j; }
        set { _j = value; }
    }
    #endregion
}
#endregion
