using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Контекст приложения (текущее состояние всех его частей)
public static class AppContext 
{
    #region Fields
    //Состояние текущей игры
    private static GameManager _gameManager;
    //Состояние координат игрового "поля"
    private static LocationManager _locationManager;
    //Состояния игрового поля и его ячеек
    private static CellsManager _cellsManager;
    #endregion

    #region Properties
    public static GameManager GameManager
    {
        get { return _gameManager; }
    }

    public static LocationManager LocationManager
    {
        get { return _locationManager; }
    }

    public static CellsManager CellsManager
    {
        get { return _cellsManager; }
    }
    #endregion

    #region Methods
    //Инициализация состояний 
    public static void Configure()
    {
        _gameManager = new GameManager();
        _locationManager = new LocationManager();
        _cellsManager = new CellsManager();
    }
    #endregion
}
