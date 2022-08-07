using UnityEngine;
using Border;
public class GateBoorderBehavior : MonoBehaviour
{
    [SerializeField]
    private Vector3 _pushDirection;

    private BorderSystem _borderSystem;

    void Start()
    {
        _borderSystem = new BorderSystem(_pushDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _borderSystem.Push(collision.gameObject);
    }
    void Update()
    {
        
    }
}
