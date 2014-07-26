using System;
using System.Windows;

namespace MoveMouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ITimer s = new Stoper();
        ITimer m = new MoveMouse2();


        public MainWindow()
        {
            InitializeComponent();
            label2.DataContext = s;
            label4.DataContext = m;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            s.czasDo = String.IsNullOrEmpty(czasDo1.Text) ? (short)0 : short.Parse(czasDo1.Text);
            m.czasDo = s.czasDo;
            m.Start();
            s.Start();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            m.Stop();
            s.Stop();
        }
    }
}
