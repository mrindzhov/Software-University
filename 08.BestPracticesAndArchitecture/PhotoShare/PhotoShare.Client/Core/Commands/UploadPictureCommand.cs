namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Services;

    public class UploadPictureCommand
    {
        private AlbumService albumService;
        private PictureService pictureService;

        public UploadPictureCommand(AlbumService albumService, PictureService pictureService)
        {
            this.albumService = albumService;
            this.pictureService = pictureService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>

        public string Execute(string[] data)
        {
            string albumName = data[0];
            string pictureTitle = data[1];
            string pictureFilePath = data[2];

            if (!this.albumService.IsAlbumExisting(albumName))
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }
            if (this.pictureService.IsPicExisting(albumName, pictureTitle, pictureFilePath))
            {
                throw new ArgumentException($"Picture {pictureTitle} already existing in album {albumName}!");
            }
            this.pictureService.AddPicture(albumName,pictureTitle, pictureFilePath);

            return $"Picture {pictureTitle} added to album {albumName}";

        }
    }
}
