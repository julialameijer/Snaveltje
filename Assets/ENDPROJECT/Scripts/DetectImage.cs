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
    [SerializeField]
    private Text headerText;
    private GameObject gameManagerObject;
    private GameManager gameManagerScript;
    private SceneSwitcher sceneSwitcherScript;

    private TrackableBehaviour mTrackableBehaviour;
    public static int st = 0;

    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");

        TrackerManager.Instance.GetStateManager().ReassociateTrackables();

        gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        sceneSwitcherScript = gameManagerObject.GetComponent<SceneSwitcher>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
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
            int imageName = int.Parse(mTrackableBehaviour.Trackable.Name);
            TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
           
            print("Is Scanned: " + imageName);
            if(imageName == gameManagerScript.getNextQuestionIndex())
            {
                print("Good Scan!");
                gameManagerScript.passQuestion(imageName);
                sceneSwitcherScript.switchScene("GameScene");
            }
            else 
            {
                print("Wrong Scan!");
                TrackerManager.Instance.GetTracker<ObjectTracker>().Start();

            }
        }
    }

    public void TESTGoNextScene()
    {
        int questionnumber = Random.Range(1, 10);
        print("Is: " + questionnumber);
        print("Should be: " + gameManagerScript.getNextQuestionIndex());
        if (questionnumber == gameManagerScript.getNextQuestionIndex())
        {
            print("Good Scan!");
            gameManagerScript.passQuestion(questionnumber);
            sceneSwitcherScript.switchScene("GameScene");
        }
        else
        {
            print("This is the wrong one!");
        }
    }
}
