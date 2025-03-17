namespace DDDCommerceBCC.Domain.Models
{
    public class Pedido : BaseModel
    {
        public string LojaOrigem { get; set; }
        public DateTime Data { get; set; }
    }
}
