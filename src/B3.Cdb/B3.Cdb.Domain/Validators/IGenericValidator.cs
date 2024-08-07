using FluentValidation.Results;

namespace B3.Cdb.Domain.Validators
{
    public interface IGenericValidator<TEntity>
    {
        ValidationResult Validar(TEntity instance);
    }
}
