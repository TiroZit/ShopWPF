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
    public Departments()
    {
      InitializeComponent();
      DGridDepartment.ItemsSource = ShopEntities.GetContext().departments.ToList();
    }
    private void Sample1_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
    {

    }
  }
}
