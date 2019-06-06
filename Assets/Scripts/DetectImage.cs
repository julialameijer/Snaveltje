using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class DetectImage : MonoBehaviour,
Vuforia.ITrackableEventHandler
{
    [SerializeField] private Text headerText;
    [SerializeField] private GameObject goodScan;
    [SerializeField] private GameObject wrongScan;


    private GameObject gameManagerObject;
    private GameManager gameManagerScript;
    private SceneSwitcher sceneSwitcherScript;
    private TrackableBehaviour mTrackableBehaviour;
    public static int st = 0;
    private int imageName;

    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");

        TrackerManager.Instance.GetStateManager().ReassociateTrackables();

        gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        sceneSwitcherScript = gameManagerObject.GetComponent<SceneSwitcher>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        setNextText();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void setNextText()
    {
        int questionIndex = gameManagerScript.getNextQuestionIndex();
        switch (questionIndex)
        {
            case 0:
                gameManagerScript.deletePlayedFromList(0);
                print("Deleted 0");
                break;
            case 1:
                headerText.text = "Zoek Kirsten de kat!";
                break;
            case 2:
                headerText.text = "Zoek Veerle de vlinder!";
                break;
            case 3:
                headerText.text = "Zoek Hannah het hert";
                break;
            case 4:
                headerText.text = "Zoek Corrie het konijn!";
                break;
            case 5:
                headerText.text = "Zoek Bert de bij!";
                break;
            case 6:
                headerText.text = "Zoek Peter het paard!";
                break;
            case 7:
                headerText.text = "Zoek Emily de egel!";
                break;
            case 8:
                headerText.text = "Zoek Victor de vos!";
                break;
            case 9:
                headerText.text = "Zoek Henry de hond!";
                break;
            case 10:
                headerText.text = "Zoek Evert de ezel!";
                break;
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status newStatus)
    {
        OnTrackableStateChanged(default(TrackableBehaviour.Status), newStatus);     
    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == null)
            throw new System.ArgumentNullException("newStatus");
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            st = 1;
            imageName = int.Parse(mTrackableBehaviour.Trackable.Name);
            print(imageName);
            TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
           
            if (imageName == gameManagerScript.getNextQuestionIndex())
            {
                goodScan.SetActive(true);

            }
            else
            {
                wrongScan.SetActive(true);
            }
        }
    }

    public void GoodScan()
    {
        gameManagerScript.passQuestion(imageName);
        print("Imagename: " + imageName);

        
        sceneSwitcherScript.switchScene("GameScene");
    }

    public void WrongScan()
    {
        wrongScan.SetActive(false);
        TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
    }

    public void TESTGoNextScene()
    {
        int questionnumber = gameManagerScript.getNextQuestionIndex();
        if (questionnumber == gameManagerScript.getNextQuestionIndex())
        {
            print("Good Scan! " + questionnumber);
            gameManagerScript.passQuestion(questionnumber);
            //sceneSwitcherScript.switchScene("GameScene");   
        }
        else
        {
            print("Wrong Scan!");
            TrackerManager.Instance.GetTracker<ObjectTracker>().Start();

        }
    }
}
