using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;
   
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)//Эта функция вызывается, когда с тригером сталкивается другой объект
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)//Проверяем, является этот другой объект объектом PlayerCharacter
        {
            player.Hurt(damage);
        }
        Destroy(this.gameObject);
    }
}
