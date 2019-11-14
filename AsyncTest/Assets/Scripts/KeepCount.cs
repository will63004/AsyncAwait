using UnityEngine;
using UnityEngine.UI;

public class KeepCount : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private int count = 0;

    // Update is called once per frame
    void Update()
    {
        text.text = count.ToString();

        count++;
    }
}
