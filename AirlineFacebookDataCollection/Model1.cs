namespace AirlineFacebookDataCollection
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;

    public class Model1 : DbContext
    {
        public Model1()
            : base(@"data source=xxx;Initial Catalog=FaceBookDataCollection;MultipleActiveResultSets=True;App=EntityFramework")
            //: base(@"data source=(LocalDb)\v11.0;initial catalog=FaceBookDataCollection;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Like> Likes { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new Post.PostConfiguration());
        //}

        public static bool RecreateDatabase()
        {
            bool result = false;
            using (var db = new Model1())
            {
                try
                {
                    result = db.Database.Delete();
                    db.Database.Create();

                }
                catch (Exception ex)
                {
                    MainForm.LogOutput(ex.Message);
                    MainForm.LogOutput(ex.StackTrace);
                    result = false;
                }
            }

            return result;
        }
    }



    public class Post
    {
        #region prop
        
        [Key, Column(TypeName = "varchar"), StringLength(128)]
        public string PostId { get; set; }

        [Column(TypeName = "varchar"), StringLength(128)]
        public string InReplyToPostId { get; set; }

        [Column(TypeName = "varchar"), StringLength(128)]
        public string InReplyToCommentId { get; set; }

        public DateTime CreatedTime { get; set; }

        public long UserId { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        public string Message { get; set; }
        #endregion

        [Column(TypeName = "varchar"), StringLength(20)]
        public string StatusType { get; set; }

        //[NotMapped]
        //public StatusType PostStatusType
        //{
        //    get { return (StatusType)Enum.Parse(typeof(StatusType), StatusTypeString); }
        //    set
        //    {
        //        StatusTypeString = Enum.GetName(typeof(StatusType), value);
        //    }
        //}

        [Column(TypeName = "varchar"), StringLength(6)]
        public string Type { get; set; }

        //[NotMapped]
        //public Type PostType
        //{
        //    get { return (Type)Enum.Parse(typeof(Type), TypeString); }
        //    set
        //    {
        //        TypeString = Enum.GetName(typeof(Type), value);
        //    }
        //}

        #region prop
        [StringLength(1024)]
        public string Story { get; set; }

        public string Link { get; set; }

        [StringLength(1024)]
        public string PostName { get; set; }

        public long NumShares { get; set; }

        public long NumLikes { get; set; }

        public long NumComments { get; set; }

        [Column(TypeName = "varchar"),MaxLength(8)]
        public string VideoLength { get; set; }
        #endregion

        //public class PostConfiguration : EntityTypeConfiguration<Post>
        //{
        //    public PostConfiguration()
        //    {
        //        Property(p => p.StatusTypeString);
        //        Property(p => p.TypeString);
        //    }
        //}
    }

    public class Like
    {
        [Key, Column(TypeName = "varchar", Order = 1), StringLength(128)]
        public string LikedPostId { get; set; }

        [Key, Column(Order = 2)]
        public long UserId { get; set; }

        [StringLength(256)]
        public string Username { get; set; }
    }

    public enum StatusType
    {
        mobile_status_update,
        created_note,
        added_photos,
        added_video,
        shared_story,
        created_group,
        created_event,
        wall_post,
        app_created_story,
        published_story,
        tagged_in_photo,
        approved_friend,
    }

    public enum Type
    {
        link,
        status,
        photo,
        video,
        offer,
    }
}