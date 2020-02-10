using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
//Управление интерфейсом пользователя

    #region methods
    void Start()
    {
        SetStartText();
    }

    //Показывает значения найденных сокровищ
    public static void SetFindTreasuresNumber(int count)
    {
        GameObject findTreasuresNumber = GameObject.FindGameObjectWithTag("FindTreasuresNumber");
        TextMeshProUGUI findTreasuresNumberText = findTreasuresNumber.GetComponent<TextMeshProUGUI>();
        findTreasuresNumberText.text = count.ToString();
    }

    //Показывает значения оставшихся сонаров
    public static void SetAvailableSonarsText(int count)
    {
        GameObject availableSonars = GameObject.FindGameObjectWithTag("AvailableSonarsNumber");
        TextMeshProUGUI availableSonarsText = availableSonars.GetComponent<TextMeshProUGUI>();
        availableSonarsText.text = count.ToString();
    }

    //Показать начальное значения всех элементов пользовательского интерфейса
    public static void SetStartText()
    {
        GameObject allTreasuresNumber = GameObject.FindGameObjectWithTag("AllTreasuresNumber");
        TextMeshProUGUI allTreasuresNumberText = allTreasuresNumber.GetComponent<TextMeshProUGUI>();
        allTreasuresNumberText.text = AppContext.GameManager.TreasureCount.ToString();
        SetFindTreasuresNumber(0);
        SetAvailableSonarsText(AppContext.GameManager.SonarCount);
    }

    //Управление кнопкой паузы
    private void OnPauseClick(bool value)
    {
        if (AppContext.GameManager.IsPaused == false)
        {
            //AppContext.DialogManager.PauseDialogShow();
            AppContext.GameManager.IsPaused = true;
        }
    }
    #endregion

}
