using GraphQL;
using GraphQL.Types;
using Series.DataBase;
using Series.GraphQL.Types;
using Series.Models;

namespace Series.GraphQL
{
    public class SeriesQuery : ObjectGraphType<object>
    {
        public SeriesQuery()
        {
            Field<SerieType, Serie>()
                .Name("serie")
                .Argument<NonNullGraphType<IdGraphType>>("id", "The unique Id of the serie.")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return new Serie(); //repository.GetAsync(id);
                });

            Field<ListGraphType<SerieType>>()
                .Name("series")
                .Resolve(context =>
                {
                    var seriesContext = context.RequestServices.GetRequiredService<SeriesContext>();
                    return seriesContext.Series.ToList();
                });
        }
    }

}