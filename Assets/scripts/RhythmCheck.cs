using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RhythmCheck : MonoBehaviour
{
    public GameObject notes;
    public int speed;     // 60bpm = 96;    138 = 220
    private List<Image> allNotes = new List<Image>();
    public Text score, hitEffect, perfectHitEffect;

    // Start is called before the first frame update
    void Start()
    {
        Image[] n = gameObject.GetComponentsInChildren<Image>();

        for (var i = 0; i < n.Length; i++)
        {
            n[i].gameObject.AddComponent<Note>();

            if (n[i].gameObject.name == "Image")
                n[i].GetComponent<Note>().Init(score, hitEffect, perfectHitEffect, 2);
            else
                n[i].GetComponent<Note>().Init(score, hitEffect, perfectHitEffect, 1);

            allNotes.Add(n[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        notes.transform.position -= new Vector3(speed * Time.deltaTime * 3, 0);
    }
}