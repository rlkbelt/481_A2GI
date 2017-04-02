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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Stack<object> backStack = new Stack<object>();
        public List<string> favouritesList = new List<string>();

        public object[,] _recipesArray = new object[,] {  { "Lemon Chicken" ,"chicken lemon lime pepper salt", "images/food/chicken.jpeg", new LemonChickenDesc() },
                                                           { "Italian Delux Pizza", "peperoni ham hamburger flour salt", "images/food/delux_pizza.jpg", new LemonChickenDesc() },
                                                           { "Vegan Stirfry", "green pepper beef cabage yam brocolli soy sauce", "images/food/gluten_free_stirfry.jpeg", new LemonChickenDesc() },
                                                           {"Honeysmoked Ham", "ham honey brown sugar salt" , "images/food/honeysmoked_ham.jpeg", new LemonChickenDesc() },
                                                           {"Homestyle Spaghetti", "spaghetti beef pepper marianara tomato paste" , "images/food/italian_spaghetti.jpg", new LemonChickenDesc() },
                                                           {"Tofu Burger", "tofu pepper salt bun lettuce tomato green pepper" , "images/food/tofu_burger.jpeg", new LemonChickenDesc() },
                                                           {"Cake", "flour salt milk eggs sugar icing sugar", "images/food/cake.jpeg", new LemonChickenDesc() },
                                                           {"Meatloaf", "Beef pepper curry salt chilli onion", "images/food/Meatloaf-121.jpg", new MeatDesc() },
                                                           {"Rosemary Fries", "french fries salt rosemary", "images/food/Rosemary_fry.jpeg", new LemonChickenDesc()},
                                                           {"Strawberry Souffle", "icing sugar strawberry dessert", "images/food/straw_sou.jpg", new StrawberrySouffleDesc() },
                                                           {"Vegetarian Pasta", "broccoli celery salt pepper carrots", "images/food/veg_pasta.jpeg", new LemonChickenDesc() },
                                                           {"Vegtable Salad", "Spinach italian dressing peppers raisons ", "images/food/veg_salad.jpg", new LemonChickenDesc() }};
        public favourites _favourites = new favourites();
        public Search _search = new Search();

        public AllRecipes _allRecipes = new AllRecipes();
        public categories _categories = new categories();
        public MeatComplete _meatComplete = new MeatComplete();
        static public MeatDesc _meatDescription = new MeatDesc();
        public MeatIngr _meatIngr = new MeatIngr();
        public Popular _popular = new Popular();
        public StrawberrySouffleIngr _strawIngr = new StrawberrySouffleIngr();
        //public LemonChickenDesc _lemonChickenDesc = new LemonChickenDesc();

        public Settings _settings = new Settings();

        public Step_window _stepWindow = new Step_window();
        public Step1Screen _step1Screen = new Step1Screen();
        public Step2Screen _step2Screen = new Step2Screen();
        public HomePage _homePage = new HomePage();
        public MeatStep1 _meatStep1 = new MeatStep1();


        private Boolean isExpanded { get; set; }

        public object CurrentUserControl { get; set; }




        public MainWindow()
        {
            InitializeComponent();
            _Navigation.Navigate(_homePage);
            CurrentUserControl = _homePage;

        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            expanderInvisible();
            _Navigation.Navigate(_homePage);
            backStack.Push(CurrentUserControl);
            CurrentUserControl = _homePage;

        }
        public void SearchClick(object sender, RoutedEventArgs e)
        {
            expanderVisible();
            _Navigation.Navigate(_search);
            backStack.Push(CurrentUserControl);
            CurrentUserControl = _search;
            OpenExpanded();

        }

        public void FavouritesClick(object sender, RoutedEventArgs e)
        {
            expanderVisible();
            _favourites.initValues(_recipesArray, favouritesList);
            _Navigation.Navigate(_favourites);
            backStack.Push(CurrentUserControl);
            CurrentUserControl = _favourites;
            OpenExpanded();
        }

        public void SettingsClick(object sender, RoutedEventArgs e)
        {
            expanderVisible();
            _Navigation.Navigate(_settings);
            backStack.Push(CurrentUserControl);
            CurrentUserControl = _settings;
            OpenExpanded();
        }
        /**
		private void LemonChickenClick(object sender, RoutedEventArgs e)
		{
			_Navigation.Navigate(_lemonChickenDesc);
			backStack.Push(CurrentUserControl);
			CurrentUserControl = _lemonChickenDesc;

		} **/
        public void OpenCollapsed()
        {
            // this._ExpanderButton.IsExpanded = true;
            this.Expanded(null, null);
            this._ExpanderButton.IsExpanded = true;



        }
        public void OpenExpanded()
        {
            // this._ExpanderButton.IsExpanded = true;
            this.Collapsed(null, null);
            this._ExpanderButton.IsExpanded = false;


        }
        private void Collapsed(object sender, RoutedEventArgs e)
        {
            isExpanded = true;
            _HomeDP.Width = 95;
            _SeachDP.Width = 95;
            _FavouritesDP.Width = 95;
            _SettingsDP.Width = 95;
            _Sidebar.Width = 120;
            _BorderDP.Width = 120;
            _pagestack.Width = 462;
            _pagestack.Margin = new Thickness(32, 0, 0, 0);
            _ExpanderDP.Margin = new Thickness(91, -256, 0, 230);
            changeWidth();

        }
        private void Expanded(object sender, RoutedEventArgs e)
        {
            isExpanded = false;
            _HomeDP.Width = 0;
            _SeachDP.Width = 0;
            _FavouritesDP.Width = 0;
            _SettingsDP.Width = 0;
            _Sidebar.Width = 24;
            _BorderDP.Width = 30;
            _pagestack.Width = 462;
            _pagestack.Margin = new Thickness(28, 0, 0, 0);
            _ExpanderDP.Margin = new Thickness(0, -256, 0, 230);

            changeWidth();

        }

        public void expanderInvisible()
        {
            _HomeDP.Width = 120;
            _HomeButton.Width = 120;

            _SeachDP.Width = 120;
            _SearchButton.Width = 120;

            _FavouritesDP.Width = 120;
            _FavouritesButton.Width = 120;

            _SettingsDP.Width = 120;
            _SettingsButton.Width = 120;

            _ExpanderButton.Visibility = Visibility.Hidden;
            _Sidebar.Width = 120;
            _BorderDP.Width = 120;

        }

        public void expanderVisible()
        {
            _HomeDP.Width = 95;
            _HomeButton.Width = 95;

            _SeachDP.Width = 95;
            _SearchButton.Width = 95;

            _FavouritesDP.Width = 95;
            _FavouritesButton.Width = 95;

            _SettingsDP.Width = 95;
            _SettingsButton.Width = 95;

            _ExpanderButton.Visibility = Visibility.Visible;
            _Sidebar.Width = 120;
            _BorderDP.Width = 120;
        }

        public void changeWidth()
        {
            if (CurrentUserControl == _favourites)
            {
                if (!isExpanded)
                {
                    _favourites._favourites_Grid.Width = 470;
                    //  _popular._PopularWrapPanel.Width = 430;
                }
                else
                {
                    _favourites._favourites_Grid.Width = 372;
                    //_popular._PopularWrapPanel.Width = 330;
                }
            }

            else if (CurrentUserControl == _search)
            {
                if (!isExpanded)
                {
                    _search._search_Grid.Width = 470;
                    //  _popular._PopularWrapPanel.Width = 430;
                }
                else
                {
                    _search._search_Grid.Width = 372;
                    //_popular._PopularWrapPanel.Width = 330;
                }
            }

            else if (CurrentUserControl == _allRecipes)
            {
                if (!isExpanded)
                {
                    _allRecipes._allRecipes_Grid.Width = 470;
                    _allRecipes._RecipesWrapPanel.Width = 430;
                }
                else
                {
                    _allRecipes._allRecipes_Grid.Width = 372;
                    _allRecipes._RecipesWrapPanel.Width = 330;
                }
            }

            else if (CurrentUserControl == _categories)
            {
                if (!isExpanded)
                {
                    _categories._categories_Grid.Width = 470;
                    _categories._CategoriesWrapPanel.Width = 430;
                }
                else
                {
                    _categories._categories_Grid.Width = 372;
                    _categories._CategoriesWrapPanel.Width = 330;
                }

            }
            else if (CurrentUserControl is LemonChickenDesc)
            {
                if (!isExpanded)
                {
                    LemonChickenDesc lcd = CurrentUserControl as LemonChickenDesc;
                    lcd._lemonChickenGrid.Width = 470;

                }
                else
                {
                    LemonChickenDesc lcd = CurrentUserControl as LemonChickenDesc;
                    lcd._lemonChickenGrid.Width = 372;


                }
            }
            else if (CurrentUserControl == _meatComplete)
            {

            }
            else if (CurrentUserControl == _meatDescription)
            {

            }
            else if (CurrentUserControl == _meatIngr)
            {

            }
            else if (CurrentUserControl == _popular)
            {
                if (!isExpanded)
                {
                    _popular._popular_Grid.Width = 470;
                    _popular._PopularWrapPanel.Width = 430;
                }
                else
                {
                    _popular._popular_Grid.Width = 372;
                    _popular._PopularWrapPanel.Width = 330;
                }
            }
            else if (CurrentUserControl == _settings)
            {
                if (!isExpanded)
                {
                    _settings._settings_Grid.Width = 470;
                    //_settings._SettingsWrapPanel.Width = 430;
                }
                else
                {
                    _settings._settings_Grid.Width = 372;
                    //_popular._PopularWrapPanel.Width = 330;
                }
            }
            else if (CurrentUserControl == _stepWindow)
            {

            }
            else if (CurrentUserControl == _step1Screen)
            {

            }
            else if (CurrentUserControl == _step2Screen)
            {

            }
            else if (CurrentUserControl is MeatStep1)
            {
                if (!isExpanded)
                {
                    _meatStep1.MeatStep1Grid.Width = 470;
					_meatStep1.BackButton.Visibility = Visibility.Visible;
				}

                else
                {
                    //this._pagestack.HorizontalAlignment = HorizontalAlignment.Right;
                    //this._pagestack.Width = 372;
                    //_meatStep1.MeatStep1Grid.Width = 372;
					//_meatStep1.MeatStep1Grid.HorizontalAlignment = HorizontalAlignment.Right;
                    _meatStep1.BackButton.Visibility = Visibility.Hidden;
                }
            }
        }

    }
}
