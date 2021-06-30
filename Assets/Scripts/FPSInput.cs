using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;// скорость передвижения
    private CharacterController _charController;//Переменная для ссылки на компонент CharacterController

    void Start()
    { 
        _charController = GetComponent<CharacterController>();//Доступ к другим компонентам, присоедененным к этому же объекту
    }

    
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0 , deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);//Ограничим движение по диагонали той же скоростью, что и движение параллелно осям

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);//Преобразуем движение от локальных к глобальным координатам
        _charController.Move(movement);//Заставим этот вектор перемещать компонент CharacterController  
    }
}
