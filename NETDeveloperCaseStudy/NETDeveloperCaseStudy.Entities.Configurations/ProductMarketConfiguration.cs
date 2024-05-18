using NETDeveloperCaseStudy.Core.Enums;

namespace NETDeveloperCaseStudy.Entities.Configurations;
public class ProductMarketConfiguration : AuditableEntityTypeConfiguration<ProductMarket>
{
    public override void Configure(EntityTypeBuilder<ProductMarket> builder)
    {
        base.Configure(builder);
        builder.HasAlternateKey(pm => new { pm.ProductId, pm.MarketId });
        builder.Property(pm=>pm.Price).HasPrecision(5,2).IsRequired();
        builder.Property(pm=>pm.Stock).IsRequired();
        builder.Property(pm=>pm.CurrencyUnit).IsRequired();
        #region Many_to_Many_Relationship
        builder.HasOne(pm => pm.Product).WithMany(p => p.Markets).HasForeignKey(pm => pm.ProductId);
        builder.HasOne(pm => pm.Market).WithMany(m => m.Products).HasForeignKey(pm => pm.MarketId);
        #endregion
        #region HasData ProductMarkets
        builder.HasData(
            new ProductMarket { Id=Guid.Parse("09051a37-5408-414d-8eb7-b814e02c77af"),ProductId=Guid.Parse("2a6f4b52-35fc-4691-9b58-a932cb1fe98d"),MarketId=Guid.Parse("266acab2-0fac-49e8-99e0-86da42d6cdc7"), Stock=1000, Price=950.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("d000e58c-ad7e-4569-a3c2-fda50d86a3ce"),ProductId=Guid.Parse("efa0763a-de8e-44f2-a42b-d14727974b7d"),MarketId=Guid.Parse("266acab2-0fac-49e8-99e0-86da42d6cdc7"), Stock=2800, Price=600.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("73ad54bc-4c4e-405b-9ee8-51f3b5563eb0"),ProductId=Guid.Parse("63966b3c-dfa3-4d04-9ac0-c6435b1c1501"),MarketId=Guid.Parse("266acab2-0fac-49e8-99e0-86da42d6cdc7"), Stock=1400, Price=200.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("00889c8f-3a4d-443a-8886-d70cba842432"),ProductId=Guid.Parse("532d0f81-9385-4cef-9a6a-46fc3c9fb65b"),MarketId=Guid.Parse("266acab2-0fac-49e8-99e0-86da42d6cdc7"), Stock=2000, Price=700.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("ba34a343-25eb-4132-8a6c-5d98ae6d9257"),ProductId=Guid.Parse("9ff60759-1df3-4762-833f-9c039ce3dd3c"),MarketId=Guid.Parse("266acab2-0fac-49e8-99e0-86da42d6cdc7"), Stock=1200, Price=890.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("18dcdd57-9952-4cb2-ac42-454221084102"),ProductId=Guid.Parse("2a6f4b52-35fc-4691-9b58-a932cb1fe98d"),MarketId=Guid.Parse("d3c7760f-6166-4058-a343-9c6870ac391d"), Stock=1500, Price=980.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("93845ffc-ef01-4ad1-b3af-009c32a729f5"),ProductId=Guid.Parse("efa0763a-de8e-44f2-a42b-d14727974b7d"),MarketId=Guid.Parse("d3c7760f-6166-4058-a343-9c6870ac391d"), Stock=1000, Price=580.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("b7c5ffce-f424-461f-b19b-186b3a38d93d"),ProductId=Guid.Parse("63966b3c-dfa3-4d04-9ac0-c6435b1c1501"),MarketId=Guid.Parse("d3c7760f-6166-4058-a343-9c6870ac391d"), Stock=1300, Price=220.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("9f729c2e-be26-42a0-8c97-5586f7ccc48e"),ProductId=Guid.Parse("085aeff8-9d2a-49f5-bc7d-1d4efa55a16f"),MarketId=Guid.Parse("d3c7760f-6166-4058-a343-9c6870ac391d"), Stock=3000, Price=620.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("315e8b4b-f028-414a-8ca3-47c50462cc19"),ProductId=Guid.Parse("9ff60759-1df3-4762-833f-9c039ce3dd3c"),MarketId=Guid.Parse("d3c7760f-6166-4058-a343-9c6870ac391d"), Stock=1200, Price=900.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("bbaf299a-8c38-4e85-950f-a999bcb48c00"),ProductId=Guid.Parse("2a6f4b52-35fc-4691-9b58-a932cb1fe98d"),MarketId=Guid.Parse("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), Stock=800, Price=990.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("781165ab-95dd-4fb7-a5b2-f90d573178f3"),ProductId=Guid.Parse("efa0763a-de8e-44f2-a42b-d14727974b7d"),MarketId=Guid.Parse("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), Stock=1350, Price=565.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("b982c629-7f10-4029-a3c0-ec7c6aadf1c8"),ProductId=Guid.Parse("63966b3c-dfa3-4d04-9ac0-c6435b1c1501"),MarketId=Guid.Parse("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), Stock=1950, Price=190.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("7d3f26ba-bca4-46f0-80c9-c51636fe04c1"),ProductId=Guid.Parse("532d0f81-9385-4cef-9a6a-46fc3c9fb65b"),MarketId=Guid.Parse("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), Stock=2000, Price=740.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new ProductMarket { Id=Guid.Parse("b4df6955-efa5-4fc7-b13c-47011201bb20"),ProductId=Guid.Parse("085aeff8-9d2a-49f5-bc7d-1d4efa55a16f"),MarketId=Guid.Parse("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), Stock=2400, Price=590.00m ,CurrencyUnit="TL", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now }
            );
        #endregion
    }
}
