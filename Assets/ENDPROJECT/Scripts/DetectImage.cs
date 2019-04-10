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
    private TrackableBehaviour mTrackableBehaviour;
    public static int st = 0;

    void Start()
    {
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
            switch (imageName)
            {   
                case "Konijn":
                        
                    break;
                case "Bij_Vlinder":
                    
                    break;
                case "Horse":
                    
                    break;
                case "Hedgehog":
                    
                    break;
                case "Fox":
                    
                    break;
                case "Dog":
                    
                    break;
                case "Duck":
                    
                    break;
                case "Deer":

                    break;
                case "Cat":

                    break;
                case "Snaveltje":

                    break;
            }
        }
    }
}
