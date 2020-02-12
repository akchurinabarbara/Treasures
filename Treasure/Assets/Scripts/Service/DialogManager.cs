using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager 
{
    #region fields
    private GameObject _ui;
    //Окно с настройками игры
    private GameObject _settingsDialog;
    //Окно, оповещающее об окончании игры
    private GameObject _restartDialog;
    //Окно паузы
    private GameObject _pauseDialog;
    #endregion

    #region constuctor
    public DialogManager()
    {
        _ui = GameObject.FindGameObjectWithTag("UI");
        _ui.SetActive(false);

        _settingsDialog = GameObject.FindGameObjectWithTag("SettingsDialog");
        _settingsDialog.SetActive(true);

        _restartDialog = GameObject.FindGameObjectWithTag("RestartDialog");
        _restartDialog.SetActive(false);

        _pauseDialog = GameObject.FindGameObjectWithTag("PauseDialog");
        _pauseDialog.SetActive(false);
    }
    #endregion

    #region methods
    public void UiShow()
    {
        _ui.SetActive(true);
    }

    public void UiHide()
    {
        _ui.SetActive(false);
    }

    public void SettingsDialogShow()
    {
        _settingsDialog.SetActive(true);
    }

    public void SettingsDialogHide()
    {
        _settingsDialog.SetActive(false);
    }

    public void RestartDialogShow()
    {
       _restartDialog.SetActive(true);
    }

    public void RestartDialogHide()
    {
        _restartDialog.SetActive(false);
    }


    public void PauseDialogShow()
    {
        _pauseDialog.SetActive(true);
    }

    public void PauseDialogHide()
    {
        _pauseDialog.SetActive(false);
    }
    #endregion
}
