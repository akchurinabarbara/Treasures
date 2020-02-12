using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsDialogController : MonoBehaviour
{
    //Управление всеми компонентами окна настройки
    #region fields
    private TMP_InputField _inputFieldMText;
    private TMP_InputField _inputFieldNText;
    private TMP_InputField _inputFieldSonarCountText;
    private TMP_InputField _inputFieldSonarRadiusText;
    private TMP_InputField _inputFieldTreasureCountText;
    #endregion

    private void Start()
    {
        GameObject inputFieldMObject = GameObject.FindGameObjectWithTag("InputFieldM");
        _inputFieldMText = inputFieldMObject.GetComponentInChildren<TMP_InputField>();


        GameObject inputFieldNObject = GameObject.FindGameObjectWithTag("InputFieldN");
        _inputFieldNText = inputFieldNObject.GetComponentInChildren<TMP_InputField>();

        GameObject inputFieldSonarCountObject = GameObject.FindGameObjectWithTag("InputFieldSonarCount");
        _inputFieldSonarCountText = inputFieldSonarCountObject.GetComponentInChildren<TMP_InputField>();

        GameObject inputFieldSonarRadiusObject = GameObject.FindGameObjectWithTag("InputFieldSonarRadius");
        _inputFieldSonarRadiusText = inputFieldSonarRadiusObject.GetComponentInChildren<TMP_InputField>();

        GameObject inputFieldSonarTreasureCountObject = GameObject.FindGameObjectWithTag("InputFieldTreasureCount");
        _inputFieldTreasureCountText = inputFieldSonarTreasureCountObject.GetComponentInChildren<TMP_InputField>();

    }


    #region Listeners
    public void OnStartButtonClick()
    {
        AppContext.GameManager.M = Convert.ToInt32(_inputFieldMText.text);
        AppContext.GameManager.N = Convert.ToInt32(_inputFieldNText.text);
        AppContext.GameManager.SonarCount = Convert.ToInt32(_inputFieldSonarCountText.text);
        AppContext.GameManager.SonarRadius = Convert.ToInt32(_inputFieldSonarRadiusText.text);
        AppContext.GameManager.TreasureCount = Convert.ToInt32(_inputFieldTreasureCountText.text);
        AppContext.GameManager.Score = 0;
        
        AppContext.DialogManager.UiShow();
        UIController.SetStartText();


        AppContext.LevelGenerateManager.Generate();
        AppContext.GameManager.IsGameStarted = true;

        AppContext.DialogManager.SettingsDialogHide();
    }

    #endregion
}
