using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignmentHandler : MonoBehaviour
{
    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Assignment[] assignments;

    private int finalnumber;
    private Player player;

    private PlayerCreator playerCreator;

    // Start is called before the first frame update
    void Start()
    {
        playerCreator = GameObject.Find("__PlayerGameManager").GetComponent<PlayerCreator>();
        player = playerCreator.getPlayer();
    }

    public void setQuestion(int listIndex)
    {
        finalnumber = listIndex;
        string text = assignments[listIndex].assignment;
        questionText.text = text;
    }

    public void saveImage()
    {
    }
}
