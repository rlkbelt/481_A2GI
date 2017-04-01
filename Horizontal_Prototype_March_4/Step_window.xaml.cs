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
using System.Windows.Shapes;

namespace Horizontal_Prototype_March_4
{
    /// <summary>
    /// Interaction logic for Step_window.xaml
    /// </summary>
    public partial class Step_window : Window
    {
        Step1Screen _step1 = new Step1Screen();
        Step2Screen _step2 = new Step2Screen();
        public Step_window()
        {
            InitializeComponent();
            StepPanel.Children.Add(_step2);
        }
    }
}
