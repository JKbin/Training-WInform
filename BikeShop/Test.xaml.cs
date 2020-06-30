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

namespace BikeShop
{
    /// <summary>
    /// Test.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Test : Page
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Init();

            Child c = new Child();
            c.Car = "";
            c.Money = 0;
            c.AddMethod();

            BaseClass b = new BaseClass();
            b.Car = "";
            b.Money = 0;
            
        }

        private void Init()
        {
            List<Car> cars = new List<Car>();

            for (int i = 0; i < 10; i++)
            {
                //Car car = new Car();
                //car.Speed = i * 10;       밑의 코드랑 같음
                //cars.Add(car);

                cars.Add(new Car()
                {
                    Speed = i * 10,
                    Color = Color.FromRgb((byte)(255/(i+1)), (byte)(255 / (i + 1)), 0)
                });
            }
            this.DataContext = cars;

        }
    }
}
