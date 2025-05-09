using UnityEngine;

public class FireColorController : MonoBehaviour
{
    [Header("Color Cycle Settings")]
    [SerializeField] private Gradient colorCycle;
    [SerializeField] private float cycleDuration = 6f;

    private ParticleSystem.MainModule mainModule;
    private float timer;

    void Start()
    {
        mainModule = GetComponent<ParticleSystem>().main;
    }

    void Update()
    {
        if (FireToggleButton.IsFireUp)
        {
            timer += Time.deltaTime;
            float t = Mathf.PingPong(timer / cycleDuration, 1f);
            mainModule.startColor = new ParticleSystem.MinMaxGradient(colorCycle.Evaluate(t));
        }
    }
}
