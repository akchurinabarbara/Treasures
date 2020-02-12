using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestartDialogController : MonoBehaviour
{
    //Устанавливает значение нажписи, говорящей об результатах
    public static void SetResultText(string text)
    {
        GameObject resultTextObject = GameObject.FindGameObjectWithTag("ResultText");
        TextMeshProUGUI resultText = resultTextObject.GetComponent<TextMeshProUGUI>();
        resultText.text = text;
    }

    public void OnYesClick()
    {
        AppContext.DialogManager.RestartDialogHide();
        AppContext.DialogManager.SettingsDialogShow();
    }
}
