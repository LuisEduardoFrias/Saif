using FontAwesome.Sharp;
using Saif.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Saif
{
    public partial class Home : Form
    {
        private GraphicsPath path,path3;
        private Point Locacion;
        private bool Ready;

        public Home()
        {
            InitializeComponent();

            path = new GraphicsPath();
            path3 = new GraphicsPath();
            Locacion = new Point(0,0);
            Ready = false;
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Tintar();

            FranjaLateara.BackColor = Color.Turquoise;

            path3.AddArc(0, 0, 550, 550, 0, 360);
            PAcercaDe.Region = new Region(path3);

            Ready = true;

            this.PAcercaDe.Hide();

            MenuLateral.Size = new Size(18, MenuLateral.Size.Height);
            MenuLateral.AutoScroll = false;
        }

        private void Tintar()
        {
            FranjaLateara.BackColor = Color.Turquoise;

            path = new GraphicsPath();

            Point[] points = {
                    new Point(18, 0),
                    new Point(27, 411),
                    new Point(18, 821)};

            path.AddCurve(points, 0.2F);

            FranjaLateara.Region = new Region(path);
        }

        private void FranjaLateara_MouseEnter(object sender, EventArgs e)
        {
            FranjaLateara.BackColor = Color.DimGray;

            path.Dispose();

            MenuLateral.Size = new Size(200, MenuLateral.Size.Height);

            if(this.WindowState != FormWindowState.Maximized)
            {
                MenuLateral.AutoScroll = true;
            }

        }

        private void Contenedor_MouseEnter(object sender, EventArgs e)
        {
            Tintar();

            MenuLateral.Size = new Size(18,MenuLateral.Size.Height);
            MenuLateral.AutoScroll = false;
        }

        //Cierra el Formulario y abre el login.
        private void BCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("Si Continua con el proseso, se cerrara la aplicacion!.", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (resul == DialogResult.OK)
            {
                this.Dispose();
            }
        }

        //Mazimiza el formulario.
        private void BMaximizar_Click(object sender, EventArgs e)
        {
            BNormal.Visible = true;
            BNormal.Enabled = true;
            BMaximizar.Visible = false;
            BMaximizar.Enabled = false;
            this.WindowState = FormWindowState.Normal;
        }

        //Cambiar el formulario al estado normal.
        private void BNormal_Click(object sender, EventArgs e)
        {
            BNormal.Visible = false;
            BNormal.Enabled = false;
            BMaximizar.Visible = true;
            BMaximizar.Enabled = true;
            this.WindowState = FormWindowState.Maximized;
        }

        //Minimiza el formulario.
        private void BMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Cebecera_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

            if (this.WindowState == FormWindowState.Normal)
            {
                BNormal.Visible = true;
                BNormal.Enabled = true;
                BMaximizar.Visible = false;
                BMaximizar.Enabled = false;
            }

            if (this.Location.Y == 0)
            {
                BNormal.Visible = false;
                BNormal.Enabled = false;
                BMaximizar.Visible = true;
                BMaximizar.Enabled = true;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void b1_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightGray;
            ((Button)sender).FlatStyle = FlatStyle.Standard;
        }
        private void b1_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Turquoise;
            ((Button)sender).FlatStyle = FlatStyle.Flat;
        }

        private void BAcerca_Click(object sender, EventArgs e)
        {
            MenuLateral.Enabled = false;
            PG.Enabled = false;
            panel1.Enabled = false;

            PAcercaDe.Enabled = true;
            PAcercaDe.Show();
            PAcercaDe.BringToFront();
        }

        private void BTCerrar2_Click(object sender, EventArgs e)
        {
            MenuLateral.Enabled = true;
            PG.Enabled = true;
            panel1.Enabled = true;

            PAcercaDe.Hide();
        }
        private void PG_SizeChanged(object sender, EventArgs e)
        {
            if(Ready == true)
            {
                double P = PG.Size.Width, I = 210;

                string Valor0 = Convert.ToString(P / I);
                string Valor1;

                try
                {
                    Valor1 = Valor0.Substring(2, 2);
                }
                catch(Exception)
                {
                    Valor1 = Valor0.Substring(2, 1);
                }

                int Valor2 = Convert.ToInt32(Valor1);
                int CFila = (PG.Size.Width / 210);

                double value = Convert.ToDouble((Convert.ToDouble(Valor2) / Convert.ToDouble(CFila + 1)));

                int EspacioX = Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero));

                List<Equipos> listaEquipos = new List<Equipos>();
                listaEquipos.Add(new Equipos { Nombre = "Camara", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._1, Precio = 150.65});
                listaEquipos.Add(new Equipos { Nombre = "Video Gravadora", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._2, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "Camara Digital", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._3, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._4, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._5, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._6, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._7, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._8, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._9, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._10, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._11, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._12, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._13, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._14, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._15, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._16, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._17, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._18, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._19, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._20, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._21, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._22, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._23, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._24, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._24, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._24, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._24, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._24, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._24, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._24, Precio = 150.65 });
                listaEquipos.Add(new Equipos { Nombre = "", Titulo = "", Descripcion = "", Imagen = global::Saif.Properties.Resources._24, Precio = 150.65 });


                BinaryFormatter formatter = new BinaryFormatter();

                Stream stream = new FileStream("Equipos.OE", FileMode.Create, FileAccess.Write, FileShare.None);

                formatter.Serialize(stream, listaEquipos);

                stream.Close();

                PG.Controls.Clear();

                int EspacioX2 = EspacioX;
                int CFila2 = CFila;
                int EspacioY = 20;
                int i = 0;
                Locacion = new Point(EspacioX, EspacioY);

                foreach (Equipos equipos in listaEquipos)
                {
                    i++;

                    int V = (210 + EspacioX2);

                    PG.Controls.Add(PGV(equipos.Nombre, equipos.Titulo, equipos.Descripcion, equipos.Imagen, equipos.Precio, i, Locacion));

                    Locacion = new Point((EspacioX += V), EspacioY);

                    if (i == CFila)
                    {
                        EspacioX = EspacioX2;
                        EspacioY += 230;
                        Locacion = new Point(EspacioX, EspacioY);
                        CFila += CFila2;
                    }
                }
            }
        }

        private Control PGV(string nombre,string Tituto, string Descripcion, Bitmap imagen, double Precio,int Numerador,Point locacion)
        {
            PictureBox PB = new PictureBox();
            Label LB = new Label();
            Panel PN = new Panel();

            // 
            // pictureBox1
            // 
            PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            PB.BackgroundImage = imagen;
            PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            PB.Location = new System.Drawing.Point(20, 6);
            PB.Name = "PB" + nombre;
            PB.Size = new System.Drawing.Size(166, 159);
            PB.TabIndex = 1;
            PB.TabStop = false;
            PB.Enabled = false;
            // 
            // label2
            // 
            LB.AutoSize = true;
            LB.Location = new System.Drawing.Point(17, 171);
            LB.Name = "Lb" + nombre;
            LB.Size = new System.Drawing.Size(39, 16);
            LB.TabIndex = 2;
            LB.Text = Tituto;
            LB.Enabled = false;
            // 
            // panel4
            // 
            PN.BackColor = System.Drawing.Color.White;
            PN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            PN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PN.Controls.Add(LB);
            PN.Controls.Add(PB);
            PN.Cursor = System.Windows.Forms.Cursors.Hand;
            PN.Location = locacion;
            PN.Name = "PN" + nombre;
            PN.Size = new System.Drawing.Size(210, 210);
            PN.MouseEnter += new System.EventHandler(this.PN_MouseEnter);
            PN.MouseLeave += new System.EventHandler(this.PN_MouseLeave);
            PN.Click += new System.EventHandler(this.PN_Click);
            PN.TabIndex = 0;

            return PN;
        }

        private void BAlmacen_Click(object sender, EventArgs e)
        {
            BTitulo.Size = ((IconButton)sender).Size;
            BTitulo.Text = ((IconButton)sender).Text;
            BTitulo.IconChar = ((IconButton)sender).IconChar;
            BTitulo.TextAlign = ((IconButton)sender).TextAlign;
        }

        private void PN_Click(Object sender, EventArgs e)
        {
            ((Panel)sender).Dispose();
        }

        private void PN_MouseEnter(Object sender, EventArgs e)
        {
            ((Panel)sender).BorderStyle = BorderStyle.Fixed3D;
        }

        private void PN_MouseLeave(Object sender, EventArgs e)
        {
            ((Panel)sender).BorderStyle = BorderStyle.FixedSingle;
        }

        //-------------------------------------------------------------------------------------------------------------------

    }
}
