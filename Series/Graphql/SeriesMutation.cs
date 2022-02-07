using GraphQL;
using GraphQL.Types;
using Series.DataBase;
using Series.GraphQL.Types;
using Series.Models;

namespace Series.GraphQL
{
    public class SeriesMutation : ObjectGraphType<object>
    {
        //private readonly ISeriesRepository repository;
        public SeriesMutation()
        {
            //repository = provider.GetRequiredService<ISeriesRepository>();

            Field<SerieType, Serie>()
                .Name("addSerie")
                .Argument<NonNullGraphType<SerieInputType>>("serie", "A brand new Serie.")
                .Resolve(context =>
                {
                    var serie = context.GetArgument<Serie>("serie");
                    var seriesContext = context.RequestServices.GetRequiredService<SeriesContext>();

                    var newSerie = seriesContext.Add(serie).Entity;
                    seriesContext.SaveChanges();
                    //var newSerie = repository.Add(serie);
                    //repository.SaveChanges();
                    return newSerie;// repository.GetAsync(serie.Id);
                });
        }
    }
}