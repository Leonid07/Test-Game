using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text Tscore;
    public Text Tapple;
    int score = 0;
    int scoreMax = 0;
    int apple = 0;
    void Start()
    {
        //Загрузка счёта и количества порожённых яблок
        if (PlayerPrefs.HasKey("maxScore")) scoreMax = PlayerPrefs.GetInt("maxScore");
        if (PlayerPrefs.HasKey("scoreApple")) apple = PlayerPrefs.GetInt("scoreApple");
        Tapple.text = "" + apple;
        Tscore.text = "Максимальный счёт " + scoreMax;
    }
}
