using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speedKnife;//Скорость ножей
    public bool isDroped = true;
    public bool startPosition = true;
    public GameObject handle;
    bool statick = true;

    bool ColHandle = false;

    //Переменная для неактивных ножей
    public bool active = true;

    [Header("Аудио")]
    public AudioSource Audio;
    public AudioClip handle_audio;
    public AudioClip log_audio;
    void Start()
    {

    }
    void Update()
    {
        if (active == true) {
            //Если нож брошен и не статичен то он двигается и обратно
            if (isDroped && statick) gameObject.GetComponent<Rigidbody>().velocity = new Vector2(0, speedKnife);
            else gameObject.GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
            //Проверка если нож не забел другую рукоять
            if (ColHandle == true)
            {
                //Отскок ножа
                if (Time.timeScale == 1) {
                    gameObject.transform.Rotate(Random.Range(1.25f, 2.5f), 0, Random.Range(1.25f, 2.5f), Space.Self);
                    gameObject.GetComponent<Rigidbody>().velocity = new Vector2(0, -speedKnife / 2);
                }
            }
        }
        //Если бревно сломано то отключается его статичность
        if (GameObject.Find("log").GetComponent<RotationLog>().hp_log <= 0)
        {
            handle.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active == true) {
            if (other.tag == "log")
            {
                //Активация вибрации
                Vibration.Vibrate();
                statick = false;
                Audio.PlayOneShot(log_audio);
                gameObject.transform.parent = GameObject.Find("log").transform;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                //Добавление счёта
                GameObject.Find("Camera").GetComponent<DropKnife>().score++;
                //Уменьшение здоровья бревна
                GameObject.Find("log").GetComponent<RotationLog>().hp_log--;
            }
            if (other.tag == "handle")
            {
                //Игра проиграна если нож коснётся рукояти
                GameObject.Find("Canvas").GetComponent<gameOver>().game_over = true;
                //Включение вибрации
                Vibration.Vibrate();
                Audio.PlayOneShot(handle_audio);
                ColHandle = true;
                gameObject.GetComponent<Collider>().enabled = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
