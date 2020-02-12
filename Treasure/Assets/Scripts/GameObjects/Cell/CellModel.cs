using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Модель, хранящая все необхордимые данные об игровых ячейках
public class CellModel
{
    #region fields
    //Объект ячейки
    private GameObject _gameObject;

    //Выделение ячейки 
    private GameObject _selection;

    //Имеет ли ячейка сокровище
    private bool _haveTreasure = false;

    //Игрок уже разместил сонар на этой ячейке
    private bool _haveSonar= false;

    //Местонахождение ячейки
    //Расположение по i
    private int _i;

    //Расположение по J
    private int _j;
    #endregion

    #region properties
    public GameObject GameObject
    {
        get { return _gameObject; }
        set { _gameObject = value; }
    }

    public GameObject Selection
    {
        get { return _selection; }
        set { _selection = value; }
    }

    public bool HaveTreasure
    {
        get { return _haveTreasure; }
        set { _haveTreasure = value; }
    }

    public bool HaveSonar
    {
        get { return _haveSonar; }
        set { _haveSonar = value; }
    }

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

//Структура, хранящщая информацию об расположении клетки
#region Location
public struct LocationStruct
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
