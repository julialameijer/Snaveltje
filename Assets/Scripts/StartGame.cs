using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GamePin gamepin;

    public void startGame()
    {
        StartCoroutine(pushStart());
        //Everything else what needs to happen when the game starts
    }

    IEnumerator pushStart()
    {

        //print(gamepin.getGamepin());
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gamepin", gamepin.getGamepin());

        UnityWebRequest www = UnityWebRequest.Post("http://192.168.178.10/Snaveltje/startGame.php", wwwForm);
        yield return www.SendWebRequest();
        print(www.downloadHandler.text);
    }
}
