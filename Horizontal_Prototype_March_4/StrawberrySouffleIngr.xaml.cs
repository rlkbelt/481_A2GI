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
        public StrawberrySouffleIngr()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
            };
        }
		public void SliderMover(object sender, RoutedEventArgs e)
		{
			if (straw_Recipe_Ratio.Value == 1)
			{
				straw_quan1.Text = "1 Cup";
				straw_quan2.Text = "2 Cups";
				straw_quan3.Text = "2 Tbsps.";
				straw_quan4.Text = "1/4 Cup";
				straw_quan5.Text = "3";
				straw_quan6.Text = "1 Cup";
				straw_quan7.Text = "1 Cup";
				straw_quan8.Text = "1 Tbsp.";
				straw_quan9.Text = "1 Tsp.";
				//RatiotextBox.Text = "Recipe Ratio: 1"; //for some reason this fails 

			}
			else if (straw_Recipe_Ratio.Value == 2)
			{
				straw_quan1.Text = "2 Cups";
				straw_quan2.Text = "4 Cups";
				straw_quan3.Text = "4 Tbsps.";
				straw_quan4.Text = "1/2 Cup";
				straw_quan5.Text = "6";
				straw_quan6.Text = "2 Cups";
				straw_quan7.Text = "2 Cups";
				straw_quan8.Text = "2 Tbsps.";
				straw_quan9.Text = "2 Tsps.";
				straw_RatiotextBox.Text = "Recipe Ratio: 2";

			}
			else
			{
				straw_quan1.Text = "3 Cups";
				straw_quan2.Text = "6 Cups";
				straw_quan3.Text = "6 Tbsps.";
				straw_quan4.Text = "3/4 Cup";
				straw_quan5.Text = "9";
				straw_quan6.Text = "3 Cups";
				straw_quan7.Text = "3 Cups";
				straw_quan8.Text = "3 Tbsps.";
				straw_quan9.Text = "3 Tsps.";
				straw_RatiotextBox.Text = "Recipe Ratio: 3";

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
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Show();
            printDialog.update();

       }

	}
}
