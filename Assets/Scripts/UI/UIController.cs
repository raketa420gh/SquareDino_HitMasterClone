public class UIController : IUIController
{
    private IUIContainer _uiContainer;

    public void SetContainer(IUIContainer container)
    {
        _uiContainer = container;
    }

    public void ShowPanel(UIPanelType type)
    {
        var panel = _uiContainer.GetPanel(type);
        panel.Show();
    }

    public void HidePanel(UIPanelType type)
    {
        var panel = _uiContainer.GetPanel(type);
        panel.Hide();
    }
}