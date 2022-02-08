using GraphQL;
using GraphQL.Types;
using Series.Database.Interfaces;
using Series.GraphQL.Types;
using Series.Models;

namespace Series.GraphQL
{
    public class SeriesMutation : ObjectGraphType<object>
    {
        private readonly ISerieRepository _serieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SeriesMutation(ISerieRepository serieRepository, ICategoryRepository categoryRepository)
        {
            _serieRepository = serieRepository;
            _categoryRepository = categoryRepository;

            Field<SerieType, Serie>()
                .Name("addSerie")
                .Argument<NonNullGraphType<SerieInputType>>("serie")
                .Resolve(context =>
                {
                    Serie? serie = _serieRepository.Add(context.GetArgument<Serie>("serie"));
                    _serieRepository.SaveChanges();
                    return serie;
                });

            Field<SerieType, Serie>()
                .Name("updateSerie")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Argument<NonNullGraphType<SerieInputType>>("serie")
                .ResolveAsync(async context =>
                {
                    Serie? serie = context.GetArgument<Serie>("serie");
                    Serie? serieToUpdate = await _serieRepository.GetAsync(context.GetArgument<int>("id"));
                    if(serieToUpdate == null) { return null; }
                    if (!string.IsNullOrEmpty(serie.Title)) serieToUpdate.Title = serie.Title;
                    if (!string.IsNullOrEmpty(serie.Description)) serieToUpdate.Description = serie.Description;
                    if (serie.CategoryId != 0) serieToUpdate.CategoryId = serie.CategoryId;
                    if (serie.ReleaseDate != new DateTime()) serieToUpdate.ReleaseDate = serie.ReleaseDate;

                    _serieRepository.Update(serieToUpdate);
                    _serieRepository.SaveChanges();
                    return serieToUpdate;
                });

            Field<BooleanGraphType, bool>()
                .Name("removeSerie")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(context =>
                {
                    bool result = _serieRepository.Delete(context.GetArgument<int>("id"));
                    if (result) _serieRepository.SaveChanges();
                    return result;
                });

            Field<CategoryType, Category>()
                .Name("addCategory")
                .Argument<NonNullGraphType<CategoryInputType>>("category")
                .Resolve(context =>
                {
                    Category? category = _categoryRepository.Add(context.GetArgument<Category>("category"));
                    _categoryRepository.SaveChanges();
                    return category;
                });
        }
    }
}