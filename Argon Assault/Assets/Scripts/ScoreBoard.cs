using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class ScoreBoard : MonoBehaviour
    {
        private int score;
        private Text scoreText;

        private void Start()
        {
            scoreText = GetComponent<Text>();
            scoreText.text = score.ToString();
        }

        public void ScoreHit(int scoreIncrease)
        {
            score = score + scoreIncrease;
            scoreText.text = score.ToString();
        }
    }
}