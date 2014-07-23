namespace Arquitetura.Domain.Interface
{
    // Interface que todas Entidades devem implementar
    // Ela garante a criação de um Repositório Genérico, 
    // poupando muito código na camada de Repositório
    public interface IEntity
    {
        long Id { get; }
    }
}
