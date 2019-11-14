using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Deadlock : MonoBehaviour
{
    [SerializeField]
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(delegate
        {
            var task = TestAsync();
            Debug.Log(task.Result);
        });
    }

    private async Task<int> TestAsync()
    {
        int result = 1;
        await Task.Delay(1);
        return result;
    }
}
