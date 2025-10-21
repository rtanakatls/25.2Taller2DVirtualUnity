using UnityEngine;
using UnityEngine.SceneManagement;

public class TestChangeScene : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadingScreen.Instance.LoadScene("Level2Scene");
        }
    }
}
