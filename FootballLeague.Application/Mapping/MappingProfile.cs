namespace FootballLeague.Application.Mapping;

using System.Reflection;
using AutoMapper;

// finding all mappings in our solution by convention and register them so they will be executed automatically.
public class MappingProfile : Profile
{
    public MappingProfile()
        => ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    
    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly
            .GetExportedTypes()
            .Where(t => t
                .GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            const string mappingMethodName = "Mapping";

            var methodInfo = type.GetMethod(mappingMethodName)
                             ?? type.GetInterface("IMapFrom`1")?.GetMethod(mappingMethodName);

            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}