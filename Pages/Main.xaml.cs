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
  /// Логика взаимодействия для Main.xaml
  /// </summary>
  public partial class Main : Page
  {
    private department _currentDepartment = new department();
    public Main()
    {
      InitializeComponent();
      DGridShop.ItemsSource = ShopEntities.GetContext().shops.ToList();
      DataContext = _currentDepartment;
    }
    private void Sample1_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
    {

    }
    private void BtnAdd_Click(object sender, RoutedEventArgs e)
    {
      if (_currentDepartment.Id == 0)
        ShopEntities.GetContext().departments.Add(_currentDepartment);
      try
      {
        ShopEntities.GetContext().SaveChanges();
        MessageBox.Show("Отдел добавлен!");
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
        DGridDepartment.ItemsSource = ShopEntities.GetContext().departments.ToList();
      }
    }
  }
}
