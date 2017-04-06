

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
	/// Interaction logic for Souffle_Step1.xaml
	/// </summary>
	public partial class Meat_Step3 : UserControl
	{
		MainWindow window;

		public Meat_Step3()
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
			window.CurrentUserControl = window._meatStep2;
			window._Navigation.Navigate(window._meatStep2);
		}
		private void NextClicked(object sender, RoutedEventArgs e)
		{

			window.CurrentUserControl = window._meatStep4;
			window._Navigation.Navigate(window._meatStep4);
		}

		private void backToDesc_Click(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);

			window.CurrentUserControl = window._meatDesc;
			window._Navigation.Navigate(window._meatDesc);
		}
	
	}
}