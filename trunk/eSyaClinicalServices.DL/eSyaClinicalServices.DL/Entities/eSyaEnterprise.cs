﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HCP.ClinicalServices.DL.Entities
{
    public partial class eSyaEnterprise : DbContext
    {
        public static string _connString = "";
        public eSyaEnterprise()
        {
        }

        public eSyaEnterprise(DbContextOptions<eSyaEnterprise> options)
            : base(options)
        {
        }

        public virtual DbSet<GtAddrin> GtAddrin { get; set; }
        public virtual DbSet<GtEadsfi> GtEadsfi { get; set; }
        public virtual DbSet<GtEaflin> GtEaflin { get; set; }
        public virtual DbSet<GtEcapcd> GtEcapcd { get; set; }
        public virtual DbSet<GtEcapct> GtEcapct { get; set; }
        public virtual DbSet<GtEcbsen> GtEcbsen { get; set; }
        public virtual DbSet<GtEcbsln> GtEcbsln { get; set; }
        public virtual DbSet<GtEcbssg> GtEcbssg { get; set; }
        public virtual DbSet<GtEccncd> GtEccncd { get; set; }
        public virtual DbSet<GtEccnsd> GtEccnsd { get; set; }
        public virtual DbSet<GtEccuco> GtEccuco { get; set; }
        public virtual DbSet<GtEcparm> GtEcparm { get; set; }
        public virtual DbSet<GtEcsupa> GtEcsupa { get; set; }
        public virtual DbSet<GtEscdst> GtEscdst { get; set; }
        public virtual DbSet<GtEsclsl> GtEsclsl { get; set; }
        public virtual DbSet<GtEsclst> GtEsclst { get; set; }
        public virtual DbSet<GtEscsst> GtEscsst { get; set; }
        public virtual DbSet<GtEsctsp> GtEsctsp { get; set; }
        public virtual DbSet<GtEsdoab> GtEsdoab { get; set; }
        public virtual DbSet<GtEsdoad> GtEsdoad { get; set; }
        public virtual DbSet<GtEsdobl> GtEsdobl { get; set; }
        public virtual DbSet<GtEsdocd> GtEsdocd { get; set; }
        public virtual DbSet<GtEsdocl> GtEsdocl { get; set; }
        public virtual DbSet<GtEsdodx> GtEsdodx { get; set; }
        public virtual DbSet<GtEsdoim> GtEsdoim { get; set; }
        public virtual DbSet<GtEsdold> GtEsdold { get; set; }
        public virtual DbSet<GtEsdoro> GtEsdoro { get; set; }
        public virtual DbSet<GtEsdos1> GtEsdos1 { get; set; }
        public virtual DbSet<GtEsdos2> GtEsdos2 { get; set; }
        public virtual DbSet<GtEsdosc> GtEsdosc { get; set; }
        public virtual DbSet<GtEsdosd> GtEsdosd { get; set; }
        public virtual DbSet<GtEsdosp> GtEsdosp { get; set; }
        public virtual DbSet<GtEsopcl> GtEsopcl { get; set; }
        public virtual DbSet<GtEspasm> GtEspasm { get; set; }
        public virtual DbSet<GtEsspbl> GtEsspbl { get; set; }
        public virtual DbSet<GtEsspcd> GtEsspcd { get; set; }
        public virtual DbSet<GtEsspcl> GtEsspcl { get; set; }
        public virtual DbSet<GtEsspct> GtEsspct { get; set; }
        public virtual DbSet<GtEsspmc> GtEsspmc { get; set; }
        public virtual DbSet<GtEssppa> GtEssppa { get; set; }
        public virtual DbSet<GtEsspun> GtEsspun { get; set; }
        public virtual DbSet<GtEssrms> GtEssrms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<GtAddrin>(entity =>
            {
                entity.HasKey(e => new { e.Isdcode, e.StateCode, e.CityCode, e.Zipcode, e.ZipserialNumber });

                entity.ToTable("GT_ADDRIN");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZipserialNumber).HasColumnName("ZIPSerialNumber");

                entity.Property(e => e.Area).HasMaxLength(250);

                entity.Property(e => e.CityDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.StateDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Zipdesc)
                    .HasColumnName("ZIPDesc")
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<GtEadsfi>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.RoomNo });

                entity.ToTable("GT_EADSFI");

                entity.Property(e => e.RoomNo).HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FloorId).HasColumnName("FloorID");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEaflin>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.RoomNo });

                entity.ToTable("GT_EAFLIN");

                entity.Property(e => e.RoomNo).HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FloorId).HasColumnName("FloorID");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcapcd>(entity =>
            {
                entity.HasKey(e => e.ApplicationCode)
                    .HasName("PK_GT_ECAPCD_1");

                entity.ToTable("GT_ECAPCD");

                entity.Property(e => e.ApplicationCode).ValueGeneratedNever();

                entity.Property(e => e.CodeDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ShortCode).HasMaxLength(15);

                entity.HasOne(d => d.CodeTypeNavigation)
                    .WithMany(p => p.GtEcapcd)
                    .HasForeignKey(d => d.CodeType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECAPCD_GT_ECAPCT");
            });

            modelBuilder.Entity<GtEcapct>(entity =>
            {
                entity.HasKey(e => e.CodeType);

                entity.ToTable("GT_ECAPCT");

                entity.Property(e => e.CodeType).ValueGeneratedNever();

                entity.Property(e => e.CodeTyepDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CodeTypeControl)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcbsen>(entity =>
            {
                entity.HasKey(e => e.BusinessId);

                entity.ToTable("GT_ECBSEN");

                entity.Property(e => e.BusinessId)
                    .HasColumnName("BusinessID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BusinessDesc)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.BusinessUnitType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcbsln>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.SegmentId })
                    .HasName("PK_GT_ECBSLN_1");

                entity.ToTable("GT_ECBSLN");

                entity.HasIndex(e => e.BusinessKey)
                    .HasName("IX_GT_ECBSLN")
                    .IsUnique();

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.EActiveUsers)
                    .IsRequired()
                    .HasColumnName("eActiveUsers");

                entity.Property(e => e.EBusinessKey)
                    .IsRequired()
                    .HasColumnName("eBusinessKey");

                entity.Property(e => e.ENoOfBeds).HasColumnName("eNoOfBeds");

                entity.Property(e => e.ESyaLicenseType)
                    .IsRequired()
                    .HasColumnName("eSyaLicenseType")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EUserLicenses)
                    .IsRequired()
                    .HasColumnName("eUserLicenses");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LocationDescription)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TocurrConversion).HasColumnName("TOCurrConversion");

                entity.Property(e => e.TolocalCurrency)
                    .IsRequired()
                    .HasColumnName("TOLocalCurrency")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TorealCurrency).HasColumnName("TORealCurrency");
            });

            modelBuilder.Entity<GtEcbssg>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.SegmentId });

                entity.ToTable("GT_ECBSSG");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OrgnDateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SegmentDesc)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.GtEcbssg)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECBSSG_GT_ECBSEN");
            });

            modelBuilder.Entity<GtEccncd>(entity =>
            {
                entity.HasKey(e => e.Isdcode);

                entity.ToTable("GT_ECCNCD");

                entity.Property(e => e.Isdcode)
                    .HasColumnName("ISDCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.CountryFlag)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.DateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsPinapplicable).HasColumnName("IsPINApplicable");

                entity.Property(e => e.IsPoboxApplicable).HasColumnName("IsPOBoxApplicable");

                entity.Property(e => e.MobileNumberPattern)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.PincodePattern)
                    .HasColumnName("PINcodePattern")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PoboxPattern)
                    .HasColumnName("POBoxPattern")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Uidlabel)
                    .HasColumnName("UIDLabel")
                    .HasMaxLength(50);

                entity.Property(e => e.Uidpattern)
                    .HasColumnName("UIDPattern")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<GtEccnsd>(entity =>
            {
                entity.HasKey(e => new { e.Isdcode, e.StatutoryCode });

                entity.ToTable("GT_ECCNSD");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.StatPattern)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.StatShortCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StatutoryDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IsdcodeNavigation)
                    .WithMany(p => p.GtEccnsd)
                    .HasForeignKey(d => d.Isdcode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECCNSD_GT_ECCNCD");
            });

            modelBuilder.Entity<GtEccuco>(entity =>
            {
                entity.HasKey(e => e.CurrencyCode);

                entity.ToTable("GT_ECCUCO");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.DecimalPlaces).HasColumnType("decimal(2, 0)");

                entity.Property(e => e.DecimalPortionWord).HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<GtEcparm>(entity =>
            {
                entity.HasKey(e => new { e.ParameterType, e.ParameterId });

                entity.ToTable("GT_ECPARM");

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ParameterDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParameterValueType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEcsupa>(entity =>
            {
                entity.HasKey(e => new { e.Isdcode, e.StatutoryCode, e.ParameterId });

                entity.ToTable("GT_ECSUPA");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEscdst>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ServiceId, e.RateType, e.DoctorId, e.CurrencyCode, e.EffectiveDate })
                    .HasName("PK_GT_ESCDST_1");

                entity.ToTable("GT_ESCDST");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.CurrencyCode).HasMaxLength(4);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EffectiveTill).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Tariff).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEsclsl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ClinicId, e.ConsultationId, e.ServiceId });

                entity.ToTable("GT_ESCLSL");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsclst>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ClinicId, e.ConsultationId, e.ServiceId, e.RateType, e.CurrencyCode, e.EffectiveDate });

                entity.ToTable("GT_ESCLST");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.CurrencyCode).HasMaxLength(4);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EffectiveTill).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Tariff).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEscsst>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ServiceId, e.RateType, e.SpecialtyId, e.CurrencyCode, e.EffectiveDate });

                entity.ToTable("GT_ESCSST");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.CurrencyCode).HasMaxLength(4);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EffectiveTill).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Tariff).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEsctsp>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId, e.ClinicId, e.ConsultationId, e.ServiceId, e.RateType, e.CurrencyCode, e.EffectiveDate });

                entity.ToTable("GT_ESCTSP");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.CurrencyCode).HasMaxLength(4);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EffectiveTill).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Tariff).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEsdoab>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.ToTable("GT_ESDOAB");

                entity.Property(e => e.DoctorId)
                    .HasColumnName("DoctorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AboutDoctor).IsRequired();

                entity.Property(e => e.CertificationCourse)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorRemarks)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Experience)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageKnown)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsdoad>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.DoctorId, e.Isdcode });

                entity.ToTable("GT_ESDOAD");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.Area).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Pobox)
                    .HasColumnName("POBox")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZipserialNumber).HasColumnName("ZIPSerialNumber");
            });

            modelBuilder.Entity<GtEsdobl>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.BusinessKey });

                entity.ToTable("GT_ESDOBL");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsdocd>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.ToTable("GT_ESDOCD");

                entity.Property(e => e.DoctorId)
                    .HasColumnName("DoctorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowSms).HasColumnName("AllowSMS");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorRegnNo)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.DoctorShortName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.TraiffFrom)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<GtEsdocl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId, e.DoctorId, e.ClinicId })
                    .HasName("PK_GT_ESDOCL_1");

                entity.ToTable("GT_ESDOCL");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsdodx>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.ToTable("GT_ESDODX");

                entity.Property(e => e.DoctorId)
                    .HasColumnName("DoctorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoxyMeUrl)
                    .IsRequired()
                    .HasColumnName("DoxyMeURL")
                    .HasMaxLength(250);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsdoim>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.ToTable("GT_ESDOIM");

                entity.Property(e => e.DoctorId)
                    .HasColumnName("DoctorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorImage)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.DoctorSignature)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsdold>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.OnLeaveFrom, e.OnLeaveTill });

                entity.ToTable("GT_ESDOLD");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.OnLeaveFrom).HasColumnType("datetime");

                entity.Property(e => e.OnLeaveTill).HasColumnType("datetime");

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.GtEsdold)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOLD_GT_ESDOCD");
            });

            modelBuilder.Entity<GtEsdoro>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ClinicId, e.ConsultationId, e.ServiceId, e.DoctorId, e.RateType, e.CurrencyCode, e.EffectiveDate });

                entity.ToTable("GT_ESDORO");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.CurrencyCode).HasMaxLength(4);

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EffectiveTill).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Tariff).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEsdos1>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ConsultationId, e.ClinicId, e.SpecialtyId, e.DoctorId, e.DayOfWeek, e.SerialNo });

                entity.ToTable("GT_ESDOS1");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.DayOfWeek).HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.RoomNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.GtEsdos1)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOS1_GT_ESDOCD");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.GtEsdos1)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOS1_GT_ESSPCD");
            });

            modelBuilder.Entity<GtEsdos2>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ConsultationId, e.ClinicId, e.SpecialtyId, e.DoctorId, e.DayOfWeek, e.SerialNo })
                    .HasName("PK_GT_ESDOS2_1");

                entity.ToTable("GT_ESDOS2");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.DayOfWeek).HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Xlreference)
                    .IsRequired()
                    .HasColumnName("XLReference")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.GtEsdos2)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOS2_GT_ESDOCD");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.GtEsdos2)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOS2_GT_ESSPCD");
            });

            modelBuilder.Entity<GtEsdosc>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ConsultationId, e.ClinicId, e.SpecialtyId, e.DoctorId, e.ScheduleChangeDate });

                entity.ToTable("GT_ESDOSC");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.ScheduleChangeDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.GtEsdosc)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOSC_GT_ESDOCD");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.GtEsdosc)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESDOSC_GT_ESSPCD");
            });

            modelBuilder.Entity<GtEsdosd>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.Isdcode, e.StatutoryCode, e.EffectiveFrom })
                    .HasName("PK_GT_ESDOSD_1");

                entity.ToTable("GT_ESDOSD");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EffectiveTill).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.StatutoryDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TaxPerc).HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<GtEsdosp>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId, e.DoctorId })
                    .HasName("PK_GT_ESDOSP_1");

                entity.ToTable("GT_ESDOSP");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsopcl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.ClinicId, e.ConsultationId });

                entity.ToTable("GT_ESOPCL");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEspasm>(entity =>
            {
                entity.HasKey(e => new { e.ServiceId, e.ParameterId });

                entity.ToTable("GT_ESPASM");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ParmDesc)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ParmPerc).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.ParmValue).HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.GtEspasm)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ESPASM_GT_ESSRMS");
            });

            modelBuilder.Entity<GtEsspbl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId })
                    .HasName("PK_GT_ESSPBL_1");

                entity.ToTable("GT_ESSPBL");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEsspcd>(entity =>
            {
                entity.HasKey(e => e.SpecialtyId);

                entity.ToTable("GT_ESSPCD");

                entity.Property(e => e.SpecialtyId)
                    .HasColumnName("SpecialtyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlliedServices)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MedicalIcon).HasMaxLength(150);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.SpecialtyDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SpecialtyType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEsspcl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId, e.DayOfWeek });

                entity.ToTable("GT_ESSPCL");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.DayOfWeek)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ip).HasColumnName("IP");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Op).HasColumnName("OP");

                entity.Property(e => e.Ot).HasColumnName("OT");
            });

            modelBuilder.Entity<GtEsspct>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId, e.ClinicId, e.RateType, e.ClinicType, e.EffectiveFrom });

                entity.ToTable("GT_ESSPCT");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.ClinicId).HasColumnName("ClinicID");

                entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");

                entity.Property(e => e.ConsultationTariff).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EffectiveTill).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.RevisitConsultationTariff).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.SecRevisitConsultationTariff).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ServiceRule)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TeleConsultationTariff).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEsspmc>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId })
                    .HasName("PK_GT_ESSPMC_1");

                entity.ToTable("GT_ESSPMC");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEssppa>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId, e.ParameterId });

                entity.ToTable("GT_ESSPPA");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ParmDesc)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ParmPerc).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.ParmValue).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEsspun>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.SpecialtyId, e.EffectiveFrom });

                entity.ToTable("GT_ESSPUN");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEssrms>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("GT_ESSRMS");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("ServiceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.InternalServiceCode).HasMaxLength(15);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ServiceClassId).HasColumnName("ServiceClassID");

                entity.Property(e => e.ServiceCost).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.ServiceDesc)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.ServiceShortDesc)
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });
        }
    }
}
