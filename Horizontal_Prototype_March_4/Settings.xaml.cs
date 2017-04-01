﻿using System;
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
            };
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            window.CurrentUserControl = window.backStack.Pop();
            window._Navigation.Navigate(window.CurrentUserControl);
        }
    }
}