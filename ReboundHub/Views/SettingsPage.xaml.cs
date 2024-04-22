using Microsoft.UI.Xaml.Media.Animation;

namespace ReboundHub.Views;
public sealed partial class SettingsPage : Page
{
    public SettingsPage()
    {
        this.InitializeComponent();
    }

    private void OnSettingCard_Click(object sender, RoutedEventArgs e)
    {
        var item = sender as SettingsCard;
        if (item.Tag != null)
        {
            Type pageType = Application.Current.GetType().Assembly.GetType($"ReboundHub.Views.{item.Tag}");

            if (pageType != null)
            {
                SlideNavigationTransitionInfo entranceNavigation = new SlideNavigationTransitionInfo();
                entranceNavigation.Effect = SlideNavigationTransitionEffect.FromRight;
                App.Current.JsonNavigationViewService.NavigateTo(pageType, item.Header, false, entranceNavigation);
            }
        }
    }
}

