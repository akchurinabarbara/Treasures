using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Структура, хранящщая информацию об расположении клетки
public struct Location
{

#region fields
    //Расположение по i
    private int _i;
    //Расположение по J
    private int _j;
#endregion

#region properties
    public int i
    {
        get { return _i; }
        set { _i = value; }
    }

    public int j
    {
        get { return _j; }
        set { _j = value; }
    }
#endregion

#region constructor
    public Location (int i, int j)
    {
        _i = i;
        _j = j;
    }
#endregion

}
