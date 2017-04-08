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
using System.Windows.Shapes;

namespace Horizontal_Prototype_March_4
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        MainWindow window;
        public Settings()
        {
            InitializeComponent();

            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
                window._HomeButton.Background = Brushes.BurlyWood;
                window._SearchButton.Background = Brushes.BurlyWood;
                window._FavouritesButton.Background = Brushes.BurlyWood;
                window._SettingsButton.Background = Brushes.SaddleBrown;
            };

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (window.backStack.Peek() is HomePage)
            {
                window.OpenExpanded();
                window.expanderInvisible();

            }
            if (window.backStack.Peek() is favourites)
            {
                window._favourites.initValues(window._recipesArray, window.favouritesList);
            }

            window.CurrentUserControl = window.backStack.Pop();
            window._Navigation.Navigate(window.CurrentUserControl);
            try { window._meatIngr.SliderMover(null, null); } catch (Exception) { }
            try { window._strawIngr.SliderMover(null, null); } catch (Exception) { }
            try { window._lemonIngr.SliderMover(null, null); } catch (Exception) { }
            //window.reinit();
            window.changeWidth();
        }

        private void ImperialCheck(object sender, RoutedEventArgs e)
        {
            
			imperialRadio.IsChecked = true;
            metricRadio.IsChecked = false;
            try
            {
                window.initStrawImp();
                window.initMeatImp();
                window.initLemonImp();
            }
            catch (Exception) { }
            try { window._meatIngr.SliderMover(null, null); } catch (Exception) { }
            try { window._strawIngr.SliderMover(null, null); } catch (Exception) { }
            try { window._lemonIngr.SliderMover(null, null); } catch (Exception) { }
            
            

        }

        private void MetricCheck(object sender, RoutedEventArgs e)
        {
            
			metricRadio.IsChecked = true;
            imperialRadio.IsChecked = false;
            window.initStrawMetric();
            window.initLemonMetric();
            window.initMeatMetric();
            try { window._meatIngr.SliderMover(null, null); } catch (Exception) { }
            try { window._strawIngr.SliderMover(window._strawIngr.straw_Recipe_Ratio, null); } catch (Exception) { }
            try { window._lemonIngr.SliderMover(null, null); } catch (Exception) { }
            


        }

        public void setMetric(bool value)
        {
            metricRadio.IsChecked = false;
        }
    }
}
