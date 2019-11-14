using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeakCoroutine : MonoBehaviour
{
    [SerializeField]
    private RawImage image;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowEffect(image));
    }

    IEnumerator ShowEffect(RawImage container)
    {
        var texture = new RenderTexture(512, 512, 0);
        try
        {
            container.texture = texture;
            for(int i = 0; i < 100; ++i)
            {
                Debug.Log("ShowEffect Countdown " + i);
                yield return null;
            }
        }
        finally
        {
            texture.Release();
            Debug.Log("Release");
        }
    }
}
