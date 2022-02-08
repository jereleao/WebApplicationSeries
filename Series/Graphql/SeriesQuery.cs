using GraphQL;
using GraphQL.Types;
using Series.Database.Interfaces;
using Series.GraphQL.Types;
using Series.Models;

namespace Series.GraphQL
{
    public class SeriesQuery : ObjectGraphType<object>
    {
        private readonly ISerieRepository _repository;
        public SeriesQuery(ISerieRepository repository)
        {
            _repository = repository;

            Field<SerieType, Serie>()
                .Name("serie")
                .Argument<NonNullGraphType<IdGraphType>>("id", "The unique Id of the serie.")
                .ResolveAsync(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return _repository.GetAsync(id);
                });

            Field<ListGraphType<SerieType>>()
                .Name("series")
                .Resolve(context =>
                {
                    return _repository.GetAll();
                });
        }
    }

}