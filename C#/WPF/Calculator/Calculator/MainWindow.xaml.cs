using Calculator.Model;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber;
        private double result;
        private SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            //btnAC.Click += BtnAC_Click;
            //btnNegative.Click += BtnNegative_Click;
            //btnPercentage.Click += BtnPercentage_Click;
            //btnEquals.Click += BtnEquals_Click;
            //btnDot.Click += BtnDot_Click;
        }

        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            if (!lblResult.Content.ToString().Contains("."))
            {
                this.lblResult.Content = $"{lblResult.Content}.";
            }
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(this.lblResult.Content.ToString(), out newNumber))
            {
                switch (this.selectedOperator)
                {
                    case SelectedOperator.Addition:
                    {
                        this.result = SimpleMath.Add(this.lastNumber, newNumber);
                        break;
                    }
                    case SelectedOperator.Multiplication:
                    {
                        this.result = SimpleMath.Multiply(this.lastNumber, newNumber);
                        break;
                    }
                    case SelectedOperator.Division:
                    {
                        this.result = SimpleMath.Divide(this.lastNumber, newNumber);
                        break;
                    }
                    case SelectedOperator.Subtraction:
                    {
                        this.result = SimpleMath.Subtract(this.lastNumber, newNumber);
                        break;
                    }

                }

                this.lblResult.Content = this.result;
            }
        }

        private void BtnPercentage_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(this.lblResult.Content.ToString(), out tempNumber))
            {
                tempNumber /= 100;
                if (this.lastNumber != 0)
                {
                    tempNumber *= this.lastNumber;
                }
                this.lblResult.Content = tempNumber.ToString();
            }
        }

        private void BtnNegative_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(this.lblResult.Content.ToString(), out this.lastNumber))
            {
                lastNumber *= -1;
                this.lblResult.Content = this.lastNumber.ToString();
            }
        }

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            this.lblResult.Content = "0";
            this.result = 0;
            this.lastNumber = 0;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (this.lblResult.Content.ToString() == "0")
            {
                this.lblResult.Content = selectedValue;
            }
            else
            {
                this.lblResult.Content = $"{this.lblResult.Content}{selectedValue}";
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(this.lblResult.Content.ToString(), out this.lastNumber))
            {
                this.lblResult.Content = "0";
            }

            if (sender == btnMultiply)
            {
                this.selectedOperator = SelectedOperator.Multiplication;
            }

            if (sender == btnDivide)
            {
                this.selectedOperator = SelectedOperator.Division;
            }

            if (sender == btnPlus)
            {
                this.selectedOperator = SelectedOperator.Addition;
            }

            if (sender == btnMinus)
            {
                this.selectedOperator = SelectedOperator.Subtraction;
            }
        }
    }
}

