using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    [SerializeField]
    private Button lagBtn;

    [SerializeField]
    private Button btn;
    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        lagBtn.onClick.AddListener(onClickLagBtn);

        btn.onClick.AddListener(async delegate
        {
            await CalculateAsync();
        });

    }

    private async void onClickLagBtn()
    {
        await LagCalculateAsync();
    }

    private async Task LagCalculateAsync()
    {
        Debug.Log("Start");
        for(int i = 0; i < 100000000; ++i) { }
        Debug.Log("End");
        await Task.CompletedTask;
    }

    private async Task CalculateAsync()
    {
        Debug.Log("Start");
        for (int i = 0; i < 100000000; ++i)
        {
            text.text = i.ToString();
            await Task.Yield();
        }
        Debug.Log("End");
    }
}
