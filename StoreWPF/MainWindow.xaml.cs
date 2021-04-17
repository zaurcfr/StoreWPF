using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
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
                ImagePath="Images/sprite.png"
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
            },
            new Product
            {
                Name="Coca Cola Zero",
                Price=1,
                ImagePath="Images/cocacolazero.png"
            },
            new Product
            {
                Name="7 Up",
                Price=0.80,
                ImagePath="Images/7up.png"
            },
            new Product
            {
                Name="Mirinda",
                Price=0.80,
                ImagePath="Images/mirinda.png"
            },
            new Product
            {
                Name="Heineken",
                Price=2,
                ImagePath="Images/heineken.png"
            }
        };
        public MainWindow()
        {
            InitializeComponent();
            productsListbox.ItemsSource = products;
            this.DataContext = this;
        }

        void ChangeVisibility(string vis)
        {
            if (vis == "Visible")
            {
                SelectPhotoBtn.Visibility = Visibility.Visible;
                SelectImg.Visibility = Visibility.Visible;
                EditImage.Visibility = Visibility.Visible;
                EditNameTxtb.Visibility = Visibility.Visible;
                EditPriceTxtb.Visibility = Visibility.Visible;
                SaveBtn.Visibility = Visibility.Visible;
                Border0.Visibility = Visibility.Visible;
                Border1.Visibility = Visibility.Visible;
                Border2.Visibility = Visibility.Visible;
                Border3.Visibility = Visibility.Visible;
            }
            else if (vis == "Hidden")
            {
                SelectPhotoBtn.Visibility = Visibility.Hidden;
                SelectImg.Visibility = Visibility.Hidden;
                EditImage.Visibility = Visibility.Hidden;
                EditNameTxtb.Visibility = Visibility.Hidden;
                EditPriceTxtb.Visibility = Visibility.Hidden;
                SaveBtn.Visibility = Visibility.Hidden;
                Border0.Visibility = Visibility.Hidden;
                Border1.Visibility = Visibility.Hidden;
                Border2.Visibility = Visibility.Hidden;
                Border3.Visibility = Visibility.Hidden;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var product = productsListbox.SelectedItem as Product;
            ChangeVisibility("Visible");
            try
            {
                EditImage.Source = new BitmapImage(new Uri(product.ImagePath, UriKind.Relative));
                EditNameTxtb.Text = product.Name;
                EditPriceTxtb.Text = product.Price.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        string newImagePath;

        private void SelectPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader reader = File.OpenText(openFileDialog.FileName))
                {
                    newImagePath = openFileDialog.FileName;
                    ImageBrush imageBrush = new ImageBrush();
                    Uri imageUri = new Uri(newImagePath, UriKind.Relative);
                    BitmapImage imageBitmap = new BitmapImage(imageUri);
                    imageBrush.ImageSource = imageBitmap;
                    EditImage.Source = imageBrush.ImageSource;
                }
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = productsListbox.SelectedItem as Product;
                foreach (var item in products)
                {
                    if (item.ID == product.ID)
                    {
                        item.Name = EditNameTxtb.Text;
                        item.Price = Double.Parse(EditPriceTxtb.Text);
                        item.ImagePath = newImagePath;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ChangeVisibility("Hidden");
        }
    }
}
