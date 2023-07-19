using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SafeInvent
{
    public partial class Index : Form
    {
        private Timer timerHora = new Timer();

        public Index()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Asociar el evento Tick del Timer a un método para actualizar la hora
            timerHora.Tick += TimerHora_Tick;
            // Establecer el intervalo del Timer a 1000 milisegundos (1 segundo)
            timerHora.Interval = 1000;
            // Iniciar el Timer
            timerHora.Start();

            // Agregar datos y aplicar estilo de gradiente al gráfico Column (chartTest)
            AgregarDatosAlGraficoColumn(chartTest);
            AplicarEstiloGradiente(chartTest.Series[0], Color.Orange, Color.Yellow);

            // Agregar datos y aplicar estilo de gradiente al gráfico Pie (chartPie)
            AgregarDatosAlGraficoPie(chartPie);
            AplicarEstiloGradiente(chartPie.Series[0], Color.Orange, Color.Yellow);
        }

        private void TimerHora_Tick(object sender, EventArgs e)
        {
            // Actualizar el Label con la hora actual
            labelHora.Text = DateTime.Now.ToString("HH:mm:ss");
            labelFecha.Text = DateTime.Today.ToString("dd MMMM yyyy");
        }

        private void pictureBoxAgrandar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBoxAgrandar.Visible = false;
            pictureBoxMin.Visible = true;
        }

        private void pictureBoxCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBoxAgrandar.Visible = true;
            pictureBoxMin.Visible = false;
        }

        private void pictureBoxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private int posY = 0;
        private int posX = 0;
        private void Titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void AgregarDatosAlGraficoColumn(Chart chart)
        {
            // Datos de ejemplo para el gráfico Column
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio" };
            int[] ventas = { 50, 30, 70, 45, 80, 60 };

            // Borrar los puntos de datos actuales del gráfico
            chart.Series.Clear();

            // Agregar una nueva serie al gráfico Column
            Series series = chart.Series.Add("Ventas");
            series.ChartType = SeriesChartType.Column;

            // Agregar los puntos de datos al gráfico Column
            for (int i = 0; i < meses.Length; i++)
            {
                series.Points.AddXY(meses[i], ventas[i]);
            }
        }

        private void AgregarDatosAlGraficoPie(Chart chart)
        {
            // Datos de ejemplo para el gráfico Pie
            string[] seriesNames = { "Manzanas", "Naranjas", "Plátanos", "Uvas" };
            int[] dataPoints = { 25, 30, 15, 20 };

            // Borrar los puntos de datos actuales del gráfico
            chart.Series.Clear();

            // Agregar una nueva serie al gráfico Pie
            Series series = chart.Series.Add("Frutas");
            series.ChartType = SeriesChartType.Doughnut;

            // Agregar los puntos de datos al gráfico Pie
            for (int i = 0; i < seriesNames.Length; i++)
            {
                series.Points.AddXY(seriesNames[i], dataPoints[i]);
            }
        }

        private void AplicarEstiloGradiente(Series series, Color color1, Color color2)
        {
            // Definir el estilo de gradiente para la serie del gráfico
            series.BackGradientStyle = GradientStyle.TopBottom;
            series.Color = color1;
            series.BackSecondaryColor = color2;
        }

    }
}
