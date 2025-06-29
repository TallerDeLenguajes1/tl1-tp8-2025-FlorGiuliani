using System.Reflection.Metadata.Ecma335;

namespace EspacioCalculadora;

public enum TipoOperacion
{
    Suma,
    Resta,
    Multiplicacion,
    Division,
    Limpiar // Representa la acción de borrar el resultado actual o el historial ?????
}

public class Operacion
{
    private double resultadoAnterior;
    private double nuevoValor;
    private TipoOperacion operacionTipo;

    public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacionTipo)
    {
        this.resultadoAnterior = resultadoAnterior;
        this.nuevoValor = nuevoValor;
        this.operacionTipo = operacionTipo;
    }

    public double Resultado()
    {
        switch (operacionTipo)
        {
            case (TipoOperacion)1:
                ResultadoAnterior += NuevoValor;
                break;
            case (TipoOperacion)2:
                ResultadoAnterior -= NuevoValor;
                break;
            case (TipoOperacion)3:
                ResultadoAnterior *= NuevoValor;
                break;
            case (TipoOperacion)4:
                if (NuevoValor != 0) ResultadoAnterior /= NuevoValor;
                break;
            case (TipoOperacion)5:
                ResultadoAnterior = 0;
                break;
            default:
                break;
        }
        return ResultadoAnterior;
    }

    public double NuevoValor { get => nuevoValor; set => nuevoValor = value; }
    public double ResultadoAnterior { get => resultadoAnterior; set => resultadoAnterior = value; }
    public TipoOperacion OperacionTipo { get => operacionTipo; set => operacionTipo = value; }
}

public class Calculadora
{
    private double dato;
    private List<Operacion> historial;

    public Calculadora()
    {
        this.dato = 0;
        this.historial = new List<Operacion>();
    }

    public double Resultado { get => dato; }
    public List<Operacion> Historial { get => historial; }

    public void Sumar(double termino)
    {
        historial.Add(new Operacion(dato, termino, TipoOperacion.Suma));
        dato += termino;
    }

    public void Restar(double termino)
    {
        historial.Add(new Operacion(dato, termino, TipoOperacion.Resta));
        dato -= termino;
    }

    public void Multiplicar(double termino)
    {
        historial.Add(new Operacion(dato, termino, TipoOperacion.Multiplicacion));
        dato *= termino;
    }

    public void Dividir(double termino)
    {
        if (termino != 0)
        {
            historial.Add(new Operacion(dato, termino, TipoOperacion.Division));
            dato /= termino;
        }  
    }

    public void Limpiar()
    {
        //historial.Clear(); //para borrar todo el historial
        historial.Add(new Operacion(dato, 0, TipoOperacion.Limpiar)); //si solo quiero borrar el resultado
        dato = 0;
    }
}