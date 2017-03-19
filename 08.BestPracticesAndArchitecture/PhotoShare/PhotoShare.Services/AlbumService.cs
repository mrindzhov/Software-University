namespace PhotoShare.Services
{
    using Data;
    using Models;
    using System.Linq;
    using System;

    public class AlbumService
    {
        public void AddAlbum(string username, string albumTitle, Color bgColor, string[] tags)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = new Album();

                album.Name = albumTitle;
                album.BackgroundColor = bgColor;
                album.Tags = context.Tags.Where(t => tags.Contains(t.Name)).ToList();

                User owner = context.Users.SingleOrDefault(u => u.Username == username);

                AlbumRole albRole = new AlbumRole();

                albRole.User = owner;
                albRole.Album = album;
                albRole.Role = Role.Owner;

                album.AlbumRoles.Add(albRole);

                context.Albums.Add(album);
                context.SaveChanges();
            }
        }

        public bool HasTag(string tag)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Tags.Any(t => t.Name == tag));
            }
        }

        public void AddTag(string albumName, string tagName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Name == albumName);
                Tag tag = context.Tags.SingleOrDefault(t => t.Name == tagName);
                album.Tags.Add(tag);
                
                context.SaveChanges();
            }
        }

        public bool IsAlbumExisting(string albumTitle)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Name == albumTitle);
            }
        }
    }
}