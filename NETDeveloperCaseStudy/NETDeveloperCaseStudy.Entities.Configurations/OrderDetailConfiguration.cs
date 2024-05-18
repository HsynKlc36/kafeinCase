namespace NETDeveloperCaseStudy.Entities.Configurations;
public class OrderDetailConfiguration : AuditableEntityTypeConfiguration<OrderDetail>
{
    public override void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        base.Configure(builder);
        builder.HasAlternateKey(od => new { od.OrderId, od.ProductId });
        builder.Property(od=>od.Amount).IsRequired();
        #region Many_to_Many_Relationship
        builder.HasOne(od => od.Order).WithMany(o => o.Products).HasForeignKey(od => od.OrderId);
        builder.HasOne(od => od.Product).WithMany(p => p.Orders).HasForeignKey(od => od.ProductId);
        #endregion
    }
}
