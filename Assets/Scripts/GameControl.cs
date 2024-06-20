 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
public class GameControl : MonoBehaviour
{
    public Text 
        txt_question,
        txt_score,
        txt_section,
        txt_answer1,
        txt_answer2,
        txt_answer3;
    public Button 
        btn_an_1,
        btn_an_2,
        btn_an_3;
    public Image Image_TrueFalse;
    string[] Question_list=null;
    int question_num = 0;
    int score = 0;
    int AnswerNum = 0;
    public GameObject panel_btn;

    [SerializeField]
    TMP_InputField countInput;
    [SerializeField]
    Button confirmCountbtn;
    string path;
    void Start()
    {
        score = 0;
        txt_section.text = StartControl.Section;
        Image_TrueFalse.gameObject.SetActive(false);
        //Question_list = System.IO.File.ReadAllLines("Assets/txt/" + StartControl.Questions_txtFile);
        confirmCountbtn.onClick.AddListener(SetQuestions);
    }
    string[] ReadQuestionsLines(int count, string path)
    {
        StreamReader reader = new StreamReader(path);
        string[] questions = new string[count];
        for (int i = 0; i < count; i++)
        {
            questions[i] = reader.ReadLine();
        }
        return questions;
    }
    public void SetQuestions()
    {
        path = Path.Combine("Assets/txt/", StartControl.Questions_txtFile);
        int count = int.Parse(countInput.text);
        Question_list = ReadQuestionsLines(count, path);
        showList();
    }
    private void showList()
    {
        btn_an_1.GetComponent<Image>().color = Color.black;
        btn_an_2.GetComponent<Image>().color = Color.black;
        btn_an_3.GetComponent<Image>().color = Color.black;
        btn_an_1.interactable = true;
        btn_an_2.interactable = true;
        btn_an_3.interactable = true;
        Image_TrueFalse.gameObject.SetActive(false);
        if (Question_list.Length > question_num)
        {
            string[] qa = Question_list[question_num].Split('/');
            if (qa.Length == 5)
            {
                txt_question.text = qa[0].Trim();
                txt_answer1.text = qa[1].Trim();
                txt_answer2.text = qa[2].Trim();
                txt_answer3.text = qa[3].Trim();
                AnswerNum = int.Parse(qa[4]);
            }
            question_num++;
        }
        else
        {
            panel_btn.gameObject.SetActive(false);
            txt_question.text = "The questions have ended";
        }
    }


    public void btnAnswer_1()
    {
        if (AnswerNum == 1)
        {
            score++;
            showImageTRueFalse("true");
            btn_an_1.GetComponent<Image>().color = Color.green;

        }
        else
        {
            showImageTRueFalse("false");
            btn_an_1.GetComponent<Image>().color = Color.red;
        }
        ChangeScoreTxt();
    }
    public void btnAnswer_2()
    {
        if (AnswerNum == 2)
        {
            score++;
            showImageTRueFalse("true");
            btn_an_2.GetComponent<Image>().color = Color.green;
        }
        else
        {
            showImageTRueFalse("false");
            btn_an_2.GetComponent<Image>().color = Color.red;
        }
        ChangeScoreTxt();
    }
    public void btnAnswer_3()
    {
        if (AnswerNum == 3)
        {
            score++;
            showImageTRueFalse("true");
            btn_an_3.GetComponent<Image>().color = Color.green;
        }
        else
        {
            showImageTRueFalse("false");
            btn_an_3.GetComponent<Image>().color = Color.red;
        }
        ChangeScoreTxt();
    }
    private void showImageTRueFalse(string img)
    {
        btn_an_1.interactable = false;
        btn_an_2.interactable = false;
        btn_an_3.interactable = false;
        Image_TrueFalse.gameObject.SetActive(true);
        Image_TrueFalse.GetComponent<Image>().sprite = Resources.Load<Sprite>(img);
        Invoke("showList", 1.5f);
    }
    void ChangeScoreTxt()
    {
        txt_score.text = ("Correct answers " + score + " From " + Question_list.Length);
    }
    public void BTN_Back()
    {
        SceneManager.LoadScene("Start");
    }
}
