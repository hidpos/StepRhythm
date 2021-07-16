using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoad : MonoBehaviour
{
    public GameObject decor;
    // Start is called before the first frame update
    void Start()
    {

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
        Debug.Log(decor.transform.position.x);
        if (decor.transform.position.x <= -153.3f)
        {
            Vector3 pos = new Vector3(decor.transform.position.x + 124,
                                      decor.transform.position.y,
                                      decor.transform.position.z);
            Instantiate(decor, pos, decor.transform.rotation);
        }
    }
}
