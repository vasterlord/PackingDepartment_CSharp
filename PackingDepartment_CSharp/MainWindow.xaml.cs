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

namespace PackingDepartment_CSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PackingShop packingShop;
        int id;
        string[] describle = new string[] { "Prepack cost : ", "Total cost  : ", "Total error : " };

        public MainWindow()
        {
            packingShop = new PackingShop();
            id = 0;
            DigitalScales tempDigitalScale = new DigitalScales();
            packingShop.digitalScales.Add(tempDigitalScale);
            tempDigitalScale = new DigitalScales();
            tempDigitalScale.Number += 10.2;
            packingShop.digitalScales.Add(tempDigitalScale);
            tempDigitalScale = new DigitalScales();
            tempDigitalScale.Number += 20.3;
            packingShop.digitalScales.Add(tempDigitalScale);
            tempDigitalScale = new DigitalScales();
            tempDigitalScale.Number += 30.4;
            packingShop.digitalScales.Add(tempDigitalScale);
            tempDigitalScale = new DigitalScales();
            tempDigitalScale.Number += 40.7;
            packingShop.digitalScales.Add(tempDigitalScale);
            InitializeComponent();
            dataGrid.SelectedIndex = 0;
            dataGrid.ItemsSource = packingShop.digitalScales.Cast<DigitalScales>();
            GetCalculationResults();
        }

        private void GetCalculationResults()
        {
            labelPrepack.Content = describle[0] + packingShop.PrepackCost(Convert.ToDouble(textBoxCommonWeight.Text)).ToString();
            labelTotalCost.Content = describle[1] + packingShop.TotalProductsCost().ToString();
            labelTotalError.Content = describle[2] + packingShop.TotalError().ToString();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DigitalScales tempScale = (DigitalScales)dataGrid.SelectedItem;
                id = packingShop.digitalScales.IndexOf(tempScale);
                textBoxMinimum.Text = packingShop[id].MinNumber.ToString();
                textBoxMaximum.Text = packingShop[id].MaxNumber.ToString();
                textBoxWeight.Text = packingShop[id].Number.ToString();
                textBoxCostOne.Text = packingShop[id].OneCost.ToString();
                textBoxCommonCost.Text = packingShop[id].CommonCost.ToString();
                textBoxWeightError.Text = packingShop[id].WeightError.ToString();
            }
            catch (Exception) { }
        }

        private void buttonPrepack_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = packingShop.digitalScales.Where(scale=>scale.Number<=Convert.ToDouble(textBoxCommonWeight.Text)).OrderBy(scale=>scale.Number).Cast<DigitalScales>();
            dataGrid.Items.Refresh();
            dataGrid.SelectedIndex = 0;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            DigitalScales nextProduct = new DigitalScales();
            nextProduct.MinNumber = Convert.ToDouble(textBoxMinimum.Text);
            nextProduct.MaxNumber = Convert.ToDouble(textBoxMaximum.Text);
            nextProduct.Number = Convert.ToDouble(textBoxWeight.Text);
            nextProduct.OneCost = Convert.ToDouble(textBoxCostOne.Text);
            nextProduct.CommonCost = Convert.ToDouble(textBoxCommonCost.Text);
            nextProduct.WeightError = Convert.ToDouble(textBoxWeightError.Text);
            packingShop.digitalScales.Add(nextProduct);
            dataGrid.ItemsSource = packingShop.digitalScales.Cast<DigitalScales>();
            dataGrid.Items.Refresh();
            dataGrid.SelectedIndex = packingShop.digitalScales.Count-1;
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            packingShop.digitalScales.Remove(packingShop[id]);
            id = 0;
            dataGrid.ItemsSource = packingShop.digitalScales.Cast<DigitalScales>();
            dataGrid.Items.Refresh();
            dataGrid.SelectedIndex = 0;
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetCalculationResults();
        }

        private void buttonDelete_Click_1(object sender, RoutedEventArgs e)
        {
            packingShop.digitalScales.Remove(packingShop[id]);
            dataGrid.ItemsSource = packingShop.digitalScales.Cast<DigitalScales>();
            dataGrid.Items.Refresh();
            dataGrid.SelectedIndex = 0;
        }

        private void buttonShowAll_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = packingShop.digitalScales.Cast<DigitalScales>();
            dataGrid.Items.Refresh();
            dataGrid.SelectedIndex = 0;
        }

        private void buttonAdd_Update_Click(object sender, RoutedEventArgs e)
        {
            packingShop[id].MinNumber = Convert.ToDouble(textBoxMinimum.Text);
            packingShop[id].MaxNumber = Convert.ToDouble(textBoxMaximum.Text);
            packingShop[id].Number = Convert.ToDouble(textBoxWeight.Text);
            packingShop[id].OneCost = Convert.ToDouble(textBoxCostOne.Text);
            packingShop[id].CommonCost = Convert.ToDouble(textBoxCommonCost.Text);
            packingShop[id].WeightError = Convert.ToDouble(textBoxWeightError.Text);
            dataGrid.ItemsSource = packingShop.digitalScales.Cast<DigitalScales>();
            dataGrid.Items.Refresh();
            dataGrid.SelectedIndex = id;
        }
    }
}
