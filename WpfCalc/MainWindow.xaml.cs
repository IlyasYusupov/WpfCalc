using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el2 in MainRoot2.Children)
            {
                if (el2 is Button)
                {
                    ((Button)el2).Click += Button2_Click;
                }
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "AC")
                textLabel2.Text = "";
            else if (str == "=")
            {
                string value = new DataTable().Compute(textLabel2.Text, null).ToString();
                textLabel2.Text = value;
            }
            else
                textLabel2.Text += str;
        }

        private void Button_Nazad_Click(object sender, RoutedEventArgs e)
        {
            //UserPageWindow userPageWindow = new UserPageWindow();
            //userPageWindow.Show();
            //Hide();
        }
    }
}
