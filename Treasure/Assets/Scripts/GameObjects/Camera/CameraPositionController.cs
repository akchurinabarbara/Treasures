using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionController : MonoBehaviour
{
   //Настройка позиции камеры. С помощью колесика мыши настраивается масштаб поля
   //Мастштабность скролинга (скорость скролинга)
    private float _deltaScale = 80.0f;

    //Объект игровой доски. Нужен для определения ограничений перемещений камеры
    private GameObject _gameBoard;

    //Границы перемещения камеры
    private float _right;
    private float _left;
    private float _top;
    private float _bottom;
    private float _minScale;
    
    //Смещение камеры от центра игрового пространства 
    private  Vector3 _bias = new Vector3(0.0f, 8.0f, -4.0f);

    //Угол наклона камеры
    private Vector3 _rotation = new Vector3(75.0f, 0.0f, 0.0f);

    //Устанавливает начальное положение камеры на уровне
    public void SetStartPosition()
    {
        _gameBoard = GameObject.FindGameObjectWithTag("GameBoard");

        _minScale = _gameBoard.transform.position.y + 10;

        _right = _gameBoard.transform.position.x + _gameBoard.transform.lossyScale.x;
        _left = _gameBoard.transform.position.x - _gameBoard.transform.lossyScale.x;
        _top = _gameBoard.transform.position.z + _gameBoard.transform.lossyScale.z * 4;
        _bottom = _gameBoard.transform.position.z - _gameBoard.transform.lossyScale.z * 4;


        //Начальная позиция камеры
        transform.position = AppContext.LocationManager.GameZoneCenter + 
                                     new Vector3(0.0f, _bias.y * _gameBoard.transform.localScale.x,_bias.z * _gameBoard.transform.localScale.z);

        //Начальный поворот камеры
        transform.Rotate(_rotation);
    }

    void Update()
    {
        //Отслеживание движения колесика мыши и движение камеры по вертикальной оси
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.position.y < _minScale)
        {
            transform.position = transform.position;
        }
        else
        {
            transform.position -= new Vector3(0.0f, Input.GetAxis("Mouse ScrollWheel") * _deltaScale, 0.0f);
        }


        //Отслежживание нажатия правой кнопки мыши и ее передвижения. При зажатии ПКМ включается режим перемещения камеры по горизонтальной плоскости
        if (Input.GetMouseButton(1))
        {
            float newX = transform.position.x + Input.GetAxis("Mouse X");
            float newZ = transform.position.z + Input.GetAxis("Mouse Y");

            if ((newX > _right) ||
                (newX < _left) ||
                (newZ > _top) ||
                (newZ < _bottom))
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
