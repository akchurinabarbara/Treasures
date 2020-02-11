using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsDialogController : MonoBehaviour
{
    #region fields
    private Text _inputFieldMText;
    private Text _inputFieldNText;
    private Text _inputFieldSonarCountText;
    private Text _inputFieldSonarRadiusText;
    private Text _inputFieldTreasureCountText;
    #endregion

    private void Start()
    {
        GameObject inputFieldMObject = GameObject.FindGameObjectWithTag("InputFieldM");
        _inputFieldMText = inputFieldMObject.GetComponentInChildren<Text>();


        GameObject inputFieldNObject = GameObject.FindGameObjectWithTag("InputFieldN");
        _inputFieldNText = inputFieldNObject.GetComponentInChildren<Text>();

        GameObject inputFieldSonarCountObject = GameObject.FindGameObjectWithTag("InputFieldSonarCount");
        _inputFieldSonarCountText = inputFieldSonarCountObject.GetComponentInChildren<Text>();

        GameObject inputFieldSonarRadiusObject = GameObject.FindGameObjectWithTag("InputFieldSonarRadius");
        _inputFieldSonarRadiusText = inputFieldSonarRadiusObject.GetComponentInChildren<Text>();

        GameObject inputFieldSonarTreasureCountObject = GameObject.FindGameObjectWithTag("InputFieldTreasureCount");
        _inputFieldTreasureCountText = inputFieldSonarTreasureCountObject.GetComponentInChildren<Text>();

    }


    #region Listeners
    public void OnStartButtonClick()
    {
        AppContext.GameManager.M = Convert.ToInt32(_inputFieldMText.text);
        AppContext.GameManager.N = Convert.ToInt32(_inputFieldNText.text);
        AppContext.GameManager.SonarCount = Convert.ToInt32(_inputFieldSonarCountText.text);
        AppContext.GameManager.SonarRadius = Convert.ToInt32(_inputFieldSonarRadiusText.text);
        AppContext.GameManager.TreasureCount = Convert.ToInt32(_inputFieldTreasureCountText.text);

        this.gameObject.SetActive(false);
        AppContext.DialogManager.UiShow();
        AppContext.LevelGenerateManager.Generate();
        AppContext.GameManager.IsGameStarted = true;
    }

    #endregion
}
