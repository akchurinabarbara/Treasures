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
    //Состояние игрового "поля"
    private static GameZoneManager _gameZonemahager;
    //Менеджер диалоговых окон
    private static DialogManager _dialogManager;
    //Менеджер генерации уровня
    private static LevelGenerateManager _levelGenerateManager;
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

    public static GameZoneManager GameZoneManager
    {
        get { return _gameZonemahager; }
    }

    public static DialogManager DialogManager
    {
        get { return _dialogManager; }
    }

    public static LevelGenerateManager LevelGenerateManager
    {
        get { return _levelGenerateManager; }
    }
    #endregion

    #region Methods
    //Инициализация состояний 
    public static void Configure()
    {
        _gameManager = new GameManager();
        _locationManager = new LocationManager();
        _gameZonemahager = new GameZoneManager();
        _dialogManager = new DialogManager();
        _levelGenerateManager = new LevelGenerateManager();
    }
    #endregion
}
