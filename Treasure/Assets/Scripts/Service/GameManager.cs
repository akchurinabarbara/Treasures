using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Общие конфигурации игры. Информация об свойствах раунда (текущего уровня)
public class GameManager
{
#region Fields
    // Размеры поля
    private int _m = 10;  // клетки в строке
    private int _n = 15;  // строк

    // Изначальное Количество доступных игроку локаторов
    private int _startSonarCount = 10;

    // Количество доступных игроку локаторов
    private int _sonarCount = 10;

    //Радиус сонара
    private int _sonarRadius = 10;

    //Количество сокровищ на карте 
    private int _treasureCount = 5;

    //Распрежеление сокровищ по карте
    private List<LocationStruct> _treasureCoordinates;

    //Счет (количетсво найденных сундуков с сокровищями во время текущего раунда
    private int _score = 0;

    //Играет ли игрок или уже завершил раунд
    private bool _isGameStarted = false;

    //Поставлена ли игра на паузу
    private bool _isPaused = false;
#endregion

#region Properties
    public int M
    {
        get { return _m; }
        set { _m = value; }
    }

    public int N
    {
        get { return _n; }
        set { _n = value; }
    }

    public int SonarCount
    {
        get { return _sonarCount; }
        set { _sonarCount = value; }
    }


    public int StartSonarCount
    {
        get { return _startSonarCount; }
        set { _startSonarCount = value; }
    }

    public int SonarRadius
    {
        get { return _sonarRadius; }
        set { _sonarRadius = value; }
    }


    public int TreasureCount
    {
        get { return _treasureCount; }
        set { _treasureCount = value; }
    }

    public List<LocationStruct> TreasureCoordinates
    {
        get { return _treasureCoordinates; }
        set { _treasureCoordinates = value; }
    }

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public bool IsGameStarted
    {
        get { return _isGameStarted; }
        set { _isGameStarted = value; }
    }

    public bool IsPaused
    {
        get { return _isPaused; }
        set { _isPaused = value; }
    }
    #endregion

    #region methods
    public void EndGame(String endText)
    {               
        AppContext.DialogManager.UiHide();
        AppContext.DialogManager.RestartDialogShow();
        RestartDialogController.SetResultText(endText);
        AppContext.LevelGenerateManager.DestroyLevel();
    }
    #endregion

}
