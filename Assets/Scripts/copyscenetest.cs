using System.Collections;
using UnityEngine;

public class copyscenetest : MonoBehaviour
{
    //public GameObject road;
    private void Start()
    {
        StartCoroutine(generateLevel());
    }

    public IEnumerator generateLevel()
    {
        yield return new WaitForSeconds(5f);
        transform.position += new Vector3(21, 0);
        Debug.Log("Text: ");
        StartCoroutine(generateLevel());
    }
}