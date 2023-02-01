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
        double result;

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
        
        bool stepen = false;
        double xStepen;
        bool stepenKoren = false;
        double xStepenKoren;
        bool logOsnov = false;
        double xLogOsnov;
        bool mod = false;
        double xMod = 0;
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            try
            {
                if (str == "C")
                    textLabel2.Text = "0";
                else if (str == "CE")
                    textLabel2.Text = "";
                else if (str == "←")
                    textLabel2.Text = textLabel2.Text.Remove(textLabel2.Text.Length - 1);
                else if (str == "=")
                {
                    if(!stepenKoren && !logOsnov && !stepen && !mod)
                    {
                        textLabel2.Text = new DataTable().Compute(textLabel2.Text, null).ToString();
                    }
                    else if (logOsnov)
                    {
                        textLabel2.Text = Math.Log(xLogOsnov, double.Parse(textLabel2.Text)).ToString();
                        logOsnov = false;
                        xLogOsnov = 0;
                    }
                    else if (stepen)
                    {
                        textLabel2.Text = Math.Pow(xStepen, double.Parse(textLabel2.Text)).ToString();
                        stepen = false;
                        xLogOsnov = 0;
                    }
                    else if (stepenKoren)
                    {
                        textLabel2.Text = Math.Pow(xStepenKoren, 1/double.Parse(textLabel2.Text)).ToString();
                        stepen = false;
                        xLogOsnov = 0;
                    }
                    else if (mod)
                    {
                        textLabel2.Text = (xMod % double.Parse(textLabel2.Text)).ToString();
                        mod = false;
                        xMod = 0;
                    }
                }
                else if (str == "√")
                {
                    if (textLabel2.Text != string.Empty)
                    {
                        result = double.Parse(textLabel2.Text);
                        result = Math.Sqrt(result);
                        textLabel2.Text = result.ToString();
                    }
                }
                else if (str == "x²")
                {
                    if (textLabel2.Text != string.Empty)
                    {
                        result = double.Parse(textLabel2.Text);
                        result = Math.Pow(result, 2);
                        textLabel2.Text = result.ToString();
                    }
                }
                else if (str == "¹/x")
                {
                    if (textLabel2.Text != string.Empty)
                    {
                        result = double.Parse(textLabel2.Text);
                        result = 1.0 / result;
                        textLabel2.Text = result.ToString();
                    }
                }
                else if (str == "n!")
                {
                    if (textLabel2.Text != string.Empty)
                    {
                        int fact = 1;
                        result = double.Parse(textLabel2.Text);
                        for (int i = 0; i < result; i++)
                        {
                            fact += fact * i;
                        }
                        textLabel2.Text = fact.ToString();
                    }
                }
                else if (str == "+/-")
                {
                    if (textLabel2.Text != string.Empty)
                    {
                        string res = textLabel2.Text;
                        if (res[0] == '-')
                        {

                            textLabel2.Text = res.Remove(0, 1);
                        }
                        else
                        {
                            textLabel2.Text = "-" + res;
                        }
                    }
                }
                else if (str == "10^ᵡ")
                {
                    if (textLabel2.Text != string.Empty)
                    {
                        result = double.Parse(textLabel2.Text);
                        result = Math.Pow(10, result);
                        textLabel2.Text = result.ToString();
                    }
                }
                else if (str == "x^3")
                {
                    result = double.Parse(textLabel2.Text);
                    result = Math.Pow(result, 3);
                    textLabel2.Text = result.ToString();
                }
                else if (str == "ln")
                {
                    double x = double.Parse(textLabel2.Text);
                    textLabel2.Text = Math.Log10(x).ToString();
                }
                else if (str == "Sin")
                {
                    result = double.Parse(textLabel2.Text);
                    result = Math.Sin(result);
                    textLabel2.Text = result.ToString();
                }
                else if (str == "Cos")
                {
                    if(rbRadians.IsChecked)
                    {
                        result = double.Parse(textLabel2.Text);
                        result = Math.Cos(result);
                        textLabel2.Text = result.ToString();
                    }
                }
                else if (str == "Tan")
                {
                    result = double.Parse(textLabel2.Text);
                    result = Math.Tan(result);
                    textLabel2.Text = result.ToString();
                }
                else if (str == "Sin")
                {
                    result = double.Parse(textLabel2.Text);
                    result = Math.Sinh(result);
                    textLabel2.Text = result.ToString();
                }
                else if (str == "Cos")
                {
                    result = double.Parse(textLabel2.Text);
                    result = Math.Cosh(result);
                    textLabel2.Text = result.ToString();

                }
                else if (str == "Tanh")
                {
                    result = double.Parse(textLabel2.Text);
                    result = Math.Tanh(result);
                    textLabel2.Text = result.ToString();
                }

                else if (str == "Exp")
                {
                    result = double.Parse(textLabel2.Text);
                    result = Math.Exp(result);
                    textLabel2.Text = result.ToString();
                }

                else if (str == "π")
                {
                    textLabel2.Text += Math.PI;
                }

                else if (str == "xᵞy")
                {
                    xStepen = double.Parse(textLabel2.Text);
                    textLabel2.Text = "";
                    stepen = true;
                }

                else if (str == "y√x")
                {
                    xStepenKoren = double.Parse(textLabel2.Text);
                    textLabel2.Text = "";
                    stepenKoren = true;
                }

                else if (str == "log")
                {
                    xLogOsnov = double.Parse(textLabel2.Text);
                    logOsnov = true;
                    textLabel2.Text = "";
                }
                else if (str == "mod")
                {
                    xMod = double.Parse(textLabel2.Text);
                    mod = true;
                    textLabel2.Text = "";
                }
                else
                    textLabel2.Text += str;
            }
            catch 
            {
                MessageBox.Show("Не верный ввод!");
            }
        }
        //формула градуса = п/180
        // надо сделать метод радиобатонов

        void Check()
        {
            
        }
        
    }
}
