using Shop.DataAccess;
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

namespace Shop.Pages
{
  /// <summary>
  /// Логика взаимодействия для Bases.xaml
  /// </summary>
  public partial class Bases : Page
  {
    private department_product _currentProduct = new department_product();

    public Bases()
    {
      InitializeComponent();
      DataContext = _currentProduct;
    }
    private void Sample1_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
    {

    }
    private void BtnAdd_Click(object sender, RoutedEventArgs e)
    {
      if (_currentProduct.Id == 0)
        ShopEntities.GetContext().department_product.Add(_currentProduct);
      try
      {
        ShopEntities.GetContext().SaveChanges();
        MessageBox.Show("Продукт куплен!");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message.ToString());
      }
    }
    private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      if (Visibility == Visibility.Visible)
      {
        ShopEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
        DGridBases.ItemsSource = ShopEntities.GetContext().base_product.ToList();
      }
    }
  }
}
