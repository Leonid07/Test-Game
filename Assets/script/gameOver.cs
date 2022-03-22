using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    //Панель окончания игры
    public GameObject gameOverPanel;
    //Переменная для окончания игры
    public bool game_over = false;

    private float time = 0;
    void Start()
    {
        AudioListener.volume = 1;
        //Дизактивация панели проигрыша
        gameOverPanel.SetActive(false);
    }
    void Update()
    {
        //Проверка на проигрыш
        if (game_over == true)
        {
            time += Time.deltaTime;
            if (time >= 0.5f)
            {
                //Активация панели проигрыша
                AudioListener.volume = 0;
                gameOverPanel.SetActive(true);
                PlayerPrefs.SetInt("score", 0);
            }
        }
        if (GameObject.Find("log").GetComponent<RotationLog>().hp_log <=0) {
            time += Time.deltaTime;
            if (time >= 0.5f)
            {
                gameObject.GetComponent<sceneManager>().LoadByIndex(1);
            }
        }
    }
}