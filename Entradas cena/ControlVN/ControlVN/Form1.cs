using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; 

namespace ControlVN
{
    public partial class Form1 : Form
    {
        int[] Checha_Evy = new int[12];
        int[] Coco_Miriam = new int[12];
        int[] Hector_Lorena = new int[12];
        int[] Hugo_Karina = new int[12];
        int[] Mario_Monica = new int[12];
        int[] Silvio = new int[12];
        int[] Tonny_Sheny = new int[12];
        int[] niños = new int[20];
        int[] main = new int[100];
        int[] sinV_Checha_Evy = new int[12];
        int[] sinV_Coco_Miriam = new int[12];
        int[] sinV_Hector_Lorena = new int[12];
        int[] sinV_Hugo_Karina = new int[12];
        int[] sinV_Mario_Monica = new int[12];
        int[] sinV_Silvio = new int[12];
        int[] sinV_Tonny_Sheny = new int[12];
        int[] sinV_niños = new int[20];
        int[] sinV_main = new int[100];

        int contChecha, contCoco, contHector, contHugo, contMario, contSilvio, contTonny, contNiños; //cantidad entradas vendidas 
        int vendidoChecha, vendidoCoco, vendidoHector, vendidoHugo, vendidoMario, vendidoSilvio, vendidoTonny, vendidoNiños; //dinero esperado etradas vendidas
        int devolverChecha, devolverCoco, devolverHector, devolverHugo, devolverMario, devolverSilvio, devolverTonny, devolverNiños; //cantidad entradas no vendidas
        int devueltoChecha, devueltoCoco, devueltoHector, devueltoHugo, devueltoMario, devueltoSilvio, devueltoTonny, devueltoNiños; // dinero esperado entradas no vendidas
        string ventaChecha, ventaCoco, ventaHector, ventaHugo, ventaMario, ventaSilvio, ventaTonny, ventaNiños;// numeros de la entradas vendidas
        string sinVentaChecha, sinVentaCoco, sinVentaHector, sinVentaHugo, sinVentaMario, sinVentaSilvio, sinVentaTonny, sinVentaNiños; // numero de las entradas no vendidas
        int entradaActual, ciclo, vuelta, contCiclo, contCicloSinV;
        int totalRecibido, totalNoVendido, totalEntradasVendidas, totalEntradasNoVendidas; 
        bool containing = false;

        private void button2_Click(object sender, EventArgs e) //txt resumen
        {
            StreamWriter text = new StreamWriter("texto.txt");            
            llenarRestantes();
            sumarVentas();

            text.WriteLine("[Silvio]"); 
            text.WriteLine("Entradas vendidas(" + contSilvio + "): ");
            text.WriteLine(ventaSilvio);
            text.WriteLine("Cantidad esperada: Q" + vendidoSilvio); 
            text.WriteLine("Entradas sin vender(" + devolverSilvio + "): ");
            text.WriteLine(sinVentaSilvio);
            text.WriteLine("Cantidad esperada: Q" + devueltoSilvio);  
            text.WriteLine("--------------------------------------------------------------------------------");

            text.WriteLine("[Hugo y Karina]");
            text.WriteLine("Entradas vendidas(" + contHugo + "): ");
            text.WriteLine(ventaHugo);
            text.WriteLine("Cantidad esperada: Q" + vendidoHugo);
            text.WriteLine("Entradas sin vender(" + devolverHugo + "): ");
            text.WriteLine(sinVentaHugo);
            text.WriteLine("Cantidad esperada: Q" + devueltoHugo);
            text.WriteLine("--------------------------------------------------------------------------------");

            text.WriteLine("[Coco y Miriam]");
            text.WriteLine("Entradas vendidas(" + contCoco + "): ");
            text.WriteLine(ventaCoco);
            text.WriteLine("Cantidad esperada: Q" + vendidoCoco);
            text.WriteLine("Entradas sin vender(" + devolverCoco + "): ");
            text.WriteLine(sinVentaCoco);
            text.WriteLine("Cantidad esperada: Q" + devueltoCoco);
            text.WriteLine("--------------------------------------------------------------------------------");

            text.WriteLine("[Mario y Monica]");
            text.WriteLine("Entradas vendidas(" + contMario + "): ");
            text.WriteLine(ventaMario);
            text.WriteLine("Cantidad esperada: Q" + vendidoMario);
            text.WriteLine("Entradas sin vender(" + devolverMario + "): ");
            text.WriteLine(sinVentaMario);
            text.WriteLine("Cantidad esperada: Q" + devueltoMario);
            text.WriteLine("--------------------------------------------------------------------------------");

            text.WriteLine("[Checha y Evy]");
            text.WriteLine("Entradas vendidas(" + contChecha + "): ");
            text.WriteLine(ventaChecha);
            text.WriteLine("Cantidad esperada: Q" + vendidoChecha);
            text.WriteLine("Entradas sin vender(" + devolverChecha + "): ");
            text.WriteLine(sinVentaChecha);
            text.WriteLine("Cantidad esperada: Q" + devueltoChecha);
            text.WriteLine("--------------------------------------------------------------------------------");

            text.WriteLine("[Tonny y Sheny]");
            text.WriteLine("Entradas vendidas(" + contTonny + "): ");
            text.WriteLine(ventaTonny);
            text.WriteLine("Cantidad esperada: Q" + vendidoTonny);
            text.WriteLine("Entradas sin vender(" + devolverTonny + "): ");
            text.WriteLine(sinVentaTonny);
            text.WriteLine("Cantidad esperada: Q" + devueltoTonny);
            text.WriteLine("--------------------------------------------------------------------------------");

            text.WriteLine("[Hector y Lorena]");
            text.WriteLine("Entradas vendidas(" + contHector + "): ");
            text.WriteLine(ventaHector);
            text.WriteLine("Cantidad esperada: Q" + vendidoHector);
            text.WriteLine("Entradas sin vender(" + devolverHector + "): ");
            text.WriteLine(sinVentaHector);
            text.WriteLine("Cantidad esperada: Q" + devueltoHector);
            text.WriteLine("--------------------------------------------------------------------------------");

            text.WriteLine("[Niños]");
            text.WriteLine("Entradas vendidas(" + contNiños + "): ");
            text.WriteLine(ventaNiños);
            text.WriteLine("Cantidad esperada: Q" + vendidoNiños);
            text.WriteLine("Entradas sin vender(" + devolverNiños + "): ");
            text.WriteLine(sinVentaNiños);
            text.WriteLine("Cantidad esperada: Q" + devueltoNiños);
            text.WriteLine("--------------------------------------------------------------------------------");
            text.WriteLine("[Resumen total]");
            text.WriteLine("Entradas vendidas: " + totalEntradasVendidas);
            text.WriteLine("Cantidad esperada: Q" + totalRecibido);
            text.WriteLine("Entradas No vendidas: " + totalEntradasNoVendidas);
            text.WriteLine("Cantidad esperada: Q" + totalNoVendido); 

            text.Close(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter text = new StreamWriter("observaciones.txt");
            text.WriteLine(textBox2.Text); 
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            try
            {
                ciclo = textBox1.Lines.Count();

                for (int i = 0; i < ciclo; i++)
                {
                    entradaActual = Convert.ToInt32(textBox1.Lines[i]);
                    vuelta = i;  
                    if (contains(entradaActual))
                    {
                        MessageBox.Show("La entrada " + entradaActual + " ya estaba ingresada");                      
                    }
                    else
                    {
                        distribuir(entradaActual);
                        main[contCiclo] = entradaActual;
                        contCiclo++;                       
                    }

                }
                textBox1.Clear();

            }
            catch
            {
                MessageBox.Show("Error en ingreso de datos (linea " + (vuelta + 2) + ")\n Los datos posteriores no fueron ingresados" ); 
            }
          
        }

        void distribuir(int num)
        {
            if (num >= 5 && num <= 16) // Silvio
            {
                Silvio[contSilvio] = num;
                contSilvio++;
                ventaSilvio += num + ",";               
            }
            else
                 if (num >= 17 && num <= 28) // Hugo y Karina
            {
                Hugo_Karina[contHugo] = num;
                contHugo++;
                ventaHugo += num + ",";              
            }
            else
             if (num >= 29 && num <= 40) // Coco y Miriam
            {
                Coco_Miriam[contCoco] = num;
                contCoco++;
                ventaCoco += num + ",";                
            }
            else
                 if (num >= 41 && num <= 52) // Mario y Monica 
            {
                Mario_Monica[contMario] = num;
                contMario++;
                ventaMario += num + ",";
            }
            else
                 if (num >= 53 && num <= 64) //Checha y Evy
            {
                Checha_Evy[contChecha] = num;
                contChecha++;
                ventaChecha += num + ",";
            }
            else
                 if (num >= 65 && num <= 76) // Tonny y Sheny
            {
                Tonny_Sheny[contTonny] = num;
                contTonny++;
                ventaTonny += num + ",";
            }
            else
                 if (num >= 77 && num <= 84) // Hector y Lorena
            {
                Hector_Lorena[contHector] = num;
                contHector++;
                ventaHector += num + ",";
            }
            else
                 if ((num >= 1 && num <= 5) || (num>= 75 && num <= 100)) //niños
            {
                niños[contNiños] = num;
                contNiños++;
                ventaNiños += num + ",";
            }
        }

        void distribuir_sinV(int num)
        {
            if (num >= 5 && num <= 16) // Silvio
            {
                sinV_Silvio[devolverSilvio] = num;
                devolverSilvio++;
                sinVentaSilvio += num + ",";
            }
            else
                 if (num >= 17 && num <= 28) // Hugo y Karina
            {
                sinV_Hugo_Karina[devolverHugo] = num;
                devolverHugo++;
                sinVentaHugo += num + ",";
            }
            else
             if (num >= 29 && num <= 40) // Coco y Miriam
            {
                sinV_Coco_Miriam[devolverCoco] = num;
                devolverCoco++;
                sinVentaCoco += num + ",";
            }
            else
                 if (num >= 41 && num <= 52) // Mario y Monica 
            {
                sinV_Mario_Monica[devolverMario] = num;
                devolverMario++;
                sinVentaMario += num + ",";
            }
            else
                 if (num >= 53 && num <= 64) //Checha y Evy
            {
                sinV_Checha_Evy[devolverChecha] = num;
                devolverChecha++;
                sinVentaChecha += num + ",";
            }
            else
                 if (num >= 65 && num <= 76) // Tonny y Sheny
            {
                sinV_Tonny_Sheny[devolverTonny] = num;
                devolverTonny++;
                sinVentaTonny += num + ",";
            }
            else
                 if (num >= 77 && num <= 84) // Hector y Lorena
            {
                sinV_Hector_Lorena[devolverHector] = num;
                devolverHector++;
                sinVentaHector += num + ",";
            }
            else
                 if ((num >= 1 && num <= 5) || (num >= 75 && num <= 100)) //niños
            {
                sinV_niños[devolverNiños] = num;
                devolverNiños++;
                sinVentaNiños += num + ",";
            }
        }

        bool contains(int num)
        {
            containing = false;
            int cont = 0;
           
            while (containing == false && cont <= 99)
            {
                if (num == main[cont])
                {
                    containing = true;
                }
                else
                {
                    containing = false;
                    cont++; 
                }
            }
            return containing; 
        }

        void sumarVentas()
        {
            int adulto = 60;
            int niño = 25;

            vendidoChecha = contChecha * adulto;
            vendidoCoco = contCoco * adulto;
            vendidoHector = contHector * adulto;
            vendidoHugo = contHugo * adulto;
            vendidoMario = contMario * adulto;
            vendidoSilvio = contSilvio * adulto;
            vendidoTonny = contTonny * adulto;
            vendidoNiños = contNiños * niño;
            totalRecibido = vendidoChecha + vendidoCoco + vendidoHector + vendidoHugo + vendidoMario + vendidoSilvio + vendidoTonny + vendidoNiños;
            totalEntradasVendidas = contChecha + contCoco + contHector + contHugo + contMario + contSilvio + contTonny + contNiños;

            devueltoChecha = devolverChecha * adulto;
            devueltoCoco = devolverCoco * adulto;
            devueltoHector = devolverHector * adulto;
            devueltoHugo = devolverHugo * adulto;
            devueltoMario = devolverMario * adulto;
            devueltoSilvio = devolverSilvio * adulto;
            devueltoTonny = devolverTonny * adulto;
            devueltoNiños = devolverNiños * adulto;
            totalNoVendido = devueltoChecha + devueltoCoco + devueltoHector + devueltoHugo + devueltoMario + devueltoSilvio + devueltoTonny + devueltoNiños;
            totalEntradasNoVendidas = devolverChecha + devolverCoco + devolverHector + devolverHugo + devolverMario + devolverSilvio + devolverTonny + devolverNiños;
        }

        void llenarRestantes()
        {
            bool containing;        

            for (int i = 0; i <= 100; i++)
            {
                containing = contains(i); 
                             
                if (containing == false)
                {
                    distribuir_sinV(i);
                    sinV_main[contCicloSinV] = i;
                    contCicloSinV++; 
                }               
            }

        }
    }
}
