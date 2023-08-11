using UnityEngine;

public class UIPanel : MonoBehaviour, IUIPanel
{
    public bool IsActive => gameObject.activeSelf;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}