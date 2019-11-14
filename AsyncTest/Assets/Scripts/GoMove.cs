using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GoMove : MonoBehaviour
{
    [SerializeField]
    private Button btn;
    [SerializeField]
    private GameObject go;

    private Task moveTask;

    // Start is called before the first frame update
    private void Start()
    {
        btn.onClick.AddListener(onGoMove);
    }

    private async void onGoMove()
    {
        if (moveTask == null)
        {
            moveTask = MoveAsync();
            await moveTask;
            moveTask = null;
        }
        else
        {
            Debug.Log("onClick Return.");
            return;
        }            

        Debug.Log("onClick Done.");
    }

    private async Task MoveAsync()
    {
        await Task.Delay(5000);
        go.transform.position += Vector3.right;
    }
}
