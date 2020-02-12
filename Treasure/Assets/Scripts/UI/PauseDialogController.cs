using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseDialogController : MonoBehaviour
{
    public void OnContinueClick()
    {
        AppContext.GameManager.IsPaused = false;
        AppContext.DialogManager.UiShow();
        AppContext.DialogManager.PauseDialogHide();
    }

    public void OnResturtClick()
    {
        AppContext.GameManager.IsGameStarted = false;
        AppContext.GameManager.IsPaused = false;
        AppContext.DialogManager.UiHide();
        AppContext.LevelGenerateManager.DestroyLevel();
        AppContext.DialogManager.PauseDialogHide();
        AppContext.DialogManager.SettingsDialogShow();
    }
}
