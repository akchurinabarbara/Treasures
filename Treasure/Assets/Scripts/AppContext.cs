using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Контекст приложения (текущее состояние всех его частей)
public static class AppContext 
{
    #region Fields
    //Состояние игрового "поля"
    private static GameManager _gameManager;
    #endregion

    #region Properties
    public static GameManager GameManager
    {
        get { return _gameManager; }
    }
    #endregion

    #region Methods
    //Инициализация состояний 
    public static void Configure()
    {
        _gameManager = new GameManager();
    }
    #endregion
}
