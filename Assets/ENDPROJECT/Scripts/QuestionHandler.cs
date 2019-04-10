using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class QuestionHandler : MonoBehaviour
{
    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Button answerA;


    [SerializeField]
    private Button answerB;

    [SerializeField]
    private Button answerC;

    [SerializeField]
    private Question[] questions;

    private Player player;


    private int finalnumber;

    void Start()
    {
    }

    public void setQuestion(int listIndex)
    {
        
        finalnumber = listIndex;
         string text = questions[listIndex].question;
        questionText.text = text;

        answerA.GetComponentInChildren<Text>().text = questions[listIndex].answerA;
        answerB.GetComponentInChildren<Text>().text = questions[listIndex].answerB;
        answerC.GetComponentInChildren<Text>().text = questions[listIndex].answerC;
    }

    public void checkQuestion(string answer)
    {
        Question question;

        question = getCurrentQuestion();
        if (question.rightAnswer == answer)
        {
            addAnswerToFile(player, question.question, answer, true);
        }
        else
        {
            addAnswerToFile(player, question.question, answer, false);
        }
        
    }

    private Question getCurrentQuestion()
    {
        return questions[finalnumber];
    }

    public void addAnswerToFile(Player player, string question, string answer, bool isCorrect)
    {
    }

}
