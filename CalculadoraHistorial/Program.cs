using EspacioCalculadora;

string ingresarRespuesta()
{
    string? respuesta;
    do
    {
        respuesta = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(respuesta));
    return respuesta;
}

double ingresarTermino()
{
    string? respuesta;
    double num;
    do
    {
        respuesta = Console.ReadLine();
    } while (!double.TryParse(respuesta, out num));
    return num;
}

Calculadora nuevaOperacion = new Calculadora();

string? respuesta;

    Console.WriteLine("+) Sumar");
    Console.WriteLine("-) Restar");
    Console.WriteLine("x) Multiplicar");
    Console.WriteLine("/) Dividir");
    Console.WriteLine("=) Resultado");
    Console.WriteLine("AC) Limpiar");
    Console.WriteLine("?) Salir");

Console.WriteLine("---CALCULADORA---");
do
{
    respuesta = ingresarRespuesta();

    switch (respuesta)
    {
        case "+":
            nuevaOperacion.Sumar(ingresarTermino());
            break;
        case "-":
            nuevaOperacion.Restar(ingresarTermino());
            break;
        case "x":
            nuevaOperacion.Multiplicar(ingresarTermino());
            break;
        case "/":
            nuevaOperacion.Dividir(ingresarTermino());
            break;
        case "=":
            Console.WriteLine(nuevaOperacion.Resultado);
            break;
        case "AC":
            nuevaOperacion.Limpiar();
            break;
        default:
            break;
    }

} while (respuesta != "?");

foreach (Operacion item in nuevaOperacion.Historial)
{
    Console.WriteLine(item.ResultadoAnterior + " " + item.OperacionTipo + " " + item.NuevoValor);
}