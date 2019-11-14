using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Cancel : MonoBehaviour
{
    [SerializeField]
    private Button btn;
    [SerializeField]
    private Text text;

    [SerializeField]
    private Button btn2;

    private CancellationTokenSource cancel;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(async delegate
        {
            cancel = new CancellationTokenSource();
            await CalculateAsync(cancel.Token);
        });

        btn2.onClick.AddListener(delegate
        {
            if(cancel != null)
            {
                cancel.Cancel();
                cancel.Dispose();
            }
        });
    }

    private async Task CalculateAsync(CancellationToken ct)
    {
        Debug.Log("Start");
        for (int i = 0; i < 100000000; ++i)
        {
            if (ct.IsCancellationRequested)
                return;

            text.text = i.ToString();
            await Task.Yield();
        }
        Debug.Log("End");
    }
}
