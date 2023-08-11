public interface IUIController
{
    void SetContainer(IUIContainer container);
    void ShowPanel(UIPanelType type);
    void HidePanel(UIPanelType type);
}