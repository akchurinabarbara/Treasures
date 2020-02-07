using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Отслеживает клики игроком по клеткам игрового поля
public class MouseClickController : MonoBehaviour
{
    //Смещение сонара от центра клетки
    private Vector3 _sonarBias = new Vector3(0.0f, 1.0f, 0.0f);

    void FixedUpdate()
    {

        if (!AppContext.GameManager.IsGameStarted)
        {
            return;
        }
        Ray ray;
        RaycastHit hit;
        Vector3 newPosition;
        if (Input.GetMouseButtonUp(0))
        {
            newPosition = transform.position;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Cell")
                {
                    GameObject sonar = Instantiate(Resources.Load("Embeded/Game/Sonar/pfSonar", typeof(GameObject))) as GameObject;
                    sonar.transform.position = hit.transform.position + _sonarBias;
                    sonar.transform.SetParent(hit.transform);
                }
            }
        }
    }
}
