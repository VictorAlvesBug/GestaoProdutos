using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoProdutos.Application.Validation
{
	public class ValidationResultModel
	{
		public string Message { get; }

		public List<ValidationError> Errors { get; }

		public ValidationResultModel(ModelStateDictionary modelState)
		{
			Message = "Erro de Validação";
			Errors = modelState.Keys
					.SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
					.ToList();
		}
	}
}
