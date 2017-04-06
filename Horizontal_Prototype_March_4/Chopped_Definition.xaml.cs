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
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class Chopped_Definition : UserControl
	{
		MainWindow window;

		public Chopped_Definition()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
				window.CurrentUserControl = this;
			};
		}

		private void BackClick(object sender, RoutedEventArgs e)
		{
			
			window.CurrentUserControl = window._meatStep1;
			window._Navigation.Navigate(window._meatStep1);
		}
	}
}

