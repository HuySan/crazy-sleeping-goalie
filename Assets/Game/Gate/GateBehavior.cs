using UnityEngine;
using TMPro;
using Gate;
using General.Scripts;

public class GateBehavior : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private int _scoreDeduction;

    private ScoreSystem _scoreSystem;
    void Start()
    {
        _scoreSystem = new ScoreSystem(_scoreText, _scoreDeduction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _scoreSystem.GateTrigger(collision.gameObject);
    }

    private void OnEnable()
    {
        EventBus.onBallDetected += BallDetected;
    }

    private void OnDisable()
    {
        EventBus.onBallDetected -= BallDetected;
    }

    private void BallDetected(bool isBall, GameObject gameObject)
    {
        _scoreSystem.BallTrigger(isBall, gameObject);
    }
}
