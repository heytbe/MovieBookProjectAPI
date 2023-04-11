using Entity.API.Entity.MovieEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.API.Configuration.MovieConfig
{
    public class MovieCategoryConf : IEntityTypeConfiguration<MovieCategory>
    {
        public void Configure(EntityTypeBuilder<MovieCategory> builder)
        {
            builder.Ignore(x => x.Id);
            builder.HasKey(x => new { x.MovieId, x.CategoryId });
            builder.HasOne(x => x.Category).WithMany(a => a.Movies).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Movie).WithMany(x => x.Categories).HasForeignKey(x => x.MovieId);
        }
    }
}
