using CParts.Domain.Abstractions.Contexts.Base;
using CParts.Domain.Core.Model.Parts;
using CParts.Domain.Core.Model.Parts.Additional;
using CParts.Domain.Core.Model.Parts.Links;
using Microsoft.EntityFrameworkCore;

namespace CParts.Domain.Abstractions.Contexts
{
    public interface IPartsDataDbContext : IDbContext
    {
        DbSet<ArticleInfo> ArticleInfo { get; set; }
        DbSet<Article> Articles { get; set; }
        DbSet<ArticleLookup> ArtLookup { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<CountryDesignation> CountryDesignations { get; set; }
        DbSet<Criteria> Criterias { get; set; }
        DbSet<GeneralDesignation> GeneralDesignations { get; set; }
        DbSet<DesignationText> DesTexts { get; set; }
        DbSet<DesignationTextOriginal> DesTextsOriginal { get; set; }
        DbSet<DocType> DocTypes { get; set; }
        DbSet<Engine> Engines { get; set; }
        DbSet<Graphic> Graphics { get; set; }
        DbSet<LaCriteria> LaCriterias { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<LinkArt> LinkArts { get; set; }
        DbSet<GroupToTreeLink> LinkGaStrs { get; set; }
        DbSet<LinkGraArt> LinkGraArts { get; set; }
        DbSet<ArticleLinkToTypeLink> LinkLaTyps { get; set; }
        DbSet<TypeToEngineLink> LinkTypEngs { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<SearchTree> SearchTrees { get; set; }
        DbSet<SupplierAddress> SupplierAddresses { get; set; }
        DbSet<SupplierLogo> SupplierLogos { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<TextModule> TextModules { get; set; }
        DbSet<TextModuleText> TextModuleTexts { get; set; }
        DbSet<TypeNumber> TypeNumbers { get; set; }
        DbSet<Type> Types { get; set; }
        DbSet<FullTypeIdentifier> FullTypeIdentifiers { get; set; }
        DbSet<SearchTreeName> SearchTreeNames { get; set; }
    }
}