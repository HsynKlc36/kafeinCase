namespace NETDeveloperCaseStudy.Entities.Configurations;
public class OrderConfiguration : AuditableEntityTypeConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);
        #region One_To_Many_Relationship
        builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
        builder.HasOne(o => o.Market).WithMany(m => m.Orders).HasForeignKey(o => o.MarketId);
        #endregion
    }
}
