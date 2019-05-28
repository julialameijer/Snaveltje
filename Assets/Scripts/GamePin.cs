using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GamePin : MonoBehaviour
{

    [SerializeField] private InputField gamePinInput;
    [SerializeField] private InputField nameInput;
    [SerializeField] private Button submitButton;
    [SerializeField] private Button createButton;
    [SerializeField] private Button startGame;
    [SerializeField] private Text wrongText;
    [SerializeField] private Text gamepinText;
    [SerializeField] private GameObject player3;
                     private SceneSwitcher sceneSwitcher;
                     private int gamePin;
                     private bool isCreated;    
    

    void Start()
    {
        //sceneSwitcher = GameObject.Find("GameManager").GetComponent<SceneSwitcher>();
        isCreated = false;
    }

    IEnumerator pushGamePin()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gamepin", gamePin);

        UnityWebRequest www = UnityWebRequest.Post("http://172.16.100.29/Snaveltje/gamepin.php", wwwForm);
        yield return www.SendWebRequest();  
        print(www.downloadHandler.text);
    }

    IEnumerator checkGamePin()
    {
        WWWForm wwwForm = new WWWForm();
        int toBeChecked = int.Parse(gamePinInput.text);
        print("To be checked: " + toBeChecked);
        wwwForm.AddField("gamepin", toBeChecked);
        UnityWebRequest www = UnityWebRequest.Post("http://172.16.100.29/Snaveltje/gamepinLogin.php", wwwForm);
        yield return www.SendWebRequest();
        
        if(www.downloadHandler.text == "1")
        {
            GameObject.Find("Player2").SetActive(false);
            player3.SetActive(true);
        }

        if (www.downloadHandler.text == "0")
        {
            wrongText.gameObject.SetActive(true);
        }

    }

    public void callIEnumerator()
    {
        StartCoroutine(checkGamePin());
    }

    public void makeGamePin()
    {
        gamePin = Random.Range(100000, 999999);
        //gamePin = 1;
        print(gamePin);
        StartCoroutine(pushGamePin());
        gamepinText.gameObject.SetActive(true);
        createButton.gameObject.SetActive(false);
        startGame.gameObject.SetActive(true);
        gamepinText.text = gamePin.ToString();
        isCreated = true;
    }

    public void checkInput()
    {
        if(gamePinInput.text.Length > 0 || nameInput.text.Length > 0)
        {
            submitButton.interactable = true;
        }
    }

    public void quitApplication()
    {
        StartCoroutine(onApplicationQuit());
    }

    IEnumerator onApplicationQuit()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gamepin", gamePin);
        UnityWebRequest www = UnityWebRequest.Post("http://172.16.100.23/Snaveltje/removeFromDB.php", wwwForm);
        yield return www.SendWebRequest();
        print("Deleted info: " + www.downloadHandler.text);
    }
}
