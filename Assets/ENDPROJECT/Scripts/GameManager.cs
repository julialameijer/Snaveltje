using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private QuestionHandler questionHandlerScript; 
    private GameObject questionHandlerObject;
    public static GameManager Instance;   

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

    public void passQuestion(int index)
    {
        SceneManager.LoadScene("GameScene");
        questionHandlerObject = GameObject.FindGameObjectWithTag("QuestionHandler");
        print(questionHandlerObject);
        questionHandlerScript = questionHandlerObject.GetComponent<QuestionHandler>();
        //questionHandlerScript = (QuestionHandler)FindObjectOfType(typeof(QuestionHandler));
        switch (index)
            {
                case 2:
                case 4:
                case 6:
                case 8:
                case 9:
                    print(index);
                    questionHandlerScript.setMultipleChoice(index);
                    break;
                case 1:
                case 3:
                case 7:
                    print(index);
                    questionHandlerScript.setOpenQuestion(index);
                    break;
                case 5:
                case 0:
                    print(index);
                    questionHandlerScript.setAssignment(index);
                    break;
            }
    }
}
