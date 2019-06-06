using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GamePin gamepin;
    [SerializeField] private Text team1;
    [SerializeField] private Text team2;
    [SerializeField] private Text team3;
    [SerializeField] private Text team4;
    [SerializeField] private Text team5;
    [SerializeField] private Text team6;

    public void startGame()
    {
        StartCoroutine(pushStart());
        //Everything else what needs to happen when the game starts
    }

    IEnumerator pushStart()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gamepin", gamepin.getCurrentGamepin());

        UnityWebRequest www = UnityWebRequest.Post("https://snaveltje.wildsea.nl/startGame.php", wwwForm);
        yield return www.SendWebRequest();
        print(www.downloadHandler.text);
    }

    private void nameShow()
    {

    }
}
