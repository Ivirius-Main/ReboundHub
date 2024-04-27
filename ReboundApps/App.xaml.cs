namespace ReboundApps;

public partial class App : Application
{
    public static Window CurrentWindow = Window.Current;
    public IThemeService ThemeService { get; set; }
    public IJsonNavigationViewService JsonNavigationViewService { get; set; }
    public new static App Current => (App)Application.Current;
    public string AppVersion { get; set; } = AssemblyInfoHelper.GetAssemblyVersion();
    public string AppName { get; set; } = "ReboundApps";
    public App()
    {
        this.InitializeComponent();
        JsonNavigationViewService = new JsonNavigationViewService();
        JsonNavigationViewService.ConfigDefaultPage(typeof(HomeLandingPage));
        JsonNavigationViewService.ConfigSettingsPage(typeof(SettingsPage));
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        CurrentWindow = new Window();

        CurrentWindow.AppWindow.TitleBar.ExtendsContentIntoTitleBar = true;
        CurrentWindow.AppWindow.TitleBar.ButtonBackgroundColor = Colors.Transparent;

        if (CurrentWindow.Content is not Frame rootFrame)
        {
            CurrentWindow.Content = rootFrame = new Frame();
        }

        ThemeService = new ThemeService();
        ThemeService.Initialize(CurrentWindow);
        ThemeService.ConfigBackdrop();
        ThemeService.ConfigElementTheme();

        rootFrame.Navigate(typeof(MainPage));

        CurrentWindow.Title = CurrentWindow.AppWindow.Title = $"{AppName} v{AppVersion}";
        CurrentWindow.AppWindow.SetIcon("Assets/icon.ico");

        if (Settings.UseDeveloperMode)
        {
            ConfigureLogger();
        }

        CurrentWindow.Activate();
        await DynamicLocalizerHelper.InitializeLocalizer("en-US");

        UnhandledException += (s, e) => Logger?.Error(e.Exception, "UnhandledException");
    }
}

