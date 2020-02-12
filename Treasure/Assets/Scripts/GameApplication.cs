using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Основная логика приложения, управление всеми менеджерами 
public class GameApplication : MonoBehaviour
{
    private void Awake()
    {
        AppContext.Configure();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        
    }

    void Update()
    {
        if (AppContext.GameManager == null)
        {
            return;
        }
    }
}
