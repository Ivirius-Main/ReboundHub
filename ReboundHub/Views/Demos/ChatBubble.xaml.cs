using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ReboundHub.Views.Demos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChatBubble : Page
    {
        public ChatBubble()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsViewer.RequestedTheme == ElementTheme.Dark) ItemsViewer.RequestedTheme = ElementTheme.Light;
            else ItemsViewer.RequestedTheme = ElementTheme.Dark;
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            string uriToLaunch = @"https://github.com/Ivirius-Main/ReboundHub/blob/main/ReboundHub/Views/Demos/ChatBubble.xaml";

            // Create a Uri object from a URI string 
            var uri = new Uri(uriToLaunch);

            // Launch the URI
            async void DefaultLaunch()
            {
                // Launch the URI
                var success = await Windows.System.Launcher.LaunchUriAsync(uri);

                if (success)
                {
                    // URI launched
                }
                else
                {
                    // URI launch failed
                }
            }
            DefaultLaunch();
        }
    }
}
