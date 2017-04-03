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

namespace Horizontal_Prototype_March_4
{
    /// <summary>
    /// Interaction logic for MeatStep1.xaml
    /// </summary>
    public partial class MeatStep1 : UserControl
    {
        MainWindow window;
        public MeatStep1()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
                window.OpenCollapsed();
               // window._ExpanderButton.Expanded = Expander.Collap
            };

        }

        private void BackClicked(object sender, RoutedEventArgs e)
        {
            window._allRecipes._searchboxAR.Text = window._Sidebar.Width.ToString();   
        }
    }
}
