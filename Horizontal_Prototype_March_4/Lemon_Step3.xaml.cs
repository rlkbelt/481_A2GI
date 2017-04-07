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
	/// Interaction logic for Lemon_Step3.xaml
	/// </summary>
	public partial class Lemon_Step3 : UserControl
	{
		MainWindow window;

		public Lemon_Step3()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
				window.OpenCollapsed();
                lemon_step3wrap.Children.Clear();
                string[] ingredString = { window._lemonIngr.lemon_ingr1.Text, window._lemonIngr.lemon_ingr8.Text, window._lemonIngr.lemon_ingr9.Text};
                string[] quantities = { window._lemonIngr.lemon_quan1.Text, window._lemonIngr.lemon_quan8.Text, window._lemonIngr.lemon_quan9.Text};
                window.populateStep(quantities, ingredString, lemon_step3wrap);
            };


		}

		private void BackClicked(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._lemonStep2;
			window._Navigation.Navigate(window._lemonStep2);
		}
		private void NextClicked(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);

			window.CurrentUserControl = window._lemonComp;
			window._Navigation.Navigate(window._lemonComp);
		}

		private void backToDesc_Click(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);
			window.CurrentUserControl = window._lemonDesc;
			window._Navigation.Navigate(window._lemonDesc);
		}

	}
}