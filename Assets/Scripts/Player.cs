using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private int ID;
    private int currentPlayingQuestion;
    private int playedTime;


    void Start()
    {

    }

    public void setName(InputField name)
    {
        this.name = name.text;
    }
    
    public void setID(int id)
    {
        this.ID = id;
    }

    public int getCurrentPlayingQuestion()
    {
        return currentPlayingQuestion;
    }

    public void setCurrentPlayingQuestion(int questionIndex)
    {
        currentPlayingQuestion = questionIndex;
    }
}
