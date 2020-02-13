using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Управление клеткой игрового поля
public class CellController : MonoBehaviour
{

#region fields
    //Характеристики клетки
    
    //Выделение клетки 
    protected GameObject selection;
    
    //Ссылка на сонар
    protected GameObject sonar;

    //Расположение
    protected Location location;

    //Смещение выделения относительно центра клетки
    private Vector3 _selectionsBias = new Vector3(0.0f, 0.2f, 0.0f);

    //Смещение сонара относительно центра клетки
    protected Vector3 _sonarBias = new Vector3(0.0f, 4.0f, 0.0f);

    //Время задержки перед показом экрана с результатом (в сек)
    private int _delayTime = 2;

#endregion

#region properties
    public Location Location
    {
        get { return location; }
        set { location = value; }
    }
#endregion


#region methods

    private void Start()
    {
        LoadSelection();
    }

    //Выделяем объект, если на него навелена мышь
    private void OnMouseEnter()
    {
        if (!AppContext.GameManager.IsGameStarted)
        {
            return;
        }
            selection.SetActive(true);
    }

    //Cнимаем выделение, когда мышь не наведена
    private void OnMouseExit()
    {
        selection.SetActive(false);
    }

    //Размещаем сонар, когда игрок нажал на клетку кнопкой мыши, предварительно проверив, можно ли это сделать
    private void OnMouseDrag()
    {
        if (!AppContext.GameManager.IsGameStarted)
        {
            return;
        }
        if (!AppContext.GameManager.IsPaused && !sonar &&
                     AppContext.GameManager.SonarCount > 0)
        {
            AddSonar();
            CheckEndGame();
            CalculateDistance();
        }
    }

    //Загрузка выделения 
    protected void LoadSelection()
    {
        selection =
                    Instantiate(Resources.Load(PrefubsNameConfig.psSELECTION, typeof(GameObject))) as GameObject;

        selection.transform.SetParent(transform);

        selection.transform.position = transform.position + _selectionsBias;
        selection.SetActive(false);
    }

    //Загрузка сонара
    protected void AddSonar()
    {
        sonar = Instantiate(Resources.Load(PrefubsNameConfig.pfSONAR, typeof(GameObject))) as GameObject;
        
        sonar.transform.position = transform.position + _sonarBias;
        sonar.transform.SetParent(transform);
        AppContext.GameManager.SonarCount--;
        UIController.SetAvailableSonarsText(AppContext.GameManager.SonarCount);
        

    }

    //Вычисление растояния от сонара до сокровищ
    public void CalculateDistance()
    {
        if (sonar)
        {
            sonar.GetComponent<SonarController>().CalculateDistance(location);
        }
    }

    //Проверка на завершение игры
    protected void CheckEndGame()
    {        
        //Проверка, завершена ли игра по условиям выиграша игрока
        if (AppContext.GameManager.Score == AppContext.GameManager.TreasureCount)
        {
            EndGame(true);
        }
        //Проверка, завершена ли игра по условиям проигрыша игрока
        else if (0 == AppContext.GameManager.SonarCount)
        {
            EndGame(false);
        }
    }

    //Действия, которые должны быть совершены при окончании игры.
    private void EndGame(bool win)
    {
        AppContext.GameManager.IsGameStarted = false;
        AppContext.GameManager.ShowAllTreasures();
        StartCoroutine(PauseBeforeEndGame(win));
    }

    //Задержка показа экрана результата при окончании игры
    private IEnumerator PauseBeforeEndGame(bool win)
    {
        yield return new WaitForSeconds(_delayTime);
        AppContext.GameManager.EndGame(win);
    }
#endregion

}