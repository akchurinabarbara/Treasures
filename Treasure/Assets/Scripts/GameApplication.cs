using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Основная логика приложения, управление всеми менеджерами 
public class GameApplication : MonoBehaviour
{
    // Размеры поля
    public int m = 10;  // клетки в строке
    public int n = 15;  // строк

    // Количество доступных игроку локаторов
    public int sonarCount = 10;

    //Радиус сонара
    public int sonarRadius = 10;

    //Количество сокровищ на карте 
    public int treasureCount = 5;

    private void Awake()
    {
        AppContext.Configure();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        AppContext.GameManager.M =  m;
        AppContext.GameManager.N = n;
        AppContext.GameManager.StartSonarCount = sonarCount;
        AppContext.GameManager.SonarRadius = sonarRadius;
        AppContext.GameManager.TreasureCount = treasureCount;
    }

    void Update()
    {
        if (AppContext.GameManager == null)
        {
            return;
        }
    }
}
