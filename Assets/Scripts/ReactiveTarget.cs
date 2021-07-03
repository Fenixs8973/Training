using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()//Метод вызванный сценарием стрельбы
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }
    
    private IEnumerator Die()// Опрокидывать врага, ждем 1,5 секунды и уничтожаем его
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);//Объект межет уничтожи ть сам себя точно так же, как любой другой объект
    }
}
