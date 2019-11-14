using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LeakAsync : MonoBehaviour
{
    [SerializeField]
    private RawImage image;

    // Start is called before the first frame update
    async void Start()
    {
        await ShowEffect(image);
    }

    async Task ShowEffect(RawImage container)
    {
        var texture = new RenderTexture(512, 512, 0);
        try
        {
            container.texture = texture;
            for(int i = 0; i < 100; ++i)
            {
                Debug.Log("ShowEffect Countdown " + i);
                await Task.Yield();
            }
        }
        finally
        {
            texture.Release();
            Debug.Log("Release");
        }
    }
}
