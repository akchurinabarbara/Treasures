using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionController : MonoBehaviour
{
   //Настройка позиции камеры. С помощью колесика мыши настраивается масштаб поля
   //Мастштабность скролинга (скорость скролинга)
    private float _deltaScale = 20.0f;

    //Объект игровой доски. Нужен для определения ограничений перемещений камеры
    private GameObject _gameBoard;

    private void Start()
    {
        _gameBoard = GameObject.FindGameObjectWithTag("GameBoard");
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.position.y < _gameBoard.transform.position.y+2)
        {
            transform.position = transform.position;
        }
        else
        {
            transform.position -= new Vector3(0.0f, Input.GetAxis("Mouse ScrollWheel") * _deltaScale, 0.0f);
        }

        if (Input.GetMouseButton(1))
        {
            float newX = transform.position.x + Input.GetAxis("Mouse X");
            float newZ = transform.position.z + Input.GetAxis("Mouse Y");

            if ((newX > _gameBoard.transform.position.x + _gameBoard.transform.lossyScale.x) ||
                (newX < _gameBoard.transform.position.x - _gameBoard.transform.lossyScale.x) ||
                (newZ > _gameBoard.transform.position.z + _gameBoard.transform.lossyScale.z * 3) ||
                (newZ < _gameBoard.transform.position.z - _gameBoard.transform.lossyScale.z * 3))
            {
                transform.position = transform.position;
            }
            else
            {
                transform.position = new Vector3(newX,transform.position.y, newZ);
            }
        }

    }
}
