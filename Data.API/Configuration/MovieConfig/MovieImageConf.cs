using Entity.API.Entity.MovieEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.API.Configuration.MovieConfig
{
    public class MovieImageConf : IEntityTypeConfiguration<MovieImages>
    {
        public void Configure(EntityTypeBuilder<MovieImages> builder)
        {
            builder.HasOne(x => x.Movie).WithMany(a => a.MovieImages).HasForeignKey(x => x.MovieId);
        }
    }
}
