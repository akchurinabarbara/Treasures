using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Клетка игрового поля с сокровищем
public class TreasureCellController : CellController
{

#region fields
    //Ссылка на сокровище
    private GameObject _treasure;
#endregion

#region properties
    private void Start()
    {
        LoadSelection();
        LoadTreasure();
    }
#endregion

#region methods
    //При нажатии на клетку необходимо разместить сонар, увеличить счетчик найденных сокровищ и пересчитать расстояния
    private void  OnMouseDrag()
    {        
        if (!AppContext.GameManager.IsPaused && !sonar &&
                     AppContext.GameManager.SonarCount > 0)
        {
            AddSonar();
            AppContext.GameManager.Score++;
            for (int i = 0; i< AppContext.GameManager.TreasureCoordinates.Count; i++)
            {
                if(location.i == AppContext.GameManager.TreasureCoordinates[i].i 
                    && location.j == AppContext.GameManager.TreasureCoordinates[i].j)
                {
                    AppContext.GameManager.TreasureCoordinates.RemoveAt(i);
                }
            }
            _treasure.GetComponent<MeshRenderer>().enabled = true;
            _treasure.GetComponent<AudioSource>().Play();
            UIController.SetFindTreasuresNumber(AppContext.GameManager.Score);
            CheckEndGame();
            CalculateDistance();
        }
    }

    //Пересчет расстояний от сонаров до сокровищ
    private new void CalculateDistance()
    {
        foreach(GameObject cell in AppContext.GameZoneManager.Cells)
        {
            cell.GetComponent<CellController>().CalculateDistance();
        }
    }

    //Загрузка префаба сокровища
    private void LoadTreasure()
    {
        _treasure =
                   Instantiate(Resources.Load(PrefubsNameConfig.pfTREASURE, typeof(GameObject))) as GameObject;

        _treasure.transform.SetParent(transform);

        _treasure.transform.position = transform.position;
        _treasure.GetComponent<MeshRenderer>().enabled = false;
    }
#endregion

}
