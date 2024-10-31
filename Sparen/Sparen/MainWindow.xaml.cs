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

namespace Sparen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            weeklyMoneyTextBox.Clear();
            weeklyRaiseTextBox.Clear();
            goalAmountTextBox.Clear();
            resultTextBox.Clear();
            weeklyMoneyTextBox.Focus();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int weeks;
            bool isValidCurrentAmount = double.TryParse(weeklyMoneyTextBox.Text, out double weeklyAmount);
            bool isValidWeeklyRaise = double.TryParse(weeklyRaiseTextBox.Text, out double weeklyRaise);
            bool isValidGoal = double.TryParse(goalAmountTextBox.Text, out double goalAmount);


            if (!isValidCurrentAmount || !isValidWeeklyRaise || !isValidGoal)
            {
                sb.AppendLine("Ongeldige input");
            } 
            else
            {
                double currentAmount = weeklyAmount;

                for (weeks = 0; currentAmount < goalAmount; weeks++)
                {
                    currentAmount += weeklyAmount;
                }


                sb.AppendLine($"Spaargeld na {weeks} weken: € {currentAmount:N2}");
                sb.AppendLine();
                sb.AppendLine($"Extra weekgeld op dat moment: € {weeks * weeklyRaise:N2}");
                sb.AppendLine();
                sb.AppendLine($"Totaal spaargeld: € {currentAmount + (weeks * weeklyRaise):N2}");
            }

            resultTextBox.Text = sb.ToString();
        }
    }
}
