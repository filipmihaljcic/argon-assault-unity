using UnityEngine;
using UnityEngine.SceneManagement;  

namespace Project.Scripts
{
    public class CollisionHandler : MonoBehaviour 
    {
        [Tooltip("How much we wait until levels loads.")]
        [SerializeField] float levelLoadDelay = 1f;
        
        [Tooltip("Death effect when player dies.")]
        [SerializeField] GameObject deathFX;

        private void OnTriggerEnter(Collider other)
        {
            StartDeathSequence();
            deathFX.SetActive(true);
            Invoke(nameof(ReloadScene), levelLoadDelay);
        }

        private void StartDeathSequence()
        {
            SendMessage("OnPlayerDeath");
        }

        private void ReloadScene() 
        {
            SceneManager.LoadScene(1);
        }
    }
}
