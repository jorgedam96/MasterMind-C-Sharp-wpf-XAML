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

namespace MasterMind
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SolidColorBrush[] colores = { Brushes.DodgerBlue, Brushes.SeaGreen, Brushes.Goldenrod, Brushes.MediumPurple, Brushes.DarkGray, Brushes.Firebrick, Brushes.Black };
        private int pos = 0;
        private Button[,] botones;
        private Button[] btnResultado;
        private Button[] resultados;



        public MainWindow()
        {
            InitializeComponent();
            generarColores();
            inicializarBotones();

        }

        private void inicializarBotones()
        {
            botones = new Button[10, 4] {
                { btnf1c1, btnf1c2, btnf1c3, btnf1c4 },
                { btnf2c1, btnf2c2, btnf2c3, btnf2c4 },
                { btnf3c1, btnf3c2, btnf3c3, btnf3c4 },
                { btnf4c1, btnf4c2, btnf4c3, btnf4c4 },
                { btnf5c1, btnf5c2, btnf5c3, btnf5c4 },
                { btnf6c1, btnf6c2, btnf6c3, btnf6c4 },
                { btnf7c1, btnf7c2, btnf7c3, btnf7c4 },
                { btnf8c1, btnf8c2, btnf8c3, btnf8c4 },
                { btnf9c1, btnf9c2, btnf9c3, btnf9c4 },
                { btnf10c1, btnf10c2, btnf10c3, btnf10c4 }};

            btnResultado = new Button[] {
                btnf1c5,
                btnf2c5,
                btnf3c5,
                btnf4c5,
                btnf5c5,
                btnf6c5,
                btnf7c5,
                btnf8c5,
                btnf9c5,
                btnf10c5, };
        }

        private void clicColorNegro(object sender, RoutedEventArgs e)
        {
            jugar(colores[6]);
        }

        private void clicColorVerde(object sender, RoutedEventArgs e)
        {
            jugar(colores[1]);

        }

        private void clicColorAmarillo(object sender, RoutedEventArgs e)
        {
            jugar(colores[2]);

        }

        private void clicColorMagenta(object sender, RoutedEventArgs e)
        {
            jugar(colores[3]);

        }

        private void clicColorGris(object sender, RoutedEventArgs e)
        {
            jugar(colores[4]);

        }

        private void clicColorRojo(object sender, RoutedEventArgs e)
        {
            jugar(colores[5]);

        }

        private void clicColorAzul(object sender, RoutedEventArgs e)
        {
            jugar(colores[0]);

        }

        private void NuevaPartida(object sender, RoutedEventArgs e)
        {

            generarColores();
            resetearTablero();

            for (int i = 0; i < btnResultado.Length; i++)
            {
                btnResultado[i].Content = "";
            }

            /*
            MessageBox.Show(res1.Background.ToString());
            MessageBox.Show(res2.Background.ToString());
            MessageBox.Show(res3.Background.ToString());
            MessageBox.Show(res4.Background.ToString());
            */


        }

        private void resetearTablero()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    botones[i, j].Background = Brushes.White;
                }
            }
        }

        private void jugar(SolidColorBrush color)
        {
            Boolean cambiado = false;
            Boolean final = false;
            Boolean ganado = false;
            int contador = 0;
            for (int i = 0; i < 10; i++)
            {
                if (!ganado)
                {


                    for (int j = 0; j < 4; j++)
                    {
                        if (botones[i, j].Background == Brushes.White && !cambiado)
                        {
                            botones[i, j].Background = color;
                            cambiado = true;
                        }
                        //comprobamos si es el final
                        if (botones[9, 3].Background != Brushes.White && !final)
                        {
                            MessageBox.Show("fin");
                            final = true;
                        }
                    }
                    //comprobamos la fila
                    for (int k = 0; k < 4; k++)
                    {
                        if (botones[i, k].Background == resultados[k].Background)
                        {
                            contador++;
                        }

                    }
                    btnResultado[i].Content = contador.ToString();

                    if (contador == 4)
                    {
                        res1.Visibility = Visibility.Visible;
                        res2.Visibility = Visibility.Visible;
                        res3.Visibility = Visibility.Visible;
                        res4.Visibility = Visibility.Visible;

                        MessageBox.Show("Has Acertado Todos!!!");
                        ganado = true;

                    }
                    else
                    {
                        //ponemos el resultado en el ultimo boton y contador a 0
                        contador = 0;
                    }
                }
            }

        }

        private void Rendirse(object sender, RoutedEventArgs e)
        {
            res1.Visibility = Visibility.Visible;
            res2.Visibility = Visibility.Visible;
            res3.Visibility = Visibility.Visible;
            res4.Visibility = Visibility.Visible;
        }

        private void generarColores()
        {
            Random rnd = new Random();
            int rnd1 = rnd.Next(colores.Count());
            res1.Background = colores[rnd1];
            int rnd2 = rnd.Next(colores.Count());
            res2.Background = colores[rnd2];
            int rnd3 = rnd.Next(colores.Count());
            res3.Background = colores[rnd3];
            int rnd4 = rnd.Next(colores.Count());
            res4.Background = colores[rnd4];

            res1.Visibility = Visibility.Hidden;
            res2.Visibility = Visibility.Hidden;
            res3.Visibility = Visibility.Hidden;
            res4.Visibility = Visibility.Hidden;


            resultados = new Button[] { res1, res2, res3, res4 };
        }
    }
}
