﻿using CParts.Domain.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace CParts.Domain.Abstractions.Contexts
{
    public interface IPartsDataDbContext : IDbContext
    {
        DbSet<ArticleInfo> ArticleInfo { get; set; }
        DbSet<Article> Articles { get; set; }
        DbSet<ArtLookup> ArtLookup { get; set; }
        DbSet<Brands> Brands { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<CountryDesignation> CountryDesignations { get; set; }
        DbSet<Criteria> Criterias { get; set; }
        DbSet<Designation> Designations { get; set; }
        DbSet<DesText> DesTexts { get; set; }
        DbSet<DesTextOriginal> DesTextsOriginal { get; set; }
        DbSet<DocType> DocTypes { get; set; }
        DbSet<Engine> Engines { get; set; }
        DbSet<Graphic> Graphics { get; set; }
        DbSet<LaCriteria> LaCriterias { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<LinkArt> LinkArts { get; set; }
        DbSet<LinkGaStr> LinkGaStrs { get; set; }
        DbSet<LinkGraArt> LinkGraArts { get; set; }
        DbSet<LinkLaTyp> LinkLaTyps { get; set; }
        DbSet<LinkTypEng> LinkTypEngs { get; set; }
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
    }
}