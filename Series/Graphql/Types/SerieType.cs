using GraphQL.Types;
using Series.Models;

namespace Series.GraphQL.Types
{
    public sealed class SerieType : ObjectGraphType<Serie>
    {
        public SerieType() 
        {
            Name = nameof(Serie);
            Description = "Uma serie na coleção";
            Field(s => s.Id, nullable: false).Description("Serie's Identifier");
            Field(s => s.createdAt, nullable: true);
            Field(s => s.updatedAt, nullable: true);
            Field(s => s.Title, nullable: false).Description("Serie's Title");
            Field(s => s.Description, nullable: true).Description("Serie's Description");
            Field(s => s.CategoryId, nullable: true);
            Field(s => s.ReleaseDate, nullable: true).Description("Realese date for de Serie first episode");
        }
    }
}
