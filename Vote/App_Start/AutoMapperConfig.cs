using AutoMapper;

namespace Vote
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
                cfg.AddProfiles(new[] {
                    "Vote.DAO",
                    "Vote.Roles",
                    "Vote"
                })
            );
        }
    }
}