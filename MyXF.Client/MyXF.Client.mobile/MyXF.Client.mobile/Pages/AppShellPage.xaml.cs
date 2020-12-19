using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyXF.Client.mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShellPage : Shell
    {
        public AppShellPage()
        {
            InitializeComponent();
        }
    }
}