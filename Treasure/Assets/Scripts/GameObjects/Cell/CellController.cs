using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    #region fields
    //Характеристики ячейки
    protected CellModel _cellModel;

    protected GameObject sonar;

    //Смещение выделения
    private Vector3 _selectionsBias = new Vector3(0.0f, 0.2f, 0.0f);

    protected Vector3 _sonarBias = new Vector3(0.0f, 4.0f, 0.0f);
    #endregion

    #region properties
    public CellModel CellModel
    {
        get { return _cellModel; }
    }
    #endregion

    #region methods
    void Awake()
    {
        _cellModel = new CellModel();
    }

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
            _cellModel.Selection.SetActive(true);
    }

    //Cнимаем выделение, когда мышь не наведена
    private void OnMouseExit()
    {
        _cellModel.Selection.SetActive(false);
    }

    //Размещаем сонар, когда игрок нажал на клетку кнопкой мыши, предварительно проверив, можно ли это сделать
    private void OnMouseDrag()
    {
        if (!AppContext.GameManager.IsGameStarted)
        {
            return;
        }
        if (!AppContext.GameManager.IsPaused && !CellModel.HaveSonar &&
                     AppContext.GameManager.SonarCount > 0)
        {
            AddSonar();
            CheckEndGame();
            CalculateDistance();
        }
    }

    protected void LoadSelection()
    {
        _cellModel.Selection =
                    Instantiate(Resources.Load("Embeded/Game/Cell/Selection/pfSelection", typeof(GameObject))) as GameObject;

        _cellModel.Selection.transform.SetParent(transform);

        _cellModel.Selection.transform.position = transform.position + _selectionsBias;
        _cellModel.Selection.SetActive(false);
    }

    protected void AddSonar()
    {
        sonar = Instantiate(Resources.Load("Embeded/Game/Sonar/pfSonar", typeof(GameObject))) as GameObject;
        
        sonar.transform.position = transform.position + _sonarBias;
        sonar.transform.SetParent(transform);
        CellModel.HaveSonar = true;
        AppContext.GameManager.SonarCount--;
        UIController.SetAvailableSonarsText(AppContext.GameManager.SonarCount);
        

    }

    public void CalculateDistance()
    {
        if (sonar)
        {
            sonar.GetComponent<SonarController>().CalculateDistance(_cellModel.i, _cellModel.j);
        }
    }

    //Возможно, перенести в другой класс
    protected void CheckEndGame()
    {        
        if (AppContext.GameManager.Score == AppContext.GameManager.TreasureCount)
        {
            EndGame(true);
        }
        else if (0 == AppContext.GameManager.SonarCount)
        {
            EndGame(false);
        }
    }

    private void EndGame(bool win)
    {
        AppContext.GameManager.IsGameStarted = false;
        ShowAllTreasures();
        StartCoroutine(PauseBeforeEndGame(win));
    }

    private IEnumerator PauseBeforeEndGame(bool win)
    {
        yield return new WaitForSeconds(1);
        AppContext.GameManager.EndGame(win);
    }

    private void ShowAllTreasures()
    {
        foreach(GameObject treasures in GameObject.FindGameObjectsWithTag("Treasure"))
        {
            treasures.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    #endregion
}