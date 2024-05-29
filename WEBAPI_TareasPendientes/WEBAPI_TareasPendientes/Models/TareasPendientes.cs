namespace WEBAPI_TareasPendientes.Models
{
    public class TareasPendientes
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public bool Completada { get; set; }
    }
}
