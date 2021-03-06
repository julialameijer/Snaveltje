﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GamePin : MonoBehaviour
{

    [SerializeField] private InputField gamePinInput;
    [SerializeField] private InputField nameInput;
    [SerializeField] private Button gamepinSubmit;
    [SerializeField] private Button nameSubmit;
    [SerializeField] private Button createButton;
    [SerializeField] private Button startGame;
    [SerializeField] private GameObject host;
    [SerializeField] private GameObject host1;
    [SerializeField] private Text wrongText;
    [SerializeField] private Text gamepinText;
    [SerializeField] private GameObject player3;
                     private SceneSwitcher sceneSwitcher;
                     private int gamePin;
                     private bool isCreated;
    private int toBeChecked;

    void Start()
    {
        isCreated = false;
    }

    IEnumerator pushGamePin()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gamepin", gamePin);

        UnityWebRequest www = UnityWebRequest.Post("https://snaveltje.wildsea.nl/gamepin.php", wwwForm);
        yield return www.SendWebRequest();  
        print(www.downloadHandler.text);
    }

    IEnumerator checkGamePin()
    {
        WWWForm wwwForm = new WWWForm();
        toBeChecked = int.Parse(gamePinInput.text);
        wwwForm.AddField("gamepin", toBeChecked);
        UnityWebRequest www = UnityWebRequest.Post("https://snaveltje.wildsea.nl/gamepinLogin.php", wwwForm);
        yield return www.SendWebRequest();

        print(www.downloadHandler.text);

        if(www.downloadHandler.text == "1")
        {
            //GameObject.Find("Player2").SetActive(false);
            player3.SetActive(true);
        }

        else if(www.downloadHandler.text == "0" || www.downloadHandler.text == null)
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
        StartCoroutine(pushGamePin());
        host.SetActive(false);
        host1.SetActive(true);
        gamepinText.text = gamePin.ToString();
        isCreated = true;
    }

    public void checkInput()
    {
        if(gamePinInput.text.Length > 0 || nameInput.text.Length > 0)
        {
            gamepinSubmit.interactable = true;
            nameSubmit.interactable = true;
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
        UnityWebRequest www = UnityWebRequest.Post("https://snaveltje.wildsea.nl/removeFromDB.php", wwwForm);
        yield return www.SendWebRequest();
        print("Deleted info: " + www.downloadHandler.text);
    }

    public int getInputGamepin()
    {
        return toBeChecked;
    }

    public int getCurrentGamepin()
    {
        return gamePin;
    }
}
