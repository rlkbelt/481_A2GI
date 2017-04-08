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
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {
		MainWindow window;
        public Intro()
        {
            InitializeComponent();

		}
        public void close()
        {
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;


				// window._ExpanderButton.Expanded = Expander.Collap

			};
			System.Threading.Thread.Sleep(8000);

            Close();
        }
    }
}
