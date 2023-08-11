using UnityEngine;

public class UnitView : MonoBehaviour, IUnitView
{
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }

    public void ResetColor()
    {
        _meshRenderer.material.color = Color.white;
    }
}