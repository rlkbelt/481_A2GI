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
    /// Interaction logic for GlutenFree.xaml
    /// </summary>
    public partial class GlutenFree : UserControl
    {
        MainWindow window;
        public GlutenFree()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
                window._HomeButton.Background = Brushes.BurlyWood;
                window._SearchButton.Background = Brushes.BurlyWood;
                window._FavouritesButton.Background = Brushes.BurlyWood;
                window._SettingsButton.Background = Brushes.BurlyWood;

            };


        }

        

        public void ClearBox(object sender, RoutedEventArgs e)
        {
            _searchboxGF.Text = "";
        }
        public void Filter(object sender, RoutedEventArgs e)
        {
            object[,] glutenArray = new object[,] { { window._recipesArray[1,0].ToString(), 1 },
                                                    { window._recipesArray[7,0].ToString(), 7 },
                                                    { window._recipesArray[8,0].ToString(), 8 },
                                                    { window._recipesArray[9,0].ToString(), 9 } };
            Boolean expand = false;
            try { expand = window._ExpanderButton.IsExpanded; } catch (Exception) { };
            _GlutenWrapPanel.Children.Clear();
            Stack<string> searchStack = new Stack<string>();

            string _searchTerm = _searchboxGF.Text.ToLower();


            for (int i = 0; i < glutenArray.GetLength(0); i++)
            {
                string recipe_name = glutenArray[i, 0].ToString().ToLower();
                if (recipe_name.Contains(_searchTerm))
                {
                    int ind = (int) glutenArray[i, 1];
                    searchStack.Push(window._recipesArray[ind, 0].ToString());
                    searchStack.Push(window._recipesArray[ind, 1].ToString());
                    searchStack.Push(window._recipesArray[ind, 2].ToString());
                    searchStack.Push("*");
                }
            }
            while (!(searchStack.Count == 0))
            {
                _scrollerGF.Visibility = Visibility.Visible;
                string temp = searchStack.Pop();
                if (!(temp == "*"))
                {

                }
                else
                {
                    Image Img = new Image();
                    BitmapImage BitImg = new BitmapImage(new Uri(searchStack.Pop(), UriKind.Relative));
                    Img.Source = BitImg;

                    if (expand)
                    {
                        searchStack.Pop();
                        TextBlock text = new TextBlock();
                        text.Text = searchStack.Pop();
                        text.FontSize = 16;
                        text.TextAlignment = System.Windows.TextAlignment.Center;
                        text.FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");
                        text.TextWrapping = TextWrapping.Wrap;

                        StackPanel sp = new StackPanel();
                        sp.Children.Add(Img);
                        sp.Children.Add(text);
                        Button button = new Button();
                        button.Height = 127;
                        button.Width = 130;
                        text.Width = button.Width - 10;
                        button.Content = sp;
                        button.Tag = text.Text;
                        button.Background = Brushes.Beige;
                        button.Click += new RoutedEventHandler(ButtonClick);
                        _GlutenWrapPanel.Children.Add(button);
                    }
                    else
                    {
                        searchStack.Pop();
                        TextBlock text = new TextBlock();
                        text.Text = searchStack.Pop();
                        text.FontSize = 14;
                        text.TextAlignment = System.Windows.TextAlignment.Center;
                        text.FontFamily = new FontFamily("Tw Cen MT Condensed Extra Bold");
                        text.TextWrapping = TextWrapping.Wrap;

                        StackPanel sp = new StackPanel();
                        sp.Children.Add(Img);
                        sp.Children.Add(text);
                        Button button = new Button();
                        button.Height = 127;
                        button.Width = 100;
                        text.Width = button.Width - 10;
                        button.Content = sp;
                        button.Tag = text.Text;
                        button.Background = Brushes.Beige;
                        button.Click += new RoutedEventHandler(ButtonClick);
                        _GlutenWrapPanel.Children.Add(button);
                    }
                }
            }
            searchStack.Clear();
        }
        public void initValues(object[,] _recipesArray)
        {
            _GlutenWrapPanel.Children.Clear();
            bool expand = false;
            try { expand = window.isExpanded; } catch (Exception) { };
            Stack<string> searchStack = new Stack<string>();
            int end = _recipesArray.GetLength(0);
            searchStack.Push(_recipesArray[1, 0].ToString());
            searchStack.Push(_recipesArray[1, 1].ToString());
            searchStack.Push(_recipesArray[1, 2].ToString());
            searchStack.Push("*");
            searchStack.Push(_recipesArray[7, 0].ToString());
            searchStack.Push(_recipesArray[7, 1].ToString());
            searchStack.Push(_recipesArray[7, 2].ToString());
            searchStack.Push("*");
            searchStack.Push(_recipesArray[8, 0].ToString());
            searchStack.Push(_recipesArray[8, 1].ToString());
            searchStack.Push(_recipesArray[8, 2].ToString());
            searchStack.Push("*");
            searchStack.Push(_recipesArray[9, 0].ToString());
            searchStack.Push(_recipesArray[9, 1].ToString());
            searchStack.Push(_recipesArray[9, 2].ToString());
            searchStack.Push("*");

            while (!(searchStack.Count == 0))
            {
                _scrollerGF.Visibility = Visibility.Visible;
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
                    text.TextWrapping = TextWrapping.Wrap;

                    StackPanel sp = new StackPanel();
                    sp.Children.Add(Img);
                    sp.Children.Add(text);
                    Button button = new Button();
                    button.Height = 127;
                    button.Width = 100;
                    text.Width = button.Width - 10;
                    button.Content = sp;
                    button.Tag = text.Text;
                    button.Background = Brushes.Beige;
                    button.BorderBrush = Brushes.BurlyWood;
                    button.Click += new RoutedEventHandler(ButtonClick);
                    _GlutenWrapPanel.Children.Add(button);

                }

            }

        }

        private void BackClick(object sender, RoutedEventArgs e)
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
