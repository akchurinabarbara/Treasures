using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    #region fields
    //Характеристики ячейки
    protected CellModel _cellModel;

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
        _cellModel.Selection =
                    Instantiate(Resources.Load("Embeded/Game/Cell/Selection/pfSelection", typeof(GameObject))) as GameObject;

        _cellModel.Selection.transform.SetParent(transform);

        _cellModel.Selection.transform.position = transform.position + _selectionsBias;
        _cellModel.Selection.SetActive(false);
    }

    //Выделяем объект, если на него навелена мышь
    private void OnMouseEnter()
    {
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
        if (!AppContext.GameManager.IsPaused && !CellModel.HaveSonar &&
                     AppContext.GameManager.SonarCount > 0)
        {
            AddSonar();
            CheckEndGame();
        }
    }

    protected void AddSonar()
    {
        GameObject sonar = Instantiate(Resources.Load("Embeded/Game/Sonar/pfSonar", typeof(GameObject))) as GameObject;
        sonar.transform.position = transform.position + _sonarBias;
        sonar.transform.SetParent(transform);
        CellModel.HaveSonar = true;
        AppContext.GameManager.SonarCount--;
        UIController.SetAvailableSonarsText(AppContext.GameManager.SonarCount);
        
    }

    protected void CheckEndGame()
    {
        //Возможно, перенести в другой класс
        if (AppContext.GameManager.Score == AppContext.GameManager.TreasureCount)
        {
            AppContext.GameManager.EndGame("You won");
        }
        else if (0 == AppContext.GameManager.SonarCount)
        {
            AppContext.GameManager.EndGame("You lose");
        }
    }
    #endregion

}
