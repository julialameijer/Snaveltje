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
            string imageName = mTrackableBehaviour.TrackableName;
            TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
            gameManagerScript.passQuestion(int.Parse(imageName));
            sceneSwitcherScript.switchScene("GameScene");
        }
    }

    public void TESTGoNextScene()
    {
        gameManagerScript.passQuestion(2);
    }
}
