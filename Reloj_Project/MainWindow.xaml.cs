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

namespace Reloj_Project
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tiempo r;
        public MainWindow()
        {
            InitializeComponent();
            r = (Tiempo)Resources["conta"];
        }

        private void Reloj_mostrar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (r.EsPrecis) { r.EsPrecis = false; }
            else { r.EsPrecis = true; }
            
        }
    }
}
