using EspacioTarea;

int ingresarValorNumerico(string? mensaje)
{
    string? respuesta;
    int num;
    do
    {
        Console.WriteLine(mensaje);
        respuesta = Console.ReadLine();
    } while (!int.TryParse(respuesta, out num));
    return num;
}

string ingresarCadena(string? mensaje)
{
    string? respuesta;
    do
    {
        Console.WriteLine(mensaje);
        respuesta = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(respuesta));
    return respuesta;
}



Tarea ingresarTarea(ref int ID)
{
    string? descripcion;
    string? duracion;
    int duracionNum;

    do
    {
        Console.WriteLine("Ingrese la descripcion de la tarea");
        descripcion = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(descripcion));

    do
    {
        do
        {
            Console.WriteLine("Ingrese la duracion de la tarea entre 10 y 100: ");
            duracion = Console.ReadLine();
        } while (!int.TryParse(duracion, out duracionNum));
    } while (duracionNum < 10 || duracionNum > 100);

    Tarea nuevaTarea = new Tarea(ID, descripcion, duracionNum);
    ID++;
    return nuevaTarea;
}

void mostrarTarea(Tarea tarea)
{
    Console.WriteLine("Tarea: " + tarea.TareaID);
    Console.WriteLine("Descripción: " + tarea.Descripcion);
    Console.WriteLine("Duración: " + tarea.Duracion + " horas\n");
}

void mostrarTodasLasTareas(List<Tarea> listaPendientes, List<Tarea> listaRealizadas)
{
    Console.WriteLine("\n--Listado de Tareas Pendientes--");
    foreach (Tarea item in listaPendientes)
    {
        mostrarTarea(item);
    }
    Console.WriteLine("\n--Listado de Tareas Realizadas--");
    foreach (Tarea item in listaRealizadas)
    {
        mostrarTarea(item);
    }
}


const int N = 1;

List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

int proximoID = 1000;
for (int i = 0; i < N; i++)
{
    Tarea nuevaTarea = ingresarTarea(ref proximoID);
    tareasPendientes.Add(nuevaTarea);
}

int eleccion;
int idTarea;
Tarea? tareaParaMarcar;
string? tareaABuscar;

do {
    Console.WriteLine("-----MENU-----");
    Console.WriteLine("1. Marcar una tarea como realizada");
    Console.WriteLine("2. Mostrar todas las tareas");
    Console.WriteLine("3. Buscar tarea");
    Console.WriteLine("4. Salir");

    eleccion = ingresarValorNumerico("Ingrese la operación que desee realizar: ");

    switch (eleccion)
    {
        case 1:
            do
            {
                idTarea = ingresarValorNumerico("Ingresa el ID de la tarea que desea marcar como realizada: ");
                /*for (int i = tareasPendientes.Count - 1; i >= 0; i--)
                {
                    if (tareasPendientes[i].TareaID == idTarea)
                    {
                        tareasRealizadas.Add(tareasPendientes[i]);
                        tareasPendientes.Remove(tareasPendientes[i]);
                    }
                }*/
                tareaParaMarcar = tareasPendientes.Find(t => t.TareaID == idTarea);
                if (tareaParaMarcar != null)
                {
                    tareasRealizadas.Add(tareaParaMarcar);
                    tareasPendientes.Remove(tareaParaMarcar);
                }
            } while (ingresarValorNumerico("Desea marcar otra tarea como realizada? Si(1) No(2): ") != 2);
        break;
        case 2:
            mostrarTodasLasTareas(tareasPendientes, tareasRealizadas);
            break;
        case 3:
            do {
                tareaABuscar = ingresarCadena("Ingresa la descripcion de la tarea a buscar: ");
                foreach (var item in tareasPendientes)
                {
                    if (item.Descripcion.IndexOf(tareaABuscar, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        mostrarTarea(item);
                    }
                }
            } while (ingresarValorNumerico("Desea buscar otra tarea? Si(1) No(2): ") != 2);
            break; 
        default:
            break;
    }
} while (eleccion != 4);
