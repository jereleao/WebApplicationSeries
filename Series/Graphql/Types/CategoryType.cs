using GraphQL.Types;
using Series.Database.Interfaces;
using Series.Models;

namespace Series.GraphQL.Types
{
    public sealed class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(ISerieRepository repository) 
        {
            Name = nameof(Category);

            Field(s => s.Id, nullable: false).Description("Category's Identifier");
            Field(s => s.Name, nullable: false);
            Field(s => s.Description, nullable: true);
            Field(s => s.createdAt, nullable: true);
            Field(s => s.updatedAt, nullable: true);

            FieldAsync<ListGraphType<SerieType>, IEnumerable<Serie>>(
            "series",
            resolve: ctx => {
                return repository.GetSeriesByCategory(ctx.Source.Id);
            });
        }
    }
}
