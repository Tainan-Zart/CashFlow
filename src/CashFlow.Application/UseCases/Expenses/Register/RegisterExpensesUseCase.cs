using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpensesUseCase
{
    public ResponseRegistedExpenseJson Execute(RequestRegisterExpenseJson request)
    {

        Validate(request);
        return new ResponseRegistedExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if(titleIsEmpty)
        {
            throw new ArgumentException("Titulo é obrigatorio");

        }
        
        if (request.Amount <= 0)
        {
            throw new ArgumentException("O valor deve ser maior que zero."); 
        }

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);

        if(result > 0)
        {
            throw new ArgumentException("Não pode ser aceito uma date no futuro");

        }
        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

        if (paymentTypeIsValid == false)
        {
            throw new ArgumentException("Tipo de pagamento não é valido");

        }
    }
}
