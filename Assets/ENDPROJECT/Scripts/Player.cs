using UnityEngine;
using UnityEngine.UI;

public class Player
{
    private string name;
    private int ID;

    public void setName(InputField name)
    {
        this.name = name.text;
    }
    
    public void setID(PlayerHandler playerHandler)
    {
        playerHandler.addPlayer(this);
    }
    
    public string getName()
    {
        return this.name;
    }
}
