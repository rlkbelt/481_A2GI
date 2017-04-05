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
    /// Interaction logic for LemonIngred.xaml
    /// </summary>
    public partial class LemonIngred : UserControl
    {
        MainWindow window;
        PrintDialog printDialog;
        public LemonIngred()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
                window.CurrentUserControl = this;
            };
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

        public void SliderMover(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Recipe_Ratio.Value == 1 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    quan1.Text = "4";
                    quan2.Text = "1/4 Cup";
                    quan3.Text = "3 tbsp.";
                    quan4.Text = "2 tbsp.";
                    quan5.Text = "1 tbsp.";
                    quan6.Text = "1 tbsp.";
                    quan7.Text = "1/3 Cup";
                    quan8.Text = "1 tsp.";
                    quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 1"; //for some reason this fails 

                }
                else if (Recipe_Ratio.Value == 2 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    quan1.Text = "8";
                    quan2.Text = "1/2 Cup";
                    quan3.Text = "6 tbsp.";
                    quan4.Text = "4 tbsp.";
                    quan5.Text = "2 tbsp.";
                    quan6.Text = "2 tbsp.";
                    quan7.Text = "2/3 Cup";
                    quan8.Text = "2 tsp.";
                    quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 2";

                }
                else if (Recipe_Ratio.Value == 3 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    quan1.Text = "12";
                    quan2.Text = "3/4 Cup";
                    quan3.Text = "9 tbsp.";
                    quan4.Text = "6 tbsp.";
                    quan5.Text = "3 tbsp.";
                    quan6.Text = "3 tbsp.";
                    quan7.Text = "1 Cup";
                    quan8.Text = "3 tsp.";
                    quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 3";

                }
                else if (Recipe_Ratio.Value == 1 && (bool)window._settings.metricRadio.IsChecked)
                {
                    quan1.Text = "4";
                    quan2.Text = "60 mL.";
                    quan3.Text = "45 mL.";
                    quan4.Text = "30 mL.";
                    quan5.Text = "15 mL.";
                    quan6.Text = "15 mL.";
                    quan7.Text = "80 mL.";
                    quan8.Text = "5 mL.";
                    quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 1"; //for some reason this fails 

                }
                else if (Recipe_Ratio.Value == 2 && (bool)window._settings.metricRadio.IsChecked)
                {
                    quan1.Text = "8";
                    quan2.Text = "120 mL.";
                    quan3.Text = "90 mL.";
                    quan4.Text = "60 mL.";
                    quan5.Text = "30 mL.";
                    quan6.Text = "30 mL.";
                    quan7.Text = "160 mL.";
                    quan8.Text = "10 mL.";
                    quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 2";

                }
                else if (Recipe_Ratio.Value == 3 && (bool)window._settings.metricRadio.IsChecked)
                {
                    quan1.Text = "12";
                    quan2.Text = "180 mL.";
                    quan3.Text = "135 mL.";
                    quan4.Text = "90 mL.";
                    quan5.Text = "45 mL.";
                    quan6.Text = "45 mL.";
                    quan7.Text = "1 Cup";
                    quan8.Text = "15 mL.";
                    quan9.Text = "Taste";
                    RatiotextBox.Text = "Recipe Ratio: 3";

                }

            }
            catch
            {

            }
        }

		private void BeginClick(object sender, RoutedEventArgs e)
		{
			window.backStack.Push(this);
			window._Navigation.Navigate(window._lemonStep1);
			window.changeWidth();
			window.expanderInvisible();
		}
	}





}
