namespace UsersDatabase
{
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using Models;
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            UsersContext context = new UsersContext();
            // context.Database.Initialize(true);            
            RecievingTags(context);

        }
        private static void RecievingTags(UsersContext context)
        {
            string parameterInput = Console.ReadLine();

            Tag tag = new Tag()
            {
                TagLabel = parameterInput
            };

            try
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                tag.TagLabel = TagTransformer.Transform(tag.TagLabel);
                context.SaveChanges();
            }
        }
    }
}
