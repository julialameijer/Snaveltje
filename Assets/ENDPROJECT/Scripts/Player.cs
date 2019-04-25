using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private int ID;
    private int currentPlayingQuestion;
    private List<int> playedQuestions;
    private List<int> toPlayQuestions;

    void Start()
    {
        for(int i = 0; i  < 10; i++)
        {
            toPlayQuestions.Add(i);
        }
    }

    public void setName(InputField name)
    {
        this.name = name.text;
    }
    
    public void setID(int id)
    {
        this.ID = id;
    }

    public List<int> getToPlayQuestions()
    {
        return toPlayQuestions.Except(playedQuestions).ToList();
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
