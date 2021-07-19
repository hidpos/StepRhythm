using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoad : MonoBehaviour
{
    public GameObject decor;
    [SerializeField] private bool cloneable;
    // Start is called before the first frame update
    void Start()
    {
        // init
        cloneable = true;
    }
    IEnumerator Move()
    {
        for (int i = 0; i < 25; i++)
        {
            this.transform.position -= new Vector3(.02f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(Move());
        }
        
        if (decor.transform.position.x <= -153.3f && cloneable)
        {
            Vector3 pos = new Vector3(decor.transform.position.x + 121,
                                      -21.9f, -1.007f);
            GameObject clone = Instantiate(decor, pos, decor.transform.rotation);
            clone.transform.localScale = new Vector3(9.4824f, 9.4824f, 9.4824f);
            cloneable = false;
            this.decor = clone;
        }
    }
}