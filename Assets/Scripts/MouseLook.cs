using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    
    
    public enum RotationAxes // объявляем структуру данных enum, которая будет сопоставлять имена с параметрами
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensivityHor = 9.0f;
    public float sensivityVert = 9.0f;

    public float minimumVert = -90.0f;
    public float maximumVert = 90.0f;

    private float _rotationX = 0;

    void Start()
    {
        Rigidbody body = GetComponent <Rigidbody>();
        if (body != null)
        body.freezeRotation = true;
    }

    void Update()
    {
        if (axes == RotationAxes.MouseX)
        //поворот по горизонтали 
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensivityHor, 0);
        }
        else if(axes == RotationAxes.MouseY)
        //поворот по вертикальной 
        {
            _rotationX -= Input.GetAxis("Mouse Y") *sensivityVert;// Увеличиваем угол повпорота по вертикали в соответствии с перемещением указателя мыши
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);// Фиксируем угол поворота по вертикали в диапозоне, заданном минимальным и максимальным значениями
            float rotationY = transform.localEulerAngles.y;// создаем одинаковый угол поворота вокруг оси Y(то есть вращение в горизонтальной плоскости отсутствуе)

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);// Создаем новый вектор из сохраненных значений поворота
        }
        else
        //комбинированный поворот
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensivityHor; // Значение delta - это величина изменения угла поворота
            float rotationY = transform.localEulerAngles.y + delta;// приращение угла поворота через delta

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}