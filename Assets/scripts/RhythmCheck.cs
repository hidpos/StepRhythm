using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class RhythmCheck : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject[] notes;
    public int speed; 
    public Text score, hitEffect, perfectHitEffect,
    perfectHitEffect2;
    private List<Image> allNotes = new List<Image>();
    public int comboCount = 0;
    public Text comboC1, comboC2;
    public AudioSource audioPlayer;
    public AudioClip[] songs;

    // Start is called before the first frame update
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i].transform.position -= new Vector3(speed * Time.deltaTime * 3, 0);

            foreach (Transform tr in notes[i].transform)
            {
                if (tr.GetComponent<RectTransform>().IsVisibleFrom())
                {
                    tr.gameObject.SetActive(true);
                    if (!tr.gameObject.GetComponent<Note>())
                    {
                        tr.gameObject.AddComponent<Note>();
                        tr.GetComponent<Note>().Init(GetComponent<RhythmCheck>(), score, hitEffect, perfectHitEffect, perfectHitEffect2, 1);
                        
                        foreach (Transform tr2 in tr)
                        {
                            tr2.gameObject.AddComponent<Note>();
                            tr2.GetComponent<Note>().Init(GetComponent<RhythmCheck>(), score, hitEffect, perfectHitEffect, perfectHitEffect2, 2);
                            allNotes.Add(tr2.GetComponent<Image>());
                        }
                        allNotes.Add(tr.GetComponent<Image>());
                    }
                }
                else
                    tr.gameObject.SetActive(false);   
            }
        }

        comboC1.text = $"{comboCount} x";
        comboC2.text = $"{comboCount} x";
    }
}