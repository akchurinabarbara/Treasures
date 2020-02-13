using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Управление интерфейсом пользователя
public class UIController : MonoBehaviour
{

#region methods
    void Start()
    {
        SetStartText();
    }

    //Показывает значения найденных сокровищ
    public static void SetFindTreasuresNumber(int count)
    {
        GameObject findTreasuresNumber = GameObject.FindGameObjectWithTag(TagConfig.FIND_TREASURE_NUMBER);
        TextMeshProUGUI findTreasuresNumberText = findTreasuresNumber.GetComponent<TextMeshProUGUI>();
        findTreasuresNumberText.text = count.ToString();
    }

    //Показывает значения оставшихся сонаров
    public static void SetAvailableSonarsText(int count)
    {
        GameObject availableSonars = GameObject.FindGameObjectWithTag(TagConfig.AVAILABLE_SONARS_NUMBER);
        TextMeshProUGUI availableSonarsText = availableSonars.GetComponent<TextMeshProUGUI>();
        availableSonarsText.text = count.ToString();
    }

    //Показать начальное значения всех элементов пользовательского интерфейса
    public static void SetStartText()
    {
        GameObject allTreasuresNumber = GameObject.FindGameObjectWithTag(TagConfig.ALL_TREASURES_NUMBER);
        TextMeshProUGUI allTreasuresNumberText = allTreasuresNumber.GetComponent<TextMeshProUGUI>();
        allTreasuresNumberText.text = AppContext.GameManager.TreasureCount.ToString();
        SetFindTreasuresNumber(0);
        SetAvailableSonarsText(AppContext.GameManager.SonarCount);
    }

    //Управление кнопкой паузы
    public void OnPauseClick(bool value)
    {
        if (AppContext.GameManager.IsPaused == false)
        {
            AppContext.GameManager.IsPaused = true;
            AppContext.DialogManager.UiHide();
            AppContext.DialogManager.PauseDialogShow();
        }
    }
#endregion

}
