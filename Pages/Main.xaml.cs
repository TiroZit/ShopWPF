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
      StringBuilder errors = new StringBuilder();

      if (string.IsNullOrWhiteSpace(_currentDepartment.name))
        errors.AppendLine("Укажите название отдела");
      if (_currentDepartment.shop_Id != 3)
        errors.AppendLine("Такого магазина не существует");
      if (_currentDepartment.person_Id <= 1 || _currentDepartment.person_Id > 6)
        errors.AppendLine("Такого заведующего не существует");

      if(errors.Length > 0)
      {
        MessageBox.Show(errors.ToString());
        return;
      }

      if (_currentDepartment.Id == 0)
        ShopEntities.GetContext().departments.Add(_currentDepartment);
      try
      {
        ShopEntities.GetContext().SaveChanges();
        MessageBox.Show("Отдел добавлен!");
        DGridDepartment.ItemsSource = ShopEntities.GetContext().departments.ToList();
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

    private void BtnRemove_Click(object sender, RoutedEventArgs e)
    {
      var departmentsForRemoving = DGridDepartment.SelectedItems.Cast<department>().ToList();

      if(MessageBox.Show($"Вы точно хотите удалить следующие {departmentsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
      {
        try
        {
          ShopEntities.GetContext().departments.RemoveRange(departmentsForRemoving);
          ShopEntities.GetContext().SaveChanges();
          MessageBox.Show("Данные удалены!");
          DGridDepartment.ItemsSource = ShopEntities.GetContext().departments.ToList();
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message.ToString());
        }
      }
    }
  }
}
