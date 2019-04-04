using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePinPlayer : MonoBehaviour
{
    [SerializeField]
    private GamePinHost GPH;

    [SerializeField]
    private InputField gamePin;

    [SerializeField]
    private Button joinButton;


    void Start()
    {
        DontDestroyOnLoad(this);
        joinButton.interactable = false;
    }

    public void checkGamePin()
    {
        print(GPH.getGamePin().ToString());
        if (this.gamePin.text == GPH.getGamePin().ToString())
        {
            joinButton.interactable = true;
        }

        else
        {
            joinButton.interactable = false;
        }
    }
}
