using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    private List<Player> players;
    private List<Text> spawnpoints;

    [SerializeField]
    private Text spawnpoint1;

    [SerializeField]
    private Text spawnpoint2;

    [SerializeField]
    private Text spawnpoint3;

    [SerializeField]
    private Text spawnpoint4;

    [SerializeField]
    private Text spawnpoint5;

    void Start()
    {
        players = new List<Player>();
        spawnpoints = new List<Text>();

        spawnpoints.Add(spawnpoint1);
        spawnpoints.Add(spawnpoint2);
        spawnpoints.Add(spawnpoint3);
        spawnpoints.Add(spawnpoint4);
        spawnpoints.Add(spawnpoint5);
    }

    public void addPlayer(Player player)
    {
        players.Add(player);
    }

    public int getPlayerID(Player player)
    {
        int index = players.IndexOf(player);
        return index;
    }

    public void spawnPlayerName(Player player)
    {
        int count = 0;
        string name = player.getName();
        count = Random.Range(1, spawnpoints.Count);
        Mathf.Round(count);
        spawnpoints[players.IndexOf(player)].text = name;
    }
}
