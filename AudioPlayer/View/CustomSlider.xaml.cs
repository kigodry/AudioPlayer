using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace AudioPlayer.View
{
    /// <summary>
    /// Interaction logic for CustomSlider.xaml
    /// </summary>
    public partial class CustomSlider : UserControl
    {

        public static readonly DependencyProperty IsDraggedProperty = DependencyProperty.Register("IsDragged", typeof(bool), typeof(CustomSlider), new PropertyMetadata(false));
        public bool IsDragged { get { return (bool)GetValue(IsDraggedProperty); } set { SetValue(IsDraggedProperty, value); } }
        public CustomSlider()
        {
            InitializeComponent();
        }

        private void Slider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            IsDragged = true;
        }

        private void Slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            IsDragged = false;
        }
    }
}
