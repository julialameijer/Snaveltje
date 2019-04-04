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
    Player player;

    private PlayerCreator playerCreator;

    void Start()
    {
        playerCreator = GameObject.Find("__PlayerGameManager").GetComponent<PlayerCreator>();
        player = playerCreator.getPlayer();
    }

    public void setQuestion(int listIndex)
    {
        finalnumber = listIndex;
        string text = questions[listIndex].question;
        questionText.text = text;
    }

    public void checkQuestion(InputField answer)
    {
        nameOfTeam.text = player.getName();
        answerOfTeam.text = answer.text;
        questionOfTeam.text = getCurrentQuestion().question;

        
        print("Player: " + player.getName() + " Current Question: " + getCurrentQuestion().question + " Answer: " + answer.text);
    }

    private OpenQuestion getCurrentQuestion()
    {
        return questions[finalnumber];
    }

    public void addAnswerToFile(Player player, string question, string answer, bool isTrue)
    {
        string path = Application.dataPath + "/AnswerFiles" + "/" + player.getName() + ".txt";
        File.AppendAllText(path, "\n" + "Question: " + question + " Answer given: " + answer + ", This answer is " + isTrue);
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
