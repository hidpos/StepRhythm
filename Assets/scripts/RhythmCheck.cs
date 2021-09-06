using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class RhythmCheck : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject[] notes;
    public GameObject results;
    public Text accurancyT, perfectsT, missesT, res1, res2;
    public int speed;
    public Text score, hitEffect, perfectHitEffect,
    perfectHitEffect2;
    public int comboCount = 0;
    public Text comboC1, comboC2;
    public AudioSource audioPlayer;
    public AudioClip[] songs;


    [SerializeField]
    public float notesAm = 0;
    [SerializeField]
    public float accurancy;
    [SerializeField]
    public int perfects, misses;
    [SerializeField]
    public List<Image> allNotes = new List<Image>();

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

        if (!audioPlayer.isPlaying)
        {
            results.SetActive(true);
            accurancy = 100 * (notesAm - misses) / notesAm;

            if (accurancy == 100)
            {
                res1.text = "S"; res2.text = "S";
            }
            if (accurancy > 90 && accurancy < 100)
            {
                res1.text = "A"; res2.text = "A";
            }
            if (accurancy > 80 && accurancy < 90)
            {
                res1.text = "B"; res2.text = "B";
            }
            if (accurancy > 70 && accurancy < 80)
            {
                res1.text = "C"; res2.text = "C";
            }
            if (accurancy > 60 && accurancy < 70)
            {
                res1.text = "D"; res2.text = "D";
            }

            accurancyT.text = $"{accurancy}";
            perfectsT.text = $"{perfects}";
            missesT.text = $"{misses}";
        }
    }
}