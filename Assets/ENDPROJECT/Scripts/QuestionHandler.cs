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
        Question question = multipleChoiceQuestions[index];
        questionText.text = question.question;

        sceneSwitcher.newElement(multipleChoiceQuestion);

        A.text = question.answerA;
        B.text = question.answerB;
        C.text = question.answerC;
    }

    public void setOpenQuestion(int index)
    {
        OpenQuestion question = openQuestions[index];
        questionText.text = question.question;
        sceneSwitcher.newElement(openQuestion);
    }

    public void setAssignment(int index)
    {
        Assignment assignment = assignments[index];
        questionText.text = assignment.assignment;
    }
}
