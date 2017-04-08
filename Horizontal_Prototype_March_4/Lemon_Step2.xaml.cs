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
	/// Interaction logic for Lemon_Step2.xaml
	/// </summary>
	public partial class Lemon_Step2 : UserControl
	{
		MainWindow window;

		public Lemon_Step2()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
				window.OpenCollapsed();
                lemon_step2wrap.Children.Clear();
                string[] ingredString = { window._lemonIngr.lemon_ingr2.Text, window._lemonIngr.lemon_ingr3.Text, window._lemonIngr.lemon_ingr4.Text, window._lemonIngr.lemon_ingr5.Text, window._lemonIngr.lemon_ingr6.Text, window._lemonIngr.lemon_ingr7.Text };
                string[] quantities = { window._lemonIngr.lemon_quan2.Text, window._lemonIngr.lemon_quan3.Text, window._lemonIngr.lemon_quan4.Text, window._lemonIngr.lemon_quan5.Text, window._lemonIngr.lemon_quan6.Text, window._lemonIngr.lemon_quan7.Text };
                window.populateStep(quantities, ingredString, lemon_step2wrap);
            };


		}

		private void BackClicked(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._lemonStep1;
			window._Navigation.Navigate(window._lemonStep1);
		}
		private void NextClicked(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._lemonStep3;
			window._Navigation.Navigate(window._lemonStep3);
		}

		private void backToDesc_Click(object sender, RoutedEventArgs e)
		{
            window.backStack.Pop();
            window.CurrentUserControl = window._recipesArray[9,3];
			window._Navigation.Navigate(window.CurrentUserControl);
            window.OpenExpanded();
        }

	}
}
