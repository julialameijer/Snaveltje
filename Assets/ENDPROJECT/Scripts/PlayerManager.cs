using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private InputField nameInput;
    [SerializeField]
    private InputField codeInput;
    private Player player;
    private List<Player> players;
    
    void Start()
    {
        players = new List<Player>();
    }

    public void createPlayer()
    {
        player = new Player();
        players.Add(player);
        player.setID(players.IndexOf(player));
        player.setName(nameInput);
    }
}
