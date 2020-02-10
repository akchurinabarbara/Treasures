using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Отслеживает клики игроком по клеткам игрового поля
public class MouseClickController : MonoBehaviour
{
    //Смещение сонара от центра клетки
    private Vector3 _sonarBias = new Vector3(0.0f, 1.0f, 0.0f);

    //Координаты прошлой выделенной клетки
    int lastSelectedI = 0;
    int lastSelectedJ = 0;

    void FixedUpdate()
    {

        if (!AppContext.GameManager.IsGameStarted)
        {
            return;
        }
        Ray ray;
        RaycastHit hit;
        Vector3 newPosition;
        newPosition = transform.position;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            //Проверяем, пересек ли луч указателя мыши объект клетки
            if (hit.transform.gameObject.tag == "Cell")
            {
                // Проверяем, была ли выделена эта клетка в прошлом кадре. Если да, то просто ничего не делаем
                //Иначе снимаем с нее выделение и выделяем новую
                CellController cellController = hit.transform.GetComponent<CellController>();
                if (cellController.CellModel.i != lastSelectedI ||
                    cellController.CellModel.j != lastSelectedJ)
                {

                    AppContext.GameZoneManager.Cells[lastSelectedI, lastSelectedJ].GetComponent<CellController>().CellModel.Selected = false;

                    lastSelectedI = cellController.CellModel.i;
                    lastSelectedJ = cellController.CellModel.j;

                    cellController.CellModel.Selected = true;
                }
                //Если была еще и кнопка ыши нажата, проверяем, занята ли клетка и есть ли у тгрока сонары. 
                //Если есть, размещаем сонар
                if (Input.GetMouseButton(0) &&
                     !cellController.CellModel.HaveSonar &&
                     AppContext.GameManager.SonarCount > 0)
                {
                    GameObject sonar = Instantiate(Resources.Load("Embeded/Game/Sonar/pfSonar", typeof(GameObject))) as GameObject;
                    sonar.transform.position = hit.transform.position + _sonarBias;
                    sonar.transform.SetParent(hit.transform);
                    cellController.CellModel.HaveSonar = true;
                    AppContext.GameManager.SonarCount--;
                    UIController.SetAvailableSonarsText(AppContext.GameManager.SonarCount);
                }

            }
            //Если нет, просто снимаем выделение с недавно выделенной клетки
            else
            {
                AppContext.GameZoneManager.Cells[lastSelectedI, lastSelectedJ].GetComponent<CellController>().CellModel.Selected = false;
            }
        }
    }
}
