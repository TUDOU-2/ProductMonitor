using ProductMonitor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// RaderUC.xaml 的交互逻辑
    /// </summary>
    public partial class RaderUC : UserControl
    {
        public RaderUC()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Drag();
        }

        /// <summary>
        /// 数据源；用于绑定雷达图数据，属于依赖属性
        /// </summary>
        public List<RaderModel> ItemSource
        {
            get { return (List<RaderModel>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(List<RaderModel>), typeof(RaderUC));

        public void Drag()
        {
            if (ItemSource == null || ItemSource.Count == 0)
            {
                return;
            }

            ClearContent();

            // 调整大小
            double size = Math.Min(RenderSize.Width, RenderSize.Height);
            LayGrid.Height = size;
            LayGrid.Width = size;

            double radius = size / 2; // 雷达图半径

            double step = 360.0 / ItemSource.Count; // 每个角度的步长
            for (int i = 0; i < ItemSource.Count; i++)
            {
                double x = (radius - 20) * Math.Cos((step * i - 90) * Math.PI / 180); // x偏移量
                double y = (radius - 20) * Math.Sin((step * i - 90) * Math.PI / 180); // y偏移量
                P1.Points.Add(new Point(radius + x, radius + y));
                P2.Points.Add(new Point(radius + x * 0.75, radius + y * 0.75));
                P3.Points.Add(new Point(radius + x * 0.5, radius + y * 0.5));
                P4.Points.Add(new Point(radius + x * 0.25, radius + y * 0.25));

                P5.Points.Add(new Point(radius + x * ItemSource[i].Value * 0.01, radius + y * ItemSource[i].Value * 0.01));

                // 添加文字
                TextBlock txt = new TextBlock();
                txt.Width = 60;
                txt.FontSize = 10;
                txt.TextAlignment = TextAlignment.Center;
                txt.Text = ItemSource[i].ItemName;
                txt.Foreground = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                txt.SetValue(Canvas.LeftProperty, radius + (radius - 10) * Math.Cos((step * i - 90) * Math.PI / 180) - 30); // 设置左边间距
                txt.SetValue(Canvas.TopProperty, radius + (radius - 10) * Math.Sin((step * i - 90) * Math.PI / 180) - 7); // 设置上边间距

                mainCanvas.Children.Add(txt);
            }
        }

        /// <summary>
        /// 清空雷达图内容
        /// </summary>
        public void ClearContent()
        {
            mainCanvas.Children.Clear();
            P1.Points.Clear();
            P2.Points.Clear();
            P3.Points.Clear();
            P4.Points.Clear();
            P5.Points.Clear();
        }
    }
}
