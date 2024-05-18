using NETDeveloperCaseStudy.Core.Enums;

namespace NETDeveloperCaseStudy.Entities.Configurations;
public class ProductConfiguration : AuditableEntityTypeConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        builder.HasIndex(p => p.Barcode).HasFilter("[BARCODE] IS NOT NULL").IsUnique();
        builder.Property(p => p.Barcode).HasMaxLength(14).IsRequired();
        builder.Property(p=>p.Name).HasMaxLength(128).IsRequired();
        builder.Property(p => p.Brand).IsRequired();
        builder.Property(p => p.Description).IsRequired(false);
        builder.Property(p => p.Size).HasMaxLength(5).IsRequired();
        builder.Property(p => p.Color).HasMaxLength(16).IsRequired();
        #region One_To_Many_Relationship
        builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
        #endregion
        #region HasData Products
        builder.HasData(
         new Product { Id = Guid.Parse("2a6f4b52-35fc-4691-9b58-a932cb1fe98d"), CategoryId = Guid.Parse("47f0cacd-7e44-4989-8eee-2ba09e470abd"), Barcode = "45123984756234", Name = "Kaban", Brand = "Zara", Size = "XL", Color = "Brown", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
         new Product { Id = Guid.Parse("efa0763a-de8e-44f2-a42b-d14727974b7d"), CategoryId = Guid.Parse("40e576f2-63c3-45eb-827f-389113dcdfd4"), Barcode = "89347210957368", Name = "Kot Pantolon", Brand = "Mavi", Size = "38", Color = "Blue", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
         new Product { Id = Guid.Parse("bd60de37-ebd9-4174-a085-6c29c2991643"), CategoryId = Guid.Parse("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), Barcode = "16734029856127", Name = "Kazak", Brand = "Lacoste", Size = "XS", Color = "Pink", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
         new Product { Id = Guid.Parse("9ff60759-1df3-4762-833f-9c039ce3dd3c"), CategoryId = Guid.Parse("47f0cacd-7e44-4989-8eee-2ba09e470abd"), Barcode = "23894571028356", Name = "Ceket", Brand = "Vakko", Size = "L", Color = "Black", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
         new Product { Id = Guid.Parse("63966b3c-dfa3-4d04-9ac0-c6435b1c1501"), CategoryId = Guid.Parse("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), Barcode = "48590123764580", Name = "Tişört", Brand = "Boyner", Size = "2XL", Color = "White", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
         new Product { Id = Guid.Parse("74b1fa9a-79bb-4b75-9c53-eee57c75e257"), CategoryId = Guid.Parse("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), Barcode = "34028571903428", Name = "Bluz", Brand = "H&M", Size = "S", Color = "Beige", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
         new Product { Id = Guid.Parse("532d0f81-9385-4cef-9a6a-46fc3c9fb65b"), CategoryId = Guid.Parse("40e576f2-63c3-45eb-827f-389113dcdfd4"), Barcode = "92837461029834", Name = "Kumaş Pantolon", Brand = "Calvin Klein", Size = "36", Color = "Khaki", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
         new Product { Id = Guid.Parse("a1e205d0-20ee-40e5-8e4c-e1164cca866e"), CategoryId = Guid.Parse("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), Barcode = "71234569018237", Name = "Tişört", Brand = "Nike", Size = "2XL", Color = "Blue", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
         new Product { Id = Guid.Parse("e8e6c63e-5054-4d9b-8f40-7d39865c81f5"), CategoryId = Guid.Parse("40e576f2-63c3-45eb-827f-389113dcdfd4"), Barcode = "56348091283749", Name = "Şort", Brand = "Adidas", Size = "40", Color = "Red", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
         new Product { Id = Guid.Parse("085aeff8-9d2a-49f5-bc7d-1d4efa55a16f"), CategoryId = Guid.Parse("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), Barcode = "49018237451028", Name = "Gömlek", Brand = "U.S. Polo Assn", Size = "XL", Color = "White", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now }
         );
        #endregion

    }
}
