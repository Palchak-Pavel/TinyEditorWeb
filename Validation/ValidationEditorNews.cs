using FluentValidation;
using News.API.Mongodb.Entities;

namespace News.API.Validation;

public class ValidationEditorNews : AbstractValidator<EditorNews>
{
    public ValidationEditorNews()
    {
        RuleFor(news => news.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Не заполнен заголовок");
        RuleFor(news => news.H1)
            .NotNull()
            .NotEmpty()
            .WithMessage("Не заполнен заголовок");
        RuleFor(news => news.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Не заполнено описание");
        RuleFor(news => news.Content)
            .NotNull()
            .NotEmpty()
            .WithMessage("Нет содержимого");
    }
}