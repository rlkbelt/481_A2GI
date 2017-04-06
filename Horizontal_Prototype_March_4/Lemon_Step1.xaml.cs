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
	/// Interaction logic for Lemon_Step1.xaml
	/// </summary>
	public partial class Lemon_Step1 : UserControl
	{
		MainWindow window;

		public Lemon_Step1()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
				window.OpenCollapsed();
			};


		}

		private void BackClicked(object sender, RoutedEventArgs e)
		{
			if (window.backStack.Peek() is HomePage)
			{
				window.expanderInvisible();
			}
			if (window.backStack.Peek() is favourites)
			{
				window._favourites.initValues(window._recipesArray, window.favouritesList);
			}
			window.CurrentUserControl = window.backStack.Pop();
			window._Navigation.Navigate(window.CurrentUserControl);
			window.changeWidth();
			window.expanderVisible();
			if (window.isExpanded == true)
			{
				window.OpenCollapsed();
			}
		}
		private void NextClicked(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._lemonStep2;
			window._Navigation.Navigate(window._lemonStep2);
		}

		private void backToDesc_Click(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);
			window.CurrentUserControl = window._lemonDesc;
			window._Navigation.Navigate(window._lemonDesc);
		}

	}
}