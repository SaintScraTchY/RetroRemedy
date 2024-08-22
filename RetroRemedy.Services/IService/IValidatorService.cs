using ErrorOr;

namespace RetroRemedy.Services.IService;

public interface IValidatorService
{
    Task<ErrorOr<Success>> ValidateAsync<TModel>(TModel model);
}