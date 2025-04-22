using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void ChangeScene() {
        SceneManager.LoadScene(sceneName);
    }
}
