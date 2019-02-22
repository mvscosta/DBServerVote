namespace Vote.Core.Interfaces.Model
{
    public interface ICategoria : IBaseModel
    {
        string Descricao { get; set; }
        string Titulo { get; set; }
    }
}