using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text playerName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {        
        if (playerName != null)
            GameManager.instance.playerName = playerName.text;
        else
            GameManager.instance.playerName = "";

        SceneManager.LoadScene("main");
    }
}
