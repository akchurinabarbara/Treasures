using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Тебе нужно определенно подумать, по каким классам разнести половину кода отсюда

public class LevelGenerateController : MonoBehaviour
{
    //ToDo Скорее всего, нужно вынести в отдельный менеджер или в GamrManager.
    //Туда же или в GameLoadedManager код с генерацией уровня. Оставить  только отображение
    
    //Коэффициент для определения размера объекта board
    private float _boardCoef = 6.0f;

    void Start()
    {
        //Генерация уровна
        AppContext.CellsManager.Initialization();
        CellModel[,] cellsArray = AppContext.CellsManager.Cells;

        //Распределение сокровищ по полю
        for (int i = 0; i < AppContext.GameManager.TreasureCount; i++)
        {
            int treasureI = (int)Random.Range(0, AppContext.GameManager.M);
            int treasureJ = (int)Random.Range(0, AppContext.GameManager.N);

            cellsArray[treasureI, treasureJ].HaveTreasure = true;
        }

        //Отображение полей на экране

        for (int i = 0; i < AppContext.GameManager.M; i++)
        {
            for (int j = 0; j < AppContext.GameManager.N; j++)
            {
                cellsArray[i, j].GameObject = Instantiate(Resources.Load("Embeded/Game/Cell/pfCell", typeof(GameObject))) as GameObject;


                //Вычисление координат
                Vector3 cellPosition = new Vector3( transform.position.x + i * 25,
                                                    transform.position.y,
                                                    transform.position.z + j * 25);
                cellsArray[i, j].GameObject.transform.position = cellPosition;
                cellsArray[i, j].GameObject.transform.SetParent(transform);
            }
        }

        //Вычисление координат центра игрового поля
        int middleI = AppContext.GameManager.M / 2;
        int middleJ = AppContext.GameManager.N / 2;

        float boardX;
        float boardZ;

        if (0 != AppContext.GameManager.M % 2)
        {
            boardX = cellsArray[middleI, middleJ].GameObject.transform.position.x;
        }
        else
        {
            boardX = (cellsArray[middleI - 1, middleJ - 1].GameObject.transform.position.x + cellsArray[middleI, middleJ].GameObject.transform.position.x) / 2;
        }

        if (0 != AppContext.GameManager.N % 2)
        {
            boardZ = cellsArray[middleI, middleJ].GameObject.transform.position.z;
        }
        else
        {
            boardZ = (cellsArray[middleI - 1, middleJ - 1].GameObject.transform.position.z + cellsArray[middleI, middleJ].GameObject.transform.position.z) / 2;
        }

        AppContext.LocationManager.GameZoneCenter = new Vector3(boardX, transform.position.y, boardZ);


        //Добавление камеры на сцену. Потому что мне нужно, чтобы камера создавалась после этого объекта
        GameObject camera = Instantiate(Resources.Load("Embeded/Game/Camera/pfMainCamera", typeof(GameObject))) as GameObject;
        camera.transform.SetParent(transform);


        GameObject board = Instantiate(Resources.Load("Embeded/Game/Board/pfBoard", typeof(GameObject))) as GameObject;
        board.transform.SetParent(transform);

        //TODO Перенести в класс для board
        board.transform.localScale = new Vector3(cellsArray[0, 0].GameObject.transform.localScale.x * AppContext.GameManager.M / _boardCoef,
                                                        board.transform.localScale.y,
                                                        cellsArray[0, 0].GameObject.transform.localScale.z * AppContext.GameManager.N / _boardCoef);
        board.transform.position = AppContext.LocationManager.GameZoneCenter;

    }

}
