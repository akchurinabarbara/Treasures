using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    #region fields
    //Характеристики ячейки
    private CellModel _cellModel;

    //Смещение выделения
    private Vector3 _selectionsBias = new Vector3(0.0f, 0.2f, 0.0f);
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
    }

    private void Update()
    {
        //Показываем выделение или скрываем его
        if (_cellModel.Selected)
        {
            _cellModel.Selection.SetActive(true);
        }
        else
        {
            _cellModel.Selection.SetActive(false);
        }
    }
    #endregion

}
