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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// WorkShopDetailUC.xaml 的交互逻辑
    /// </summary>
    public partial class WorkShopDetailUC : UserControl
    {
        public WorkShopDetailUC()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            detail.Visibility = Visibility.Visible;

            // 位移动画
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0,50,0,-50), new Thickness(0,0,0,0),new TimeSpan(0,0,0,0,400));

            // 透明度动画
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(thicknessAnimation, detailContent);
            Storyboard.SetTarget(doubleAnimation, detailContent);
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath(MarginProperty));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(OpacityProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);

            storyboard.Begin();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 位移
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(
                new Thickness(0, 0, 0, 0), new Thickness(0, 50, 0, -50),
                new TimeSpan(0, 0, 0, 0, 400));
            // 透明度
            DoubleAnimation doubleAnimation = new DoubleAnimation(1, 0, new TimeSpan(0, 0, 0, 0, 400));

            Storyboard.SetTarget(thicknessAnimation, detailContent);
            Storyboard.SetTarget(doubleAnimation, detailContent);
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);

            //动画效果完了才关闭
            storyboard.Completed += (se, ev) =>
            {
                detail.Visibility = Visibility.Collapsed;
            };
            storyboard.Begin();
        }
    }
}
