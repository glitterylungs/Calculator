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
using System.Data;

namespace Calculator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void componentClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                string element = button.Content.ToString();
                string operation = this.textDisplay.Text;
                if (operation.Length < 10) //maksymalna dlugosc w textblock
                {
                    if (!(operation.Length == 9 && (element == "*" || element == "/" || element == "+"
                        || element == "-"))) // +,-, *, /, nie moga wystepowac na ostatnim dostepnym miejscu znakowym
                    {
                        if ((element.Equals("*") || element.Equals("/") || element.Equals("+") || element.Equals("-"))
                            && ( operation.EndsWith("+") || operation.EndsWith("-") 
                            || operation.EndsWith("*") || operation.EndsWith("/"))) //operatory nie moga wystepowac obok sb, zastepowanie operatora innym
                        {
                            operation = operation.Remove(operation.Length - 1) + element;
                            this.textDisplay.Text = operation;
                        }
                        else
                        {
                            if (!(operation.Length == 0 && (element == "*" || element == "/" || element == "+"
                        || element == "-")))
                            {
                                this.textDisplay.Text += element;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }

        private void equalClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string operation = this.textDisplay.Text;
                DataTable dt = new DataTable();
                var result = dt.Compute(operation, "");
                if (result.ToString() == "∞" || result.ToString() == "NaN")
                {
                    this.textDisplay.Text = "";
                }
                else
                {
                    this.textDisplay.Text = result.ToString().Replace(",", ".");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void backClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string operation = this.textDisplay.Text;
                if (operation.Length > 0)
                {
                    operation = operation.Remove(operation.Length - 1);
                    this.textDisplay.Text = operation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string operation = this.textDisplay.Text;
                if (operation.Length > 0)
                {
                    operation = "";
                    this.textDisplay.Text = operation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void plusMinusClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string operation = this.textDisplay.Text;
                DataTable dt = new DataTable();
                var result = dt.Compute(operation, "");
              
                if (result.ToString().StartsWith("-"))
                {  
                   this.textDisplay.Text = result.ToString().Replace(",", ".").Replace("-","");
                }
                else
                {
                    this.textDisplay.Text = "-" + result.ToString().Replace(",", ".");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void squareClick(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = 0;
                string operation = this.textDisplay.Text;
                DataTable dt = new DataTable();
                var result = dt.Compute(operation, "");
                double.TryParse(result.ToString(), out x);

                this.textDisplay.Text = (x*x).ToString().Replace(",", ".");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fractionClick(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = 0;
                string operation = this.textDisplay.Text;
                DataTable dt = new DataTable();
                var result = dt.Compute(operation, "");
                double.TryParse(result.ToString(), out x);
                if(result.ToString() != "0")
                {
                    this.textDisplay.Text = (1 / x).ToString().Replace(",", ".");
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
