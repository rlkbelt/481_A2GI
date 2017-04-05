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
        public MeatIngr()
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
        public void SliderMover (object sender, RoutedEventArgs e)
        {
            try
            {
                if (Recipe_Ratio.Value == 1 && (bool) window._settings.imperialRadio.IsChecked)
                {
                    quan1.Text = "1 lb.";
                    quan2.Text = "2";
                    quan3.Text = "2 Cups";
                    quan4.Text = "1 Cup";
                    quan5.Text = "1";
                    quan6.Text = "1 Cup";
                    quan7.Text = "1 tbsp.";
                    quan8.Text = "1 tbsp.";
                    quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 1"; //for some reason this fails 

                }
                else if (Recipe_Ratio.Value == 2 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    quan1.Text = "2 lb.";
                    quan2.Text = "4";
                    quan3.Text = "4 Cups";
                    quan4.Text = "2 Cups";
                    quan5.Text = "2";
                    quan6.Text = "2 Cups";
                    quan7.Text = "2 tbsps.";
                    quan8.Text = "2 tbsps.";
                    quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 2";

                }
                else if (Recipe_Ratio.Value == 3 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    quan1.Text = "3 lb.";
                    quan2.Text = "6";
                    quan3.Text = "6 Cups";
                    quan4.Text = "3 Cups";
                    quan5.Text = "3";
                    quan6.Text = "3 Cups";
                    quan7.Text = "3 tbsps.";
                    quan8.Text = "3 tbsps.";
                    quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 3";

                }
				else if (Recipe_Ratio.Value == 1 && (bool)window._settings.metricRadio.IsChecked)
				{
					quan1.Text = "0.45 kg.";
					quan2.Text = "2";
					quan3.Text = "500 mL.";
					quan4.Text = "250 mL.";
					quan5.Text = "1";
					quan6.Text = "250 mL.";
					quan7.Text = "15 mL.";
					quan8.Text = "15 mL.";
					quan9.Text = "Taste";
					RatiotextBox.Text = "Recipe Ratio: 1"; //for some reason this fails 

				}
				else if (Recipe_Ratio.Value == 2 && (bool)window._settings.metricRadio.IsChecked)
				{
					quan1.Text = "0.9 kg.";
					quan2.Text = "4";
					quan3.Text = "1 L.";
					quan4.Text = "500 mL.";
					quan5.Text = "2";
					quan6.Text = "500 mL.";
					quan7.Text = "30 mL.";
					quan8.Text = "30 mL.";
					quan9.Text = "Taste";
					RatiotextBox.Text = "Recipe Ratio: 2";

				}
				else if (Recipe_Ratio.Value == 3 && (bool)window._settings.metricRadio.IsChecked)
				{
					quan1.Text = "3 lb.";
					quan2.Text = "6";
					quan3.Text = "1.5 L.";
					quan4.Text = "750 mL";
					quan5.Text = "3";
					quan6.Text = "750 mL";
					quan7.Text = "45 mL.";
					quan8.Text = "45 mL.";
					quan9.Text = "Taste";
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

    }
}
