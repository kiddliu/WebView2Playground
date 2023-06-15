using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebView2Playground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeWebView2();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.WebView.Visibility = Visibility.Hidden;
            }
            else
            {
                this.WebView.Visibility = Visibility.Visible;
            }
        }

        private async void InitializeWebView2()
        {
            // setting user agent string by providing additional arguments
            //var environment = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(null, null, new Microsoft.Web.WebView2.Core.CoreWebView2EnvironmentOptions
            //{
            //    AdditionalBrowserArguments = "--user-agent=WebView2Playground/1.0"
            //});
            await this.WebView.EnsureCoreWebView2Async(/* environment */);

            // or, by setting UserAgent property of CoreWebView2Settings
            // this.WebView.CoreWebView2.Settings.UserAgent = "WebView2Playground/1.0";

            // or, by calling DevToolsProtocol method
            await this.WebView.CoreWebView2.CallDevToolsProtocolMethodAsync("Network.setUserAgentOverride", "{\"userAgent\":\"WebView2Playground/1.0\",\"userAgentMetadata\":{\"mobile\":false,\"platform\":\"Windows\",\"platformVersion\":\"10.0.25387\",\"architecture\":\"x64\",\"model\":\"\"}}");
            
            // fail all the cases
            this.WebView.Source = new Uri("edge://about");

        }
    }
}
