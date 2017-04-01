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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {

        MainWindow window;
        public HomePage()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
            };
        }

        public void AllRecipes_Click(object sender, RoutedEventArgs e)
        {
            if (window != null)
            {
                window.backStack.Push(this);
                
                window.expanderVisible();
                window._allRecipes.initValues(window._recipesArray);
                window._Navigation.Navigate(window._allRecipes);
                window.CurrentUserControl = window._allRecipes;
                
            }
        }
        public void Popular_Click(object sender, RoutedEventArgs e)
        {
            if (window != null)
            {
                window.backStack.Push(this);
                
                window.expanderVisible();
                window._popular.initValues(window._recipesArray);
                window._Navigation.Navigate(window._popular);
                window.CurrentUserControl = window._popular;
                
            }
        }

        public void Categories_Click(object sender, RoutedEventArgs e)
        {
            if (window != null)
            {
                window.backStack.Push(this);
                
                window.expanderVisible();
                window._Navigation.Navigate(window._categories);
                window.CurrentUserControl = window._categories;
            }
        }

    }
}
