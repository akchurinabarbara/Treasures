using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Управление сонаром
public class SonarController : MonoBehaviour
{

#region methods
    void Start()
    {
        transform.GetComponentInChildren<Canvas>().worldCamera = Camera.main; //задает камеру canvas, отображающем расстояние
    }

    //Вычисление дистанции
    public void CalculateDistance(Location startLocation)
    {
        int minDistanse = findDistanse(startLocation);

        transform.GetComponentInChildren<TextMeshProUGUI>().text = minDistanse == -1 ?
            "X" : minDistanse.ToString();
    }


    //Нахождение сокровищ под радиусом радара (диагонали учитываются)
    private int findDistanse(Location startLocation)
    {
        int result = AppContext.GameManager.SonarRadius + 1;

        for (int i = 0; i < AppContext.GameManager.SonarRadius + 1; i++)
        {
            //Вверх
            if (AppContext.GameManager.TreasureCoordinates.Exists(
                element => startLocation.i + i == element.i && startLocation.j == element.j))
            {
                result = i < result ? i : result;
            }

            //Вниз
            if (AppContext.GameManager.TreasureCoordinates.Exists(
                element => startLocation.i - i == element.i && startLocation.j == element.j))
            {
                result = i < result ? i : result;
            }

            //Вправо
            if (AppContext.GameManager.TreasureCoordinates.Exists(
              element => startLocation.i == element.i && startLocation.j + i == element.j))
            {
                result = i < result ? i : result;
            }

            //Влево
            if (AppContext.GameManager.TreasureCoordinates.Exists(
                element => startLocation.i == element.i && startLocation.j - i== element.j))
            {
                result = i < result ? i : result;
            }

            //Диагональ в право вверх
            if (AppContext.GameManager.TreasureCoordinates.Exists(
              element => startLocation.i + i == element.i && startLocation.j + i == element.j))
            {
                result = i < result ? i : result;
            }

            //Диагональ в влево вниз
            if (AppContext.GameManager.TreasureCoordinates.Exists(
                element => startLocation.i - i == element.i && startLocation.j - i == element.j))
            {
                result = i < result ? i : result;
            }

            //Диагональ в влево вверх
            if (AppContext.GameManager.TreasureCoordinates.Exists(
            element => startLocation.i + i == element.i && startLocation.j - i == element.j))
            {
                result = i < result ? i : result;
            }

            //Диагональ вправо вниз
            if (AppContext.GameManager.TreasureCoordinates.Exists(
                element => startLocation.i - i == element.i && startLocation.j + i == element.j))
            {
                result = i < result ? i : result;
            }
        }

        return result == AppContext.GameManager.SonarRadius + 1 ? -1 : result;
    }
#endregion

}
