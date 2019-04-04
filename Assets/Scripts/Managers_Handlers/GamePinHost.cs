using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePinHost : MonoBehaviour
{ 
    [SerializeField]
    private int gamePin;

    [SerializeField]
    private Text gamePinText;

    void Start()
    {    }

    public void createGamePin()
    {
        this.gamePin = Random.Range(100000, 999999);
        print("Gamepin: " + gamePin);
        setGamePinText();
    }

    public int getGamePin()
    {
        return this.gamePin;
    }

    public void setGamePin(int gamePin)
    {
        this.gamePin = gamePin;
    }

    public void setGamePinText()
    {
        gamePinText.text = "Gamepin: " + gamePin.ToString();
    }
}
