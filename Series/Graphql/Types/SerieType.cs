using GraphQL.Types;
using Series.Database.Interfaces;
using Series.Models;

namespace Series.GraphQL.Types
{
    public sealed class SerieType : ObjectGraphType<Serie>
    {
        public SerieType(ICategoryRepository repository) 
        {
            Name = nameof(Serie);
            Description = "Uma serie na coleção";
            Field(s => s.Id, nullable: false).Description("Serie's Identifier");
            Field(s => s.Title, nullable: false);
            Field(s => s.Description, nullable: true);
            Field(s => s.CategoryId, nullable: true);
            Field(s => s.ReleaseDate, nullable: true);
            Field(s => s.createdAt, nullable: true);
            Field(s => s.updatedAt, nullable: true);
            FieldAsync<CategoryType, Category>("category",
            resolve: ctx =>
            {
                return repository.GetAsync(ctx.Source.CategoryId);
            });
        }
    }
}
