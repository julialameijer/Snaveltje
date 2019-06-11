using System.Collections;
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

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ScannerScene")
        {
            InvokeRepeating("pushScoreCall", 1f, 1f);
        }
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

    private void pushScoreCall()
    {
        StartCoroutine(pushScore(gameManager.rightAnswered, "Lalala"));
    }

    IEnumerator pushScore(int score, string teamName)
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("score", score);
        wwwForm.AddField("teamName", teamName);
        UnityWebRequest www = UnityWebRequest.Post("https://snaveltje.wildsea.nl/pushScore.php", wwwForm);
        yield return www.SendWebRequest();
        print(www.downloadHandler.text);
    }
}
