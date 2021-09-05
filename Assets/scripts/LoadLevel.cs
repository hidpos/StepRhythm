using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public GameObject mainMenu, game, system, songs;
    public MainMenu mMenu;
    public RhythmCheck rythmCh;
    public string difficulty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeDifficulty()
    {
        difficulty = EventSystem.current.currentSelectedGameObject.tag;
        switch (difficulty)
        {
            case "easy": rythmCh.speed = 100; break;
            case "normal": rythmCh.speed = 300; break;
            case "hard": rythmCh.speed = 500; break;
        }
    }

    public void StartGame()
    {
        foreach (Transform child in songs.transform)
        {
            if (child.name == mMenu.songName.text)
            {
                child.gameObject.SetActive(true);
                
                foreach (Transform child2 in child.transform)
                {
                    if (child2.name == difficulty)
                        child2.gameObject.SetActive(true);
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
