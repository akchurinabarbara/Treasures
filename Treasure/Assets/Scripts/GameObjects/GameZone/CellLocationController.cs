using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Тебе нужно определенно подумать, по каким классам разнести половину кода отсюда

public class CellLocationController : MonoBehaviour
{
    //ToDo Скорее всего, нужно вынести в отдельный менеджер или в GamrManager.
    //Туда же или в GameLoadedManager код с генерацией уровня. Оставить  только отображение

    //Массив полей игрового поля. True - на этой клетке находится сокровище, False - нет
    private bool[,] _cellsZone;

    //Массив GameObject ячеек игрового поля
    //TODO Не забыть переделать на private
    public GameObject[,] _cells;

    //Объект игровой доски. Нужен для определения ограничений перемещений камеры
    private GameObject _gameBoard;

    //Коэффициент для определения размера объекта board
    private float _boardCoef = 6.0f;

    void Start()
    {
        _gameBoard = GameObject.FindGameObjectWithTag("GameBoard");

        //Генерация уровна
        //Инициализвция игрового поля
        _cellsZone = new bool[AppContext.GameManager.M, AppContext.GameManager.N];

        for (int i = 0; i < AppContext.GameManager.M; i++)
        {
            for (int j = 0; j < AppContext.GameManager.N; j++)
            {
                _cellsZone[i, j] = false;
            }
        }

        //Распределение сокровищ по полю
        for (int i = 0; i < AppContext.GameManager.TreasureCount; i++)
        {
            int treasureI = (int)Random.Range(0, AppContext.GameManager.M);
            int treasureJ = (int)Random.Range(0, AppContext.GameManager.N);

            _cellsZone[treasureI, treasureJ] = true;
        }

        //Отображение полей на экране
        _cells = new GameObject[AppContext.GameManager.M, AppContext.GameManager.N];

        for (int i = 0; i < AppContext.GameManager.M; i++)
        {
            for (int j = 0; j < AppContext.GameManager.N; j++)
            {
                _cells[i, j] = Instantiate(Resources.Load("Embeded/Game/Cell/pfCell", typeof(GameObject))) as GameObject;


                //Вычисление координат
                Vector3 cellPosition = new Vector3( transform.position.x + i * 25,
                                                    transform.position.y,
                                                    transform.position.z + j * 25);
                _cells[i, j].transform.position = cellPosition;
                _cells[i, j].transform.SetParent(transform);
            }
        }

        _gameBoard.transform.localScale = new Vector3 ( _cells[0, 0].transform.localScale.x * AppContext.GameManager.M / _boardCoef,
                                                        _gameBoard.transform.localScale.y,
                                                        _cells[0, 0].transform.localScale.z * AppContext.GameManager.N / _boardCoef);

        //Вычисление координат центра игрового поля
        int middleI = AppContext.GameManager.M / 2;
        int middleJ = AppContext.GameManager.N / 2;

        float boardX;
        float boardZ;

        if (0 != AppContext.GameManager.M % 2)
        {
            boardX = _cells[middleI, middleJ].transform.position.x;
        }
        else
        {
            boardX = (_cells[middleI - 1, middleJ - 1].transform.position.x + _cells[middleI, middleJ].transform.position.x) / 2;
        }

        if (0 != AppContext.GameManager.N % 2)
        {
            boardZ = _cells[middleI, middleJ].transform.position.z;
        }
        else
        {
            boardZ = (_cells[middleI - 1, middleJ - 1].transform.position.z + _cells[middleI, middleJ].transform.position.z) / 2;
        }

        AppContext.LocationManager.GameZoneCenter = new Vector3(boardX, transform.position.y, boardZ);

        //TODO Перенести в класс для board

        _gameBoard.transform.position = AppContext.LocationManager.GameZoneCenter;

    }

    void Update()
    {
        
    }
}
