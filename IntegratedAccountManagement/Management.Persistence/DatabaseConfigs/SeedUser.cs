namespace IntegratedAccountManagement.Persistence.DatabaseConfigs;

public static class SeedUser
{
    public static void CreateUsers(DataContext context)
    {
        // User user = new(
        //     Guid.NewGuid(),
        //     "leandro@gmail.com.br",
        //     "leandro",
        //     EUserProfile.Admin,
        //     "leandro",
        //     true,
        //     ""
        // );

        // if(context.Set<User>().Any(x => x.SolutionsPortalUserName == user.SolutionsPortalUserName)) return;
        //
        // context.Set<User>().Add(user);

        context.SaveChanges();
    }
}