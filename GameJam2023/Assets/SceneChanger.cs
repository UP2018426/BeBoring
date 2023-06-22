using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void quit()
    {
        Application.Quit();
    }
}
