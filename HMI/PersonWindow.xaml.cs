using LogicLayer;
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
using System.Windows.Shapes;

namespace HMI
{
    /// <summary>
    /// Logique d'interaction pour PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        public PersonWindow(IPerson person)
        {
            InitializeComponent();
            this.DataContext = person;
            if (person is PersonHMI pHmi)
            {
                Console.WriteLine("C'est un PersonHMI - IsMale: " + pHmi.IsMale + ", IsFemale: " + pHmi.IsFemale);
            }
            else
            {
                Console.WriteLine("Ce n'est PAS un PersonHMI - type: " + person.GetType());
            }
        }


        private void False(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


        private void True(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
