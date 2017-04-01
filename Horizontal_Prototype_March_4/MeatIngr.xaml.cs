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
        public MeatIngr()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
            };
            
        }
        public void SliderMover (object sender, RoutedEventArgs e)
        {
            if(Recipe_Ratio.Value == 1)
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
                //RatiotextBox.Text = "Recipe Ratio: 1"; //for some reason this fails 

            }
            else if (Recipe_Ratio.Value == 2)
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
            else 
            {
                quan1.Text = "4 lb.";
                quan2.Text = "6";
                quan3.Text = "6 Cups";
                quan4.Text = "4 Cups";
                quan5.Text = "4";
                quan6.Text = "4 Cups";
                quan7.Text = "4 tbsps.";
                quan8.Text = "4 tbsps.";
                quan9.Text = "Taste";
                RatiotextBox.Text = "Recipe Ratio: 3";

            }
        }
        
        private void BackClick(object sender, RoutedEventArgs e)
        {
            if (window.backStack.Peek() is HomePage)
            {
                window.expanderInvisible();
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
