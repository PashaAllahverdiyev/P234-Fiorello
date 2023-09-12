using Fiorello.Application.DTOs.CategoryDtos;
using FluentValidation;

namespace Fiorello.Application.Validators.CategoryValidators;

public class CategoryCreateDtoValidator:AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x=>x.Description)
            .NotEmpty()
            .MaximumLength(500);
    }
}
