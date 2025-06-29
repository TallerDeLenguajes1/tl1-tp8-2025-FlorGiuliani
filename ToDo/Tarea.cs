namespace EspacioTarea;

public class Tarea
{
    public int TareaID { get; set; } //Numérico autoincremental comenzando en 1000
    public string Descripcion { get; set; }
    public int Duracion { get; set; } // entre 10 – 100

    public Tarea(int tareaID, string descripcion, int duracion)
    {
        TareaID = tareaID;
        Descripcion = descripcion;
        Duracion = duracion;
    }
    
}
