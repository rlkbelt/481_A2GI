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
	/// Interaction logic for Souffle_Step3.xaml
	/// </summary>
	public partial class Souffle_Step3 : UserControl
	{
		MainWindow window;
		public Souffle_Step3()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
				window.OpenCollapsed();
                straw_step3wrap.Children.Clear();
                string[] ingredString = { window._strawIngr.straw_ingr9.Text };
                string[] quantities = { window._strawIngr.straw_quan9.Text };
                window.populateStep(quantities, ingredString, straw_step3wrap);
                
            };

		}

		private void BackClicked(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._souffleStep2;
			window._Navigation.Navigate(window._souffleStep2);
		}
		private void NextClicked(object sender, RoutedEventArgs e)
		{
			window.CurrentUserControl = window._souffleComp;
			window._Navigation.Navigate(window._souffleComp);
            StrawberrySouffleDesc ssd = window._recipesArray[11, 3] as StrawberrySouffleDesc;
            if (ssd.favFlag)
            {
                window._recipesArray[11, 3] = new StrawberrySouffleDesc(true);
            }
            else
            {
                window._recipesArray[11, 3] = new StrawberrySouffleDesc(false);

            }
        }

		private void backToDesc_Click(object sender, RoutedEventArgs e)
		{
            window.backStack.Pop();
            window.CurrentUserControl = window._recipesArray[11,3];
			window._Navigation.Navigate(window.CurrentUserControl);
            window.OpenExpanded();
		}
	}
}
