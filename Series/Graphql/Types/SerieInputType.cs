using GraphQL.Types;
using Series.Models;

namespace Series.GraphQL.Types
{
    public sealed class SerieInputType : InputObjectGraphType<Serie>
    {
        public SerieInputType()
        {
            Name = "SerieInput";
            Description = "Data to add a Serie";

            Field(s => s.Title).Description("Serie's Title");
        }
    }
}