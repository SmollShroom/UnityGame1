using UnityEngine;
using UnityEngine.UI;

public class ResourceMonitorScript : MonoBehaviour
{
    private RectTransform _rect;

    [SerializeField]
    public Slider slider;

    public void SetMaxResources(float res)
    {
        slider.maxValue = res;
        slider.value = res;
    }

    public void _AdjustSlider(float res)
    {
        //_rect.sizeDelta = new Vector2(_liveImageWidth * Mathf.RoundToInt(stats), _rect.sizeDelta.y);
        slider.value = res;
    }

}
