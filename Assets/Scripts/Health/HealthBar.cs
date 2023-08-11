using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _foregroundImage;
    [SerializeField] [Min(0)] private float _updateSpeedSeconds = 0.25f;
    private Camera _camera;

    public void Initialize()
    {
        _camera = Camera.main;
        GetComponent<Canvas>().worldCamera = _camera;
        _health.OnPercentChanged += OnPercentChanged;
    }

    private void LateUpdate()
    {
        transform.LookAt(_camera.transform);
        transform.rotation = Quaternion.Euler(new Vector3(45, 0, transform.rotation.z));;
    }

    private IEnumerator ChangeToCurrentPercent(float currentHealthPercent)
    {
        float preChangePercent = _foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < _updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            _foregroundImage.fillAmount =
                Mathf.Lerp(preChangePercent, currentHealthPercent, elapsed / _updateSpeedSeconds);
            yield return null;
        }

        _foregroundImage.fillAmount = currentHealthPercent;
    }

    private void OnPercentChanged(float currentHealthPercent) => 
        StartCoroutine(ChangeToCurrentPercent(currentHealthPercent));
}