using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Тебе нужно определенно подумать, по каким классам разнести половину кода отсюда

public class LevelGenerateController : MonoBehaviour
{
    //ToDo Скорее всего, нужно вынести в отдельный менеджер или в GamrManager.
    //Туда же или в GameLoadedManager код с генерацией уровня. Оставить  только отображение

    //Массив полей игрового поля. True - на этой клетке находится сокровище, False - нет
    private bool[,] _cellsZone;

    //Массив GameObject ячеек игрового поля
    //TODO Не забыть переделать на private
    public GameObject[,] _cells;


    //Коэффициент для определения размера объекта board
    private float _boardCoef = 6.0f;

    void Start()
    {
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


        //Добавление камеры на сцену. Потому что мне нужно, чтобы камера создавалась после этого объекта
        GameObject camera = Instantiate(Resources.Load("Embeded/Game/Camera/pfMainCamera", typeof(GameObject))) as GameObject;
        camera.transform.SetParent(transform);


        GameObject board = Instantiate(Resources.Load("Embeded/Game/Board/pfBoard", typeof(GameObject))) as GameObject;
        board.transform.SetParent(transform);

        //TODO Перенести в класс для board
        board.transform.localScale = new Vector3(_cells[0, 0].transform.localScale.x * AppContext.GameManager.M / _boardCoef,
                                                        board.transform.localScale.y,
                                                        _cells[0, 0].transform.localScale.z * AppContext.GameManager.N / _boardCoef);
        board.transform.position = AppContext.LocationManager.GameZoneCenter;

    }

}
