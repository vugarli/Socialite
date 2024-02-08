using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Socialite.Api.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public class FromRouteAndBodyAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource { get; } = CompositeBindingSource.Create(
            new[] { BindingSource.Path, BindingSource.Body }, nameof(FromRouteAndBodyAttribute));
    }
}
