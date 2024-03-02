using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selectable : MonoBehaviour, IPointerClickHandler
{
    private CinemachineVirtualCamera _virtualCamera;
    private Transform _transform1;

    private void Awake()
    {
        _transform1 = transform;
    }

    private void Start()
    {
        _virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _virtualCamera.LookAt = _transform1;
        _virtualCamera.Follow = _transform1;    
    }
}
