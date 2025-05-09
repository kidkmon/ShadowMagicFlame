using UnityEngine;
using UnityEngine.UI;

public class FireToggleButton : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Toggle fireToggle;
    [SerializeField] private FlameManager flameManager;

    public static bool IsFireUp { get; private set; }
    void Start()
    {
        fireToggle.onValueChanged.AddListener(OnFireToggleChanged);
    }

    void OnDestroy()
    {
        fireToggle.onValueChanged.RemoveListener(OnFireToggleChanged);
    }

    private void OnFireToggleChanged(bool isOn)
    {
        IsFireUp = isOn;
        flameManager.ToggleFire(isOn);
    }
}
