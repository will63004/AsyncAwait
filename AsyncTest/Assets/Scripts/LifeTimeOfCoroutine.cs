using System.Collections;
using UnityEngine;

public class LifeTimeOfCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        StartCoroutine(Rotate());
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward, 1.0f);
            yield return null;
        }
    }
}
