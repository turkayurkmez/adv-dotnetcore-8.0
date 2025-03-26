using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Behaviors
{

    //IRequestHandler'a gitmeden önce validation işlemlerini yapmak için kullanılır.
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any()) 
            {
                //oluşan tüm hata ve bilgiler context içerisinde tutulur.
                var context = new ValidationContext<TRequest>(request);

                //tüm validasyonlar asenkron çalıştır. Bitince sonuçları al.
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                //oluşan tüm hatalar bir listeye toplanır.
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                //Eğer hata varsa, hata fırlatılır.
                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }

            }

            return await next();

        }
    }
}
