using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;//Значения для скорости движения и расстояния, с которого начинается реакция на препятствие
    public float obstacleRange = 5.0f;
    private bool _alive;
    
    void Start()
    {
        _alive = true;
    }
    
    
    
     void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);//Непрерывно движемся вперед в каждом кадре, несмотря на повороты

        Ray  ray = new Ray(transform.position, transform.forward);//Луч находится в том же положении и нацеливается в том же направлении, что и персонаж
        RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))//бросаем луч с описанной вокруг него окружностью
            {
             if (hit.distance < obstacleRange)
                {
                  float angle = Random.Range(-110, 110);//Поворот с наполовину случайным выбором нового направления
                  transform.Rotate(0, angle, 0);
                }
            }
        }
        

    }

    public void SetAlive(bool alive)//Открытый меттод, позволяющий внешнему коду воздействовать на "живое" состояние
    {
        _alive = alive;
    }
}
