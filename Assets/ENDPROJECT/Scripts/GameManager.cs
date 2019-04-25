using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private QuestionHandler questionHandlerScript;
    private GameObject[] dontDestroyObjects;
    private Scene gameScene;
    private GameObject questionHandlerObject;
    public static GameManager Instance;
    public List<int> questionOrder;

    void Start()
    {


        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }

    public void setOrder(int questionAmount)
    {
        for (int i = 0; i < questionAmount; i++)
        {
            questionOrder.Add(i);
        }
        for (int i = 0; i < questionOrder.Count; i++)
        {
            int temp = questionOrder[i];
            int randomIndex = Random.Range(i, questionOrder.Count);
            questionOrder[i] = questionOrder[randomIndex];
            questionOrder[randomIndex] = temp;
        }
    }

    public int getNextQuestionIndex()
    {
        print(questionOrder.First());
        return questionOrder.First();
    }

    public void deletePlayedFromList(int playedQuestion)
    {
        questionOrder.Remove(playedQuestion);
        print("Next to be found: " + questionOrder.First());
    }

    public void passQuestion(int index)
    {
        gameScene = SceneManager.GetSceneByBuildIndex(2);
        SceneManager.LoadScene("GameScene");
        StartCoroutine(ABC(index));
    }

    IEnumerator ABC(int index)
    {
        yield return 0;
        questionHandlerObject = GameObject.Find("QuestionHandler");
        questionHandlerScript = questionHandlerObject.GetComponent<QuestionHandler>();
        deletePlayedFromList(index);
        switch (index)
        {
            case 2:
            case 4:
            case 6:
            case 8:
            case 9:
                questionHandlerScript.setMultipleChoice(index);
                break;
            case 1:
            case 3:
            case 7:
                questionHandlerScript.setOpenQuestion(index);
                break;
            case 5:
            case 0:
                questionHandlerScript.setAssignment(index);
                break;
        }
    }
}
