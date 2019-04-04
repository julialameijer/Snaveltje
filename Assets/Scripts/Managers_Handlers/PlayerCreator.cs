using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerCreator : MonoBehaviour
{
    [SerializeField]
    private InputField nameInput;
    [SerializeField]
    private InputField codeInput;
    [SerializeField]
    private PlayerHandler playerHandler;

    private Player player;
    string path;
    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void createPlayer()
    {
        player = new Player();
        player.setID(playerHandler);
        player.setName(nameInput);
        playerHandler.spawnPlayerName(player);
        print("Name: " + player.getName() + ", ID: " + playerHandler.getPlayerID(player));
        createTextFile();
    }

    public Player getPlayer()
    {
        return player;
    }

    public void createTextFile()
    {
        path = Application.dataPath + "/AnswerFiles" + "/" + player.getName() + ".txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Answers from team " + player.getName());    
        }
    }
}
