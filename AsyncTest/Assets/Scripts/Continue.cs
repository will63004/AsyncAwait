using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    [SerializeField]
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(async delegate
        {
            await Phase(1).ContinueWith(delegate
            {
                Debug.Log("Phase End");
            });
        });
    }

    private async Task Phase(int phase)
    {
        Debug.Log("Phase " + phase + " start");
        await Task.Delay(3000);
    }
}
