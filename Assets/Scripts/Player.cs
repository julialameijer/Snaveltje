using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private int currentPlayingQuestion;
    private int playedTime;
    private int gamePin;
    private int score;
    

    void Start()
    {

    }

    public void setName(InputField name)
    {
        this.name = name.text;
    }

    public int getCurrentPlayingQuestion()
    {
        return currentPlayingQuestion;
    }

    public void setCurrentPlayingQuestion(int questionIndex)
    {
        currentPlayingQuestion = questionIndex;
    }

    public void setGamePin(InputField gamepin)
    {
        this.gamePin = int.Parse(gamepin.text);
    }

    public int getScore()
    {
        return 0;
    }

    public int getGamepin()
    {
        return gamePin;
    }
}
