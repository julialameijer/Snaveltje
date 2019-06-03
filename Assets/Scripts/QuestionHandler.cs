using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class QuestionHandler : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameObject sceneSwitcherObject;

    private GameManager gamemanagerScript;
    private PlayerManager playerManager;
    private SceneSwitcher sceneSwitcher;

    private int index;
    private int rightansweredquestions;
    
    [SerializeField] private Text questionText;
    [SerializeField] private Text A;
    [SerializeField] private Text B;
    [SerializeField] private Text C;

    [SerializeField] private OpenQuestion[] biologyQuestions;
    [SerializeField] private Question[] biologymMultipleChoiceQuestions;

    [SerializeField] private OpenQuestion[] gameQuestions;
    [SerializeField] private Question[] gameMultipleChoiceQuestions;

    [SerializeField] private OpenQuestion[] historyQuestions;
    [SerializeField] private Question[] historyMultipleChoiceQuestions;

    [SerializeField] private OpenQuestion[] englishQuestions;
    [SerializeField] private Question[] englishMultipleChoiceQuestions;

    [SerializeField] private OpenQuestion[] arithmeticQuestions;
    [SerializeField] private Question[] arithmeticMultipleChoiceQuestions;

    [SerializeField] private GameObject openQuestion;
    [SerializeField] private GameObject multipleChoiceQuestion;
    [SerializeField] private GameObject rightAnswer;
    [SerializeField] private GameObject wrongAnswer;



    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        sceneSwitcherObject = GameObject.Find("Sceneswitcher");
        gamemanagerScript = gameManagerObject.GetComponent<GameManager>();
        playerManager = gameManagerObject.GetComponent<PlayerManager>();
        sceneSwitcher = sceneSwitcherObject.GetComponent<SceneSwitcher>();
    }

    public void setMultipleChoice(int index)
    {
        this.index = index;
        Question question = gameMultipleChoiceQuestions[index];
        questionText.text = question.question;
        sceneSwitcher.newElement(multipleChoiceQuestion);
        A.text = question.answerA;
        B.text = question.answerB;
        C.text = question.answerC;
    }

    public void setOpenQuestion(int index)
    {
        this.index = index;
        OpenQuestion question = englishQuestions[index];
        questionText.text = question.question;
        sceneSwitcher.newElement(openQuestion);
    }

 /*   public void setAssignment(int index)
    {
        this.index = index;

        Assignment assignment = assignments[index];
        questionText.text = assignment.assignment;
        sceneSwitcher.newElement(assignmentObject);

    }*/

    public void checkMultipleChoice(string answer)
    {
        if(answer == gameMultipleChoiceQuestions[index].rightAnswer)
        {
            sceneSwitcher.oldElement(multipleChoiceQuestion);
            sceneSwitcher.newElement(rightAnswer);
            gamemanagerScript.rightAnswerPlus();
        }

        else
        {
            sceneSwitcher.newElement(wrongAnswer);
            sceneSwitcher.oldElement(multipleChoiceQuestion);
        }
    }

    public void checkList()
    {
        if (gamemanagerScript.questionOrder.Count == 0 || gamemanagerScript.questionOrder.First() == 0 && gamemanagerScript.questionOrder.Count == 1)
        {
            gamemanagerScript.lastScene();
        }
    }
}
