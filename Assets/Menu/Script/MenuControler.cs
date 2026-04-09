using UnityEngine;
using UnityEngine.SceneManagement;

public enum PanelType
{
    None,

    Main,

    Option,

    Credits,
}

public class MenuControler : MonoBehaviour 
{
    private GameManager manager;

    private void Start()
    {
        manager = GameManager.Instance;
    }

    public void OpenPanel()
    {

    }

    public void ChangeScene(string _sceneName)
    {
        manager.ChangeScene(_sceneName);
    }

    public void Quit()
    {
        manager.Quit();
    }
}
