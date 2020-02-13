using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SonarController : MonoBehaviour
{
    void Start()
    {
        transform.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
    }

    public void CalculateDistance(int i, int j)
    {

        int minDistanse = findDistanse(i, j);

        transform.GetComponentInChildren<TextMeshProUGUI>().text = minDistanse == -1 ?
            "X" : minDistanse.ToString();

    }


    //Нахождение сокровищ под радиусом радара (диагонали учитываются)
    private int findDistanse(int startI, int startJ)
    {
        int result = AppContext.GameManager.SonarRadius + 1;

        for (int i = 0; i < AppContext.GameManager.SonarRadius + 1; i++)
        {
            //Вверх
            if (AppContext.GameManager.TreasureCoordinates.Exists(
                element => startI + i == element.i && startJ == element.j))
            {
                result = i < result ? i : result;
            }

            //Вниз
            if (AppContext.GameManager.TreasureCoordinates.Exists(
                element => startI - i == element.i && startJ == element.j))
            {
                result = i < result ? i : result;
            }

            //Вправо
            if (AppContext.GameManager.TreasureCoordinates.Exists(
              element => startI == element.i && startJ + i == element.j))
            {
                result = i < result ? i : result;
            }

            //Влево
            if (AppContext.GameManager.TreasureCoordinates.Exists(
                element => startI == element.i && startJ - i== element.j))
            {
                result = i < result ? i : result;
            }

            //Диагональ в право вверх
            if (AppContext.GameManager.TreasureCoordinates.Exists(
              element => startI + i == element.i && startJ + i == element.j))
            {
                result = i < result ? i : result;
            }

            //Диагональ в влево вниз
            if (AppContext.GameManager.TreasureCoordinates.Exists(
                element => startI - i == element.i && startJ - i == element.j))
            {
                result = i < result ? i : result;
            }

            //Диагональ в влево вверх
            if (AppContext.GameManager.TreasureCoordinates.Exists(
            element => startI + i == element.i && startJ - i == element.j))
            {
                result = i < result ? i : result;
            }

            //Диагональ вправо вниз
            if (AppContext.GameManager.TreasureCoordinates.Exists(
                element => startI - i == element.i && startJ + i == element.j))
            {
                result = i < result ? i : result;
            }
        }

        return result == AppContext.GameManager.SonarRadius + 1 ? -1 : result;


    }
}
