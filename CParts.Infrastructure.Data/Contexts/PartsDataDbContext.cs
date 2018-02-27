using CParts.Domain.Abstractions.Contexts;
using CParts.Domain.Core.Model.Parts;
using CParts.Domain.Core.Model.Parts.Additional;
using CParts.Domain.Core.Model.Parts.Links;
using Microsoft.EntityFrameworkCore;

namespace CParts.Infrastructure.Data.Contexts
{
    public partial class PartsDataDbContext : DbContext, IPartsDataDbContext
    {
        public virtual DbSet<ArticleCriteria> ArticleCriteria { get; set; }
        public virtual DbSet<ArticleInfo> ArticleInfo { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleLookup> ArtLookup { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryDesignation> CountryDesignations { get; set; }
        public virtual DbSet<Criteria> Criterias { get; set; }
        public virtual DbSet<GeneralDesignation> GeneralDesignations { get; set; }
        public virtual DbSet<DesignationText> DesTexts { get; set; }
        public virtual DbSet<DesignationTextOriginal> DesTextsOriginal { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }
        public virtual DbSet<Graphic> Graphics { get; set; }
        public virtual DbSet<LaCriteria> LaCriterias { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LinkArt> LinkArts { get; set; }
        public virtual DbSet<GroupToTreeLink> LinkGaStrs { get; set; }
        public virtual DbSet<LinkGraArt> LinkGraArts { get; set; }
        public virtual DbSet<ArticleLinkToTypeLink> LinkLaTyps { get; set; }
        public virtual DbSet<TypeToEngineLink> LinkTypEngs { get; set; }
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
        public virtual DbSet<FullTypeIdentifier> FullTypeIdentifiers { get; set; }
        public virtual DbSet<SearchTreeName> SearchTreeNames { get; set; }

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
            //TODO: Maybe will be removed further
            modelBuilder.Entity<FullTypeIdentifier>(entity =>
            {
                entity.ToTable("FULL_TYPE_IDENTIFIER");
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.FullIdentifier)
                    .HasName("fts_idx");
                
                entity.Property(e => e.Id)
                    .HasColumnName("FTP_ID")
                    .HasColumnType("int(11)");
                
                entity.Property(e => e.FullIdentifier)
                    .HasColumnName("FTP_FULL_IDENTIFIER")
                    .HasColumnType("text");
                
                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("FTP_MFA_ID")
                    .HasColumnType("int(11)");
                
                entity.Property(e => e.ModelId)
                    .HasColumnName("FTP_MOD_ID")
                    .HasColumnType("int(11)");
                
                entity.Property(e => e.TypeId)
                    .HasColumnName("FTP_TYP_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(e => e.Type).WithMany().HasForeignKey(e => e.TypeId);
                entity.HasOne(e => e.Model).WithMany().HasForeignKey(e => e.ModelId);
                entity.HasOne(e => e.Manufacturer).WithMany().HasForeignKey(e => e.ManufacturerId);
            });       
            
            modelBuilder.Entity<SearchTreeName>(entity =>
            {
                entity.ToTable("SEARCH_TREE_NAME");
                entity.HasKey(e => e.SearchTreeId);

                entity.HasIndex(e => e.Name)
                    .HasName("fdx_idx");
                
                entity.Property(e => e.SearchTreeId)
                    .HasColumnName("STR_ID")
                    .HasColumnType("int(11)");
                
                entity.Property(e => e.Name)
                    .HasColumnName("TEX_TEXT")
                    .HasColumnType("text");
                
                entity.HasOne(e => e.SearchTree).WithMany().HasForeignKey(e => e.SearchTreeId);
            });

            modelBuilder.Entity<CountryDesignation>(entity =>
            {
                entity.ToTable("COUNTRY_DESIGNATIONS");

                entity.HasKey(e => new {e.Id, e.LanguageId, DesignationTextId = e.TextId});
                entity.Property(e => e.Id)
                    .HasColumnName("CDS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("CDS_LNG_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TextId)
                    .HasColumnName("CDS_TEX_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(e => e.Text).WithMany().HasForeignKey(e => e.TextId);
                entity.HasOne(e => e.Language).WithMany().HasForeignKey(e => e.LanguageId);
            });

            modelBuilder.Entity<ArticleCriteria>(entity =>
            {
                entity.HasKey(e => new {AcrArtId = e.ArticleId, e.AcrGaId, AcrSort = e.Sort});

                entity.ToTable("ARTICLE_CRITERIA");

                entity.HasIndex(e => e.KvDesignationId)
                    .HasName("ACR_KV_DES_ID");

                entity.HasIndex(e => e.Value)
                    .HasName("ACR_VALUE");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("ACR_ART_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Article).WithMany().HasForeignKey(e => e.ArticleId);

                entity.Property(e => e.AcrGaId)
                    .HasColumnName("ACR_GA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sort)
                    .HasColumnName("ACR_SORT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CriteriaId)
                    .HasColumnName("ACR_CRI_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Criteria).WithMany().HasForeignKey(e => e.CriteriaId);

                entity.Property(e => e.Display)
                    .HasColumnName("ACR_DISPLAY")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.KvDesignationId)
                    .HasColumnName("ACR_KV_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvDesignation).WithMany().HasForeignKey(e => e.KvDesignationId);

                entity.Property(e => e.Value)
                    .HasColumnName("ACR_VALUE")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<ArticleInfo>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.ArticleId,
                    AinGaId = e.GaId,
                    AinSort = e.Sort,
                    AinKvType = e.KvType,
                    e.AinDisplay,
                    AinTmoId = e.TextModuleId
                });

                entity.ToTable("ARTICLE_INFO");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("AIN_ART_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Article).WithMany().HasForeignKey(e => e.ArticleId);

                entity.Property(e => e.GaId)
                    .HasColumnName("AIN_GA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sort)
                    .HasColumnName("AIN_SORT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.KvType)
                    .HasColumnName("AIN_KV_TYPE")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AinDisplay)
                    .HasColumnName("AIN_DISPLAY")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TextModuleId)
                    .HasColumnName("AIN_TMO_ID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
                entity.HasOne(e => e.TextModule).WithMany().HasForeignKey(e => e.TextModuleId);
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("ARTICLES");

                entity.HasIndex(e => e.Number)
                    .HasName("ART_ARTICLE_NR");

                entity.HasIndex(e => e.CompleteDesignationId)
                    .HasName("ART_COMPLETE_DES_ID");

                entity.HasIndex(e => e.DesignationId)
                    .HasName("ART_DES_ID");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("ART_SUP_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ART_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Accessory)
                    .HasColumnName("ART_ACCESSORY")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("ART_ARTICLE_NR")
                    .HasMaxLength(66);

                entity.Property(e => e.BatchSize1)
                    .HasColumnName("ART_BATCH_SIZE1")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BatchSize2)
                    .HasColumnName("ART_BATCH_SIZE2")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CompleteDesignationId)
                    .HasColumnName("ART_COMPLETE_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DesignationId)
                    .HasColumnName("ART_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MaterialMark)
                    .HasColumnName("ART_MATERIAL_MARK")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.PackSelfservice)
                    .HasColumnName("ART_PACK_SELFSERVICE")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Replacement)
                    .HasColumnName("ART_REPLACEMENT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("ART_SUP_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Supplier).WithMany().HasForeignKey(e => e.SupplierId);
            });

            modelBuilder.Entity<ArticleLookup>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.ArticleId,
                    e.CatalogueCode,
                    e.Kind,
                    e.BrandId,
                    e.DisplayNumber,
                    e.Display,
                    e.Block,
                    e.Sort
                });

                entity.ToTable("ART_LOOKUP");

                entity.HasIndex(e => e.BrandId)
                    .HasName("ARL_BRA_ID");

                entity.HasIndex(e => new {ArlSearchNumber = e.CatalogueCode, ArlBraId = e.BrandId, ArlKind = e.Kind})
                    .HasName("ARL_SEARCH_NUMBER");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("ARL_ART_ID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
                entity.HasOne(e => e.Article).WithMany().HasForeignKey(e => e.ArticleId);

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
                entity.HasOne(e => e.Brand).WithMany().HasForeignKey(e => e.BrandId);

                entity.Property(e => e.DisplayNumber)
                    .HasColumnName("ARL_DISPLAY_NR")
                    .HasMaxLength(105)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Display)
                    .HasColumnName("ARL_DISPLAY")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Block)
                    .HasColumnName("ARL_BLOCK")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sort)
                    .HasColumnName("ARL_SORT")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("BRANDS");

                entity.HasIndex(e => e.Name)
                    .HasName("BRA_BRAND");

                entity.Property(e => e.Id)
                    .HasColumnName("BRA_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Name)
                    .HasColumnName("BRA_BRAND")
                    .HasMaxLength(60);

                entity.Property(e => e.MfNr)
                    .HasColumnName("BRA_MF_NR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MfcCode)
                    .HasColumnName("BRA_MFC_CODE")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("COUNTRIES");

                entity.Property(e => e.Id)
                    .HasColumnName("COU_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CC)
                    .HasColumnName("COU_CC")
                    .HasMaxLength(9);

                entity.Property(e => e.CurrencyCode)
                    .HasColumnName("COU_CURRENCY_CODE")
                    .HasMaxLength(9);

                entity.Property(e => e.DesignationId)
                    .HasColumnName("COU_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Designation).WithMany().HasForeignKey(e => e.DesignationId);

                entity.Property(e => e.IsGroup)
                    .HasColumnName("COU_IS_GROUP")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Iso2)
                    .HasColumnName("COU_ISO2")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<Criteria>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("CRITERIA");

                entity.Property(e => e.Id)
                    .HasColumnName("CRI_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.DesignationId)
                    .HasColumnName("CRI_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsInterval)
                    .HasColumnName("CRI_IS_INTERVAL")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.KtId)
                    .HasColumnName("CRI_KT_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ShortDesignationId)
                    .HasColumnName("CRI_SHORT_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Successor)
                    .HasColumnName("CRI_SUCCESSOR")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Type)
                    .HasColumnName("CRI_TYPE")
                    .HasColumnType("binary(1)");

                entity.Property(e => e.UnitDesignationId)
                    .HasColumnName("CRI_UNIT_DES_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<GeneralDesignation>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("DESIGNATIONS");

                entity.HasIndex(e => e.TextId)
                    .HasName("DES_TEX_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("DES_LNG_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Language).WithMany().HasForeignKey(e => e.LanguageId);

                entity.Property(e => e.TextId)
                    .HasColumnName("DES_TEX_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Text).WithOne().HasForeignKey<GeneralDesignation>(e => e.TextId);
            });

            modelBuilder.Entity<DesignationText>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("DES_TEXTS");

                entity.HasIndex(e => e.Text)
                    .HasName("des_texts101_index02");

                entity.Property(e => e.Id)
                    .HasColumnName("TEX_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Text)
                    .HasColumnName("TEX_TEXT")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<DesignationTextOriginal>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("DES_TEXTS_ORIGINAL");

                entity.HasIndex(e => e.Text)
                    .HasName("TEX_TEXT");

                entity.Property(e => e.Id)
                    .HasColumnName("TEX_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Text)
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

                entity.Property(e => e.Extension)
                    .HasColumnName("DOC_EXTENSION")
                    .HasMaxLength(9);
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("ENGINES");

                entity.Property(e => e.Id)
                    .HasColumnName("ENG_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CcmFrom)
                    .HasColumnName("ENG_CCM_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CcmTaxFrom)
                    .HasColumnName("ENG_CCM_TAX_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CcmTaxUpto)
                    .HasColumnName("ENG_CCM_TAX_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CcmUpto)
                    .HasColumnName("ENG_CCM_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("ENG_CODE")
                    .HasMaxLength(180);

                entity.Property(e => e.CompressionFrom)
                    .HasColumnName("ENG_COMPRESSION_FROM");

                entity.Property(e => e.CompressionUpto)
                    .HasColumnName("ENG_COMPRESSION_UPTO");

                entity.Property(e => e.Crankshaft)
                    .HasColumnName("ENG_CRANKSHAFT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Cylinders)
                    .HasColumnName("ENG_CYLINDERS")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Description)
                    .HasColumnName("ENG_DESCRIPTION")
                    .HasMaxLength(90);

                entity.Property(e => e.Drilling).HasColumnName("ENG_DRILLING");

                entity.Property(e => e.Extension).HasColumnName("ENG_EXTENSION");

                entity.Property(e => e.HpFrom)
                    .HasColumnName("ENG_HP_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HpUpto)
                    .HasColumnName("ENG_HP_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KvChargeDesignationId)
                    .HasColumnName("ENG_KV_CHARGE_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvChargeDesignation).WithOne().HasForeignKey<Engine>(e => e.KvChargeDesignationId);

                entity.Property(e => e.KvControlDesignationId)
                    .HasColumnName("ENG_KV_CONTROL_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvControlDesignation).WithOne()
                    .HasForeignKey<Engine>(e => e.KvControlDesignationId);

                entity.Property(e => e.KvCoolingDesignationId)
                    .HasColumnName("ENG_KV_COOLING_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvCoolingDesignation).WithOne()
                    .HasForeignKey<Engine>(e => e.KvCoolingDesignationId);

                entity.Property(e => e.KvCylindersDesignationId)
                    .HasColumnName("ENG_KV_CYLINDERS_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvCylindersDesignation).WithOne()
                    .HasForeignKey<Engine>(e => e.KvCylindersDesignationId);

                entity.Property(e => e.KvDesignDesignationId)
                    .HasColumnName("ENG_KV_DESIGN_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvDesignDesignation).WithOne().HasForeignKey<Engine>(e => e.KvDesignDesignationId);

                entity.Property(e => e.KvEngineDesignationId)
                    .HasColumnName("ENG_KV_ENGINE_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvEngineDesignation).WithOne().HasForeignKey<Engine>(e => e.KvEngineDesignationId);

                entity.Property(e => e.KvFuelSupplyDesignationId)
                    .HasColumnName("ENG_KV_FUEL_SUPPLY_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvFuelSupplyDesignation).WithOne()
                    .HasForeignKey<Engine>(e => e.KvFuelSupplyDesignationId);

                entity.Property(e => e.KvFuelTypeDesignationId)
                    .HasColumnName("ENG_KV_FUEL_TYPE_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvFuelTypeDesignation).WithOne()
                    .HasForeignKey<Engine>(e => e.KvFuelTypeDesignationId);

                entity.Property(e => e.KvGasNormDesignationId)
                    .HasColumnName("ENG_KV_GAS_NORM_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvGasNormDesignation).WithOne()
                    .HasForeignKey<Engine>(e => e.KvGasNormDesignationId);

                entity.Property(e => e.KvUseDesignationId)
                    .HasColumnName("ENG_KV_USE_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvUseDesignation).WithOne().HasForeignKey<Engine>(e => e.KvUseDesignationId);

                entity.Property(e => e.KvValveControlDesignationId)
                    .HasColumnName("ENG_KV_VALVE_CONTROL_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvValveControlDesignation).WithOne()
                    .HasForeignKey<Engine>(e => e.KvValveControlDesignationId);

                entity.Property(e => e.KwFrom)
                    .HasColumnName("ENG_KW_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KwRPMFrom)
                    .HasColumnName("ENG_KW_RPM_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KwRPMUpto)
                    .HasColumnName("ENG_KW_RPM_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KwUpto)
                    .HasColumnName("ENG_KW_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LitresFrom).HasColumnName("ENG_LITRES_FROM");

                entity.Property(e => e.LitresTaxFrom).HasColumnName("ENG_LITRES_TAX_FROM");

                entity.Property(e => e.LitresTaxUpto).HasColumnName("ENG_LITRES_TAX_UPTO");

                entity.Property(e => e.LitresUpto).HasColumnName("ENG_LITRES_UPTO");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("ENG_MFA_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Manufacturer).WithOne().HasForeignKey<Engine>(e => e.ManufacturerId);

                entity.Property(e => e.PconEnd)
                    .HasColumnName("ENG_PCON_END")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PconStart)
                    .HasColumnName("ENG_PCON_START")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TorqueFrom)
                    .HasColumnName("ENG_TORQUE_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TorqueRpmFrom)
                    .HasColumnName("ENG_TORQUE_RPM_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TorqueRpmUpto)
                    .HasColumnName("ENG_TORQUE_RPM_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TorqueUpto)
                    .HasColumnName("ENG_TORQUE_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valves)
                    .HasColumnName("ENG_VALVES")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<Graphic>(entity =>
            {
                entity.HasKey(e => new {GraId = e.Id, GraLngId = e.LanguageId});

                entity.ToTable("GRAPHICS");

                entity.Property(e => e.Id)
                    .HasColumnName("GRA_ID")
                    .HasMaxLength(11);

                entity.Property(e => e.LanguageId)
                    .HasColumnName("GRA_LNG_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Language).WithMany().HasForeignKey(e => e.LanguageId);

                entity.Property(e => e.DesignationId)
                    .HasColumnName("GRA_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Designation).WithMany().HasForeignKey(e => e.DesignationId);

                entity.Property(e => e.GraDocType)
                    .HasColumnName("GRA_DOC_TYPE")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.GraGrdId)
                    .HasColumnName("GRA_GRD_ID")
                    .HasMaxLength(14);

                entity.Property(e => e.Norm)
                    .HasColumnName("GRA_NORM")
                    .HasMaxLength(9);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("GRA_SUP_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Supplier).WithMany().HasForeignKey(e => e.SupplierId);

                entity.Property(e => e.SupplierNumber)
                    .HasColumnName("GRA_SUPPLIER_NR")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TabNr)
                    .HasColumnName("GRA_TAB_NR")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Type)
                    .HasColumnName("GRA_TYPE")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<LaCriteria>(entity =>
            {
                entity.HasKey(e => new {LacLaId = e.LinkArtId, LacSort = e.Sort});

                entity.ToTable("LA_CRITERIA");

                entity.Property(e => e.LinkArtId)
                    .HasColumnName("LAC_LA_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.LinkArt).WithMany().HasForeignKey(e => e.LinkArtId);

                entity.Property(e => e.Sort)
                    .HasColumnName("LAC_SORT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CriteriaId)
                    .HasColumnName("LAC_CRI_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Criteria).WithMany().HasForeignKey(e => e.CriteriaId);

                entity.Property(e => e.Display)
                    .HasColumnName("LAC_DISPLAY")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.KvDesignationId)
                    .HasColumnName("LAC_KV_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Designation).WithMany().HasForeignKey(e => e.KvDesignationId);

                entity.Property(e => e.Value)
                    .HasColumnName("LAC_VALUE")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("LANGUAGES");

                entity.Property(e => e.Id)
                    .HasColumnName("LNG_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Codepage)
                    .HasColumnName("LNG_CODEPAGE")
                    .HasMaxLength(30);

                entity.Property(e => e.DesignationId)
                    .HasColumnName("LNG_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Designation).WithMany().HasForeignKey(e => e.DesignationId);

                entity.Property(e => e.Iso2)
                    .HasColumnName("LNG_ISO2")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<LinkArt>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("LINK_ART");

                entity.HasIndex(e => e.ArticleId)
                    .HasName("LA_ART_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("LA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("LA_ART_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Article).WithOne().HasForeignKey<LinkArt>(e => e.ArticleId);

                entity.Property(e => e.GaId)
                    .HasColumnName("LA_GA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sort)
                    .HasColumnName("LA_SORT")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<GroupToTreeLink>(entity =>
            {
                entity.HasKey(e => new {LgsStrId = e.SearchTreeId, LgsGaId = e.GaId});

                entity.ToTable("LINK_GA_STR");

                entity.Property(e => e.SearchTreeId)
                    .HasColumnName("LGS_STR_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.SearchTree).WithOne().HasForeignKey<GroupToTreeLink>(e => e.SearchTreeId);

                entity.Property(e => e.GaId)
                    .HasColumnName("LGS_GA_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<LinkGraArt>(entity =>
            {
                entity.HasKey(e => new {LgaArtId = e.ArticleId, LgaSort = e.Sort});

                entity.ToTable("LINK_GRA_ART");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("LGA_ART_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sort)
                    .HasColumnName("LGA_SORT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.GraphicId)
                    .IsRequired()
                    .HasColumnName("LGA_GRA_ID")
                    .HasMaxLength(11);
            });

            modelBuilder.Entity<ArticleLinkToTypeLink>(entity =>
            {
                entity.HasKey(e => new {LatTypId = e.TypeId, e.LatGaId, LatLaId = e.LinkArtId, LatSort = e.Sort});

                entity.ToTable("LINK_LA_TYP");

                entity.HasIndex(e => e.LinkArtId)
                    .HasName("LAT_LA_ID");

                entity.Property(e => e.TypeId)
                    .HasColumnName("LAT_TYP_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LatGaId)
                    .HasColumnName("LAT_GA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LinkArtId)
                    .HasColumnName("LAT_LA_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sort)
                    .HasColumnName("LAT_SORT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("LAT_SUP_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Supplier).WithMany().HasForeignKey(e => e.SupplierId);
            });

            modelBuilder.Entity<TypeToEngineLink>(entity =>
            {
                entity.HasKey(e => new {LteTypId = e.TypeId, LteNr = e.Number, LteEngId = e.EngineId});

                entity.ToTable("LINK_TYP_ENG");

                entity.Property(e => e.TypeId)
                    .HasColumnName("LTE_TYP_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Type).WithMany().HasForeignKey(e => e.TypeId);

                entity.Property(e => e.Number)
                    .HasColumnName("LTE_NR")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.EngineId)
                    .HasColumnName("LTE_ENG_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Engine).WithMany().HasForeignKey(e => e.EngineId);

                entity.Property(e => e.PconEnd)
                    .HasColumnName("LTE_PCON_END")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PconStart)
                    .HasColumnName("LTE_PCON_START")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("MANUFACTURERS");

                entity.HasIndex(e => e.Brand)
                    .HasName("MFA_BRAND");

                entity.Property(e => e.Id)
                    .HasColumnName("MFA_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.AxlMfc)
                    .HasColumnName("MFA_AXL_MFC")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Brand)
                    .HasColumnName("MFA_BRAND")
                    .HasMaxLength(60);

                entity.Property(e => e.CvMfc)
                    .HasColumnName("MFA_CV_MFC")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.EngineMfc)
                    .HasColumnName("MFA_ENG_MFC")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.EngineType)
                    .HasColumnName("MFA_ENG_TYP")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MfNumber)
                    .HasColumnName("MFA_MF_NR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("MFA_MFC_CODE")
                    .HasMaxLength(30);

                entity.Property(e => e.PcMfc)
                    .HasColumnName("MFA_PC_MFC")
                    .HasColumnType("smallint(6)");
            });


            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("MODELS");

                entity.HasIndex(e => e.CountryDesignationId)
                    .HasName("MOD_CDS_ID");

                entity.HasIndex(e => e.ManufacturerId)
                    .HasName("MOD_MFA_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("MOD_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Axl)
                    .HasColumnName("MOD_AXL")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.CountryDesignationId)
                    .HasColumnName("MOD_CDS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cv)
                    .HasColumnName("MOD_CV")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("MOD_MFA_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Manufacturer).WithMany().HasForeignKey(e => e.ManufacturerId);

                entity.Property(e => e.Pc)
                    .HasColumnName("MOD_PC")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.PconEnd)
                    .HasColumnName("MOD_PCON_END")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PconStart)
                    .HasColumnName("MOD_PCON_START")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SearchTree>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("SEARCH_TREE");

                entity.HasIndex(e => e.ParentId)
                    .HasName("STR_ID_PARENT");

                entity.HasIndex(e => e.Level)
                    .HasName("STR_LEVEL");

                entity.Property(e => e.Id)
                    .HasColumnName("STR_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DesignationId)
                    .HasColumnName("STR_DES_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ParentId)
                    .HasColumnName("STR_ID_PARENT")
                    .HasColumnType("int(11)");
//                entity.HasOne(e => e.Parent).WithOne().HasForeignKey<SearchTree>(e => e.ParentId);

                entity.Property(e => e.Level)
                    .HasColumnName("STR_LEVEL")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.NodeNr)
                    .HasColumnName("STR_NODE_NR")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sort)
                    .HasColumnName("STR_SORT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Type)
                    .HasColumnName("STR_TYPE")
                    .HasColumnType("smallint(6)");

                entity.HasMany(x => x.Childs).WithOne(x => x.Parent).HasForeignKey(x => x.ParentId);
            });

            modelBuilder.Entity<SupplierAddress>(entity =>
            {
                entity.HasKey(e =>
                    new {SadSupId = e.SupplierId, SadTypeOfAddress = e.TypeOfAddress, SadCouId = e.CountryId});

                entity.ToTable("SUPPLIER_ADDRESSES");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SAD_SUP_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Supplier).WithMany().HasForeignKey(e => e.SupplierId);

                entity.Property(e => e.TypeOfAddress)
                    .HasColumnName("SAD_TYPE_OF_ADDRESS")
                    .HasMaxLength(9);

                entity.Property(e => e.CountryId)
                    .HasColumnName("SAD_COU_ID")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");
                entity.HasOne(e => e.Country).WithMany().HasForeignKey(e => e.CountryId);

                entity.Property(e => e.City1)
                    .HasColumnName("SAD_CITY1")
                    .HasMaxLength(120);

                entity.Property(e => e.City2)
                    .HasColumnName("SAD_CITY2")
                    .HasMaxLength(120);

                entity.Property(e => e.CountryIdPostal)
                    .HasColumnName("SAD_COU_ID_POSTAL")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.CountryPostal).WithMany().HasForeignKey(e => e.CountryIdPostal);

                entity.Property(e => e.Email)
                    .HasColumnName("SAD_EMAIL")
                    .HasMaxLength(180);

                entity.Property(e => e.Fax)
                    .HasColumnName("SAD_FAX")
                    .HasMaxLength(60);

                entity.Property(e => e.Name1)
                    .HasColumnName("SAD_NAME1")
                    .HasMaxLength(120);

                entity.Property(e => e.Name2)
                    .HasColumnName("SAD_NAME2")
                    .HasMaxLength(120);

                entity.Property(e => e.Pob)
                    .HasColumnName("SAD_POB")
                    .HasMaxLength(30);

                entity.Property(e => e.PostalCodeCust)
                    .HasColumnName("SAD_POSTAL_CODE_CUST")
                    .HasMaxLength(24);

                entity.Property(e => e.PostalCodePlace)
                    .HasColumnName("SAD_POSTAL_CODE_PLACE")
                    .HasMaxLength(24);

                entity.Property(e => e.PostalCodePob)
                    .HasColumnName("SAD_POSTAL_CODE_POB")
                    .HasMaxLength(24);

                entity.Property(e => e.Street1)
                    .HasColumnName("SAD_STREET1")
                    .HasMaxLength(120);

                entity.Property(e => e.Street2)
                    .HasColumnName("SAD_STREET2")
                    .HasMaxLength(120);

                entity.Property(e => e.Tel)
                    .HasColumnName("SAD_TEL")
                    .HasMaxLength(120);

                entity.Property(e => e.Web)
                    .HasColumnName("SAD_WEB")
                    .HasMaxLength(180);
            });

            modelBuilder.Entity<SupplierLogo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("SUPPLIER_LOGOS");

                entity.HasIndex(e => new {SloSupId = e.SupplierId, SloLngId = e.LanguageId})
                    .HasName("SLO_SUP_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("SLO_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("SLO_LNG_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Language).WithMany().HasForeignKey(e => e.LanguageId);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SLO_SUP_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Supplier).WithOne().HasForeignKey<SupplierLogo>(e => e.SupplierId);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("SUPPLIERS");

                entity.HasIndex(e => e.Brand)
                    .HasName("SUP_BRAND");

                entity.Property(e => e.Id)
                    .HasColumnName("SUP_ID")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Brand)
                    .HasColumnName("SUP_BRAND")
                    .HasMaxLength(60);

                entity.Property(e => e.CountryId)
                    .HasColumnName("SUP_COU_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Country).WithMany().HasForeignKey(e => e.CountryId);

                entity.Property(e => e.IsHess)
                    .HasColumnName("SUP_IS_HESS")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Number)
                    .HasColumnName("SUP_SUPPLIER_NR")
                    .HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<TextModule>(entity =>
            {
                entity.HasKey(e => e.TmoId);

                entity.ToTable("TEXT_MODULES");

                entity.Property(e => e.TmoId)
                    .HasColumnName("TMO_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("TMO_LNG_ID")
                    .HasColumnType("smallint(6)");
                entity.HasOne(e => e.Language).WithMany().HasForeignKey(e => e.LanguageId);

                entity.Property(e => e.Fixed)
                    .HasColumnName("TMO_FIXED")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TextId)
                    .HasColumnName("TMO_TMT_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Text).WithOne().HasForeignKey<TextModule>(e => e.TextId);
            });

            modelBuilder.Entity<TextModuleText>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TEXT_MODULE_TEXTS");

                entity.Property(e => e.Id)
                    .HasColumnName("TMT_ID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Text)
                    .HasColumnName("TMT_TEXT")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TypeNumber>(entity =>
            {
                entity.HasKey(e =>
                    new
                    {
                        TynTypId = e.TypeId,
                        TynSearchText = e.SearchText,
                        TynKind = e.Kind,
                        TynDisplayNr = e.DisplayNumber,
                        TynGopNr = e.GopNumber,
                        TynGopStart = e.GopStart
                    });

                entity.ToTable("TYPE_NUMBERS");

                entity.HasIndex(e => new {TynSearchText = e.SearchText, TynKind = e.Kind})
                    .HasName("TYN_SEARCH_TEXT");

                entity.Property(e => e.TypeId)
                    .HasColumnName("TYN_TYP_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SearchText)
                    .HasColumnName("TYN_SEARCH_TEXT")
                    .HasMaxLength(60);

                entity.Property(e => e.Kind)
                    .HasColumnName("TYN_KIND")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.DisplayNumber)
                    .HasColumnName("TYN_DISPLAY_NR")
                    .HasMaxLength(60)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GopNumber)
                    .HasColumnName("TYN_GOP_NR")
                    .HasMaxLength(75)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.GopStart)
                    .HasColumnName("TYN_GOP_START")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TYPES");

                entity.HasIndex(e => e.CountryDesignationId)
                    .HasName("TYP_CDS_ID");

                entity.HasIndex(e => e.ModelId)
                    .HasName("TYP_MOD_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("TYP_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ccm)
                    .HasColumnName("TYP_CCM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CcmTax)
                    .HasColumnName("TYP_CCM_TAX")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountryDesignationId)
                    .HasColumnName("TYP_CDS_ID")
                    .HasColumnType("int(11)");
//                entity.HasOne(e => e.CountryDesignation).WithMany().HasForeignKey(e => e.CountryDesignationId);

                entity.Property(e => e.Cylinders)
                    .HasColumnName("TYP_CYLINDERS")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Doors)
                    .HasColumnName("TYP_DOORS")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.HpFrom)
                    .HasColumnName("TYP_HP_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HpUpto)
                    .HasColumnName("TYP_HP_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KvAbsDesignationId)
                    .HasColumnName("TYP_KV_ABS_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvAbsDesignation).WithOne().HasForeignKey<Type>(e => e.KvAbsDesignationId);

                entity.Property(e => e.KvAsrDesignationId)
                    .HasColumnName("TYP_KV_ASR_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvAsrDesignation).WithOne().HasForeignKey<Type>(e => e.KvAsrDesignationId);

                entity.Property(e => e.KvAxleDesignationId)
                    .HasColumnName("TYP_KV_AXLE_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvAxleDesignation).WithOne().HasForeignKey<Type>(e => e.KvAxleDesignationId);

                entity.Property(e => e.KvBodyDesignationId)
                    .HasColumnName("TYP_KV_BODY_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvBodyDesignation).WithOne().HasForeignKey<Type>(e => e.KvBodyDesignationId);

                entity.Property(e => e.KvBrakeSystemDesignationId)
                    .HasColumnName("TYP_KV_BRAKE_SYST_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvBrakeSystemDesignation).WithOne()
                    .HasForeignKey<Type>(e => e.KvBrakeSystemDesignationId);

                entity.Property(e => e.KvBrakeTypeDesignationId)
                    .HasColumnName("TYP_KV_BRAKE_TYPE_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvBrakeTypeDisignation).WithOne()
                    .HasForeignKey<Type>(e => e.KvBrakeTypeDesignationId);

                entity.Property(e => e.KvCatalystDesignationId)
                    .HasColumnName("TYP_KV_CATALYST_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvCatalystDesignation).WithOne()
                    .HasForeignKey<Type>(e => e.KvCatalystDesignationId);

                entity.Property(e => e.KvDriveDesignationId)
                    .HasColumnName("TYP_KV_DRIVE_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvDriveDesignation).WithOne().HasForeignKey<Type>(e => e.KvDriveDesignationId);

                entity.Property(e => e.KvEngineDesignationId)
                    .HasColumnName("TYP_KV_ENGINE_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvEngineDesignation).WithOne().HasForeignKey<Type>(e => e.KvEngineDesignationId);

                entity.Property(e => e.KvFuelDesignationId)
                    .HasColumnName("TYP_KV_FUEL_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvFuelDesignation).WithOne().HasForeignKey<Type>(e => e.KvFuelDesignationId);

                entity.Property(e => e.KvFuelSupplyDesignationId)
                    .HasColumnName("TYP_KV_FUEL_SUPPLY_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvFuelSupplyDesignation).WithOne()
                    .HasForeignKey<Type>(e => e.KvFuelSupplyDesignationId);

                entity.Property(e => e.KvModelDesignationId)
                    .HasColumnName("TYP_KV_MODEL_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvModelDesignation).WithOne().HasForeignKey<Type>(e => e.KvModelDesignationId);

                entity.Property(e => e.KvSteeringDesignationId)
                    .HasColumnName("TYP_KV_STEERING_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvSteeringDesignation).WithOne()
                    .HasForeignKey<Type>(e => e.KvSteeringDesignationId);

                entity.Property(e => e.KvSteeringSideDesignationId)
                    .HasColumnName("TYP_KV_STEERING_SIDE_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvSteeringSideDesignation).WithOne()
                    .HasForeignKey<Type>(e => e.KvSteeringSideDesignationId);

                entity.Property(e => e.KvTransDesignationId)
                    .HasColumnName("TYP_KV_TRANS_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvTransDesignation).WithOne().HasForeignKey<Type>(e => e.KvTransDesignationId);

                entity.Property(e => e.KvVoltageDesignationId)
                    .HasColumnName("TYP_KV_VOLTAGE_DES_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.KvVoltageDesignation).WithOne().HasForeignKey<Type>(e => e.KvVoltageDesignationId);

                entity.Property(e => e.KwFrom)
                    .HasColumnName("TYP_KW_FROM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KwUpto)
                    .HasColumnName("TYP_KW_UPTO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Litres).HasColumnName("TYP_LITRES");

                entity.Property(e => e.TypMaxWeight).HasColumnName("TYP_MAX_WEIGHT");

                entity.Property(e => e.MmtCountryDesignationId)
                    .HasColumnName("TYP_MMT_CDS_ID")
                    .HasColumnType("int(11)");
//                entity.HasOne(e => e.MmtCountryDesignationIds).WithOne()
//                    .HasForeignKey<Type>(e => e.MmtCountryDesignationId);

                entity.Property(e => e.ModelId)
                    .HasColumnName("TYP_MOD_ID")
                    .HasColumnType("int(11)");
                entity.HasOne(e => e.Model).WithMany().HasForeignKey(e => e.ModelId);

                entity.Property(e => e.PconEnd)
                    .HasColumnName("TYP_PCON_END")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PconStart)
                    .HasColumnName("TYP_PCON_START")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RtExists)
                    .HasColumnName("TYP_RT_EXISTS")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Sort)
                    .HasColumnName("TYP_SORT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tank)
                    .HasColumnName("TYP_TANK")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Valves)
                    .HasColumnName("TYP_VALVES")
                    .HasColumnType("smallint(6)");
            });
        }
    }
}