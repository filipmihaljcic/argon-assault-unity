using UnityEngine;

namespace Project.Scripts
{

    public class Enemy : MonoBehaviour 
    {
        [Header("Enemy ship settings")]

        [Tooltip("Visual effect when enemy is hit.")]
        [SerializeField] GameObject deathFX;

        [Tooltip("Position of displayed enemy death fx.")]
        [SerializeField] Transform parent;

        [Tooltip("How much damage is inflicted to enemy.")]
        [SerializeField] int scorePerHit = 12;

        [Tooltip("How many times we need to hit enemy before death.")]
        [SerializeField] int hits = 3;

        ScoreBoard scoreBoard;

	    private void Start ()
        {
            AddBoxCollider();
            scoreBoard = FindObjectOfType<ScoreBoard>();
        }

        private void AddBoxCollider()
        {
            Collider boxCollider = gameObject.AddComponent<BoxCollider>();
            boxCollider.isTrigger = false;
        }

        private void OnParticleCollision(GameObject other)
        {
            ProcessHit();
            if (hits <= 1)
                KillEnemy();
        }

        private void ProcessHit()
        {
            scoreBoard.ScoreHit(scorePerHit);
            hits = hits - 1;
        }

        private void KillEnemy()
        {
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
            Destroy(gameObject);
        }
    }
}
