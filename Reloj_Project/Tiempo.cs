using System;
using System.Windows;
using System.Windows.Threading;

namespace Reloj_Project
{
    class Tiempo : FrameworkElement
    {
        double hora;
        double minut;
        double segonds;
        public Boolean esPrecis;
        string XCompleta { get {
                if (EsPrecis) { return date.ToString("HH:mm:ss.fff"); }
                else { return date.ToString("HH:mm:ss"); }
        } }

        public double Hora { get { return date.Hour; } }
        public double Minut { get { return date.Minute; } }
        public double Segonds { get { return date.Second; } }
        public bool EsPrecis { get => esPrecis; set => esPrecis = value; }

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
            segonds = date.Second;
            minut = date.Minute;
            hora = date.Hour;

            SetValue(XAML_VSegundos, segonds);
            SetValue(XAML_VMinutos, minut);
            SetValue(XAML_VHora, hora);

            //Conversor
            //if (EsPrecis) {

            //    segonds = (date.Second * 1000 + date.Millisecond) * 360 / 60000;
            //    minut = (date.Second * 360 / 3600) + (date.Minute * 360 / 60);
            //    hora = (date.Minute * 360 / 720) + ((date.Hour % 12) * 360 / 12);
            if (EsPrecis){SetValue(XAML_Valor, date.ToString("HH:mm:ss.fff"));}
            if (!EsPrecis) { SetValue(XAML_Valor, date.ToString("HH:mm:ss")); }
            //}



        }

    }
}
