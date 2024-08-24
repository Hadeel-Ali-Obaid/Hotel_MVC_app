using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AboutusElement> AboutusElements { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<ContactusElement> ContactusElements { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<HomepageElement> HomepageElements { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelImage> HotelImages { get; set; }

    public virtual DbSet<PaymentDatum> PaymentData { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomFacility> RoomFacilities { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION= (ADDRESS=(PROTOCOL=TCP) (HOST=localhost) (PORT=1521)) (CONNECT_DATA=(SID=xe))); User Id=C##HADEEL1;Password=Test321;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("C##HADEEL1")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<AboutusElement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008994");

            entity.ToTable("ABOUTUS_ELEMENTS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Article1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE1");
            entity.Property(e => e.Article2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE2");
            entity.Property(e => e.Article3)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE3");
            entity.Property(e => e.Article4)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE4");
            entity.Property(e => e.Article5)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE5");
            entity.Property(e => e.HeaderImgPath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HEADER_IMG_PATH");
            entity.Property(e => e.HeaderQuoteAr)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_AR");
            entity.Property(e => e.HeaderQuoteEn)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_EN");
            entity.Property(e => e.HeaderQuoteHeadAr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_HEAD_AR");
            entity.Property(e => e.HeaderQuoteHeadEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_HEAD_EN");
            entity.Property(e => e.ImgPath1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_1");
            entity.Property(e => e.ImgPath10)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_10");
            entity.Property(e => e.ImgPath2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_2");
            entity.Property(e => e.ImgPath3)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_3");
            entity.Property(e => e.ImgPath4)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_4");
            entity.Property(e => e.ImgPath5)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_5");
            entity.Property(e => e.ImgPath6)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_6");
            entity.Property(e => e.ImgPath7)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_7");
            entity.Property(e => e.ImgPath8)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_8");
            entity.Property(e => e.ImgPath9)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_9");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C009038");

            entity.ToTable("CITY");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.CityImagePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CITY_IMAGE_PATH");
            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CITY_NAME");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008984");

            entity.ToTable("CONTACT_US");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Case)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CASE");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.ContactUs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_CONTACT_US_USER_ID");
        });

        modelBuilder.Entity<ContactusElement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008992");

            entity.ToTable("CONTACTUS_ELEMENTS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Article1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE1");
            entity.Property(e => e.Article2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE2");
            entity.Property(e => e.Article3)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE3");
            entity.Property(e => e.Article4)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE4");
            entity.Property(e => e.Article5)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE5");
            entity.Property(e => e.HeaderImgPath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HEADER_IMG_PATH");
            entity.Property(e => e.HeaderQuoteAr)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_AR");
            entity.Property(e => e.HeaderQuoteEn)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_EN");
            entity.Property(e => e.HeaderQuoteHeadAr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_HEAD_AR");
            entity.Property(e => e.HeaderQuoteHeadEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_HEAD_EN");
            entity.Property(e => e.ImgPath1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_1");
            entity.Property(e => e.ImgPath10)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_10");
            entity.Property(e => e.ImgPath2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_2");
            entity.Property(e => e.ImgPath3)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_3");
            entity.Property(e => e.ImgPath4)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_4");
            entity.Property(e => e.ImgPath5)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_5");
            entity.Property(e => e.ImgPath6)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_6");
            entity.Property(e => e.ImgPath7)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_7");
            entity.Property(e => e.ImgPath8)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_8");
            entity.Property(e => e.ImgPath9)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_9");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C009086");

            entity.ToTable("EVENTS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.HotelId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("HOTEL_ID");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMAGE_PATH");
            entity.Property(e => e.UserLoginId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USER_LOGIN_ID");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Events)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_EVENTS_HOTEL_ID");

            entity.HasOne(d => d.UserLogin).WithMany(p => p.Events)
                .HasForeignKey(d => d.UserLoginId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_EVENTS_USER_LOGIN_ID");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C009065");

            entity.ToTable("FACILITIES");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.FacilityName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FACILITY_NAME");
        });

        modelBuilder.Entity<HomepageElement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C009004");

            entity.ToTable("HOMEPAGE_ELEMENTS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Article1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE1");
            entity.Property(e => e.Article2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE2");
            entity.Property(e => e.Article3)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE3");
            entity.Property(e => e.Article4)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE4");
            entity.Property(e => e.Article5)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE5");
            entity.Property(e => e.Article6)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ARTICLE6");
            entity.Property(e => e.ChefName1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CHEF_NAME_1");
            entity.Property(e => e.ChefName2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CHEF_NAME_2");
            entity.Property(e => e.ChefName3)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CHEF_NAME_3");
            entity.Property(e => e.ChefName4)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CHEF_NAME_4");
            entity.Property(e => e.HeaderH1Text)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HEADER_H1_TEXT");
            entity.Property(e => e.HeaderIconClass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HEADER_ICON_CLASS");
            entity.Property(e => e.HeaderImgPath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HEADER_IMG_PATH");
            entity.Property(e => e.HeaderQuoteAr)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_AR");
            entity.Property(e => e.HeaderQuoteEn)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_EN");
            entity.Property(e => e.HeaderQuoteHeadAr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_HEAD_AR");
            entity.Property(e => e.HeaderQuoteHeadEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HEADER_QUOTE_HEAD_EN");
            entity.Property(e => e.ImgPath1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_1");
            entity.Property(e => e.ImgPath10)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_10");
            entity.Property(e => e.ImgPath2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_2");
            entity.Property(e => e.ImgPath3)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_3");
            entity.Property(e => e.ImgPath4)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_4");
            entity.Property(e => e.ImgPath5)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_5");
            entity.Property(e => e.ImgPath6)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_6");
            entity.Property(e => e.ImgPath7)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_7");
            entity.Property(e => e.ImgPath8)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_8");
            entity.Property(e => e.ImgPath9)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMG_PATH_9");
            entity.Property(e => e.TestimonialArticle1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TESTIMONIAL_ARTICLE_1");
            entity.Property(e => e.TestimonialArticle2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TESTIMONIAL_ARTICLE_2");
            entity.Property(e => e.TestimonialArticle3)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TESTIMONIAL_ARTICLE_3");
            entity.Property(e => e.TestimonialArticle4)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TESTIMONIAL_ARTICLE_4");
            entity.Property(e => e.TestimonialImgPath1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TESTIMONIAL_IMG_PATH_1");
            entity.Property(e => e.TestimonialImgPath2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TESTIMONIAL_IMG_PATH_2");
            entity.Property(e => e.TestimonialImgPath3)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TESTIMONIAL_IMG_PATH_3");
            entity.Property(e => e.TestimonialImgPath4)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("TESTIMONIAL_IMG_PATH_4");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C009044");

            entity.ToTable("HOTELS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.CityId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CITY_ID");
            entity.Property(e => e.Discription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DISCRIPTION");
            entity.Property(e => e.Gym)
                .HasPrecision(1)
                .HasDefaultValueSql("0")
                .HasColumnName("GYM");
            entity.Property(e => e.HotelName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HOTEL_NAME");
            entity.Property(e => e.Hottub)
                .HasPrecision(1)
                .HasDefaultValueSql("0")
                .HasColumnName("HOTTUB");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMAGE_PATH");
            entity.Property(e => e.Location)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Parking)
                .HasPrecision(1)
                .HasDefaultValueSql("0")
                .HasColumnName("PARKING");
            entity.Property(e => e.Policies)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("POLICIES");
            entity.Property(e => e.Pool)
                .HasPrecision(1)
                .HasDefaultValueSql("0")
                .HasColumnName("POOL");
            entity.Property(e => e.Rate)
                .HasColumnType("NUMBER")
                .HasColumnName("RATE");
            entity.Property(e => e.TotalRooms)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTAL_ROOMS");
            entity.Property(e => e.Wifi)
                .HasPrecision(1)
                .HasDefaultValueSql("0")
                .HasColumnName("WIFI");

            entity.HasOne(d => d.City).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_HOTEL_CITY_ID");
        });

        modelBuilder.Entity<HotelImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C009048");

            entity.ToTable("HOTEL_IMAGES");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.HotelId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("HOTEL_ID");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMAGE_PATH");

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelImages)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_HOTEL_ID");
        });

        modelBuilder.Entity<PaymentDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008952");

            entity.ToTable("PAYMENT_DATA");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Balance)
                .HasColumnType("NUMBER")
                .HasColumnName("BALANCE");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CARD_NUMBER");
            entity.Property(e => e.CardProvider)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CARD_PROVIDER");
            entity.Property(e => e.ExpirationDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EXPIRATION_DATE");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C009093");

            entity.ToTable("ROOMS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.HotelId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("HOTEL_ID");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMAGE_PATH");
            entity.Property(e => e.NumberOfBeds)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NUMBER_OF_BEDS");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER")
                .HasColumnName("PRICE");
            entity.Property(e => e.RoomName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ROOM_NAME");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UserLoginId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USER_LOGIN_ID");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_ROOMS_HOTEL_ID");

            entity.HasOne(d => d.UserLogin).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.UserLoginId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_ROOMS_USER_LOGIN_ID");
        });

        modelBuilder.Entity<RoomFacility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C009097");

            entity.ToTable("ROOM_FACILITIES");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.FacilityId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("FACILITY_ID");
            entity.Property(e => e.RoomId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROOM_ID");

            entity.HasOne(d => d.Facility).WithMany(p => p.RoomFacilities)
                .HasForeignKey(d => d.FacilityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_ROOM_FACILITIES_FACILITY_ID");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomFacilities)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_ROOM_FACILITIES_ROOM_ID");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008987");

            entity.ToTable("TESTIMONIAL");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Case)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CASE");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_TESTIMONIAL_USER_ID");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008956");

            entity.ToTable("USER_LOGIN");

            entity.HasIndex(e => e.Username, "SYS_C008957").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.PaymentId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PAYMENT_ID");
            entity.Property(e => e.RoleId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROLE_ID");
            entity.Property(e => e.UserProfileId)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("USER_PROFILE_ID");
            entity.Property(e => e.Username)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Payment).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_USER_LOGIN_PAYMENT_ID");

            entity.HasOne(d => d.Role).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_USER_LOGIN_USER_ROLE_ID");

            entity.HasOne(d => d.UserProfile).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_USER_LOGIN_USER_PROFILE_ID");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008945");

            entity.ToTable("USER_PROFILE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMAGE_PATH");
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008948");

            entity.ToTable("USER_ROLE");

            entity.HasIndex(e => e.RoleName, "SYS_C008949").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ROLE_NAME");
        });
        modelBuilder.HasSequence("ID_1").IncrementsBy(2);
        modelBuilder.HasSequence("ID_2").IncrementsBy(-2);
        modelBuilder.HasSequence("ISEQ$$_79289");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
