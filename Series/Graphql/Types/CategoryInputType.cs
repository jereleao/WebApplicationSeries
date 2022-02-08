using GraphQL.Types;
using Series.Models;

namespace Series.GraphQL.Types
{
    public sealed class CategoryInputType : InputObjectGraphType<Category>
    {
        public CategoryInputType()
        {
            Name = "CategoryInput";
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
        }
    }
}