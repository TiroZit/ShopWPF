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
  /// Логика взаимодействия для Departments.xaml
  /// </summary>
  public partial class Departments : Page
  {
    //private department _currentDepartment = new department();
    public Departments()
    {
      InitializeComponent();
      using (ShopEntities db = new ShopEntities())
      {
        // получаем объекты из бд и выводим на консоль
        var department_product = db.department_product.ToList();
        foreach (department_product d in department_product)
        {
          int currentPrice = d.price;
          int quantity = d.quantity;
          int sumPrice = currentPrice * quantity;
          //db.department_product.Add(sumPrice);
        }
      }
    }
    private void BtnSave_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        ShopEntities.GetContext().SaveChanges();
        MessageBox.Show("Данные обнавлены!");
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
        DGridDepartmentProduct.ItemsSource = ShopEntities.GetContext().department_product.ToList();
      }
    }
    private void Sample1_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
    {

    }
    //private void BtnAdd_Click(object sender, RoutedEventArgs e)
    //{
    //  if(_currentDepartment.Id == 0)
    //    ShopEntities.GetContext().departments.Add(_currentDepartment);
    //  try
    //  {
    //    ShopEntities.GetContext().SaveChanges();
    //    MessageBox.Show("Отдел добавлен");
    //  }
    //  catch(Exception ex)
    //  {
    //    MessageBox.Show(ex.Message.ToString());
    //  }
    //}

    //private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    //{
    //  if(Visibility == Visibility.Visible)
    //  {
    //    ShopEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
    //    DGridDepartmentProduct.ItemsSource = ShopEntities.GetContext().department_product.ToList();
    //  }
    //}
  }
}
