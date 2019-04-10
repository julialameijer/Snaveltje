using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePinHandler : MonoBehaviour
{
///Player
    [SerializeField]
    private InputField inputGamePin;

    [SerializeField]
    private Button joinButton;


///Host
    private int gamePin;

    [SerializeField]
    private Text gamePinText;


    // Start is called before the first frame update
    void Start()
    {
        joinButton.interactable = false;

    }

    public void createGamePin()
    {
        /*this.gamePin = Random.Range(100000, 999999);
        print("Gamepin: " + gamePin);
        setGamePinText();*/
        this.gamePin = 1234;
    }

    public void setGamePinText()
    {
        gamePinText.text = "Gamepin: " + gamePin.ToString();
    }

    public void checkGamePin()
    {
        if (this.inputGamePin.text == gamePin.ToString())
        {
            joinButton.interactable = true;
        }
        else
        {
            joinButton.interactable = false;
        }
    }
}
