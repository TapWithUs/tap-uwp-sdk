using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TAPUWPSDK;
using System.Diagnostics;
using Windows.ApplicationModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TAPUWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            TAPManager.Instance.OnTapped += onTapped;
            TAPManager.Instance.OnMoused += OnMoused;
            TAPManager.Instance.Start();
            
        }

      
        private async void OnMoused(string identifier, int vx, int vy, bool isMouse)
        {
            if (isMouse)
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    textVX.Text = vx.ToString();
                    textVY.Text = vy.ToString();
                });
            }
            
        }

        private async void onTapped(string identifier, int tapCode)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                textBlock.Text = tapCode.ToString();
            });

        }

     
    }
}
