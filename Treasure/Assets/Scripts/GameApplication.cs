using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Управление всеми менеджерами и задание характеристик уровня
public class GameApplication : MonoBehaviour
{

#region fields
    // Размеры поля
    public int m = 10;  // клетки в строке
    public int n = 15;  // строк

    // Количество доступных игроку локаторов
    public int sonarCount = 10;

    //Радиус сонара
    public int sonarRadius = 10;

    //Количество сокровищ на карте 
    public int treasureCount = 5;
#endregion

 #region methods
    //Создание всез менеджеров и задание значений для игры через редактор Unity
    private void Awake()
    {
        AppContext.Configure();
        AppContext.GameManager.M = m;
        AppContext.GameManager.N = n;
        AppContext.GameManager.StartSonarCount = sonarCount;
        AppContext.GameManager.SonarRadius = sonarRadius;
        AppContext.GameManager.TreasureCount = treasureCount;
    }

    //Выход из игры
    public void ExitGame()
    {
        Application.Quit();
    }



    void Update()
    {
        if (AppContext.GameManager == null)
        {
            return;
        }
    }
#endregion

}
