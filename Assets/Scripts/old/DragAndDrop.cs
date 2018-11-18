 using UnityEngine;
 using UnityEngine.EventSystems;
 
 public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject DraggedInstance;

    Vector3 _startPosition;
    Vector3 _offsetToMouse;
    float _zDistanceToCamera;

    #region Interface Implementations

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (LevelManager.Instance.timeForAttack <= 0)
            return;

        DraggedInstance = gameObject;
        _startPosition = transform.position;
        _zDistanceToCamera = Mathf.Abs(_startPosition.z - Camera.main.transform.position.z);

        _offsetToMouse = _startPosition - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera)
        );
        DraggedInstance.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 1 || DraggedInstance == null)
            return;

        transform.position = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera)
            ) + _offsetToMouse;

        if (LevelManager.Instance.timeForAttack <= 0)
        {
            DraggedInstance.GetComponent<Rigidbody2D>().isKinematic = false;
            DraggedInstance = null;
            _offsetToMouse = Vector3.zero;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (DraggedInstance == null)
        {
            return;
        }
        DraggedInstance.GetComponent<Rigidbody2D>().isKinematic = false;
        DraggedInstance = null;
        _offsetToMouse = Vector3.zero;

    }

    #endregion
}
