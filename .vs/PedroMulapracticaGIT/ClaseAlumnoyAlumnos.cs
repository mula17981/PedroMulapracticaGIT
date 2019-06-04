using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMBPractica6App
{

    public partial class Form1 : Form
    {
        private Button button1;
        private TextBox aluNombre;
        private TextBox aluNota;
        private TextBox listaAlumnos;
        private Label label1;
        private Label label2;
        private Label label3;
        Alumnos misAlumnos = new Alumnos();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumno miAlumno = new Alumno();
            String miAlumnoStr;

            miAlumno.Nombre = aluNombre.Text;
            miAlumno.Nota = Convert.ToInt32(aluNota.Text);
            miAlumnoStr = aluNombre.Text + " " + aluNota.Text + (miAlumno.Aprobado ? " Aprobado" : " Suspenso") + "\n";
            listaAlumnos.AppendText(miAlumnoStr);
            misAlumnos.Agregar(miAlumno);
        }


        private void InitializeComponent()
        {
            this.aluNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.aluNota = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listaAlumnos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aluNombre
            // 
            this.aluNombre.Location = new System.Drawing.Point(25, 29);
            this.aluNombre.Name = "aluNombre";
            this.aluNombre.Size = new System.Drawing.Size(332, 20);
            this.aluNombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Alumno";
            // 
            // aluNota
            // 
            this.aluNota.Location = new System.Drawing.Point(385, 29);
            this.aluNota.Name = "aluNota";
            this.aluNota.Size = new System.Drawing.Size(100, 20);
            this.aluNota.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(500, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Guardar Alumno";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listaAlumnos
            // 
            this.listaAlumnos.Location = new System.Drawing.Point(25, 67);
            this.listaAlumnos.Multiline = true;
            this.listaAlumnos.Name = "listaAlumnos";
            this.listaAlumnos.ReadOnly = true;
            this.listaAlumnos.Size = new System.Drawing.Size(569, 391);
            this.listaAlumnos.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nota";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Lista de Alumnos";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(658, 529);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listaAlumnos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.aluNota);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aluNombre);
            this.Name = "Form1";
            this.Text = "Alumnos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        class Alumno
        {
            private string nombre;
            private int nota;
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }
            public int Nota
            {
                get { return nota; }
                set
                {
                    if (value >= 0 && value <= 10)
                        nota = value;
                }
            }
            public Boolean Aprobado
            {
                get
                {
                    if (nota >= 5)
                        return true;
                    else
                        return false;
                }
            }
        }

        class Alumnos
        {
            private ArrayList listaAlumnos = new ArrayList();

            // Agrega un nuevo alumno a la lista
            //        
            public void Agregar(Alumno alu)
            {
                listaAlumnos.Add(alu);
            }

            // Devuelve el alumno que está en la posición num
            //
            public Alumno Obtener(int num)
            {
                if (num >= 0 && num <= listaAlumnos.Count)
                {
                    return ((Alumno)listaAlumnos[num]);
                }
                return null;
            }

            // Devuelve la nota media de los alumnos
            //
            public float Media
            {
                get
                {
                    if (listaAlumnos.Count == 0)
                        return 0;
                    else
                    {
                        float media = 0;
                        for (int i = 0; i < listaAlumnos.Count; i++)
                        {
                            media += ((Alumno)listaAlumnos[i]).Nota;
                        }
                        return (media / listaAlumnos.Count);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }


