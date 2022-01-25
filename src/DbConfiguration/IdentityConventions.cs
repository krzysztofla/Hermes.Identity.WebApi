using System.Collections.Generic;


namespace Hermes.Identity.DbConfiguration
{
    public class IdentityConventions : IConventionPack
    {
        public IEnumerable<IConvention> Conventions => new List<IConvention> {
            new CamelCaseElementNameConvention(),
            new IgnoreExtraElementsConvention(true),
            new EnumRepresentationConvention(BsonType.String)             
        };
    }
}