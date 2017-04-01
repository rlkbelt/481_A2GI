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
    /// Interaction logic for PrintDialog.xaml
    /// </summary>
    public partial class PrintDialog : Window
    {
        public PrintDialog()
        {
            InitializeComponent();

        }
    
    public void update() {
           
    
        Status.Text = "Printing Complete";
        Progress.Text = "";
        percent.Text = "";
        System.Threading.Thread.Sleep(1000);
        Close();

    }
}
}
