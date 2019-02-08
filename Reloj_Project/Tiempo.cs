using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Reloj_Project
{
    class Tiempo : FrameworkElement
    {
        static double Xhora;
        static double XMinut;
        static double XSegons;
        public static Boolean EsPrecis;
        String XCompleta { get { return date.ToString("HH:mm:ss.fff"); } }
        public static bool EsPrecis1 { get => EsPrecis; set => EsPrecis = value; }

        DateTime date;
        DispatcherTimer timer;
        static DependencyProperty XAML_Valor = DependencyProperty.Register("ValorX", typeof(String), typeof(Tiempo));
        static DependencyProperty XAML_VHora = DependencyProperty.Register("ValorHora", typeof(double), typeof(Tiempo));
        static DependencyProperty XAML_VMinutos = DependencyProperty.Register("ValorMin", typeof(double), typeof(Tiempo));
        static DependencyProperty XAML_VSegundos = DependencyProperty.Register("ValorSeg", typeof(double), typeof(Tiempo));

        public Tiempo()
        {
            
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Incrementar;
            timer.Start();
        }

        private void Incrementar(object sender, EventArgs e)
        {
            date = DateTime.Now;
            //Conversor
            if (EsPrecis) {

                XSegons = (date.Second * 1000 + date.Millisecond) * 360 / 60000;
                XMinut = (date.Second * 360 / 3600) + (date.Minute * 360 / 60);
                Xhora = (date.Minute * 360 / 720) + ((date.Hour % 12) * 360 / 12);

                SetValue(XAML_Valor, date.ToString("HH:mm:ss.fff"));
            }
            else {

                Xhora = (date.Hour % 12) * 360 / 12;
                XMinut = date.Minute * 360 / 60;
                XSegons = date.Second * 360 / 60;

                SetValue(XAML_Valor, date.ToString("HH:mm:ss"));
            }

            //Grados
            SetValue(XAML_VHora, Xhora);
            SetValue(XAML_VMinutos, XMinut);
            SetValue(XAML_VSegundos, XSegons);



        }

    }
}
