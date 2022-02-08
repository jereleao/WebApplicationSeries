using GraphQL.Types;
using Series.Models;

namespace Series.GraphQL.Types
{
    public sealed class SerieInputType : InputObjectGraphType<Serie>
    {
        public SerieInputType()
        {
            Name = "SerieInput";
            Field<StringGraphType>("title");
            Field<StringGraphType>("description");
            Field<IntGraphType>("categoryId");
            Field<DateGraphType>("releaseDate", "yyyy-MM-dd");
        }
    }
}