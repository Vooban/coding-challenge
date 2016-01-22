using FluentNHibernate.Mapping;

namespace Coding_Challenge.Models
{
    public class CitiesMap : ClassMap<Cities>
    {

        public CitiesMap()
        {
            Table("Cities");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            Map(x => x.name).Column("name").Not.Nullable();
            Map(x => x.lat).Column("lat").Not.Nullable();
            Map(x => x.@long).Column("long").Not.Nullable();
            Map(x => x.country).Column("country").Not.Nullable();
            Map(x => x.stateprov).Column("stateprov").Not.Nullable();
        }
    }
}