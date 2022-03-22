using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class RotationLog : MonoBehaviour
{
    [Header("Скорость кручение бревна мин и макс значения")]
    public float speedMin = 0.5f;
    public float speedMax = 2;

    [Header("Время начало кручения мин и макс значения")]
    public float torsion_start_min = 0.4f;
    public float torsion_start_max = 0.9f;

    [Header("Время окончания кручения мин и макс значения")]
    public float torsion_stop_min = 1.9f;
    public float torsion_stop_max = 2.5f;

    [Header("Скорость кручения")]
    public float TimeSpeed = 1;

    [Header("Настройка спавна яблок")]
    public GameObject apple;
    public GameObject Knife;
    public int countAppleMin = 0;
    public int countAppleMax = 3;

    [Header("Радиус спавна")]
    public float radius;

    [Header("Шанс рандома")]
    public int chance;

    [Header("Уничтожение бревна")]
    public GameObject log1;
    public GameObject log2;
    public GameObject log3;
    public GameObject log4;
    public GameObject destroy_Log;
    public int hp_log = 8;

    void Start()
    {
        destroy_Log.SetActive(false);
        // шанс будут ли спавниться яблоки на бревне
        if (Random.Range(0, 100) < chance)
        {
            for (int i = 0; i < Random.Range(countAppleMin, countAppleMax); i++)
            {
                //Спавн яблок вокруг окружности
                Vector3 center = transform.position;
                Vector3 pos = RandomCircle(center, radius);
                Quaternion rot = Quaternion.LookRotation(Vector3.forward, center - pos);

                GameObject applechild = Instantiate(apple, pos, rot);
                applechild.transform.parent = GameObject.Find("log").transform;
            }
        }
        // Цикл спавна ножей вокруг окружности
        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            Vector3 center = transform.position;
            Vector3 pos = RandomCircle(center, radius);
            Quaternion rot = Quaternion.LookRotation(Vector3.forward, center - pos);

            GameObject applechild = Instantiate(Knife, pos, rot);
            applechild.transform.parent = GameObject.Find("log").transform;
        }
    }
    //Метод для нахождения радиуса окружности
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
    void Update()
    {

        TimeSpeed += Time.deltaTime;
        //Проверка на начало кручение бревна
        if (TimeSpeed >= Random.Range(torsion_start_min, torsion_start_max))
        {
            //Кручение бревна с определённой скоростью
            transform.Rotate(0, 0, Random.Range(speedMin, speedMax), Space.Self);
            //Проверка на остановление бревна
            if (TimeSpeed >= Random.Range(torsion_stop_min, torsion_stop_max)) TimeSpeed = 0;
        }
        //Проверка если на уничтожение бревна и продолжение уровней
        if (hp_log <= 0)
        {
            //Для реалестичного разрыва бревна
            log1.GetComponent<Rigidbody>().isKinematic = false;
            log2.GetComponent<Rigidbody>().isKinematic = false;
            log3.GetComponent<Rigidbody>().isKinematic = false;
            log4.GetComponent<Rigidbody>().isKinematic = false;
            log1.GetComponent<MeshCollider>().enabled = true;
            log2.GetComponent<MeshCollider>().enabled = true;
            log3.GetComponent<MeshCollider>().enabled = true;
            log4.GetComponent<MeshCollider>().enabled = true;
            gameObject.GetComponent<RotationLog>().enabled = false;

            Vibration.Vibrate();
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
}