using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text songName, songName2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayAnim(Animation gameObject)
    {
        gameObject.Play();
    }

    public void SelectSong()
    {
        Text[] n = EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Text>();
        string song_n = "";

        for (var i = 0; i < n.Length; i++)
        {
            song_n = n[i].text;
        }
        
        songName.text = song_n;
        songName2.text = song_n;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
