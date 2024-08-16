using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.BlogPosts;
using RetroRemedy.Core.Entities.GameTags;
using RetroRemedy.Core.Entities.Publishers;
using RetroRemedy.Core.Entities.UploadMedias;

namespace RetroRemedy.Core.Entities.Games;

    public class Game : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDateTime { get; set; }
        public long PublisherId { get; set; }
        
        //TODO Add Vote Implementation
        public float Rating { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<GameTag> GameTags { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
        public ICollection<UploadMedia> Medias { get; set; }

        protected Game(string title, string description, DateTime releaseDateTime, 
            long publisherId, float rating, ICollection<GameTag> gameTags,
            ICollection<UploadMedia> medias, long userId) : base(userId,true)
        {
            Title = title;
            Description = description;
            ReleaseDateTime = releaseDateTime;
            PublisherId = publisherId;
            Rating = rating;
            GameTags = gameTags;
            Medias = medias;
        }
    }
