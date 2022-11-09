using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
