using CParts.Domain.Abstractions;
using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data
{
    public partial class PartsDataDbContext : DbContext, IPartsDataDbContext
    {
        public virtual DbSet<ArticleCriteria> ArticleCriteria { get; set; }
        public virtual DbSet<ArticleInfo> ArticleInfo { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArtLookup> ArtLookup { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryDesignation> CountryDesignations { get; set; }
        public virtual DbSet<Criteria> Criterias { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<DesText> DesTexts { get; set; }
        public virtual DbSet<DesTextOriginal> DesTextsOriginal { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }
        public virtual DbSet<Graphic> Graphics { get; set; }
        public virtual DbSet<LaCriteria> LaCriterias { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LinkArt> LinkArts { get; set; }
        public virtual DbSet<LinkGaStr> LinkGaStrs { get; set; }
        public virtual DbSet<LinkGraArt> LinkGraArts { get; set; }
        public virtual DbSet<LinkLaTyp> LinkLaTyps { get; set; }
        public virtual DbSet<LinkTypEng> LinkTypEngs { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<SearchTree> SearchTrees { get; set; }
        public virtual DbSet<SupplierAddress> SupplierAddresses { get; set; }
        public virtual DbSet<SupplierLogo> SupplierLogos { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<TextModule> TextModules { get; set; }
        public virtual DbSet<TextModuleText> TextModuleTexts { get; set; }
        public virtual DbSet<TypeNumber> TypeNumbers { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        public PartsDataDbContext(DbContextOptions<PartsDataDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql(
                    "server=80.179.152.184;user=mysqluser1;password=FFznrHAcM3Pn9VHYbn85;database=reseller_main");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryDesignation>(entity =>
            {
                entity.ToTable("COUNTRY_DESIGNATION");

                entity.Property(e => e.CdsId)
                    .HasColumnName("CDS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CdsLngId)
                    .HasColumnName("CDS_LNG_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CdsTexId)
                    .HasColumnName("CDS_TEX_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<ArticleCriteria>(entity =>
            {
                entity.HasKey(e => new {AcrArtId = e.Id, e.AcrGaId, e.AcrSort});

                entity.ToTable("ARTICLE_CRITERIA");

                entity.HasIndex(e => e.AcrKvDesId)
                    .HasName("ACR_KV_DES_ID");

                entity.HasIndex(e => e.AcrValue)
                    .HasName("ACR_VALUE");

                entity.Property(e => e.Id)
                    .HasColumnName("ACR_ART_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcrGaId)
                    .HasColumnName("ACR_GA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcrSort)
                    .HasColumnName("ACR_SORT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.AcrCriId)
                    .HasColumnName("ACR_CRI_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.AcrDisplay)
                    .HasColumnName("ACR_DISPLAY")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.AcrKvDesId)
                    .HasColumnName("ACR_KV_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AcrValue)
                    .HasColumnName("ACR_VALUE")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<ArticleInfo>(entity =>
            {
                entity.HasKey(e => new {e.AinArtId, e.AinGaId, e.AinSort, e.AinKvType, e.AinDisplay, e.AinTmoId});

                entity.ToTable("ARTICLE_INFO");

                entity.Property(e => e.AinArtId)
                    .HasColumnName("AIN_ART_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AinGaId)
                    .HasColumnName("AIN_GA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AinSort)
                    .HasColumnName("AIN_SORT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.AinKvType)
                    .HasColumnName("AIN_KV_TYPE")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AinDisplay)
                    .HasColumnName("AIN_DISPLAY")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AinTmoId)
                    .HasColumnName("AIN_TMO_ID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("ARTICLES");

                entity.HasIndex(e => e.ArtArticleNr)
                    .HasName("ART_ARTICLE_NR");

                entity.HasIndex(e => e.ArtCompleteDesId)
                    .HasName("ART_COMPLETE_DES_ID");

                entity.HasIndex(e => e.ArtDesId)
                    .HasName("ART_DES_ID");

                entity.HasIndex(e => e.ArtSupId)
                    .HasName("ART_SUP_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ART_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArtAccessory)
                    .HasColumnName("ART_ACCESSORY")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ArtArticleNr)
                    .IsRequired()
                    .HasColumnName("ART_ARTICLE_NR")
                    .HasMaxLength(66);

                entity.Property(e => e.ArtBatchSize1)
                    .HasColumnName("ART_BATCH_SIZE1")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArtBatchSize2)
                    .HasColumnName("ART_BATCH_SIZE2")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArtCompleteDesId)
                    .HasColumnName("ART_COMPLETE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArtDesId)
                    .HasColumnName("ART_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArtMaterialMark)
                    .HasColumnName("ART_MATERIAL_MARK")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ArtPackSelfservice)
                    .HasColumnName("ART_PACK_SELFSERVICE")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ArtReplacement)
                    .HasColumnName("ART_REPLACEMENT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ArtSupId)
                    .HasColumnName("ART_SUP_ID")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<ArtLookup>(entity =>
            {
                entity.HasKey(e => new
                {
                    ArlArtId = e.ArlArtId,
                    ArlSearchNumber = e.CatalogueCode,
                    ArlKind = e.Kind,
                    ArlBraId = e.BrandId,
                    e.ArlDisplayNr,
                    e.ArlDisplay,
                    e.ArlBlock,
                    e.ArlSort
                });

                entity.ToTable("ART_LOOKUP");

                entity.HasIndex(e => e.BrandId)
                    .HasName("ARL_BRA_ID");

                entity.HasIndex(e => new {ArlSearchNumber = e.CatalogueCode, ArlBraId = e.BrandId, ArlKind = e.Kind})
                    .HasName("ARL_SEARCH_NUMBER");

                entity.Property(e => e.ArlArtId)
                    .HasColumnName("ARL_ART_ID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CatalogueCode)
                    .HasColumnName("ARL_SEARCH_NUMBER")
                    .HasMaxLength(105)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Kind)
                    .HasColumnName("ARL_KIND")
                    .HasColumnType("binary(1)")
                    .HasDefaultValueSql("' '");

                entity.Property(e => e.BrandId)
                    .HasColumnName("ARL_BRA_ID")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ArlDisplayNr)
                    .HasColumnName("ARL_DISPLAY_NR")
                    .HasMaxLength(105)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ArlDisplay)
                    .HasColumnName("ARL_DISPLAY")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ArlBlock)
                    .HasColumnName("ARL_BLOCK")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ArlSort)
                    .HasColumnName("ARL_SORT")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BraId);

                entity.ToTable("BRANDS");

                entity.HasIndex(e => e.BraBrand)
                    .HasName("BRA_BRAND");

                entity.Property(e => e.BraId)
                    .HasColumnName("BRA_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.BraBrand)
                    .HasColumnName("BRA_BRAND")
                    .HasMaxLength(60);

                entity.Property(e => e.BraMfNr)
                    .HasColumnName("BRA_MF_NR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BraMfcCode)
                    .HasColumnName("BRA_MFC_CODE")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CouId);

                entity.ToTable("COUNTRIES");

                entity.Property(e => e.CouId)
                    .HasColumnName("COU_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CouCc)
                    .HasColumnName("COU_CC")
                    .HasMaxLength(9);

                entity.Property(e => e.CouCurrencyCode)
                    .HasColumnName("COU_CURRENCY_CODE")
                    .HasMaxLength(9);

                entity.Property(e => e.CouDesId)
                    .HasColumnName("COU_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CouIsGroup)
                    .HasColumnName("COU_IS_GROUP")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CouIso2)
                    .HasColumnName("COU_ISO2")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<Criteria>(entity =>
            {
                entity.HasKey(e => e.CriId);

                entity.ToTable("CRITERIA");

                entity.Property(e => e.CriId)
                    .HasColumnName("CRI_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CriDesId)
                    .HasColumnName("CRI_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CriIsInterval)
                    .HasColumnName("CRI_IS_INTERVAL")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CriKtId)
                    .HasColumnName("CRI_KT_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CriShortDesId)
                    .HasColumnName("CRI_SHORT_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CriSuccessor)
                    .HasColumnName("CRI_SUCCESSOR")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CriType)
                    .HasColumnName("CRI_TYPE")
                    .HasColumnType("binary(1)");

                entity.Property(e => e.CriUnitDesId)
                    .HasColumnName("CRI_UNIT_DES_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.HasKey(e => new {e.DesId, e.DesLngId});

                entity.ToTable("DESIGNATIONS");

                entity.HasIndex(e => e.DesTexId)
                    .HasName("DES_TEX_ID");

                entity.Property(e => e.DesId)
                    .HasColumnName("DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DesLngId)
                    .HasColumnName("DES_LNG_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.DesTexId)
                    .HasColumnName("DES_TEX_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<DesText>(entity =>
            {
                entity.HasKey(e => e.TexId);

                entity.ToTable("DES_TEXTS");

                entity.HasIndex(e => e.TexText)
                    .HasName("des_texts101_index02");

                entity.Property(e => e.TexId)
                    .HasColumnName("TEX_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TexText)
                    .HasColumnName("TEX_TEXT")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<DesTextOriginal>(entity =>
            {
                entity.HasKey(e => e.TexId);

                entity.ToTable("DES_TEXTS_ORIGINAL");

                entity.HasIndex(e => e.TexText)
                    .HasName("TEX_TEXT");

                entity.Property(e => e.TexId)
                    .HasColumnName("TEX_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TexText)
                    .HasColumnName("TEX_TEXT")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<DocType>(entity =>
            {
                entity.HasKey(e => e.Type);

                entity.ToTable("DOC_TYPES");

                entity.Property(e => e.Type)
                    .HasColumnName("DOC_TYPE")
                    .HasColumnType("smallint(4)");

                entity.Property(e => e.DocExtension)
                    .HasColumnName("DOC_EXTENSION")
                    .HasMaxLength(9);
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.HasKey(e => e.EngId);

                entity.ToTable("ENGINES");

                entity.Property(e => e.EngId)
                    .HasColumnName("ENG_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngCcmFrom)
                    .HasColumnName("ENG_CCM_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngCcmTaxFrom)
                    .HasColumnName("ENG_CCM_TAX_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngCcmTaxUpto)
                    .HasColumnName("ENG_CCM_TAX_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngCcmUpto)
                    .HasColumnName("ENG_CCM_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngCode)
                    .IsRequired()
                    .HasColumnName("ENG_CODE")
                    .HasMaxLength(180);

                entity.Property(e => e.EngCompressionFrom).HasColumnName("ENG_COMPRESSION_FROM");

                entity.Property(e => e.EngCompressionUpto).HasColumnName("ENG_COMPRESSION_UPTO");

                entity.Property(e => e.EngCrankshaft)
                    .HasColumnName("ENG_CRANKSHAFT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.EngCylinders)
                    .HasColumnName("ENG_CYLINDERS")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.EngDescription)
                    .HasColumnName("ENG_DESCRIPTION")
                    .HasMaxLength(90);

                entity.Property(e => e.EngDrilling).HasColumnName("ENG_DRILLING");

                entity.Property(e => e.EngExtension).HasColumnName("ENG_EXTENSION");

                entity.Property(e => e.EngHpFrom)
                    .HasColumnName("ENG_HP_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngHpUpto)
                    .HasColumnName("ENG_HP_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKvChargeDesId)
                    .HasColumnName("ENG_KV_CHARGE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKvControlDesId)
                    .HasColumnName("ENG_KV_CONTROL_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKvCoolingDesId)
                    .HasColumnName("ENG_KV_COOLING_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKvCylindersDesId)
                    .HasColumnName("ENG_KV_CYLINDERS_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKvDesignDesId)
                    .HasColumnName("ENG_KV_DESIGN_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKvEngineDesId)
                    .HasColumnName("ENG_KV_ENGINE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKvFuelSupplyDesId)
                    .HasColumnName("ENG_KV_FUEL_SUPPLY_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKvFuelTypeDesId)
                    .HasColumnName("ENG_KV_FUEL_TYPE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKvGasNormDesId)
                    .HasColumnName("ENG_KV_GAS_NORM_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKvUseDesId)
                    .HasColumnName("ENG_KV_USE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKvValveControlDesId)
                    .HasColumnName("ENG_KV_VALVE_CONTROL_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKwFrom)
                    .HasColumnName("ENG_KW_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KwRPMFrom)
                    .HasColumnName("ENG_KW_RPM_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKwRpmUpto)
                    .HasColumnName("ENG_KW_RPM_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngKwUpto)
                    .HasColumnName("ENG_KW_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngLitresFrom).HasColumnName("ENG_LITRES_FROM");

                entity.Property(e => e.EngLitresTaxFrom).HasColumnName("ENG_LITRES_TAX_FROM");

                entity.Property(e => e.EngLitresTaxUpto).HasColumnName("ENG_LITRES_TAX_UPTO");

                entity.Property(e => e.EngLitresUpto).HasColumnName("ENG_LITRES_UPTO");

                entity.Property(e => e.EngMfaId)
                    .HasColumnName("ENG_MFA_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.EngPconEnd)
                    .HasColumnName("ENG_PCON_END")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngPconStart)
                    .HasColumnName("ENG_PCON_START")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngTorqueFrom)
                    .HasColumnName("ENG_TORQUE_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngTorqueRpmFrom)
                    .HasColumnName("ENG_TORQUE_RPM_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngTorqueRpmUpto)
                    .HasColumnName("ENG_TORQUE_RPM_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngTorqueUpto)
                    .HasColumnName("ENG_TORQUE_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EngValves)
                    .HasColumnName("ENG_VALVES")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<Graphic>(entity =>
            {
                entity.HasKey(e => new {e.GraId, e.GraLngId});

                entity.ToTable("GRAPHICS");

                entity.Property(e => e.GraId)
                    .HasColumnName("GRA_ID")
                    .HasMaxLength(11);

                entity.Property(e => e.GraLngId)
                    .HasColumnName("GRA_LNG_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.GraDesId)
                    .HasColumnName("GRA_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GraDocType)
                    .HasColumnName("GRA_DOC_TYPE")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.GraGrdId)
                    .HasColumnName("GRA_GRD_ID")
                    .HasMaxLength(14);

                entity.Property(e => e.GraNorm)
                    .HasColumnName("GRA_NORM")
                    .HasMaxLength(9);

                entity.Property(e => e.GraSupId)
                    .HasColumnName("GRA_SUP_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.GraSupplierNr)
                    .HasColumnName("GRA_SUPPLIER_NR")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.GraTabNr)
                    .HasColumnName("GRA_TAB_NR")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.GraType)
                    .HasColumnName("GRA_TYPE")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<LaCriteria>(entity =>
            {
                entity.HasKey(e => new {e.LacLaId, e.LacSort});

                entity.ToTable("LA_CRITERIA");

                entity.Property(e => e.LacLaId)
                    .HasColumnName("LAC_LA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LacSort)
                    .HasColumnName("LAC_SORT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LacCriId)
                    .HasColumnName("LAC_CRI_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.LacDisplay)
                    .HasColumnName("LAC_DISPLAY")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.LacKvDesId)
                    .HasColumnName("LAC_KV_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LacValue)
                    .HasColumnName("LAC_VALUE")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.LngId);

                entity.ToTable("LANGUAGES");

                entity.Property(e => e.LngId)
                    .HasColumnName("LNG_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.LngCodepage)
                    .HasColumnName("LNG_CODEPAGE")
                    .HasMaxLength(30);

                entity.Property(e => e.LngDesId)
                    .HasColumnName("LNG_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LngIso2)
                    .HasColumnName("LNG_ISO2")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<LinkArt>(entity =>
            {
                entity.HasKey(e => e.LaId);

                entity.ToTable("LINK_ART");

                entity.HasIndex(e => e.LaArtId)
                    .HasName("LA_ART_ID");

                entity.Property(e => e.LaId)
                    .HasColumnName("LA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LaArtId)
                    .HasColumnName("LA_ART_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LaGaId)
                    .HasColumnName("LA_GA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LaSort)
                    .HasColumnName("LA_SORT")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<LinkGaStr>(entity =>
            {
                entity.HasKey(e => new {e.LgsStrId, e.LgsGaId});

                entity.ToTable("LINK_GA_STR");

                entity.Property(e => e.LgsStrId)
                    .HasColumnName("LGS_STR_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LgsGaId)
                    .HasColumnName("LGS_GA_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<LinkGraArt>(entity =>
            {
                entity.HasKey(e => new {e.LgaArtId, e.LgaSort});

                entity.ToTable("LINK_GRA_ART");

                entity.Property(e => e.LgaArtId)
                    .HasColumnName("LGA_ART_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LgaSort)
                    .HasColumnName("LGA_SORT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.LgaGraId)
                    .IsRequired()
                    .HasColumnName("LGA_GRA_ID")
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<LinkLaTyp>(entity =>
            {
                entity.HasKey(e => new {e.LatTypId, e.LatGaId, e.LatLaId, e.LatSort});

                entity.ToTable("LINK_LA_TYP");

                entity.HasIndex(e => e.LatLaId)
                    .HasName("LAT_LA_ID");

                entity.Property(e => e.LatTypId)
                    .HasColumnName("LAT_TYP_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LatGaId)
                    .HasColumnName("LAT_GA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LatLaId)
                    .HasColumnName("LAT_LA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LatSort)
                    .HasColumnName("LAT_SORT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LatSupId)
                    .HasColumnName("LAT_SUP_ID")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<LinkTypEng>(entity =>
            {
                entity.HasKey(e => new {e.LteTypId, e.LteNr, e.LteEngId});

                entity.ToTable("LINK_TYP_ENG");

                entity.Property(e => e.LteTypId)
                    .HasColumnName("LTE_TYP_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LteNr)
                    .HasColumnName("LTE_NR")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.LteEngId)
                    .HasColumnName("LTE_ENG_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LtePconEnd)
                    .HasColumnName("LTE_PCON_END")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LtePconStart)
                    .HasColumnName("LTE_PCON_START")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.MfaId);

                entity.ToTable("MANUFACTURERS");

                entity.HasIndex(e => e.MfaBrand)
                    .HasName("MFA_BRAND");

                entity.Property(e => e.MfaId)
                    .HasColumnName("MFA_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MfaAxlMfc)
                    .HasColumnName("MFA_AXL_MFC")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MfaBrand)
                    .HasColumnName("MFA_BRAND")
                    .HasMaxLength(60);

                entity.Property(e => e.MfaCvMfc)
                    .HasColumnName("MFA_CV_MFC")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MfaEngMfc)
                    .HasColumnName("MFA_ENG_MFC")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MfaEngTyp)
                    .HasColumnName("MFA_ENG_TYP")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MfaMfNr)
                    .HasColumnName("MFA_MF_NR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MfaMfcCode)
                    .HasColumnName("MFA_MFC_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.MfaPcMfc)
                    .HasColumnName("MFA_PC_MFC")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.ModId);

                entity.ToTable("MODELS");

                entity.HasIndex(e => e.ModCdsId)
                    .HasName("MOD_CDS_ID");

                entity.HasIndex(e => e.ModMfaId)
                    .HasName("MOD_MFA_ID");

                entity.Property(e => e.ModId)
                    .HasColumnName("MOD_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModAxl)
                    .HasColumnName("MOD_AXL")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ModCdsId)
                    .HasColumnName("MOD_CDS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModCv)
                    .HasColumnName("MOD_CV")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ModMfaId)
                    .HasColumnName("MOD_MFA_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ModPc)
                    .HasColumnName("MOD_PC")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ModPconEnd)
                    .HasColumnName("MOD_PCON_END")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModPconStart)
                    .HasColumnName("MOD_PCON_START")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SearchTree>(entity =>
            {
                entity.HasKey(e => e.StrId);

                entity.ToTable("SEARCH_TREE");

                entity.HasIndex(e => e.StrIdParent)
                    .HasName("STR_ID_PARENT");

                entity.HasIndex(e => e.StrLevel)
                    .HasName("STR_LEVEL");

                entity.Property(e => e.StrId)
                    .HasColumnName("STR_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrDesId)
                    .HasColumnName("STR_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrIdParent)
                    .HasColumnName("STR_ID_PARENT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrLevel)
                    .HasColumnName("STR_LEVEL")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.StrNodeNr)
                    .HasColumnName("STR_NODE_NR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StrSort)
                    .HasColumnName("STR_SORT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.StrType)
                    .HasColumnName("STR_TYPE")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<SupplierAddress>(entity =>
            {
                entity.HasKey(e => new {e.SadSupId, e.SadTypeOfAddress, e.SadCouId});

                entity.ToTable("SUPPLIER_ADDRESSES");

                entity.Property(e => e.SadSupId)
                    .HasColumnName("SAD_SUP_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SadTypeOfAddress)
                    .HasColumnName("SAD_TYPE_OF_ADDRESS")
                    .HasMaxLength(9);

                entity.Property(e => e.SadCouId)
                    .HasColumnName("SAD_COU_ID")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SadCity1)
                    .HasColumnName("SAD_CITY1")
                    .HasMaxLength(120);

                entity.Property(e => e.SadCity2)
                    .HasColumnName("SAD_CITY2")
                    .HasMaxLength(120);

                entity.Property(e => e.SadCouIdPostal)
                    .HasColumnName("SAD_COU_ID_POSTAL")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SadEmail)
                    .HasColumnName("SAD_EMAIL")
                    .HasMaxLength(180);

                entity.Property(e => e.SadFax)
                    .HasColumnName("SAD_FAX")
                    .HasMaxLength(60);

                entity.Property(e => e.SadName1)
                    .HasColumnName("SAD_NAME1")
                    .HasMaxLength(120);

                entity.Property(e => e.SadName2)
                    .HasColumnName("SAD_NAME2")
                    .HasMaxLength(120);

                entity.Property(e => e.SadPob)
                    .HasColumnName("SAD_POB")
                    .HasMaxLength(30);

                entity.Property(e => e.SadPostalCodeCust)
                    .HasColumnName("SAD_POSTAL_CODE_CUST")
                    .HasMaxLength(24);

                entity.Property(e => e.SadPostalCodePlace)
                    .HasColumnName("SAD_POSTAL_CODE_PLACE")
                    .HasMaxLength(24);

                entity.Property(e => e.SadPostalCodePob)
                    .HasColumnName("SAD_POSTAL_CODE_POB")
                    .HasMaxLength(24);

                entity.Property(e => e.SadStreet1)
                    .HasColumnName("SAD_STREET1")
                    .HasMaxLength(120);

                entity.Property(e => e.SadStreet2)
                    .HasColumnName("SAD_STREET2")
                    .HasMaxLength(120);

                entity.Property(e => e.SadTel)
                    .HasColumnName("SAD_TEL")
                    .HasMaxLength(120);

                entity.Property(e => e.SadWeb)
                    .HasColumnName("SAD_WEB")
                    .HasMaxLength(180);
            });

            modelBuilder.Entity<SupplierLogo>(entity =>
            {
                entity.HasKey(e => e.SloId);

                entity.ToTable("SUPPLIER_LOGOS");

                entity.HasIndex(e => new {e.SloSupId, e.SloLngId})
                    .HasName("SLO_SUP_ID");

                entity.Property(e => e.SloId)
                    .HasColumnName("SLO_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SloLngId)
                    .HasColumnName("SLO_LNG_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SloSupId)
                    .HasColumnName("SLO_SUP_ID")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupId);

                entity.ToTable("SUPPLIERS");

                entity.HasIndex(e => e.SupBrand)
                    .HasName("SUP_BRAND");

                entity.Property(e => e.SupId)
                    .HasColumnName("SUP_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SupBrand)
                    .HasColumnName("SUP_BRAND")
                    .HasMaxLength(60);

                entity.Property(e => e.SupCouId)
                    .HasColumnName("SUP_COU_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SupIsHess)
                    .HasColumnName("SUP_IS_HESS")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SupSupplierNr)
                    .HasColumnName("SUP_SUPPLIER_NR")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<TextModule>(entity =>
            {
                entity.HasKey(e => new {e.TmoId, e.TmoLngId});

                entity.ToTable("TEXT_MODULES");

                entity.Property(e => e.TmoId)
                    .HasColumnName("TMO_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TmoLngId)
                    .HasColumnName("TMO_LNG_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TmoFixed)
                    .HasColumnName("TMO_FIXED")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TmoTmtId)
                    .HasColumnName("TMO_TMT_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TextModuleText>(entity =>
            {
                entity.HasKey(e => e.TmtId);

                entity.ToTable("TEXT_MODULE_TEXTS");

                entity.Property(e => e.TmtId)
                    .HasColumnName("TMT_ID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TmtText)
                    .HasColumnName("TMT_TEXT")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TypeNumber>(entity =>
            {
                entity.HasKey(e =>
                    new {e.TynTypId, e.TynSearchText, e.TynKind, e.TynDisplayNr, e.TynGopNr, e.TynGopStart});

                entity.ToTable("TYPE_NUMBERS");

                entity.HasIndex(e => new {e.TynSearchText, e.TynKind})
                    .HasName("TYN_SEARCH_TEXT");

                entity.Property(e => e.TynTypId)
                    .HasColumnName("TYN_TYP_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TynSearchText)
                    .HasColumnName("TYN_SEARCH_TEXT")
                    .HasMaxLength(60);

                entity.Property(e => e.TynKind)
                    .HasColumnName("TYN_KIND")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TynDisplayNr)
                    .HasColumnName("TYN_DISPLAY_NR")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TynGopNr)
                    .HasColumnName("TYN_GOP_NR")
                    .HasMaxLength(75)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TynGopStart)
                    .HasColumnName("TYN_GOP_START")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.TypId);

                entity.ToTable("TYPES");

                entity.HasIndex(e => e.TypCdsId)
                    .HasName("TYP_CDS_ID");

                entity.HasIndex(e => e.TypModId)
                    .HasName("TYP_MOD_ID");

                entity.Property(e => e.TypId)
                    .HasColumnName("TYP_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypCcm)
                    .HasColumnName("TYP_CCM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypCcmTax)
                    .HasColumnName("TYP_CCM_TAX")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypCdsId)
                    .HasColumnName("TYP_CDS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypCylinders)
                    .HasColumnName("TYP_CYLINDERS")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TypDoors)
                    .HasColumnName("TYP_DOORS")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TypHpFrom)
                    .HasColumnName("TYP_HP_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypHpUpto)
                    .HasColumnName("TYP_HP_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvAbsDesId)
                    .HasColumnName("TYP_KV_ABS_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvAsrDesId)
                    .HasColumnName("TYP_KV_ASR_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvAxleDesId)
                    .HasColumnName("TYP_KV_AXLE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvBodyDesId)
                    .HasColumnName("TYP_KV_BODY_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvBrakeSystDesId)
                    .HasColumnName("TYP_KV_BRAKE_SYST_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvBrakeTypeDesId)
                    .HasColumnName("TYP_KV_BRAKE_TYPE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvCatalystDesId)
                    .HasColumnName("TYP_KV_CATALYST_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvDriveDesId)
                    .HasColumnName("TYP_KV_DRIVE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvEngineDesId)
                    .HasColumnName("TYP_KV_ENGINE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvFuelDesId)
                    .HasColumnName("TYP_KV_FUEL_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvFuelSupplyDesId)
                    .HasColumnName("TYP_KV_FUEL_SUPPLY_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvModelDesId)
                    .HasColumnName("TYP_KV_MODEL_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvSteeringDesId)
                    .HasColumnName("TYP_KV_STEERING_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvSteeringSideDesId)
                    .HasColumnName("TYP_KV_STEERING_SIDE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvTransDesId)
                    .HasColumnName("TYP_KV_TRANS_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKvVoltageDesId)
                    .HasColumnName("TYP_KV_VOLTAGE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKwFrom)
                    .HasColumnName("TYP_KW_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypKwUpto)
                    .HasColumnName("TYP_KW_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypLitres).HasColumnName("TYP_LITRES");

                entity.Property(e => e.TypMaxWeight).HasColumnName("TYP_MAX_WEIGHT");

                entity.Property(e => e.TypMmtCdsId)
                    .HasColumnName("TYP_MMT_CDS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypModId)
                    .HasColumnName("TYP_MOD_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypPconEnd)
                    .HasColumnName("TYP_PCON_END")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypPconStart)
                    .HasColumnName("TYP_PCON_START")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypRtExists)
                    .HasColumnName("TYP_RT_EXISTS")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TypSort)
                    .HasColumnName("TYP_SORT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TypTank)
                    .HasColumnName("TYP_TANK")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TypValves)
                    .HasColumnName("TYP_VALVES")
                    .HasColumnType("smallint(6)");
            });
        }
    }
}