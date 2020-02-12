using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCellController : CellController
{
    private void  OnMouseDrag()
    {        
        if (!AppContext.GameManager.IsPaused && !CellModel.HaveSonar &&
                     AppContext.GameManager.SonarCount > 0)
        {
            base.AddSonar();
            AppContext.GameManager.Score++;
            UIController.SetFindTreasuresNumber(AppContext.GameManager.Score);
            base.CheckEndGame();
        }
    }
}
