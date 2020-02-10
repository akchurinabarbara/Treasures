using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager 
{
    #region fields
    private GameObject _ui;
    #endregion

    #region constuctor
    public DialogManager()
    {
        _ui = GameObject.FindGameObjectWithTag("UI");
        _ui.SetActive(true);
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
    #endregion
}
