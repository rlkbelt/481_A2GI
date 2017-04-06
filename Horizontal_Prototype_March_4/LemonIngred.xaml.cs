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
	/// Interaction logic for LemonIngred
	/// </summary>
	public partial class LemonIngred : UserControl
	{
		MainWindow window;
		PrintDialog printDialog;
        public bool lemonIngrCollapsed;


        public LemonIngred()
		{
			InitializeComponent();
			this.Loaded += (s, e) =>
			{
				window = Window.GetWindow(this) as MainWindow;
				window.CurrentUserControl = this;
				window._HomeButton.Background = Brushes.Beige;
				window._SearchButton.Background = Brushes.Beige;
				window._FavouritesButton.Background = Brushes.Beige;
				window._SettingsButton.Background = Brushes.Beige;
                lemonIngrCollapsed = false;
                if (!window.isExpanded)
                {
                    lemonIngrCollapsed = true;
                }
            };
		}
		public void SliderMover(object sender, RoutedEventArgs e)
		{
			try
			{
				if (lemon_Recipe_Ratio.Value == 1 && (bool)window._settings.imperialRadio.IsChecked)
				{
					lemon_quan1.Text = "4";
					lemon_quan2.Text = "1/4 Cup";
					lemon_quan3.Text = "3 Tbsps.";
					lemon_quan4.Text = "2 Tbsps.";
					lemon_quan5.Text = "1 Tbsp.";
					lemon_quan6.Text = "1 Tbsp.";
					lemon_quan7.Text = "1/3 Cup";
					lemon_quan8.Text = "1 Tsp.";
					lemon_quan9.Text = "Taste";
					lemon_RatiotextBox.Text = "Recipe Ratio: 1";

				}
				else if (lemon_Recipe_Ratio.Value == 2 && (bool)window._settings.imperialRadio.IsChecked)
				{
					lemon_quan1.Text = "8";
					lemon_quan2.Text = "1/2 Cup";
					lemon_quan3.Text = "6 Tbsps.";
					lemon_quan4.Text = "4 Tbsps.";
					lemon_quan5.Text = "2 Tbsps.";
					lemon_quan6.Text = "2 Tbsp.";
					lemon_quan7.Text = "2/3 Cup";
					lemon_quan8.Text = "2 Tsps.";
					lemon_quan9.Text = "Taste";
					lemon_RatiotextBox.Text = "Recipe Ratio: 2";

				}
				else if (lemon_Recipe_Ratio.Value == 3 && (bool)window._settings.imperialRadio.IsChecked)
				{
					lemon_quan1.Text = "12";
					lemon_quan2.Text = "3/4 Cup";
					lemon_quan3.Text = "9 Tbsps.";
					lemon_quan4.Text = "6 Tbsps.";
					lemon_quan5.Text = "3 Tbsps.";
					lemon_quan6.Text = "3 Tbsps.";
					lemon_quan7.Text = "1 Cup";
					lemon_quan8.Text = "3 Tsps.";
					lemon_quan9.Text = "Taste";
					lemon_RatiotextBox.Text = "Recipe Ratio: 3";

				}

				else if (lemon_Recipe_Ratio.Value == 1 && (bool)window._settings.metricRadio.IsChecked)
				{
					lemon_quan1.Text = "4";
					lemon_quan2.Text = "60 mL";
					lemon_quan3.Text = "45 mL";
					lemon_quan4.Text = "30 mL";
					lemon_quan5.Text = "15 mL";
					lemon_quan6.Text = "15 mL";
					lemon_quan7.Text = "235 mL";
					lemon_quan8.Text = "5 mL";
					lemon_quan9.Text = " Taste";
					lemon_RatiotextBox.Text = "Recipe Ratio: 1";

				}
				else if (lemon_Recipe_Ratio.Value == 2 && (bool)window._settings.metricRadio.IsChecked)
				{
					lemon_quan1.Text = "8";
					lemon_quan2.Text = "120 mL";
					lemon_quan3.Text = "90 mL";
					lemon_quan4.Text = "60 mL";
					lemon_quan5.Text = "30 mL";
					lemon_quan6.Text = "30 mL";
					lemon_quan7.Text = "470 mL";
					lemon_quan8.Text = "10 mL";
					lemon_quan9.Text = "Taste";
					lemon_RatiotextBox.Text = "Recipe Ratio: 2";

				}
				else if (lemon_Recipe_Ratio.Value == 3 && (bool)window._settings.metricRadio.IsChecked)
				{
					lemon_quan1.Text = "12";
					lemon_quan2.Text = "180 mL";
					lemon_quan3.Text = "135 mL";
					lemon_quan4.Text = "90 mL";
					lemon_quan5.Text = "45 mL";
					lemon_quan6.Text = "45 mL";
					lemon_quan7.Text = "705 mL";
					lemon_quan8.Text = "15 mL";
					lemon_quan9.Text = "Taste";
					lemon_RatiotextBox.Text = "Recipe Ratio: 3";

				}
			}
			catch
			{

			}

		}


		private void BackClick(object sender, RoutedEventArgs e)
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
			if (window.isExpanded == false)
			{
				window.OpenCollapsed();
			}
		}

		private void print_Click(object sender, RoutedEventArgs e)
		{
			printDialog = new PrintDialog();
			printDialog.Show();
			printDialog.Process();


		}

		private void BeginClick(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);
			window.CurrentUserControl = window._lemonStep1;
			window._Navigation.Navigate(window._lemonStep1);
		//	window.expanderVisible();
		}
	


	}
}
