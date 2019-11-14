using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private Button[] btns;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < btns.Length; ++i)
        {
            int index = i;
            btns[i].onClick.AddListener(async delegate { await LoadSceneAsync(index); });
        }
    }

    private static async Task LoadSceneAsync(int sceneBuildIndex)
    {
        Debug.Log("Load Scene");
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Single);

        while (!ao.isDone)
        {
            Debug.Log("Loading Scene...");
            await Task.Yield();
        }

        Debug.Log("Load Done");
    }
}
