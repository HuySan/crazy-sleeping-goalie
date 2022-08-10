using System;
using UnityEngine;
using TMPro;
using Flags;
namespace Gate
{
    class ScoreSystem
    {
        private TextMeshProUGUI _scoreText;
        private int _scoreCount;
        private int _scoreDeductionStatic;

        public ScoreSystem(TextMeshProUGUI scoreText, int scoreDeductionStatic)
        {
            _scoreText = scoreText;
            _scoreDeductionStatic = scoreDeductionStatic;

            _scoreCount = 0;
        }

        public void GateTrigger(GameObject gameObjectCollision)
        {
            if (gameObjectCollision.GetComponent<BombFlag>())
            {
                GameObject.Destroy(gameObjectCollision);
                return;
            }

            _scoreCount -= _scoreDeductionStatic;
            ScoreChange(_scoreCount);
            GameObject.Destroy(gameObjectCollision);
        }

        public void BallTrigger(bool isBall, GameObject triggerObject)
        {
            if (isBall)
                _scoreCount += 10;//change in GateBehavior Serializefield
            else
                _scoreCount = _scoreCount / 2;

            if(triggerObject != null)
                GameObject.Destroy(triggerObject);
            ScoreChange(_scoreCount);

        }

        private void ScoreChange(int score)
        {
            _scoreText.text = $"Score: {score}";
        }
    }
}
