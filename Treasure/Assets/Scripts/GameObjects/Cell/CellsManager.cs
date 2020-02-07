using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Массив ячеек игрового поля. Нужен для того, чтобы предоставить к нему доступ из несколькиз скриптов
public class CellsManager
{
    #region field
    //Массив GameObject ячеек игрового поля
    //TODO Не забыть переделать на private
    private CellModel[,] _cells;
    #endregion

    #region properties
    public CellModel[,] Cells
    {
        get { return _cells; }
        set { _cells = value; }
    }
    #endregion

    #region methods
    public void Initialization()
    {
        _cells = new CellModel[AppContext.GameManager.M, AppContext.GameManager.N];
        for (int i = 0; i < AppContext.GameManager.M; i++)
            for (int j = 0; j < AppContext.GameManager.N; j++)
                _cells[i, j] = new CellModel(i, j);
    }
    #endregion

}
