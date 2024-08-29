using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.BlogPosts;
using RetroRemedy.Core.Entities.GameTags;
using RetroRemedy.Core.Entities.Publishers;
using RetroRemedy.Core.Entities.UploadMedias;

namespace RetroRemedy.Core.Entities.Games;

    public class Game : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateOnly ReleaseDate { get; private set; }
        public long PublisherId { get; private set; }
        
        //TODO Add Vote Implementation
        public float Rating { get; private set; }
        public UploadFile Thumbnail { get; set; }
        public long ThumbnailId { get; private set; }
        public Publisher Publisher { get; private set; }
        public ICollection<GameTag> GameTags { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
        public ICollection<UploadFile> Medias { get; set; }

        protected Game()
        {
            
        }
        public Game(string title, string description, DateOnly releaseDate,
            long publisherId, UploadFile thumbnail, IEnumerable<long> tagIds,
            ICollection<UploadFile> medias, long userId, bool isActive = true) : base(userId, isActive)
        {
            Title = title;
            Description = description;
            ReleaseDate = releaseDate;
            PublisherId = publisherId;
            Thumbnail = thumbnail;
            AddGameTags(tagIds);
            
            if(medias != null && medias.Count != 0)
                Medias = medias;
        }
        
        public void Update(string? title, string? description, DateOnly? releaseDate,
            long? publisherId,long? thumbnailId,long userId)
        {
            base.UpdateTimestamp(userId);
            Title = title ?? Title;
            Description = description ?? Description;
            ReleaseDate = releaseDate ?? ReleaseDate;
            PublisherId = publisherId ?? PublisherId;
            ThumbnailId = thumbnailId ?? ThumbnailId;
        }

        private void AddGameTags(IEnumerable<long> tagIds)
        {
            GameTags = tagIds.Select(x => new GameTag(this, x)).ToList();
        }
    }
