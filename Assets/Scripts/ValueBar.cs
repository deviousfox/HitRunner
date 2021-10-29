using UnityEngine.UI;
using UnityEngine;

public class ValueBar : MonoBehaviour
{
    [SerializeField] private Transform FollowTransform;
    [SerializeField] private RectTransform selfTransform;
    [SerializeField] private Slider valueSlider;
    [SerializeField] private float screenYOffset;
    [SerializeField] private bool canSelfDestroy;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (FollowTransform != null)
        {
            selfTransform.position = cam.WorldToScreenPoint(FollowTransform.position) + new Vector3(0, screenYOffset);
        }
        else
        {
            if (canSelfDestroy)
                Destroy(gameObject);
        }

    }
    public void SetTargetFollow(Transform target)
    {
        FollowTransform = target;
    }
    public void UpdateValue(float normalizedValue)
    {
        valueSlider.value = normalizedValue;
    }
    public void UpdateValue(float currentValue, float maxValue)
    {
        valueSlider.value = currentValue / maxValue;
    }
}
