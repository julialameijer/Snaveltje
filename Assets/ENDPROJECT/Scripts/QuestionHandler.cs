using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class QuestionHandler : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameObject sceneSwitcherObject;

    private GameManager gamemanagerScript;
    private PlayerManager playerManager;
    private SceneSwitcher sceneSwitcher;

    private int index;

    [SerializeField] private Text questionText;
    [SerializeField] private Text A;
    [SerializeField] private Text B;
    [SerializeField] private Text C;
    [SerializeField] private OpenQuestion[] openQuestions;
    [SerializeField] private Question[] multipleChoiceQuestions;
    [SerializeField] private Assignment[] assignments;

    [SerializeField] private GameObject openQuestion;
    [SerializeField] private GameObject assignment;
    [SerializeField] private GameObject multipleChoiceQuestion;
    [SerializeField] private GameObject questionObject;
    [SerializeField] private GameObject rightAnswer;
    [SerializeField] private GameObject wrongAnswer;

    

    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        sceneSwitcherObject = GameObject.Find("Sceneswitcher");
        gamemanagerScript = gameManagerObject.GetComponent<GameManager>();
        playerManager =   gameManagerObject.GetComponent<PlayerManager>();
        sceneSwitcher = sceneSwitcherObject.GetComponent<SceneSwitcher>();
    }


    public void setMultipleChoice(int index)
    {
        this.index = index;
        Question question = multipleChoiceQuestions[index];
        questionText.text = question.question;
        sceneSwitcher.newElement(multipleChoiceQuestion);
        A.text = question.answerA;
        B.text = question.answerB;
        C.text = question.answerC;
    }

    public void setOpenQuestion(int index)
    {
        this.index = index;
        OpenQuestion question = openQuestions[index];
        questionText.text = question.question;
        sceneSwitcher.newElement(openQuestion);
    }

    public void setAssignment(int index)
    {
        this.index = index;

        Assignment assignment = assignments[index];
        questionText.text = assignment.assignment;
    }

    public void checkMultipleChoice(string answer)
    {
        if(answer == multipleChoiceQuestions[index].rightAnswer)
        {
            sceneSwitcher.oldElement(questionObject);
            sceneSwitcher.newElement(rightAnswer);
        }

        else
        {
            sceneSwitcher.newElement(wrongAnswer);
            sceneSwitcher.oldElement(questionObject);
        }
    }

    public void checkList()
    {
        if (gamemanagerScript.questionOrder.Count == 0)
        {
            sceneSwitcher.switchScene("EndScene");
        }
    }
}
