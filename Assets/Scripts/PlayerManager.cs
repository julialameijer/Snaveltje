﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private InputField nameInput;
    [SerializeField]
    private InputField codeInput;
    private Player player;
    [SerializeField]
    private GameManager gameManager;
    private List<Player> players;
    
    void Start()
    {
        players = new List<Player>();
    }

    public void createPlayer()
    {
        player = new Player();
        players.Add(player);
        player.setGamePin(codeInput);
        player.setName(nameInput);
    }



    public void callPlayerPush()
    {
        StartCoroutine(pushPlayer());
    }

    IEnumerator pushPlayer()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("username", nameInput.text);
        wwwForm.AddField("gamepin", int.Parse(codeInput.text));
        UnityWebRequest www = UnityWebRequest.Post("https://snaveltje.wildsea.nl/player.php", wwwForm);
        yield return www.SendWebRequest();
        print(www.downloadHandler.text);    
    }


}
