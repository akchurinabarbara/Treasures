using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestartDialogController : MonoBehaviour
{

    public static void PlayWinMusic()
    {
        AudioSource winMusic = GameObject.FindGameObjectWithTag("WinMusic").GetComponent<AudioSource>();
        winMusic.Play();
    }

    public static void PlayDefeatMusic()
    {
        AudioSource defeatMusic = GameObject.FindGameObjectWithTag("DefeatMusic").GetComponent<AudioSource>();
        defeatMusic.Play();
    }


    public static void SetWinText()
    {
        SetResultText("You won");
    }

    public static void SetDefeatText()
    {
        SetResultText("You lose");
    }

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
