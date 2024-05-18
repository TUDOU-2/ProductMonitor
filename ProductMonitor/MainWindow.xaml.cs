using ProductMonitor.OpCommand;
using ProductMonitor.UserControls;
using ProductMonitor.ViewModels;
using ProductMonitor.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM mainWindowVM = new MainWindowVM();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mainWindowVM;
        }

        private void ShowDetailUC()
        {
            WorkShopDetailUC workShopDetailUC = new WorkShopDetailUC();
            mainWindowVM.MonitorUC = workShopDetailUC;
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0,50,0,-50),
                new Thickness(0,0,0,0),new TimeSpan(0,0,0,0,400)); // 位移动画

            DoubleAnimation doubleAnimation = new DoubleAnimation(0,1,new TimeSpan(0,0,0,0,400)); // 透明度动画

            Storyboard.SetTarget(thicknessAnimation, workShopDetailUC); // 设置动画目标
            Storyboard.SetTarget(doubleAnimation, workShopDetailUC); // 设置动画目标

            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin")); // 设置动画属性
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity")); // 设置动画属性

            Storyboard storyboard = new Storyboard(); // 创建故事板
            storyboard.Children.Add(thicknessAnimation); // 添加动画
            storyboard.Begin();
        }

        private void GoBack()
        {
            mainWindowVM.MonitorUC = new MonitorUC();
        }

        public Command ShowDetailCmm
        {
            get
            {
                return new Command(ShowDetailUC);
            }
        }
        public Command GoBackCmm
        {
            get
            {
                return new Command(GoBack);
            }
        }

        private void BtnMin(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private void ShowSettingsWin()
        {
            SettingsWin settingWindow = new SettingsWin() { Owner = this};
            settingWindow.ShowDialog();
        }

        public Command ShowSettingsCmm
        {
            get
            {
                return new Command(ShowSettingsWin);
            }
        }
    }
}