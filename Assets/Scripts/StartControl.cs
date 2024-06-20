using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartControl : MonoBehaviour
{
    public static string Questions_txtFile = "";
    public static string Section = "";
    public Button BTN_1, BTN_2, BTN_3;
    public Text txt_title, txt_BTN_1, txt_BTN_2, txt_BTN_3;
    void Start()
    {
        txt_title.text = "QuizGame";
        txt_BTN_1.text = "General  Questions";
        txt_BTN_2.text = "Historical Questions ";
        txt_BTN_3.text = "Geographical Questions";
    }

    public void BTN1()
    {
        Questions_txtFile = "txtfile_1.txt";
        Section = "General  Questions";
        GOTO_Game();
    }
    public void BTN2()
    {
        Questions_txtFile = "txtfile_2.txt";
        Section = "Historical Questions";
        GOTO_Game();
    }
    public void BTN3()
    {
        Questions_txtFile = "txtfile_3.txt";
        Section = "Geographical Questions";
        GOTO_Game();
    }
    public void GOTO_Game()
    {
        SceneManager.LoadScene("Game");
    }
}
