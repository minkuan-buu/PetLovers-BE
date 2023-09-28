﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Entities
{
    public partial class PetLoversDbContext : DbContext
    {
        public PetLoversDbContext()
        {
        }

        public PetLoversDbContext(DbContextOptions<PetLoversDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblNotification> TblNotifications { get; set; } = null!;
        public virtual DbSet<TblPost> TblPosts { get; set; } = null!;
        public virtual DbSet<TblPostReaction> TblPostReactions { get; set; } = null!;
        public virtual DbSet<TblPostStored> TblPostStoreds { get; set; } = null!;
        public virtual DbSet<TblReport> TblReports { get; set; } = null!;
        public virtual DbSet<TblReward> TblRewards { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblTradeRequest> TblTradeRequests { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
        public virtual DbSet<TblUserFollowing> TblUserFollowings { get; set; } = null!;
        public virtual DbSet<TblUserReward> TblUserRewards { get; set; } = null!;
        public virtual DbSet<TblUserTimeout> TblUserTimeouts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-6Q8041M\\SQLEXPRESS;Initial Catalog=PetLovers;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblNotification>(entity =>
            {
                entity.ToTable("tblNotification");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Content)
                    .HasMaxLength(100)
                    .HasColumnName("content");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.TradeId).HasColumnName("tradeId");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateAt");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TblNotifications)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__tblNotifi__postI__49C3F6B7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblNotifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblNotifi__userI__5441852A");
            });

            modelBuilder.Entity<TblPost>(entity =>
            {
                entity.ToTable("tblPost");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("attachment");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.Hashtag)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hashtag");

                entity.Property(e => e.IsFree).HasColumnName("isFree");

                entity.Property(e => e.IsProcessed).HasColumnName("isProcessed");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateAt");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblPosts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPost__userId__4BAC3F29");
            });

            modelBuilder.Entity<TblPostReaction>(entity =>
            {
                entity.ToTable("tblPostReaction");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("attachment");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.TypeReact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("typeReact");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateAt");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TblPostReactions)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPostRe__postI__4AB81AF0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblPostReactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPostRe__userI__52593CB8");
            });

            modelBuilder.Entity<TblPostStored>(entity =>
            {
                entity.ToTable("tblPostStored");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateAt).HasColumnName("createAt");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TblPostStoreds)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPostSt__postI__4E88ABD4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblPostStoreds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPostSt__userI__4CA06362");
            });

            modelBuilder.Entity<TblReport>(entity =>
            {
                entity.ToTable("tblReport");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CommentId).HasColumnName("commentId");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.IsProcessed).HasColumnName("isProcessed");

                entity.Property(e => e.ModeratorId).HasColumnName("moderatorId");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.Reason)
                    .HasMaxLength(200)
                    .HasColumnName("reason");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.TblReports)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK__tblReport__comme__46E78A0C");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TblReports)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__tblReport__postI__45F365D3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblReports)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblReport__userI__44FF419A");
            });

            modelBuilder.Entity<TblReward>(entity =>
            {
                entity.ToTable("tblReward");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TotalComment).HasColumnName("totalComment");

                entity.Property(e => e.TotalPost).HasColumnName("totalPost");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.ToTable("tblRole");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TblTradeRequest>(entity =>
            {
                entity.ToTable("tblTradeRequest");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.IsProcessed).HasColumnName("isProcessed");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateAt");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TblTradeRequests)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblTradeR__postI__5629CD9C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblTradeRequests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblTradeR__userI__47DBAE45");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tblUser");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateAt");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUser__roleId__4D94879B");
            });

            modelBuilder.Entity<TblUserFollowing>(entity =>
            {
                entity.ToTable("tblUserFollowing");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FollowerId).HasColumnName("followerId");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Follower)
                    .WithMany(p => p.TblUserFollowingFollowers)
                    .HasForeignKey(d => d.FollowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUserFo__follo__4F7CD00D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserFollowingUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUserFo__userI__5165187F");
            });

            modelBuilder.Entity<TblUserReward>(entity =>
            {
                entity.ToTable("tblUserReward");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateAt).HasColumnName("createAt");

                entity.Property(e => e.RewardId).HasColumnName("rewardId");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Reward)
                    .WithMany(p => p.TblUserRewards)
                    .HasForeignKey(d => d.RewardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUserRe__rewar__5070F446");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserRewards)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUserRe__userI__5535A963");
            });

            modelBuilder.Entity<TblUserTimeout>(entity =>
            {
                entity.ToTable("tblUserTimeout");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.ExpiredAt)
                    .HasColumnType("datetime")
                    .HasColumnName("expiredAt");

                entity.Property(e => e.ModeratorId).HasColumnName("moderatorId");

                entity.Property(e => e.Reason).HasColumnName("reason");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Moderator)
                    .WithMany(p => p.TblUserTimeoutModerators)
                    .HasForeignKey(d => d.ModeratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUserTi__moder__48CFD27E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserTimeoutUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUserTi__userI__534D60F1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
