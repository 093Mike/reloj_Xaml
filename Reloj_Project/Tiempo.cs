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
        static double XMicroSegons;
        public static Boolean EsPrecis;
        String XCompleta { get { return date.ToLongTimeString() + "." + XMicroSegons.ToString(); } }
        public static bool EsPrecis1 { get => EsPrecis; set => EsPrecis = value; }

        DateTime date;
        DispatcherTimer timer;
        static DependencyProperty XAML_Valor = DependencyProperty.Register("ValorX", typeof(String), typeof(Tiempo));
        static DependencyProperty XAML_VHora = DependencyProperty.Register("ValorHora", typeof(String), typeof(Tiempo));
        static DependencyProperty XAML_VMinutos = DependencyProperty.Register("ValorMin", typeof(String), typeof(Tiempo));
        static DependencyProperty XAML_VSegundos = DependencyProperty.Register("ValorSeg", typeof(String), typeof(Tiempo));

        public Tiempo()
        {
            
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Incrementar;
            timer.Start();
        }

        private void Incrementar(object sender, EventArgs e)
        {
            //Horas
            Xhora = date.Hour % 12;
            float hora = (float) Xhora * 360 / 12 ;

            XMinut = date.Minute;
            float minutos = (float)XMinut * 360 / 60 ;

            XSegons = date.Second;
            XMicroSegons = date.Millisecond;
            float segundos = (float)XSegons * 360 / 60;
           

            String Xmicros = "";
            if (XMicroSegons < 10)
            {
                Xmicros += "00";
            }
            else if (XMicroSegons < 100) {
                Xmicros += "0";
            }
            Xmicros += XMicroSegons.ToString();

            date = DateTime.Now;
            //Texto
            if (EsPrecis) { SetValue(XAML_Valor, date.ToLongTimeString() + "." + Xmicros); }
            else { SetValue(XAML_Valor, date.ToLongTimeString()); }

            //Grados
            SetValue(XAML_VHora, hora.ToString());
            SetValue(XAML_VMinutos, minutos.ToString());
            SetValue(XAML_VSegundos, segundos.ToString());



        }

    }
}
