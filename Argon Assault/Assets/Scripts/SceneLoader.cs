using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts
{
    public class SceneLoader : MonoBehaviour 
    {       
        private void Start()
        {
            Invoke(nameof(LoadFirstScene), 2f);
        }

        private void LoadFirstScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}
