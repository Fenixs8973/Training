using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    public float speed = 3.0f; //
    public float maxZ = 16.0f; //Объект движется между этими точками
    public float minZ = -16.0f;//

    private int _directions = 1;//В каком направлении объект движется в данный момент? 

    void Update()
    {
        transform.Translate(0, 0, _directions * speed * Time.deltaTime);

        bool bounced = false;
        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            _directions = -_directions;//Меняем направление на притивоположное
            bounced = true;
        }
        if (bounced)
        {
            transform.Translate(0, 0, _directions * speed * Time.deltaTime);//Делаем дополнительное движение в этом кадре, если объект поменял направление
        }
    }
}
