using System;
using System.Collections.Generic;
using System.Linq;
using System;
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
	public partial class UserControl1 : UserControl
	{
		public string straw_quan1;
		public string straw_quan2;
		public string straw_quan3;
		public string straw_quan4;
		public string straw_quan5;
		public string straw_quan6;
		public string straw_quan7;
		public string straw_quan8;
		public string straw_quan9;
        MainWindow window;
		
		public UserControl1()
		{
            this.Loaded += (s, e) =>
            {
                window = Window.GetWindow(this) as MainWindow;
                window.OpenCollapsed();

                // window._ExpanderButton.Expanded = Expander.Collap

            };
            straw_quan1 = "1 Cup";
			straw_quan2 = "2 Cups";
			straw_quan3 = "2 Tbsps.";
			straw_quan4 = "3";
			straw_quan5 = "1/4 Cup";
			straw_quan6 = "1 Cup";
			straw_quan7 = "1 Tsp.";
			straw_quan8 = "1 Tbsp.";
			straw_quan9 = "1 Cup";
		}
        public void changeMetrics()
        {
            try
            {
                if (window._strawIngr.straw_Recipe_Ratio.Value == 1 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    straw_quan1 = "1 Cup";
                    straw_quan2 = "2 Cups";
                    straw_quan3 = "2 Tbsps.";
                    straw_quan4 = "3";
                    straw_quan5 = "1/4 Cup";
                    straw_quan6 = "1 Cup";
                    straw_quan7 = "1 Tsp.";
                    straw_quan8 = "1 Tbsp.";
                    straw_quan9 = "1 Cup";
                    

                }
                else if (window._strawIngr.straw_Recipe_Ratio.Value == 2 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    straw_quan1 = "2 Cups";
                    straw_quan2 = "4 Cups";
                    straw_quan3 = "4 Tbsps.";
                    straw_quan4 = "6";
                    straw_quan5 = "1/2 Cup";
                    straw_quan6 = "2 Cups";
                    straw_quan7 = "2 Tsps.";
                    straw_quan8 = "2 Tbsps.";
                    straw_quan9 = "2 Cups";
                    

                }
                else if (window._strawIngr.straw_Recipe_Ratio.Value == 3 && (bool)window._settings.imperialRadio.IsChecked)
                {
                    straw_quan1 = "3 Cups";
                    straw_quan2 = "6 Cups";
                    straw_quan3 = "6 Tbsps.";
                    straw_quan4 = "9";
                    straw_quan5 = "3/4 Cup";
                    straw_quan6 = "3 Cups";
                    straw_quan7 = "3 Tsps.";
                    straw_quan8 = "3 Tbsps.";
                    straw_quan9 = "3 Cups";
                    

                }

                else if (window._strawIngr.straw_Recipe_Ratio.Value == 1 && (bool)window._settings.metricRadio.IsChecked)
                {
                    straw_quan1 = "250 mL";
                    straw_quan2 = "500 mL";
                    straw_quan3 = "30 mL";
                    straw_quan4 = "3";
                    straw_quan5 = "60 mL";
                    straw_quan6 = "250 mL";
                    straw_quan7 = "5 mL";
                    straw_quan8 = "15 mL";
                    straw_quan9 = "250 mL";
                    

                }
                else if (window._strawIngr.straw_Recipe_Ratio.Value == 2 && (bool)window._settings.metricRadio.IsChecked)
                {
                    straw_quan1 = "500 mL";
                    straw_quan2 = "1 L";
                    straw_quan3 = "60 mL";
                    straw_quan4 = "6";
                    straw_quan5 = "120 mL";
                    straw_quan6 = "500 mL";
                    straw_quan7 = "10 mL";
                    straw_quan8 = "30 mL";
                    straw_quan9 = "500 mL";
                    

                }
                else if (window._strawIngr.straw_Recipe_Ratio.Value == 3 && (bool)window._settings.metricRadio.IsChecked)
                {
                    straw_quan1 = "750 mL";
                    straw_quan2 = "1.5 L";
                    straw_quan3 = "90 mL";
                    straw_quan4 = "9";
                    straw_quan5 = "180 mL";
                    straw_quan6 = "750 mL";
                    straw_quan7 = "15 mL";
                    straw_quan8 = "45 mL";
                    straw_quan9 = "750 mL";
                    

                }
            }
            catch
            {

            }

        }
    }
}
