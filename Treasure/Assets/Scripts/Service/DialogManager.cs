using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Управление диалоговыми окнами
public class DialogManager 
{

#region fields
    private GameObject _ui;
    //Окно с настройками игры
    private GameObject _startDialog;
    //Окно, оповещающее об окончании игры
    private GameObject _resultDialog;
    //Окно паузы
    private GameObject _pauseDialog;
#endregion

#region constuctor
    public DialogManager()
    {
        _ui = GameObject.FindGameObjectWithTag(TagConfig.UI);
        _ui.SetActive(false);

        _startDialog = GameObject.FindGameObjectWithTag(TagConfig.START_DIALOG);
        _startDialog.SetActive(true);

        _resultDialog = GameObject.FindGameObjectWithTag(TagConfig.RESULT_DIALOG);
        _resultDialog.SetActive(false);

        _pauseDialog = GameObject.FindGameObjectWithTag(TagConfig.PAUSE_DIALOG);
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

    public void StartDialogShow()
    {
        _startDialog.SetActive(true);
    }

    public void StartDialogHide()
    {
        _startDialog.SetActive(false);
    }

    public void ResultDialogShow()
    {
       _resultDialog.SetActive(true);
    }

    public void ResultDialogHide()
    {
        _resultDialog.SetActive(false);
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
