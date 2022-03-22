using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropKnife : MonoBehaviour
{
    public GameObject knife;
    public GameObject[] knifeA;//���� ����� �� Canvas
    public GameObject firstKnife;//��������� ���
    public Transform knifeTransform;//����� ������ ����� �����
    GameObject knifeDrop;

    public GameObject[] shadowKnife;//���� ����� �� Canvas
    public int start = 0;//���������� ��� �������� �����

    [Header("GUI")]
    public Text scoreText;
    public Text scoreApple;
    public int score = 0;
    public int Apple = 0;
    public int MaxScore = 0;

    void Start()
    {

        for (int i = 0; i < shadowKnife.Length; i++) shadowKnife[i].SetActive(false);
        // �������� ����� ���� ���������� ������ ���� ����������
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
        //���������� ����� � ���������� �����
        PlayerPrefs.SetInt("scoreApple", Apple);
        PlayerPrefs.SetInt("score", score);

        //�������� �� ���������� ������������� �����
        if (score >= PlayerPrefs.GetInt("maxScore"))
        {
            MaxScore = score;
            PlayerPrefs.SetInt("maxScore", MaxScore);
        }
        PlayerPrefs.Save();

        scoreText.text = "Score " + score;
        scoreApple.text = "" + Apple;

        //�������� �� �������� ���� ����� �������� �� �� �� ����� ������ ����
        if (GameObject.Find("Canvas").GetComponent<gameOver>().game_over == false)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //���������� ������ �����, ������������ �����
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

    //����� ���������� ����� ����� �������� ������� �����
    public void _score(int sc)
    {
        score = sc;
    }
}
