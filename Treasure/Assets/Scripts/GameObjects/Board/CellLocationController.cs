using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellLocationController : MonoBehaviour
{
    //ToDo Скорее всего, нужно вынести в отдельный менеджер или в GamrManager.
    //Туда же код с генерацией уровня. Оставить  только отображение

    //Массив полей игрового поля. Trie - на этой клетке находится сокровище, False - нет
    private bool[,] _gameZone;

    //Массив GameObject ячеек игрового поля
    private GameObject[,] _cells;

    void Start()
    {
        //Генерация уровна
        //Инициализвция игрового поля
        _gameZone = new bool[AppContext.GameManager.M, AppContext.GameManager.N];      

        for (int i = 0; i < AppContext.GameManager.M; i++)
        {
            for (int j = 0; j < AppContext.GameManager.N; j++)
            {
                _gameZone[i,j] = false;
            }
        }

        //Распределение сокровищ по полю
        for (int i = 0; i < AppContext.GameManager.TreasureCount; i++)
        {
            int treasureI = (int) Random.Range(0, AppContext.GameManager.M);
            int treasureJ = (int)Random.Range(0, AppContext.GameManager.N);

            _gameZone[treasureI, treasureJ] = true;
        }

        //Отображение полей на экране
        _cells = new GameObject[AppContext.GameManager.M, AppContext.GameManager.N];

        for (int i = 0; i < AppContext.GameManager.M; i++)
        {
            for (int j = 0; j < AppContext.GameManager.N; j++)
            {
                _cells[i,j] = Instantiate(Resources.Load("Embeded/Game/Cell/pfCell", typeof(GameObject))) as GameObject;

                Vector3 cellPosition = new Vector3( transform.position.x + i * 150, 
                                                    transform.position.y, 
                                                    transform.position.z + j * 150);
                _cells[i, j].transform.position = cellPosition;
            }
        }
    }

    void Update()
    {
        
    }
}
