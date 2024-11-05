using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Lifespaned");
    }

    // Update is called once per frame
    IEnumerator Lifespaned()
    {
        yield return new WaitForSeconds(2);
        Destroy(parent);
    }
}
