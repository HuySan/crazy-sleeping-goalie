using UnityEngine;
using TMPro;
public class GateBehavior : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Какой-то коллайдер коснулся ворот");
    }
}
