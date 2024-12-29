using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOverSizeIncrease : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleFactor = 1.2f;
    public float timeToGrow = 0.4f;
    public float timeToShrink = 0.4f;

    private Vector3 _defaultScale;
    private void Awake()
    {
        _defaultScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hovering");
        transform.DOScale(new Vector3(_defaultScale.x * scaleFactor, _defaultScale.y * scaleFactor, _defaultScale.z * scaleFactor), timeToGrow).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(_defaultScale, timeToShrink).SetUpdate(true);
    }
}