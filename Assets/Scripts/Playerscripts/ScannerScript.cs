using BarcodeScanner;
using BarcodeScanner.Scanner;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Wizcorp.Utils.Logger;
using System.Collections.Generic;
using System.Linq;


public class ScannerScript: MonoBehaviour
{

    private IScanner barcodeScanner;
    private int barcodeID;

    [SerializeField]
    private RawImage _image;

    [SerializeField]
    private Button button;

    [SerializeField]
    private Text textheader;

    [SerializeField]
    private SceneSwitcher sceneSwitcher;

    [SerializeField]
    private OpenQuestionHandler openQuestionHandler;

    [SerializeField]
    private QuestionHandler questionHandler;

    [SerializeField]
    private AssignmentHandler assignmentHandler;

    [SerializeField]
    private GameObject scanObject;

    [SerializeField]
    private GameObject multipleChoiceObject;

    [SerializeField]
    private GameObject openQuestionObject;

    [SerializeField]
    private GameObject assignmentObject;


    void Awake()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    void Start()
    {
        // Create a basic scanner
        barcodeScanner = new Scanner();
        barcodeScanner.Camera.Play();
        DontDestroyOnLoad(this);

        // Display the camera texture through a RawImage
        barcodeScanner.OnReady += (sender, arg) => {
            // Set Orientation & Texture
            _image.transform.localEulerAngles = barcodeScanner.Camera.GetEulerAngles();
            _image.transform.localScale = barcodeScanner.Camera.GetScale();
            _image.texture = barcodeScanner.Camera.Texture;

            // Keep Image Aspect Ratio
            var rect = _image.GetComponent<RectTransform>();
            var newHeight = rect.sizeDelta.x * barcodeScanner.Camera.Height / barcodeScanner.Camera.Width;
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, newHeight);
        };

    }
    void Update()
    {
        if (barcodeScanner == null)
        {
            return;
        }
        barcodeScanner.Update();
    }


    public void ClickStart()
    {
        if (barcodeScanner == null)
        {
            Log.Warning("No valid camera - Click Start");
            return;
        }

        // Start Scanning
        barcodeScanner.Scan((barCodeType, barCodeValue) =>
        {
            barcodeScanner.Stop();

            int barcodevalue = int.Parse(barCodeValue);
            switch (barcodevalue)
            {
                case 1:
                case 5:
                case 7:
                    questionHandler.setQuestion(barcodevalue);
                    sceneSwitcher.newElement(multipleChoiceObject);
                    sceneSwitcher.oldElement(scanObject);
                    break;

                case 2:
                case 4:
                case 6:
                    openQuestionHandler.setQuestion(barcodevalue);
                    sceneSwitcher.newElement(openQuestionObject);
                    sceneSwitcher.oldElement(scanObject);
                    break;

                case 3:
                    assignmentHandler.setQuestion(barcodevalue);
                    sceneSwitcher.newElement(assignmentObject);
                    sceneSwitcher.oldElement(scanObject);
                    break;

            }

        });
    }

    public void ClickStop()
    {
        if (barcodeScanner == null)
        {
            Log.Warning("No valid camera - Click Stop");
            return;
        }

        // Stop Scanning
        barcodeScanner.Stop();
    }

    public void ClickBack()
    {
        // Try to stop the camera before loading another scene
        StartCoroutine(StopCamera(() => {
            SceneManager.LoadScene("Boot");
        }));
    }

    /// <summary>
    /// This coroutine is used because of a bug with unity (http://forum.unity3d.com/threads/closing-scene-with-active-webcamtexture-crashes-on-android-solved.363566/)
    /// Trying to stop the camera in OnDestroy provoke random crash on Android
    /// </summary>
    /// <param name="callback"></param>
    /// <returns></returns>
    public IEnumerator StopCamera(Action callback)
    {
        // Stop Scanning
        _image = null;
        barcodeScanner.Destroy();
        barcodeScanner = null;

        // Wait a bit
        yield return new WaitForSeconds(0.1f);

        callback.Invoke();
    }
}