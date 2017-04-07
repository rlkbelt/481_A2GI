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
	public partial class Souffle_Step1 : UserControl
	{
		MainWindow window;

		public Souffle_Step1()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
				window.OpenCollapsed();
                window._HomeButton.Background = Brushes.Beige;
                window._SearchButton.Background = Brushes.Beige;
                window._FavouritesButton.Background = Brushes.Beige;
                window._SettingsButton.Background = Brushes.Beige;
                straw_step1wrap.Children.Clear();
                //window.reinit();
              //  try { window._strawIngr.SliderMover(null, null); } catch (Exception) { }
                string[] ingredString = { window._strawIngr.straw_ingr1.Text, window._strawIngr.straw_ingr2.Text, window._strawIngr.straw_ingr3.Text, window._strawIngr.straw_ingr4.Text, window._strawIngr.straw_ingr5.Text };
                string[] quantities = { window._strawIngr.straw_quan1.Text, window._strawIngr.straw_quan2.Text, window._strawIngr.straw_quan3.Text, window._strawIngr.straw_quan4.Text, window._strawIngr.straw_quan5.Text };
                window.populateStep(quantities, ingredString, straw_step1wrap);
                

            };
			

		}

		private void BackClicked(object sender, RoutedEventArgs e)
		{
            if (window.backStack.Peek() is StrawberrySouffleDesc && window._strawDesc.strawDescSidebarCollapsed == false)
            {
                window.OpenExpanded();
                window.isExpanded = true;
            }
            else if (window.backStack.Peek() is StrawberrySouffleIngr && window._strawIngr.strawSoufIngrCollapsed == false)
            {
                window.OpenExpanded();
                window.isExpanded = true;
            }
            else
            {
                window.isExpanded = false;
                window.OpenCollapsed();
            }

            window.CurrentUserControl = window.backStack.Pop();
            window._Navigation.Navigate(window.CurrentUserControl);
            window.changeWidth();
            
        }
		private void NextClicked(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._souffleStep2;
			window._Navigation.Navigate(window._souffleStep2);
		}

		private void backToDesc_Click(object sender, RoutedEventArgs e)
		{
            window.CurrentUserControl = window._strawDesc;
            window._Navigation.Navigate(window.CurrentUserControl);
            window.OpenExpanded();
            window.changeWidth();
            
        }

		private void term_Click(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._beatDefinition;
			window._Navigation.Navigate(window._beatDefinition);
		}

    }
}
