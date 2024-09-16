using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBarRenderer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Canvas _canvas;

    private float _smoothlyValue = 100;
    private Slider _bar;
    private Coroutine _smoothlyChangeHealthCoroutine;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        _canvas.GetComponent<RectTransform>().rotation = Quaternion.Euler(Vector3.zero);
    }

    private void OnEnable()
    {
        _health.ValueChanged += ChangeHealthInfo;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= ChangeHealthInfo;
    }

    public  void ChangeHealthInfo(float currentHealth)
    {
        if (_smoothlyChangeHealthCoroutine != null)
            StopCoroutine(_smoothlyChangeHealthCoroutine);

        _smoothlyChangeHealthCoroutine = StartCoroutine(SmoothlyChangeHealthBarValue(GetHealthPrecentage(currentHealth)));
    }
    
    private  float GetHealthPrecentage(float currentHeatlh)
    {
        float maxPrecentage = 100;

        return currentHeatlh / _health.MaxValue * maxPrecentage;
    }

    private IEnumerator SmoothlyChangeHealthBarValue(float currentHealth)
    {
        while (_bar.value != currentHealth)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, currentHealth, _smoothlyValue * Time.deltaTime);

            yield return null;
        }
    }
}
