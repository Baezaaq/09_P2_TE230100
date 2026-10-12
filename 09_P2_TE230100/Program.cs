// Programa principal: evaluación comparativa de dos bombas.
Console.WriteLine("Evaluación Comparativa de Dos Bombas");
Console.WriteLine();

Bomba bomba1 = new Bomba();
Bomba bomba2 = new Bomba();

// Arreglo que permite procesar los dos objetos.
Bomba[] bombas = { bomba1, bomba2 };

// Ciclo for: captura y procesa exactamente dos bombas.
for (int i = 0; i < bombas.Length; i++)
{
    Console.WriteLine($"Registro de bomba {i + 1} ");

    Console.Write("Ingrese el identificador: ");
    bombas[i].Identificador = Console.ReadLine() ?? "Sin ID";

    Console.Write("Ingrese el voltaje (V): ");
    bombas[i].Voltaje = Convert.ToDouble(Console.ReadLine());

    Console.Write("Ingrese la corriente (A): ");
    bombas[i].Corriente = Convert.ToDouble(Console.ReadLine());

    Console.Write("Ingrese el caudal (L/min): ");
    bombas[i].Caudal = Convert.ToDouble(Console.ReadLine());

    // Cálculo de potencia e indicador de desempeño.
    bombas[i].CalcularPotencia();
    bombas[i].CalcularIndicador();

    Console.WriteLine();
    bombas[i].MostrarDatos();
    Console.WriteLine();
}

// Comparación: solo se realiza si ambos indicadores son válidos.
Console.WriteLine("Comparación");

if (bomba1.IndicadorValido && bomba2.IndicadorValido)
{
    if (bomba1.Indicador > bomba2.Indicador)
    {
        Console.WriteLine(
            $"La bomba {bomba1.Identificador} presenta mayor caudal por watt.");
    }
    else if (bomba2.Indicador > bomba1.Indicador)
    {
        Console.WriteLine(
            $"La bomba {bomba2.Identificador} presenta mayor caudal por watt.");
    }
    else
    {
        Console.WriteLine("Existe empate entre los indicadores.");
    }
}
else
{
    Console.WriteLine(
        "Comparación no válida: al menos una bomba tiene potencia nula.");
}

// Clase que representa una bomba eléctrica.
class Bomba
{
    // Propiedades de identificación y medición.
    public string Identificador { get; set; } = "";
    public double Voltaje { get; set; }
    public double Corriente { get; set; }
    public double Caudal { get; set; }

    // Propiedades calculadas.
    public double Potencia { get; set; }
    public double Indicador { get; set; }
    public bool IndicadorValido { get; set; }

    // Método para calcular la potencia eléctrica.
    public void CalcularPotencia()
    {
        Potencia = Voltaje * Corriente;
    }

    // Método para calcular el indicador de desempeño.
    public void CalcularIndicador()
    {
        if (Potencia > 0)
        {
            Indicador = Caudal / Potencia;
            IndicadorValido = true;
        }
        else
        {
            Indicador = 0;
            IndicadorValido = false;
        }
    }

    // Método para mostrar los datos y resultados.
    public void MostrarDatos()
    {
        Console.WriteLine("DATOS DE LA BOMBA");
        Console.WriteLine($"Identificador: {Identificador}");
        Console.WriteLine($"Voltaje: {Voltaje:F2} V");
        Console.WriteLine($"Corriente: {Corriente:F2} A");
        Console.WriteLine($"Caudal: {Caudal:F2} L/min");
        Console.WriteLine($"Potencia: {Potencia:F2} W");

        if (IndicadorValido)
        {
            Console.WriteLine(
                $"Indicador de desempeño: {Indicador:F4} (L/min)/W");
        }
        else
        {
            Console.WriteLine("Indicador de desempeño: No calculable");
        }
    }
}