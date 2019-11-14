using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Blocking : MonoBehaviour
{
    [SerializeField]
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(delegate
        {
            TaskTest().Wait();
        });
    }

    private Task TaskTest()
    {
        return Task.Delay(5000);
    }
}
