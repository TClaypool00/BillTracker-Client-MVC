using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class BilltrackerContext : DbContext
    {
        public BilltrackerContext()
        {
        }

        public BilltrackerContext(DbContextOptions<BilltrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Commenttype> Commenttypes { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Error> Errors { get; set; } = null!;
        public virtual DbSet<Loan> Loans { get; set; } = null!;
        public virtual DbSet<Miscellaneou> Miscellaneous { get; set; } = null!;
        public virtual DbSet<Paymenthistory> Paymenthistories { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Reply> Replies { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<Suggestion> Suggestions { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Userprofile> Userprofiles { get; set; } = null!;
        public virtual DbSet<Vwbill> Vwbills { get; set; } = null!;
        public virtual DbSet<Vwcomment> Vwcomments { get; set; } = null!;
        public virtual DbSet<Vwcompany> Vwcompanies { get; set; } = null!;
        public virtual DbSet<Vwerror> Vwerrors { get; set; } = null!;
        public virtual DbSet<Vwloan> Vwloans { get; set; } = null!;
        public virtual DbSet<Vwmiscellaneou> Vwmiscellaneous { get; set; } = null!;
        public virtual DbSet<Vwpost> Vwposts { get; set; } = null!;
        public virtual DbSet<Vwreply> Vwreplies { get; set; } = null!;
        public virtual DbSet<Vwsubscription> Vwsubscriptions { get; set; } = null!;
        public virtual DbSet<Vwsuggestion> Vwsuggestions { get; set; } = null!;
        public virtual DbSet<Vwuser> Vwusers { get; set; } = null!;
        public virtual DbSet<Watingoption> Watingoptions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(SecretConfig.ConnectionString, ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("bills");

                entity.HasIndex(e => e.CompanyId, "fk_companies_bill");

                entity.Property(e => e.BillId).HasColumnType("int(11)");

                entity.Property(e => e.AmountDue).HasPrecision(15, 2);

                entity.Property(e => e.BillName).HasMaxLength(255);

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_companies_bill");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.HasIndex(e => e.TypeId, "TypeId");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.CommentId).HasColumnType("int(11)");

                entity.Property(e => e.CommentBody).HasMaxLength(255);

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ParentId).HasColumnType("int(11)");

                entity.Property(e => e.TypeId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_ibfk_3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_ibfk_2");
            });

            modelBuilder.Entity<Commenttype>(entity =>
            {
                entity.ToTable("commenttypes");

                entity.Property(e => e.CommentTypeId).HasColumnType("int(11)");

                entity.Property(e => e.CommentType1)
                    .HasMaxLength(255)
                    .HasColumnName("CommentType");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("companies");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("companies_ibfk_2");
            });

            modelBuilder.Entity<Error>(entity =>
            {
                entity.ToTable("error");

                entity.Property(e => e.ErrorId).HasColumnType("int(11)");

                entity.Property(e => e.ErrorCode).HasColumnType("int(11)");

                entity.Property(e => e.ErrorLine).HasColumnType("int(11)");

                entity.Property(e => e.ErrorMessage).HasColumnType("text");

                entity.Property(e => e.StackTrace).HasColumnType("text");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("loans");

                entity.HasIndex(e => e.CompanyId, "fk_loans_companies");

                entity.Property(e => e.LoanId).HasColumnType("int(11)");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LoanName).HasMaxLength(255);

                entity.Property(e => e.MonthlyAmountDue).HasPrecision(11, 2);

                entity.Property(e => e.RemainingAmount).HasPrecision(11, 2);

                entity.Property(e => e.TotalAmountDue).HasPrecision(11, 2);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_loans_companies");
            });

            modelBuilder.Entity<Miscellaneou>(entity =>
            {
                entity.HasKey(e => e.MiscellaneousId)
                    .HasName("PRIMARY");

                entity.ToTable("miscellaneous");

                entity.HasIndex(e => e.CompanyId, "CompanyId");

                entity.Property(e => e.MiscellaneousId).HasColumnType("int(11)");

                entity.Property(e => e.Amount).HasPrecision(11, 2);

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.DateAdded).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Miscellaneous)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("miscellaneous_ibfk_1");
            });

            modelBuilder.Entity<Paymenthistory>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PRIMARY");

                entity.ToTable("paymenthistory");

                entity.HasIndex(e => e.TypeId, "TypeId");

                entity.Property(e => e.PaymentId).HasColumnType("int(11)");

                entity.Property(e => e.ExpenseId).HasColumnType("int(11)");

                entity.Property(e => e.TypeId).HasColumnType("int(11)");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Paymenthistories)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("paymenthistory_ibfk_1");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.PostId).HasColumnType("int(11)");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.PostBody).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("posts_ibfk_1");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("replies");

                entity.HasIndex(e => e.CommentId, "CommentId");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.ReplyId).HasColumnType("int(11)");

                entity.Property(e => e.CommentId).HasColumnType("int(11)");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.ReplyBody).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("replies_ibfk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("replies_ibfk_2");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("subscriptions");

                entity.HasIndex(e => e.CompanyId, "CompanyId");

                entity.Property(e => e.SubscriptionId).HasColumnType("int(11)");

                entity.Property(e => e.AmountDue).HasPrecision(11, 2);

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subscriptions_ibfk_1");
            });

            modelBuilder.Entity<Suggestion>(entity =>
            {
                entity.ToTable("suggestions");

                entity.HasIndex(e => e.ApproveDenyBy, "ApprovedBy");

                entity.HasIndex(e => e.SuggestionOption, "SuggestionOption");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.SuggestionId).HasColumnType("int(11)");

                entity.Property(e => e.ApproveDenyBy).HasColumnType("int(11)");

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.DenyReason).HasColumnType("text");

                entity.Property(e => e.SuggestBody).HasColumnType("text");

                entity.Property(e => e.SuggestHeader).HasMaxLength(255);

                entity.Property(e => e.SuggestionOption).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.ApproveDenyByNavigation)
                    .WithMany(p => p.SuggestionApproveDenyByNavigations)
                    .HasForeignKey(d => d.ApproveDenyBy)
                    .HasConstraintName("suggestions_ibfk_2");

                entity.HasOne(d => d.SuggestionOptionNavigation)
                    .WithMany(p => p.Suggestions)
                    .HasForeignKey(d => d.SuggestionOption)
                    .HasConstraintName("suggestions_ibfk_3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SuggestionUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("suggestions_ibfk_1");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("types");

                entity.Property(e => e.TypeId).HasColumnType("int(11)");

                entity.Property(e => e.TypeName).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.HasMany(d => d.Errors)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "Usererror",
                        l => l.HasOne<Error>().WithMany().HasForeignKey("ErrorId").HasConstraintName("Constr_UserError_Error"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("Constr_UserError_user"),
                        j =>
                        {
                            j.HasKey("UserId", "ErrorId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("usererror");

                            j.HasIndex(new[] { "ErrorId" }, "Constr_UserError_Error");

                            j.IndexerProperty<int>("UserId").HasColumnType("int(11)");

                            j.IndexerProperty<int>("ErrorId").HasColumnType("int(11)");
                        });
            });

            modelBuilder.Entity<Userprofile>(entity =>
            {
                entity.HasKey(e => e.ProfileId)
                    .HasName("PRIMARY");

                entity.ToTable("userprofile");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.ProfileId).HasColumnType("int(11)");

                entity.Property(e => e.Budget).HasPrecision(11, 2);

                entity.Property(e => e.MonthlySalary).HasPrecision(11, 2);

                entity.Property(e => e.Savings).HasPrecision(11, 2);

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userprofiles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userprofile_ibfk_1");
            });

            modelBuilder.Entity<Vwbill>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwbills");

                entity.Property(e => e.AmountDue).HasPrecision(15, 2);

                entity.Property(e => e.BillId).HasColumnType("int(11)");

                entity.Property(e => e.BillName).HasMaxLength(255);

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Vwcomment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwcomments");

                entity.Property(e => e.CommentBody).HasMaxLength(255);

                entity.Property(e => e.CommentId).HasColumnType("int(11)");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.ParentId).HasColumnType("int(11)");

                entity.Property(e => e.TypeId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Vwcompany>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwcompanies");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Vwerror>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwerrors");

                entity.Property(e => e.ErrorCode).HasColumnType("int(11)");

                entity.Property(e => e.ErrorId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ErrorLine).HasColumnType("int(11)");

                entity.Property(e => e.ErrorMessage).HasColumnType("text");

                entity.Property(e => e.StackTrace).HasColumnType("text");

                entity.Property(e => e.UsersCount).HasColumnType("bigint(21)");
            });

            modelBuilder.Entity<Vwloan>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwloans");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.LoanId).HasColumnType("int(11)");

                entity.Property(e => e.LoanName).HasMaxLength(255);

                entity.Property(e => e.MonthlyAmountDue).HasPrecision(11, 2);

                entity.Property(e => e.RemainingAmount).HasPrecision(11, 2);

                entity.Property(e => e.TotalAmountDue).HasPrecision(11, 2);

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Vwmiscellaneou>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwmiscellaneous");

                entity.Property(e => e.Amount).HasPrecision(11, 2);

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.DateAdded).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.MiscellaneousId).HasColumnType("int(11)");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Vwpost>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwposts");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.PostBody).HasMaxLength(255);

                entity.Property(e => e.PostId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Vwreply>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwreplies");

                entity.Property(e => e.CommentId).HasColumnType("int(11)");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.ReplyBody).HasMaxLength(255);

                entity.Property(e => e.ReplyId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Vwsubscription>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwsubscriptions");

                entity.Property(e => e.AmountDue).HasPrecision(11, 2);

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.SubscriptionId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Vwsuggestion>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwsuggestions");

                entity.Property(e => e.ApproveDenyBy).HasColumnType("int(11)");

                entity.Property(e => e.AuthorFirstName).HasMaxLength(255);

                entity.Property(e => e.AuthorId).HasColumnType("int(11)");

                entity.Property(e => e.AuthorLastName).HasMaxLength(255);

                entity.Property(e => e.DateSubmitted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.DenyReason).HasColumnType("text");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.SuggestBody).HasColumnType("text");

                entity.Property(e => e.SuggestHeader).HasMaxLength(255);

                entity.Property(e => e.SuggestionId).HasColumnType("int(11)");

                entity.Property(e => e.SuggestionOption).HasColumnType("int(11)");

                entity.Property(e => e.WaitingOption).HasMaxLength(255);
            });

            modelBuilder.Entity<Vwuser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwusers");

                entity.Property(e => e.Budget).HasPrecision(11, 2);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.MonthlySalary).HasPrecision(11, 2);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.Property(e => e.ProfileId).HasColumnType("int(11)");

                entity.Property(e => e.Savings).HasPrecision(11, 2);

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Watingoption>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("PRIMARY");

                entity.ToTable("watingoptions");

                entity.Property(e => e.OptionId).HasColumnType("int(11)");

                entity.Property(e => e.WaitingOption).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
