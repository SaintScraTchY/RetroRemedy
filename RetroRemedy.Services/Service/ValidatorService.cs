using ErrorOr;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RetroRemedy.Services.IService;

namespace RetroRemedy.Services.Service;

public class ValidatorService(IServiceProvider serviceProvider) : IValidatorService
{
    public async Task<ErrorOr<Success>> ValidateAsync<TModel>(TModel model)
    {
        var validator = serviceProvider.GetService<IValidator<TModel>>();
        if (validator == null)
        {
            throw new InvalidOperationException($"No validator found for {typeof(TModel).Name}");
        }

        var validationResult = await validator.ValidateAsync(model);
        
        if (validationResult.IsValid) return Result.Success;
        
        var errors = validationResult.Errors.Select(e => Error.Validation(e.PropertyName, e.ErrorMessage)).ToList();
        return errors;
    }
}