using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public GameObject mainMenu, game, system, songs;
    public MainMenu mMenu;
    public string difficulty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeDifficulty()
    {
        difficulty = EventSystem.current.currentSelectedGameObject.tag;
    }

    public void StartGame()
    {
        foreach (Transform child in songs.transform)
        {
            if (child.name == mMenu.songName.text)
            {
                child.gameObject.SetActive(true);
                GameObject[] n = child.GetComponentsInChildren<GameObject>();

                for (var j = 0; j < n.Length; j++)
                {
                   if (n[j].name == difficulty)
                       n[j].SetActive(true);
                }
            }  
        }   
        mainMenu.SetActive(false);
        game.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
