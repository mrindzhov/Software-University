namespace PhotoShare.Client.Core.Commands
{
    using Services;
    using System;
    using Utilities;

    public class AddTagToCommand
    {
        private readonly AlbumService albumService;
        private readonly TagService tagService;

        // AddTagTo <albumName> <tag>
        public AddTagToCommand(TagService tagService, AlbumService albumService)
        {
            this.tagService = tagService;
            this.albumService = albumService;
        }

        public string Execute(string[] data)
        {
            string albumName = data[0];
            string tag = data[1].ValidateOrTransform();

            if (!this.tagService.IsTagExisting(tag) || !this.albumService.IsAlbumExisting(albumName))
            {
                throw new ArgumentException($"Either tag or album do not exist!");
            }

            if (this.albumService.HasTag(tag))
            {
                throw new ArgumentException("Album already has this tag!");
            }
            this.albumService.AddTag(albumName, tag);

            return $"{tag} was added successfully to {albumName}!";
        }

    }
}