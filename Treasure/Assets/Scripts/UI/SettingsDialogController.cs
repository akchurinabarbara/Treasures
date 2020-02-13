using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsDialogController : MonoBehaviour
{
    //Управление всеми компонентами окна настройки
    private void Start()
    {
        GameObject inputFieldMObject = GameObject.FindGameObjectWithTag("InputFieldM");
        TMP_InputField inputFieldMText = inputFieldMObject.GetComponentInChildren<TMP_InputField>();
        inputFieldMText.text = AppContext.GameManager.M.ToString();

        GameObject inputFieldNObject = GameObject.FindGameObjectWithTag("InputFieldN");
        TMP_InputField inputFieldNText = inputFieldNObject.GetComponentInChildren<TMP_InputField>();
        inputFieldNText.text = AppContext.GameManager.N.ToString();

        GameObject inputFieldSonarCountObject = GameObject.FindGameObjectWithTag("InputFieldSonarCount");
        TMP_InputField inputFieldSonarCountText = inputFieldSonarCountObject.GetComponentInChildren<TMP_InputField>();
        inputFieldSonarCountText.text = AppContext.GameManager.StartSonarCount.ToString();

        GameObject inputFieldSonarRadiusObject = GameObject.FindGameObjectWithTag("InputFieldSonarRadius");
        TMP_InputField inputFieldSonarRadiusText = inputFieldSonarRadiusObject.GetComponentInChildren<TMP_InputField>();
        inputFieldSonarRadiusText.text = AppContext.GameManager.SonarRadius.ToString();

        GameObject inputFieldSonarTreasureCountObject = GameObject.FindGameObjectWithTag("InputFieldTreasureCount");
        TMP_InputField inputFieldTreasureCountText = inputFieldSonarTreasureCountObject.GetComponentInChildren<TMP_InputField>();
        inputFieldTreasureCountText.text = AppContext.GameManager.TreasureCount.ToString();

    }


    #region Listeners
    public void OnStartButtonClick()
    {
        AppContext.GameManager.SonarCount = AppContext.GameManager.StartSonarCount;
        AppContext.GameManager.Score = 0;
        
        AppContext.DialogManager.UiShow();
        UIController.SetStartText();


        AppContext.LevelGenerateManager.Generate();
        AppContext.GameManager.IsGameStarted = true;

        AppContext.DialogManager.SettingsDialogHide();
    }

    #endregion
}
