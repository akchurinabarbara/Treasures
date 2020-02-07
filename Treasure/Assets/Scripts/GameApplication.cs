using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Основная логика приложения, управление всеми менеджерами 
public class GameApplication : MonoBehaviour
{
    private void Awake()
    {
        AppContext.Configure();
        AppContext.GameManager.IsGameStarted = true;
    }

    void Update()
    {
        if (AppContext.GameManager == null)
        {
            return;
        }
    }
}
