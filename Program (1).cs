using System;

class CarWash
{

    static string nombreOperador = "";
    static string nombreCliente = "";
    static string placa = "";
    static int tipoVehiculo = 0;
    static int tamañoRin = 0;
    static int totalVehiculos = 0;
    static int totalServiciosExtra = 0;
    static bool ticketActivo = false;
    static bool servicioRinesActivo = false;
    static double tarifaBase = 0.0;
    static double costoExtra = 0.0;
    static double totalIngresos = 0.0;


    static void CrearTicket()
    {
        if (ticketActivo)
        {
            Console.WriteLine("Ya hay un ticket creado previamente. Registre la salida primero.");
        }
        else
        {
            Console.Write("Ingrese los dígitos de la placa: ");
            placa = Console.ReadLine();

            while (placa.Length != 6 || placa.Contains(" "))
            {
                Console.WriteLine("Ingrese una placa válida (6 caracteres, sin espacios).");
                Console.Write("Placa: ");
                placa = Console.ReadLine();
            }

            Console.WriteLine("Ingrese el tipo de vehículo:");
            Console.WriteLine("1 = Sedan  (Q50)");
            Console.WriteLine("2 = Pickup o SUV  (Q75)");
            Console.Write("Seleccione: ");
            tipoVehiculo = int.Parse(Console.ReadLine());

            if (tipoVehiculo == 1)
            {
                tarifaBase = 50.0;
            }
            else
            {
                tarifaBase = 75.0;
            }

            Console.Write("Ingresar nombre del cliente: ");
            nombreCliente = Console.ReadLine();

            servicioRinesActivo = false;
            tamañoRin = 0;
            costoExtra = 0.0;
            ticketActivo = true;

            Console.WriteLine("Ticket creado: " + placa + "  " + nombreCliente + "  Q" + tarifaBase);
        }
    }
    static void AgregarRines()
    {
        if (ticketActivo == false)
        {
            Console.WriteLine("No hay ticket activo. Cree un ticket primero.");
        }
        else
        {
            if (servicioRinesActivo)
            {
                Console.WriteLine("Ya tiene servicio extra activo (Rines " + tamañoRin + "\", Q" + costoExtra + ").");
                Console.Write("¿Desea cancelar el servicio extra? (S/N): ");
                string confirmarCancelacion = Console.ReadLine();

                if (confirmarCancelacion == "S" || confirmarCancelacion == "s")
                {
                    servicioRinesActivo = false;
                    tamañoRin = 0;
                    costoExtra = 0.0;
                    Console.WriteLine("Servicio extra cancelado.");
                }
                else
                {
                    Console.WriteLine("Servicio extra se mantiene.");
                }
            }
            else
            {
                Console.Write("Ingresar tamaño de los rines (12 a 22): ");
                tamañoRin = int.Parse(Console.ReadLine());

                while (tamañoRin < 12 || tamañoRin > 22)
                {
                    Console.WriteLine("Ingrese un tamaño de rines correcto (12 a 22).");
                    Console.Write("Tamaño de rines: ");
                    tamañoRin = int.Parse(Console.ReadLine());
                }

                if (tamañoRin >= 12 && tamañoRin <= 16)
                {
                    costoExtra = 30.0;
                }
                else if (tamañoRin >= 17 && tamañoRin <= 19)
                {
                    costoExtra = 40.0;
                }
                else
                {
                    costoExtra = 60.0;
                }

                servicioRinesActivo = true;
                Console.WriteLine("Servicio extra agregado: Rines " + tamañoRin + " = Q" + costoExtra);
                Console.WriteLine("Total a cobrar: Q" + (tarifaBase + costoExtra));
            }
        }
    }

    static void ConsultarMonto()
    {
        if (ticketActivo == false)
        {
            Console.WriteLine("No hay ticket activo.");
        }
        else
        {
            Console.WriteLine("\n   TICKET ACTIVO   ");
            Console.WriteLine("Placa   : " + placa);
            Console.WriteLine("Cliente : " + nombreCliente);
            Console.WriteLine("Lavado  : Q" + tarifaBase);

            if (servicioRinesActivo)
            {
                Console.WriteLine("Rines " + tamañoRin + ": Q" + costoExtra);
            }
            else
            {
                Console.WriteLine("Sin servicio extra");
            }

            Console.WriteLine("TOTAL   : Q" + (tarifaBase + costoExtra));
        }
    }

    static void RegistrarSalida()
    {
        if (ticketActivo == false)
        {
            Console.WriteLine("No hay ticket activo.");
        }
        else
        {
            double montoTotal = tarifaBase + costoExtra;

            Console.WriteLine("\n   COBRO FINAL   ");
            Console.WriteLine("Placa   : " + placa);
            Console.WriteLine("Cliente : " + nombreCliente);
            Console.WriteLine("Lavado  : Q" + tarifaBase);

            if (servicioRinesActivo)
            {
                Console.WriteLine("Rines " + tamañoRin + "  : Q" + costoExtra);
            }
            else
            {
                Console.WriteLine("Sin servicio extra");
            }

            Console.WriteLine("TOTAL   : Q" + montoTotal);


            totalVehiculos++;
            if (servicioRinesActivo)
            {
                totalServiciosExtra++;
            }
            totalIngresos = totalIngresos + montoTotal;


            Random random = new Random();
            Console.Write("\nElige un número del 1 al 3 para ganar una rifa: ");
            int NumeroC = int.Parse(Console.ReadLine());
            int numeroRandom = random.Next(1, 4);

            Console.WriteLine("Número Car Wash: " + numeroRandom);

            if (NumeroC == numeroRandom)
            {
                Console.WriteLine("¡Felicidades, ganó un viaje en yate todo pagado!");
            }
            else
            {
                Console.WriteLine("Lástima, suerte a la próxima.");
            }

            ticketActivo = false;
            placa = "";
            tipoVehiculo = 0;
            nombreCliente = "";
            tarifaBase = 0.0;
            servicioRinesActivo = false;
            tamañoRin = 0;
            costoExtra = 0.0;

            Console.WriteLine("Salida registrada. Sistema listo para el siguiente vehículo.");
        }
    }

    static void MostrarReporte()
    {
        Console.WriteLine("\n        REPORTE FINAL DE SESIÓN        ");
        Console.WriteLine("Operador                         : " + nombreOperador);
        Console.WriteLine("Total de carros atendidos        : " + totalVehiculos);
        Console.WriteLine("Total con servicio extra         : " + totalServiciosExtra);
        Console.WriteLine("Total de ingresos recaudados     : Q" + totalIngresos);
        Console.WriteLine("Gracias por utilizar este servicio.");
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Sistema de Car Wash");

        Console.Write("Ingrese el nombre del operador: ");
        nombreOperador = Console.ReadLine();

        Console.WriteLine("Bienvenido, " + nombreOperador + "!");

        int opcionMenu = 0;

        while (opcionMenu != 5)
        {
            Console.WriteLine("\n Menú \n 1. Crear ticket de entrada \n 2. Lavado de llantas y rines\n 3. Consultar monto a cobrar \n 4. Registrar salida y calcular cobro \n 5. Salir del programa");
            Console.Write("Ingrese su opción: ");

            opcionMenu = int.Parse(Console.ReadLine());

            switch (opcionMenu)
            {
                case 1:
                    CrearTicket();
                    break;

                case 2:
                    AgregarRines();
                    break;

                case 3:
                    ConsultarMonto();
                    break;

                case 4:
                    RegistrarSalida();
                    break;

                case 5:
                    MostrarReporte();
                    break;

                default:
                    Console.WriteLine("Opción no válida. Ingrese un número del 1 al 5.");
                    break;
            }
        }

    }
}

