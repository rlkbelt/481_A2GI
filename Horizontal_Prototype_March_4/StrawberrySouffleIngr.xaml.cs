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
    public partial class StrawberrySouffleIngr : UserControl
    {
        MainWindow window;
		PrintDialog printDialog;

		public StrawberrySouffleIngr()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
                window.CurrentUserControl = this;
                window._HomeButton.Background = Brushes.White;
                window._SearchButton.Background = Brushes.White;
                window._FavouritesButton.Background = Brushes.White;
                window._SettingsButton.Background = Brushes.White;
            };
        }
		public void SliderMover(object sender, RoutedEventArgs e)
		{
            try
            {
                if (straw_Recipe_Ratio.Value == 1 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    straw_quan1.Text = "1 Cup";
                    straw_quan2.Text = "2 Cups";
                    straw_quan3.Text = "2 Tbsps.";
                    straw_quan4.Text = "3";
                    straw_quan5.Text = "1/4 Cup";
                    straw_quan6.Text = "1 Cup";
                    straw_quan7.Text = "1 Tsp.";
                    straw_quan8.Text = "1 Tbsp.";
                    straw_quan9.Text = "1 Cup";
                    straw_RatiotextBox.Text = "Recipe Ratio: 1";  

                }
                else if (straw_Recipe_Ratio.Value == 2 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    straw_quan1.Text = "2 Cups";
                    straw_quan2.Text = "4 Cups";
                    straw_quan3.Text = "4 Tbsps.";
                    straw_quan4.Text = "6";
                    straw_quan5.Text = "1/2 Cup";
                    straw_quan6.Text = "2 Cups";
                    straw_quan7.Text = "2 Tsps.";
                    straw_quan8.Text = "2 Tbsps.";
                    straw_quan9.Text = "2 Cups";
                    straw_RatiotextBox.Text = "Recipe Ratio: 2";

                }
                else if (straw_Recipe_Ratio.Value == 3 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    straw_quan1.Text = "3 Cups";
                    straw_quan2.Text = "6 Cups";
                    straw_quan3.Text = "6 Tbsps.";
                    straw_quan4.Text = "9";
                    straw_quan5.Text = "3/4 Cup";
                    straw_quan6.Text = "3 Cups";
                    straw_quan7.Text = "3 Tsps.";
                    straw_quan8.Text = "3 Tbsps.";
                    straw_quan9.Text = "3 Cups";
                    straw_RatiotextBox.Text = "Recipe Ratio: 3";

                }

                else if (straw_Recipe_Ratio.Value == 1 && (bool)window._settings.metricRadio.IsChecked)
                {
                    straw_quan1.Text = "250 mL";
                    straw_quan2.Text = "500 mL";
                    straw_quan3.Text = "30 mL";
                    straw_quan4.Text = "3";
                    straw_quan5.Text = "60 mL";
                    straw_quan6.Text = "250 mL";
                    straw_quan7.Text = "5 mL";
                    straw_quan8.Text = "15 mL";
                    straw_quan9.Text = "250 mL";
                    straw_RatiotextBox.Text = "Recipe Ratio: 1"; 

                }
                else if (straw_Recipe_Ratio.Value == 2 && (bool)window._settings.metricRadio.IsChecked)
                {
                    straw_quan1.Text = "500 mL";
                    straw_quan2.Text = "1 L";
                    straw_quan3.Text = "60 mL";
                    straw_quan4.Text = "6";
                    straw_quan5.Text = "120 mL";
                    straw_quan6.Text = "500 mL";
                    straw_quan7.Text = "10 mL";
                    straw_quan8.Text = "30 mL";
                    straw_quan9.Text = "500 mL";
                    straw_RatiotextBox.Text = "Recipe Ratio: 2";

                }
                else if (straw_Recipe_Ratio.Value == 3 && (bool)window._settings.metricRadio.IsChecked)
                {
                    straw_quan1.Text = "750 mL";
                    straw_quan2.Text = "1.5 L";
                    straw_quan3.Text = "90 mL";
                    straw_quan4.Text = "9";
                    straw_quan5.Text = "180 mL";
                    straw_quan6.Text = "750 mL";
                    straw_quan7.Text = "15 mL";
                    straw_quan8.Text = "45 mL";
                    straw_quan9.Text = "750 mL";
                    straw_RatiotextBox.Text = "Recipe Ratio: 3";

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
            if (window.isExpanded == true)
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

		private void strawIngr_BeginClick(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);
			window.CurrentUserControl = window._souffleStep1;
			window._Navigation.Navigate(window._souffleStep1);
            window.expanderVisible();
        }

		
	}
}
