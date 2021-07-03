using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enumyPrefab;//Сериализованная переменная для связи с объектом-шаблоном
    private GameObject _enumy;//Закрытая переменная для слежения за экземпляром врага в сцене
        void Update()
    {
        if (_enumy == null)//Порождаем нового врага, только если враги в сцене отсутсвуют
        {
            _enumy = Instantiate(enumyPrefab) as GameObject;//Метод, копирующий объект-шаблон
            _enumy.transform.position = new Vector3(0, 2, 0);
            float angel = Random.Range(0, 360);
            _enumy.transform.Rotate(0, angel,0);
        }
    }
}
