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

namespace StoreWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> products { get; set; } = new List<Product>
        {
            new Product
            {
                Name="Coca-Cola",
                Price=1,
                ImagePath="Images/cocacola.png"
            },
            new Product
            {
                Name="Pepsi",
                Price=1,
                ImagePath="Images/pepsi.png"
            },
            new Product
            {
                Name="Fanta",
                Price=1,
                ImagePath="Images/fanta.png"
            },
            new Product
            {
                Name="Sprite",
                Price=1,
                ImagePath="Images/sprite.jpg"
            },
            new Product
            {
                Name="FuseTea",
                Price=1.5,
                ImagePath="Images/fusetea.png"
            },
            new Product
            {
                Name="Red Bull",
                Price=3,
                ImagePath="Images/redbull.png"
            }
        };
        public MainWindow()
        {
            InitializeComponent();
            productsListbox.ItemsSource = products;
        }
    }
}
