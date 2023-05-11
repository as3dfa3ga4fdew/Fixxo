using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Fixxo.Extenstions
{
    public static class ModelStateDictionaryExtension
    {
        public static void DisplayErrors(this ModelStateDictionary modelState)
        {
            List<ModelErrorCollection> modelErrorCollections = modelState.Select(x => x.Value.Errors)
                                 .Where(y => y.Count > 0)
                                 .ToList();

            foreach (var modelErrorCollection in modelErrorCollections)
                foreach (var modelError in modelErrorCollection)
                    Console.WriteLine(modelError.ErrorMessage);
        }
    }
}
