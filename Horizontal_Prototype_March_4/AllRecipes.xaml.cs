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
	/// Interaction logic for AllRecipes.xaml
	/// </summary>
	public partial class AllRecipes : UserControl
    {
		public Stack<object> backStack = new Stack<object>();

		public LemonChickenDesc _lemonChickenDesc = new LemonChickenDesc();
		private Boolean isExpanded { get; set; }

		public object CurrentUserControl { get; set; }

		MainWindow window;
        public AllRecipes()
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
            };

        }
        public void ClearBox(object sender, RoutedEventArgs e)
        {
            _searchboxAR.Text = "";
        }
        public void Filter(object sender, RoutedEventArgs e)
        {
            _RecipesWrapPanel.Children.Clear();
            Stack<string> searchStack = new Stack<string>();
            
            string _searchTerm = _searchboxAR.Text.ToLower();

            for (int i = 0; i < window._recipesArray.GetLength(0); i++)
            {
                string recipe_name = window._recipesArray[i, 0].ToString().ToLower();
                if (recipe_name.Contains(_searchTerm))
                {
                    searchStack.Push(window._recipesArray[i, 0].ToString());
                    searchStack.Push(window._recipesArray[i, 1].ToString());
                    searchStack.Push(window._recipesArray[i, 2].ToString());
                    searchStack.Push("*");
                }
            }
            while (!(searchStack.Count == 0))
            {
                _scrollerAR.Visibility = Visibility.Visible;
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
                    _RecipesWrapPanel.Children.Add(button);
                }

            }
            searchStack.Clear();
        }
        public void initValues(object[,] _recipesArray)
        {
            Stack<string> searchStack = new Stack<string>();
            int end = _recipesArray.GetLength(0);
            for (int i = 0; i < end; i++)
            {
                searchStack.Push(_recipesArray[i, 0].ToString());
                searchStack.Push(_recipesArray[i, 1].ToString());
                searchStack.Push(_recipesArray[i, 2].ToString());
                searchStack.Push("*");
            }
            while (!(searchStack.Count == 0))
            {
                _scrollerAR.Visibility = Visibility.Visible;
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
                    _RecipesWrapPanel.Children.Add(button);
                }

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
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            window.backStack.Push(this);
            Button but = sender as Button;

            for (int i = 0; i < window._recipesArray.GetLength(0); i++)
            {

                if (but.Tag.ToString().ToLower().Equals(window._recipesArray[i, 0].ToString().ToLower()))
                {
                    window._Navigation.Navigate(window._recipesArray[i, 3]);
                    break;
                }
            }
        }
    }
}
