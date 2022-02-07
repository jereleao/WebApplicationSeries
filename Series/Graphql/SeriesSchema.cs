using GraphQL.Types;

namespace Series.GraphQL
{
    public class SeriesSchema : Schema
    {
        public SeriesSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<SeriesQuery>();
            //Mutation = serviceProvider.GetRequiredService<SeriesMutation>();
        }
    }
}
