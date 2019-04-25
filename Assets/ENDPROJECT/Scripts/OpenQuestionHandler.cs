using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class OpenQuestionHandler : MonoBehaviour
{
    [SerializeField]
    private Text questionText;

    [SerializeField]
    private OpenQuestion[] questions;

    [SerializeField]
    private InputField answer;

    [SerializeField]
    private Text nameOfTeam;

    [SerializeField]
    private Text answerOfTeam;

    [SerializeField]
    private Text questionOfTeam;


    private int finalnumber;
    private Player player;


    void Start()
    {
    }

    public void setQuestion(int listIndex)
    {
        finalnumber = listIndex;
        string text = questions[listIndex].question;
        questionText.text = text;
    }


    private OpenQuestion getCurrentQuestion()
    {
        return questions[finalnumber];
    }

    public void addAnswerToFile(Player player, string question, string answer, bool isTrue)
    {

    }

    public void isTrue()
    {
        addAnswerToFile(player, getCurrentQuestion().question, answer.text, true);
    }

    public void isFalse()
    {
        addAnswerToFile(player, getCurrentQuestion().question, answer.text, false);
    }
}
