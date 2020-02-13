using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Управление окном паузв
public class PauseDialogController : MonoBehaviour
{

#region methods
    //При нажатии на кнопку "continue" вернуться к основной игра
    public void OnContinueClick()
    {
        AppContext.GameManager.IsPaused = false;
        AppContext.DialogManager.UiShow();
        AppContext.DialogManager.PauseDialogHide();
    }

    //При нажатии на кнопку "restart" вернуться к стартовому окну
    public void OnResturtClick()
    {
        AppContext.GameManager.IsGameStarted = false;
        AppContext.GameManager.IsPaused = false;
        AppContext.DialogManager.UiHide();
        AppContext.LevelGenerateManager.DestroyLevel();
        AppContext.DialogManager.PauseDialogHide();
        AppContext.DialogManager.StartDialogShow();
    }
#endregion

}
