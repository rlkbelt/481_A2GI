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
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class MeatIngr : UserControl
    {
        MainWindow window;
        PrintDialog printDialog;
        public bool meatIngrCollapsed;
        public MeatIngr()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
				window.CurrentUserControl = this;
                window._HomeButton.Background = Brushes.BurlyWood;
                window._SearchButton.Background = Brushes.BurlyWood;
                window._FavouritesButton.Background = Brushes.BurlyWood;
                window._SettingsButton.Background = Brushes.BurlyWood;
                meatIngrCollapsed = false;
                if (!window.isExpanded)
                {
                    meatIngrCollapsed = true;
                }
            };
            
        }
        public void SliderMover (object sender, RoutedEventArgs e)
        {
            try
            {
                if (Recipe_Ratio.Value == 1 && (bool) window._settings.imperialRadio.IsChecked)
                {
                    meat_quan1.Text = "1 lb.";
                    meat_quan2.Text = "2";
                    meat_quan3.Text = "2 Cups";
                    meat_quan4.Text = "1 Cup";
                    meat_quan5.Text = "1";
                    meat_quan6.Text = "1 Cup";
                    meat_quan7.Text = "1 tbsp.";
                    meat_quan8.Text = "1 tbsp.";
                    meat_quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 1"; //for some reason this fails 

                }
                else if (Recipe_Ratio.Value == 2 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    meat_quan1.Text = "2 lb.";
                    meat_quan2.Text = "4";
                    meat_quan3.Text = "4 Cups";
                    meat_quan4.Text = "2 Cups";
                    meat_quan5.Text = "2";
                    meat_quan6.Text = "2 Cups";
                    meat_quan7.Text = "2 tbsps.";
                    meat_quan8.Text = "2 tbsps.";
                    meat_quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 2";

                }
                else if (Recipe_Ratio.Value == 3 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    meat_quan1.Text = "3 lb.";
                    meat_quan2.Text = "6";
                    meat_quan3.Text = "6 Cups";
                    meat_quan4.Text = "3 Cups";
                    meat_quan5.Text = "3";
                    meat_quan6.Text = "3 Cups";
                    meat_quan7.Text = "3 tbsps.";
                    meat_quan8.Text = "3 tbsps.";
                    meat_quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 3";

                }
				else if (Recipe_Ratio.Value == 1 && (bool)window._settings.metricRadio.IsChecked)
				{
					meat_quan1.Text = "0.45 kg.";
					meat_quan2.Text = "2";
					meat_quan3.Text = "500 mL.";
					meat_quan4.Text = "250 mL.";
					meat_quan5.Text = "1";
					meat_quan6.Text = "250 mL.";
					meat_quan7.Text = "15 mL.";
					meat_quan8.Text = "15 mL.";
					meat_quan9.Text = "Taste";
					RatiotextBox.Text = "Recipe Ratio: 1"; //for some reason this fails 

				}
				else if (Recipe_Ratio.Value == 2 && (bool)window._settings.metricRadio.IsChecked)
				{
					meat_quan1.Text = "1.35 kg.";
					meat_quan2.Text = "4";
					meat_quan3.Text = "1 L.";
					meat_quan4.Text = "500 mL.";
					meat_quan5.Text = "2";
					meat_quan6.Text = "500 mL.";
					meat_quan7.Text = "30 mL.";
					meat_quan8.Text = "30 mL.";
					meat_quan9.Text = "Taste";
					RatiotextBox.Text = "Recipe Ratio: 2";

				}
				else if (Recipe_Ratio.Value == 3 && (bool)window._settings.metricRadio.IsChecked)
				{
					meat_quan1.Text = "3 lb.";
					meat_quan2.Text = "6";
					meat_quan3.Text = "1.5 L.";
					meat_quan4.Text = "750 mL";
					meat_quan5.Text = "3";
					meat_quan6.Text = "750 mL";
					meat_quan7.Text = "45 mL.";
					meat_quan8.Text = "45 mL.";
					meat_quan9.Text = "Taste";
					RatiotextBox.Text = "Recipe Ratio: 3";

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
			window.CurrentUserControl = window._meatStep1;
			window._Navigation.Navigate(window._meatStep1);
			window.expanderVisible();
		}

	}
}
