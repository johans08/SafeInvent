using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica.Api;

namespace SafeInvent
{
	public partial class Credenciales : Form
	{
		public Credenciales()
		{
			InitializeComponent();
			CustomizeButton();
		}

		private void AgarrarDatos(string token)
		{
			var json = "{" +
				"Usuraio: Test," +
				"Password: test}";
			APIClient testPost = new APIClient();
			try
			{
				string usuario;
				var datos = testPost.SendPostRequest("www.test.com", json, token);

			}
			catch
			{ 
			
			}
		}


		private void CustomizeButton()
		{
			// Configurar el color gradiente del botón
			Color buttonColor1 = ColorTranslator.FromHtml("#020024");
			Color buttonColor2 = ColorTranslator.FromHtml("#090979");
			Color buttonColor3 = ColorTranslator.FromHtml("#00d4ff");

			LinearGradientBrush buttonGradientBrush = new LinearGradientBrush(
				new Rectangle(0, 0, buttonIngresar.Width, buttonIngresar.Height),
				buttonColor1,
				buttonColor3,
				LinearGradientMode.Horizontal);

			ColorBlend colorBlend = new ColorBlend(3);
			colorBlend.Colors = new Color[] { buttonColor1, buttonColor2, buttonColor3 };
			colorBlend.Positions = new float[] { 0f, 0.5f, 1f };
			buttonGradientBrush.InterpolationColors = colorBlend;

			// Configurar las esquinas redondeadas del botón
			int buttonBorderRadius = 15;
			Rectangle buttonPathRect = new Rectangle(0, 0, buttonIngresar.Width - 1, buttonIngresar.Height - 1);
			GraphicsPath buttonRoundedRect = GetRoundedRect(buttonPathRect, buttonBorderRadius);

			// Configurar el botón
			buttonIngresar.FlatStyle = FlatStyle.Flat;
			buttonIngresar.FlatAppearance.BorderSize = 0;
			buttonIngresar.ForeColor = Color.White;
			buttonIngresar.Font = new Font("Arial", 10f);
			buttonIngresar.Region = new Region(buttonRoundedRect);

			// Establecer el fondo del botón como el gradiente
			buttonIngresar.BackgroundImage = new Bitmap(buttonIngresar.Width, buttonIngresar.Height);
			Graphics buttonGraphics = Graphics.FromImage(buttonIngresar.BackgroundImage);
			buttonGraphics.FillPath(buttonGradientBrush, buttonRoundedRect);

			// Limpieza
			buttonGradientBrush.Dispose();
			buttonGraphics.Dispose();
		}

		private GraphicsPath GetRoundedRect(Rectangle rect, int borderRadius)
		{
			GraphicsPath path = new GraphicsPath();
			path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
			path.AddArc(rect.X + rect.Width - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
			path.AddArc(rect.X + rect.Width - borderRadius, rect.Y + rect.Height - borderRadius, borderRadius, borderRadius, 0, 90);
			path.AddArc(rect.X, rect.Y + rect.Height - borderRadius, borderRadius, borderRadius, 90, 90);
			path.CloseFigure();
			return path;
		}

		private void Credenciales_Load(object sender, EventArgs e)
		{

		}
	}
}
