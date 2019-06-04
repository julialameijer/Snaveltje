using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    private QuestionHandler questionHandlerScript;
    private Scene gameScene;
    private GameObject questionHandlerObject;
    private GameObject timeTextObject;
    private GameObject scoreTextObject;
    private GameObject bonusTextObject;
    private Text timeText;
    private Text scoretext;
    private Text bonusText;
    [SerializeField] private Text updateTimeText;
    [SerializeField] private GamePin gamepin;
    private int rightAnswered;


    public static GameManager Instance;
    public List<int> questionOrder;
    public Stopwatch timer;

    void Start()
    {

        
        timer = new Stopwatch();

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

    void Update()
    {
        timer.Elapsed.Seconds.ToString();
        updateTimeText.text = timer.Elapsed.TotalSeconds.ToString();
    }

    public void rightAnswerPlus()
    {
        rightAnswered++;
    }

    public void setOrder(int questionAmount)
    {
        for (int i = 0; i < questionAmount+ 1; i++)
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
        return questionOrder.First();
    }

    public void startTimer()
    {
        timer.Start();
    }


    public void stopTimer()
    {
        timer.Stop();
    }


    public void resultScreen()
    {
        double score;
        float timePlayed;
        double bonus;
        double finalscore;

        bonus = rightAnswered * 32;
        timePlayed = Mathf.Round((float)timer.Elapsed.TotalSeconds);

        //timePlayed = (float)timer.Elapsed.TotalSeconds;
        score = timePlayed * 50;
        finalscore = score - bonus;

        timeTextObject = GameObject.Find("TimeText");
        scoreTextObject = GameObject.Find("ScoreText");
        bonusTextObject = GameObject.Find("BonusText");

        timeText = timeTextObject.GetComponent<Text>();
        timeText.text = timePlayed.ToString() + " Seconden";

        bonusText = bonusTextObject.GetComponent<Text>();
        bonusText.text = "Je verdiende bonus: " + bonus.ToString();

        scoretext = scoreTextObject.GetComponent<Text>();
        scoretext.text = "Je eindscore: " + score.ToString();
    }

    public void lastScene()
    {
        stopTimer();
        SceneManager.LoadScene("EndScene");
        StartCoroutine(MakeEndScene());
    }

    IEnumerator MakeEndScene()
    {
        yield return 0;
        resultScreen();
    }
    
    public void deletePlayedFromList(int playedQuestion)
    {
        questionOrder.Remove(playedQuestion);
    }

    public void passQuestion(int index)
    {
        //gameScene = SceneManager.GetSceneByBuildIndex(2);
        SceneManager.LoadScene("GameScene");
        print("passquestion");
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
            case 5:
            case 7:
            case 6:
            case 8:
            case 9:
            case 10:
                questionHandlerScript.setMultipleChoice(index);
                break;
            case 1:
            case 3:
                //questionHandlerScript.setOpenQuestion(index);
                questionHandlerScript.setMultipleChoice(index);
                break;

        }
    }

    public void startInvokeRepeat()
    {
        InvokeRepeating("checkStart",0.0f, 0.5f);

    }

    private void checkStart()
    {
        StartCoroutine(Check());
    }

    private IEnumerator Check()
    {        
        WWWForm wwwForm = new WWWForm();        
        wwwForm.AddField("gamepin", gamepin.getGamepin());
        UnityWebRequest www = UnityWebRequest.Post("https://snaveltje.wildsea.nl/checkStart.php", wwwForm);
        yield return www.SendWebRequest();


        if(www.downloadHandler.text == "1")
        {
            startGame();
        }
    }

    public void startGame()
    {
        StopCoroutine(Check());
        CancelInvoke();
        SceneManager.LoadScene("ScannerScene");
        startTimer();
    }
}
