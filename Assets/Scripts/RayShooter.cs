using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();//Доступ к другим компонентам, присоедененным к этому же объекту

        Cursor.lockState = CursorLockMode.Locked;//Скравем указатель мыши в центре экрана
        Cursor.visible = false;                  //Скравем указатель мыши в центре экрана
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth/2 - size/4;
        float posY = _camera.pixelHeight/2 - size/4;
        GUI.Label(new Rect(posX, posY, size, size), "*");//Команда GUI.Labe() отображает на экране символ
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//Реакция на нажатие кнопки мыши
        {
            Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);    
            Ray ray = _camera.ScreenPointToRay(point);    
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))//Испущенный луч запоняет информацией переменную, на которую имеется ссылка
            {
                StartCoroutine(SphereIndicator(hit.point));//StartCoroutine() - запуск сопрограммы в ответ на попадание
                //Debug.Log("Hit" + hit.position);//Загружаем координаты точки, в которую попал луч
            }
        }
    }
    private IEnumerator SphereIndicator(Vector3 pos)//Сопрограммы используются функциями IEnumerator
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        
        yield return new WaitForSeconds(1);//Ключевое слово yield указывает программе, когда следует остановиться

        Destroy(sphere);//Удаляем этот GameObject и очищаем память
    }
}
