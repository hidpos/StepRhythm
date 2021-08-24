using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoad : MonoBehaviour
{
    public GameObject decor;
    private List<GameObject> clones = new List<GameObject>();
    private const float cloneScale = 9.4824f;
    private enum CloneParams {
        scale = 9,
        y = -22.01,
        z = -1.2,
        offsetX = 121
    }
    
    // Start is called before the first frame update
    void Start()
    {
        clones.Add(decor);
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
        
        if (decor.transform.position.x <= -153.3f)
        {
            Vector3 pos = new Vector3(decor.transform.position.x + (int)CloneParams.offsetX, (int)CloneParams.y, (int)CloneParams.z);

            GameObject clone = Instantiate(decor, pos, decor.transform.rotation);
            clone.transform.localScale = new Vector3((int)CloneParams.scale, (int)CloneParams.scale, (int)CloneParams.scale);

            this.decor = clone;
            clone.transform.parent = this.transform;
            clones.Add(clone);

            if (clones.Count >= 3)
            {
                Destroy(clones[clones.Count - 3].gameObject);
            }
        }
    }
}