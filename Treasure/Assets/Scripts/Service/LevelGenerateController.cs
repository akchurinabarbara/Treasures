using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Управление уровнем (его генерацией и уничтожением)
public class LevelGenerateManager
{

#region fields
    //Коэффициент для определения размера объекта board
    private float _boardCoef = 6.0f;
#endregion

#region methods
    //Генерация уровна
    public void Generate()
    {
        GameObject gameZone = GameObject.FindGameObjectWithTag(TagConfig.GAME_ZONE);
        
        GameObject[,] cellsArray = new GameObject[AppContext.GameManager.M, AppContext.GameManager.N];

        //Генерация номеров для расположения сокровищ
        List<Location> treasureCoordinates = new List<Location>();

        for (int i = 0; i < AppContext.GameManager.TreasureCount; i++)
        {
            Location treasureLocation = new Location();
            do
            {
                treasureLocation.i = (int)UnityEngine.Random.Range(0, AppContext.GameManager.M);
                treasureLocation.j = (int)UnityEngine.Random.Range(0, AppContext.GameManager.N);
            }
            while (treasureCoordinates.Exists(element =>  treasureLocation.i == element.i && treasureLocation.j == element.j));
            treasureCoordinates.Add(treasureLocation);
        }

        AppContext.GameManager.TreasureCoordinates = treasureCoordinates;

        //Отображение полей на экране

            for (int i = 0; i < AppContext.GameManager.M; i++)
        {
            for (int j = 0; j < AppContext.GameManager.N; j++)
            {
                if (treasureCoordinates.Exists(element => i == element.i && j == element.j))
                {
                    cellsArray[i, j] = GameObject.Instantiate(Resources.Load(PrefubsNameConfig.pfTREASURECELL, typeof(GameObject))) as GameObject;
                }
                else
                {
                    cellsArray[i, j] = GameObject.Instantiate(Resources.Load(PrefubsNameConfig.pfCELL, typeof(GameObject))) as GameObject;
                }

                //Вычисление координат
                Vector3 cellPosition = new Vector3(gameZone.transform.position.x + i * 25,
                                                    gameZone.transform.position.y,
                                                    gameZone.transform.position.z + j * 25);
                cellsArray[i, j].transform.position = cellPosition;
                cellsArray[i, j].transform.SetParent(gameZone.transform);

                cellsArray[i, j].transform.GetComponent<CellController>().Location = new Location(i, j);     

            }
        }


        AppContext.GameZoneManager.Cells = cellsArray;

        //Вычисление координат центра игрового поля
        int middleI = AppContext.GameManager.M / 2;
        int middleJ = AppContext.GameManager.N / 2;

        float boardX;
        float boardZ;

        if (0 != AppContext.GameManager.M % 2)
        {
            boardX = cellsArray[middleI, middleJ].transform.position.x;
        }
        else
        {
            boardX = (cellsArray[middleI - 1, middleJ - 1].transform.position.x + cellsArray[middleI, middleJ].transform.position.x) / 2;
        }

        if (0 != AppContext.GameManager.N % 2)
        {
            boardZ = cellsArray[middleI, middleJ].transform.position.z;
        }
        else
        {
            boardZ = (cellsArray[middleI - 1, middleJ - 1].transform.position.z + cellsArray[middleI, middleJ].transform.position.z) / 2;
        }

        AppContext.GameZoneManager.GameZoneCenter = new Vector3(boardX, gameZone.transform.position.y, boardZ);        

        GameObject board = GameObject.Instantiate(Resources.Load(PrefubsNameConfig.pfBOARD, typeof(GameObject))) as GameObject;
        board.transform.SetParent(gameZone.transform);

        board.transform.localScale = new Vector3(cellsArray[0, 0].transform.localScale.x * AppContext.GameManager.M / _boardCoef,
                                                        board.transform.localScale.y,
                                                        cellsArray[0, 0].transform.localScale.z * AppContext.GameManager.N / _boardCoef);
        board.transform.position = AppContext.GameZoneManager.GameZoneCenter;

        //Изменение положения камеры
        Camera.main.transform.GetComponent<CameraPositionController>().SetStartPosition();

    }

    //Уничтожение уровня
    public void DestroyLevel()
    {
        foreach (GameObject cell in GameObject.FindGameObjectsWithTag(TagConfig.CELL))
        {
            GameObject.Destroy(cell);
        }

        GameObject.Destroy(GameObject.FindGameObjectWithTag(TagConfig.GAME_BOARD));
    }
#endregion

}
