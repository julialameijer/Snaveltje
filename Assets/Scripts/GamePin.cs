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
    [SerializeField] private Button generatePinButton;
    [SerializeField] private Text wrongText;
    [SerializeField] private GameObject player3;
                     private SceneSwitcher sceneSwitcher;
                     private int gamePin;
                     
    

    void Start()
    {
        sceneSwitcher = GameObject.Find("GameManager").GetComponent<SceneSwitcher>();
    }

    IEnumerator pushGamePin()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gamepin", gamePin);

        UnityWebRequest www = UnityWebRequest.Post("http://172.16.100.49/Snaveltje/gamepin.php", wwwForm);
        yield return www.SendWebRequest();
        print(www.downloadHandler.text);
    }

    IEnumerator checkGamePin()
    {
        WWWForm wwwForm = new WWWForm();
        int toBeChecked = int.Parse(gamePinInput.text);
        print("To be checked: " + toBeChecked);
        wwwForm.AddField("gamepin", toBeChecked);
        UnityWebRequest www = UnityWebRequest.Post("http://172.16.100.49/Snaveltje/gamepinLogin.php", wwwForm);
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
    }
    
    public void checkInput()
    {
        if(gamePinInput.text.Length > 0 && nameInput.text.Length > 0)
        {
            submitButton.interactable = true;
        }
    }
}
