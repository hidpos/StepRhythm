using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RhythmCheck : MonoBehaviour
{
    public GameObject[] notes;
    public int speed; 
    public Text score, hitEffect, perfectHitEffect,
    perfectHitEffect2;
    private List<Image> allNotes = new List<Image>();
    public int comboCount = 0;
    public Text comboC1, comboC2;

    // Start is called before the first frame update
    void Start()
    {
        Image[] n = gameObject.GetComponentsInChildren<Image>();

        for (var i = 0; i < n.Length; i++)
        {
            n[i].gameObject.AddComponent<Note>();

            if (n[i].gameObject.name == "Image")
                n[i].GetComponent<Note>().Init(GetComponent<RhythmCheck>(), score, hitEffect, perfectHitEffect, perfectHitEffect2, 2);
            else
                n[i].GetComponent<Note>().Init(GetComponent<RhythmCheck>(), score, hitEffect, perfectHitEffect, perfectHitEffect2, 1);

            allNotes.Add(n[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i].transform.position -= new Vector3(speed * Time.deltaTime * 3, 0);
        }
        comboC1.text = $"{comboCount} x";
        comboC2.text = $"{comboCount} x";
    }
}