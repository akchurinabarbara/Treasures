using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Управление стартовым окном
public class StartDialogController : MonoBehaviour
{

#region methods
    //Вывод информации о уровне
    private void Start()
    {
        GameObject inputFieldMObject = GameObject.FindGameObjectWithTag(TagConfig.INPUT_FIELD_M);
        TMP_InputField inputFieldMText = inputFieldMObject.GetComponentInChildren<TMP_InputField>();
        inputFieldMText.text = AppContext.GameManager.M.ToString();

        GameObject inputFieldNObject = GameObject.FindGameObjectWithTag(TagConfig.INPUT_FIELD_N);
        TMP_InputField inputFieldNText = inputFieldNObject.GetComponentInChildren<TMP_InputField>();
        inputFieldNText.text = AppContext.GameManager.N.ToString();

        GameObject inputFieldSonarCountObject = GameObject.FindGameObjectWithTag(TagConfig.INPUT_FIELD_SONAR_COUNT);
        TMP_InputField inputFieldSonarCountText = inputFieldSonarCountObject.GetComponentInChildren<TMP_InputField>();
        inputFieldSonarCountText.text = AppContext.GameManager.StartSonarCount.ToString();

        GameObject inputFieldSonarRadiusObject = GameObject.FindGameObjectWithTag(TagConfig.INPUT_FIELD_SONAR_RADIUS);
        TMP_InputField inputFieldSonarRadiusText = inputFieldSonarRadiusObject.GetComponentInChildren<TMP_InputField>();
        inputFieldSonarRadiusText.text = AppContext.GameManager.SonarRadius.ToString();

        GameObject inputFieldSonarTreasureCountObject = GameObject.FindGameObjectWithTag(TagConfig.INPUT_FIELD_TREASURE_COUNT);
        TMP_InputField inputFieldTreasureCountText = inputFieldSonarTreasureCountObject.GetComponentInChildren<TMP_InputField>();
        inputFieldTreasureCountText.text = AppContext.GameManager.TreasureCount.ToString();

    }

    //При нажатии кнопки "start" сгенерировать уровень и начать игру
    public void OnStartButtonClick()
    {
        AppContext.GameManager.SonarCount = AppContext.GameManager.StartSonarCount;
        AppContext.GameManager.Score = 0;
        
        AppContext.DialogManager.UiShow();
        UIController.SetStartText();


        AppContext.LevelGenerateManager.Generate();
        AppContext.GameManager.IsGameStarted = true;

        AppContext.DialogManager.StartDialogHide();
    }
#endregion

}
