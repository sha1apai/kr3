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

namespace kr3
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage(Users users)
        {
            InitializeComponent();
            ComboSort.SelectedIndex = 0;
            ComboType.SelectedIndex = 0;
            FIOTB.Text = users.FirstName + " " + users.SecondName + " " + users.Patronymic;
            if (users.RoleID == 1)
                RoleTB.Text = "Администратор";
            else if (users.RoleID == 2)
                RoleTB.Text = "Менеджер";
            else if (users.RoleID == 3)
                RoleTB.Text = "Клиент";
            else
                RoleTB.Text = "Гость";
                ComboType.Visibility = Visibility.Collapsed;
                ComboSort.Visibility= Visibility.Collapsed;
            TBSearch.Visibility = Visibility.Collapsed;
            Update();
        }
        public void Update()
        {
            var currentProducts = kr_chudo_obuvEntities.GetContext().Products.ToList();
            if (ComboType.SelectedIndex == 1)
                currentProducts = currentProducts.Where(p => p.CategoryID == 1).ToList();
            if (ComboType.SelectedIndex == 2)
                currentProducts = currentProducts.Where(p => p.CategoryID == 2).ToList();
            if (ComboType.SelectedIndex == 3)
                currentProducts = currentProducts.Where(p => p.CategoryID == 3).ToList();
            if (ComboSort.SelectedIndex == 1)
                currentProducts = currentProducts.OrderBy(p => p.Price).ToList();
            if (ComboSort.SelectedIndex == 2)
                currentProducts = currentProducts.OrderByDescending(p => p.Price).ToList();
            currentProducts = currentProducts.Where(p => p.ProductName.ToLower().Contains(TBSearch.Text.ToLower())
                || p.Manufactury.ToLower().Contains(TBSearch.Text.ToLower())
                || p.Composition.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
            ProductsListView.ItemsSource = currentProducts.ToList();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
