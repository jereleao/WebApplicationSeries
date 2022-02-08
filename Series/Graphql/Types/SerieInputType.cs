using GraphQL.Types;
using Series.Models;

namespace Series.GraphQL.Types
{
    public sealed class SerieInputType : InputObjectGraphType<Serie>
    {
        public SerieInputType()
        {
            Name = "SerieInput";
            Field<NonNullGraphType<StringGraphType>>("title");
        }
    }
}