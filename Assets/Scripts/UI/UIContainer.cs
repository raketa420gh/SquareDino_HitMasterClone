using UnityEngine;

public class UIContainer : MonoBehaviour, IUIContainer
{
    [SerializeField] private UIPanel _startPanel;
    [SerializeField] private UIPanel _finishPanel;
    
    public IUIPanel GetPanel(UIPanelType type)
    {
        return type switch
        {
            UIPanelType.Start => _startPanel,
            UIPanelType.Finish => _finishPanel,
            _ => null
        };
    }
}