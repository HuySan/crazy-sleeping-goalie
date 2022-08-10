using UnityEngine.EventSystems;
using UnityEngine;
using Character;
using Flags;

public class CharacterBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Transform _transform;

    //scripts
    private MoveSystem _moveSystem;

    public void Start()
    {
        _transform = this.transform;
        _moveSystem = new MoveSystem(_transform);
        gameObject.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        _moveSystem.Move();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _moveSystem.Ñapture();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _moveSystem.LetGo();
    }
}
