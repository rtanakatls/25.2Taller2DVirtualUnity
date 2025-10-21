using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    private static LoadingScreen instance;

    public static LoadingScreen Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/LoadingScreen"));
                instance = obj.GetComponent<LoadingScreen>();
            }
            return instance;
        }
    }

    private bool isLoading;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        if(!isLoading)
        {
            isLoading = true;
            StartCoroutine(LoadingScene(sceneName));
        }
    }

    private IEnumerator LoadingScene(string sceneName)
    {
        animator.Play("In");
        yield return new WaitForSeconds(1f);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            yield return null;
        }
        animator.Play("Out");
        yield return new WaitForSeconds(1f);
        instance = null;
        Destroy(gameObject);
    }


}
