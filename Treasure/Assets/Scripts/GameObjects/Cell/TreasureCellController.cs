using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCellController : CellController
{
    private GameObject _treasure;

    private void Start()
    {
        LoadSelection();
        LoadTreasure();
    }

    private void  OnMouseDrag()
    {        
        if (!AppContext.GameManager.IsPaused && !CellModel.HaveSonar &&
                     AppContext.GameManager.SonarCount > 0)
        {
            AddSonar();
            AppContext.GameManager.Score++;
            for (int i = 0; i< AppContext.GameManager.TreasureCoordinates.Count; i++)
            {
                if(_cellModel.i == AppContext.GameManager.TreasureCoordinates[i].i 
                    && _cellModel.j == AppContext.GameManager.TreasureCoordinates[i].j)
                {
                    AppContext.GameManager.TreasureCoordinates.RemoveAt(i);
                }
            }
            _treasure.GetComponent<MeshRenderer>().enabled = true;
            UIController.SetFindTreasuresNumber(AppContext.GameManager.Score);
            CheckEndGame();
            CalculateDistance();
        }
    }


    private IEnumerator PauseBeforeDestroy()
    {
        yield return new WaitForSeconds(50);
    }

    private new void CalculateDistance()
    {
        foreach(GameObject cell in AppContext.GameZoneManager.Cells)
        {
            cell.GetComponent<CellController>().CalculateDistance();
        }
    }

    private void LoadTreasure()
    {
        _treasure =
                   Instantiate(Resources.Load("Embeded/Game/Treasure/pfTreasure", typeof(GameObject))) as GameObject;

        _treasure.transform.SetParent(transform);

        _treasure.transform.position = transform.position;
        _treasure.GetComponent<MeshRenderer>().enabled = false;
    }
}
