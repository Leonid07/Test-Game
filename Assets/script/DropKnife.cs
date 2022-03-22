using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropKnife : MonoBehaviour
{
    public GameObject knife;
    public GameObject[] knifeA;//Тени ножей на Canvas
    public GameObject firstKnife;//Стартовый нож
    public Transform knifeTransform;//Место спавна новых ножей
    GameObject knifeDrop;

    public GameObject[] shadowKnife;//Тень ножей на Canvas
    public int start = 0;//Переменная для подсчёта ножей

    [Header("GUI")]
    public Text scoreText;
    public Text scoreApple;
    public int score = 0;
    public int Apple = 0;
    public int MaxScore = 0;

    void Start()
    {

        for (int i = 0; i < shadowKnife.Length; i++) shadowKnife[i].SetActive(false);
        // Звгрузка счёта если существует данный ключ сохранения
        if (PlayerPrefs.HasKey("scoreApple")) {
            Apple = PlayerPrefs.GetInt("scoreApple");
            scoreApple.text = "" + Apple;
        }

        score = PlayerPrefs.GetInt("score");
        Apple = PlayerPrefs.GetInt("scoreApple");
    }

    // Update is called once per frame
    void Update()
    {
        //Сохранение счёта и количества яблок
        PlayerPrefs.SetInt("scoreApple", Apple);
        PlayerPrefs.SetInt("score", score);

        //Проверка на сохранение максимального счёта
        if (score >= PlayerPrefs.GetInt("maxScore"))
        {
            MaxScore = score;
            PlayerPrefs.SetInt("maxScore", MaxScore);
        }
        PlayerPrefs.Save();

        scoreText.text = "Score " + score;
        scoreApple.text = "" + Apple;

        //Проверка на проигрыш если игрок проиграл то он не может кидать ножи
        if (GameObject.Find("Canvas").GetComponent<gameOver>().game_over == false)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //Реализация спавна ножей, проигрывания звука
                start++;
                firstKnife.GetComponent<Knife>().isDroped = true;
                firstKnife.GetComponent<AudioSource>().Play();
                if (firstKnife.GetComponent<Knife>().isDroped == true && start == 1)
                {

                    knifeA[start - 1].SetActive(false);
                    shadowKnife[start - 1].SetActive(true);
                    knifeDrop = Instantiate(knife, knifeTransform.position, knifeTransform.rotation);
                }
                if (firstKnife.GetComponent<Knife>().isDroped == true && start == 2)
                {
                    knifeA[start - 1].SetActive(false);
                    shadowKnife[start - 1].SetActive(true);
                    knifeDrop.GetComponent<Animation>().Stop();
                    knifeDrop.GetComponent<Knife>().isDroped = true;
                    knifeDrop = Instantiate(knife, knifeTransform.position, knifeTransform.rotation);
                }
                if (firstKnife.GetComponent<Knife>().isDroped == true && start == 3)
                {
                    knifeA[start - 1].SetActive(false);
                    shadowKnife[start - 1].SetActive(true);
                    knifeDrop.GetComponent<Animation>().Stop();
                    knifeDrop.GetComponent<Knife>().isDroped = true;
                    knifeDrop = Instantiate(knife, knifeTransform.position, knifeTransform.rotation);
                }
                if (firstKnife.GetComponent<Knife>().isDroped == true && start == 4)
                {
                    knifeA[start - 1].SetActive(false);
                    shadowKnife[start - 1].SetActive(true);
                    knifeDrop.GetComponent<Animation>().Stop();
                    knifeDrop.GetComponent<Knife>().isDroped = true;
                    knifeDrop = Instantiate(knife, knifeTransform.position, knifeTransform.rotation);
                }
                if (firstKnife.GetComponent<Knife>().isDroped == true && start == 5)
                {
                    knifeA[start - 1].SetActive(false);
                    shadowKnife[start - 1].SetActive(true);
                    knifeDrop.GetComponent<Animation>().Stop();
                    knifeDrop.GetComponent<Knife>().isDroped = true;
                    knifeDrop = Instantiate(knife, knifeTransform.position, knifeTransform.rotation);
                }
                if (firstKnife.GetComponent<Knife>().isDroped == true && start == 6)
                {
                    knifeA[start - 1].SetActive(false);
                    shadowKnife[start - 1].SetActive(true);
                    knifeDrop.GetComponent<Animation>().Stop();
                    knifeDrop.GetComponent<Knife>().isDroped = true;
                    knifeDrop = Instantiate(knife, knifeTransform.position, knifeTransform.rotation);
                }
                if (firstKnife.GetComponent<Knife>().isDroped == true && start == 7)
                {
                    knifeA[start - 1].SetActive(false);
                    shadowKnife[start - 1].SetActive(true);
                    knifeDrop.GetComponent<Animation>().Stop();
                    knifeDrop.GetComponent<Knife>().isDroped = true;
                    knifeDrop = Instantiate(knife, knifeTransform.position, knifeTransform.rotation);
                }
                if (firstKnife.GetComponent<Knife>().isDroped == true && start == 8)
                {
                    knifeA[start - 1].SetActive(false);
                    shadowKnife[start - 1].SetActive(true);
                    knifeDrop.GetComponent<Animation>().Stop();
                    knifeDrop.GetComponent<Knife>().isDroped = true;
                }
            }

        }
    }

    //Метод сохранения счёта после рестарта игровой сцены
    public void _score(int sc)
    {
        score = sc;
    }
}
