using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StoreWPF
{
    public class Product : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }

        private string imagepath;
        public string ImagePath
        {
            get { return imagepath; }
            set { imagepath = value; OnPropertyChanged(); }
        }

        public int ID { get; set; } = 0;
        public static int ProductID { get; set; } = 0;

        public Product()
        {
            ID = ProductID++;
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

    }
}
