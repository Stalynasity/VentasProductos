using BOOT.Application.Dtos.Invoice;
using FluentValidation;


namespace BOOT.Application.Validators.Product
{
    public class InvoiceValidators: AbstractValidator<InvoiceRequestDto>
    {
        public InvoiceValidators()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacio");
        }
    }
}
