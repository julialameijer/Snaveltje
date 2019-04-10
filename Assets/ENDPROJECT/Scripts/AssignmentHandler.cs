using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignmentHandler : MonoBehaviour
{
    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Assignment[] assignments;

    private int finalnumber;
    private Player player;

    private Camera _camera;
    private bool saveImageOnNextFrame;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        print(_camera);

        //playerCreator = GameObject.Find("__PlayerGameManager").GetComponent<PlayerCreator>();
        //player = playerCreator.getPlayer();
    }

    public void setQuestion(int listIndex)
    {
        finalnumber = listIndex;
        string text = assignments[listIndex].assignment;
        questionText.text = text;
    }

    private void Update()
    {
        print("hallo");
        if (saveImageOnNextFrame)
        {
            print("hey");
            saveImageOnNextFrame = false;
            RenderTexture renderTexture = _camera.targetTexture;

            Texture2D renderresult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0,0, renderTexture.width, renderTexture.height);

            renderresult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderresult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/Screenshot.png", byteArray);
            print("Saved!");

            RenderTexture.ReleaseTemporary(renderTexture);
            _camera.targetTexture = null;
            
        }
    }

    public void saveImage()
    {
        //_camera.targetTexture = RenderTexture.GetTemporary( , ,  16);
        saveImageOnNextFrame = true;
    }
}
