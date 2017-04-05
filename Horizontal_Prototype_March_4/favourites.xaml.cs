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
    /// Interaction logic for favourites.xaml
    /// </summary>
    public partial class favourites : UserControl
    {
        MainWindow window;
        public favourites()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
                window._HomeButton.Background = Brushes.Beige;
                window._SearchButton.Background = Brushes.Beige;
                window._FavouritesButton.Background = Brushes.BurlyWood;
                window._SettingsButton.Background = Brushes.Beige;
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
        }

        public void initValues(object[,] _recipesArray, List<string> stackFavs)
        {

            try
            {
                window._favourites._FavsWrapPanel.Children.Clear();
            }
            catch (Exception e) {}
            
            
            Stack<string> searchStack = new Stack<string>();
            Stack<string> tempStack = new Stack<string>();

            while (stackFavs.Count != 0)
            {
                string tempString = stackFavs.Last();
                stackFavs.RemoveAt(stackFavs.IndexOf(stackFavs.Last()));
                tempStack.Push(tempString);
                for (int i = 0; i < _recipesArray.GetLength(0); i++)
                {
                    if (tempString.Equals(_recipesArray[i, 0].ToString().ToLower()))
                    {
                        
                        searchStack.Push(_recipesArray[i, 0].ToString());
                        searchStack.Push(_recipesArray[i, 1].ToString());
                        searchStack.Push(_recipesArray[i, 2].ToString());
                        searchStack.Push("*");
                        break;
                    }
                }
            }
            while (tempStack.Count != 0)
            {
                stackFavs.Add(tempStack.Pop());
            }

            
            while (searchStack.Count != 0)
            {
                _ScrollerFav.Visibility = Visibility.Visible;
                string temp = searchStack.Pop();
                if (!(temp == "*"))
                {

                }
                else
                {

                    Image Img = new Image();
                    BitmapImage BitImg = new BitmapImage(new Uri(searchStack.Pop(), UriKind.Relative));
                    Img.Source = BitImg;



                    searchStack.Pop();
                    TextBlock text = new TextBlock();
                    text.Text = searchStack.Pop();
                    text.FontSize = 14;
                    text.TextAlignment = System.Windows.TextAlignment.Center;
                    text.FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");

                    StackPanel sp = new StackPanel();
                    sp.Children.Add(Img);
                    sp.Children.Add(text);
                    Button button = new Button();
                    button.Height = 127;
                    button.Width = 100;
                    button.Content = sp;
                    button.Tag = text.Text;
                    button.Background = Brushes.White;
                    button.Click += new RoutedEventHandler(ButtonClick);
                    _FavsWrapPanel.Children.Add(button);
                }

            }
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            window.backStack.Push(this);
            Button but = sender as Button;
            

            for (int i = 0; i < window._recipesArray.GetLength(0); i++)
            {
                
                if (but.Tag.ToString().ToLower().Equals(window._recipesArray[i, 0].ToString().ToLower()))
                {
                    window.CurrentUserControl = window._recipesArray[i, 3];
                    window.changeWidth();
                    window._Navigation.Navigate(window._recipesArray[i, 3]);
                    break;
                }
            }
        }
    }
}
