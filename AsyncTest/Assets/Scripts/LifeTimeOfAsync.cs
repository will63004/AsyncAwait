using System.Threading.Tasks;
using UnityEngine;

public class LifeTimeOfAsync : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        Rotate();

        await Task.Delay(1000);
        Destroy(gameObject);
    }

    async void Rotate()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward, 1.0f);
            await Task.Yield();
        }
    }
}
