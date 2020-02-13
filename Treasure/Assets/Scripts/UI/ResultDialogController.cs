using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Управление окном результата
public class ResultDialogController : MonoBehaviour
{

#region methods
    //Запуск мелодии для попеды
    public static void PlayWinMusic()
    {
        AudioSource winMusic = GameObject.FindGameObjectWithTag(TagConfig.WIN_MUSIC).GetComponent<AudioSource>();
        winMusic.Play();
    }

    //Запуск мелодии для поражения
    public static void PlayDefeatMusic()
    {
        AudioSource defeatMusic = GameObject.FindGameObjectWithTag(TagConfig.DEFEAT_MUSIC).GetComponent<AudioSource>();
        defeatMusic.Play();
    }

    //Установка сообщения о победе
    public static void SetWinText()
    {
        SetResultText("You won");
    }

    //Установка сообщения о поражении
    public static void SetDefeatText()
    {
        SetResultText("You lose");
    }

    //Устанавливает значение нажписи, говорящей об результатах
    public static void SetResultText(string text)
    {
        GameObject resultTextObject = GameObject.FindGameObjectWithTag(TagConfig.RESULT_TEXT);
        TextMeshProUGUI resultText = resultTextObject.GetComponent<TextMeshProUGUI>();
        resultText.text = text;
    }


    //При нажатии на кнопку "yes" перезапустить игру и показать стартовое окно
    public void OnYesClick()
    {
        AppContext.DialogManager.ResultDialogHide();
        AppContext.DialogManager.StartDialogShow();
    }
#endregion

}
