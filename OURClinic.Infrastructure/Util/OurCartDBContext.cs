using Microsoft.EntityFrameworkCore;

using OURCart.DataModel.DTO;
using OURCart.DataModel.DTO.LocalModels;


namespace OURCart.Infrastructure.Util
{
    public partial class OurCartDBContext : DbContext
    {
        public OurCartDBContext()
        {
        }

        public OurCartDBContext(DbContextOptions<OurCartDBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<CartProducts> CartProducts { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<DeliveryClient> DeliveryClient { get; set; }
        public virtual DbSet<Favourites> Favourites { get; set; }
        public virtual DbSet<ItemBarCode> ItemBarCode { get; set; }
        public virtual DbSet<ItemCategory> ItemCategory { get; set; }
        public virtual DbSet<AppMessages> AppMessages { get; set; }
        public virtual DbSet<SalesRep> SalesRep { get; set; }



        public virtual DbSet<ItemPriceAttribute> ItemPriceAttribute { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<ItemsPackages> ItemsPackages { get; set; }
        public virtual DbSet<ItemsVendors> ItemsVendors { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PoscurrentDailyTransDetails> PoscurrentDailyTransDetails { get; set; }
        public virtual DbSet<PoscurrentDailyTransHeader> PoscurrentDailyTransHeader { get; set; }
        public virtual DbSet<CategoryItemsDisplayItem> CategoryItemsDisplayItem { get; set; } // will only used retrieve data from many tables 
        public virtual DbSet<CategoryItem> CategorItem { get; set; } // will only used retrieve data from many tables in ds as view
        public virtual DbSet<CategoryItemWithQnty> OrderProducts { get; set; }
        public virtual DbSet<CategoryOffersDisplayItem> CategoryOffersDisplayItem { get; set; } // will only used retrieve data from many tables in ds as view
        public virtual DbSet<itemsCountInCategory> itemsCountInCategory { get; set; } // retrieve count of  all items in specific data
        public virtual DbSet<CartTotalModel> CartTotalModel { get; set; }
        public virtual DbSet<userCartItem> userCartItem { get; set; }
        public virtual DbSet<OffersModel> offers { get; set; }
       
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
              
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.AreaId).ValueGeneratedNever();

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AreaNameEn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.FkStoreId).HasColumnName("fkStoreId");

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.InsUserId).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RecId)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.Property(e => e.UpdUserId).HasColumnType("decimal(18, 0)");
            });



            modelBuilder.Entity<CartProducts>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.quantity)
          .HasColumnName("quantity")
          .HasColumnType("numeric(18, 0)");

            entity.Property(e => e.FkDeliveryClientId)
                .HasColumnName("fk_DeliveryClientId")
                .HasColumnType("numeric(18, 0)");

            entity.Property(e => e.fkPackageID)
                .HasColumnName("fkPackageID")
                .HasColumnType("numeric(18, 0)");

            entity.Property(e => e.FkItemId)
                .HasColumnName("FkItemId")
                .HasColumnType("numeric(18, 0)");

            entity.Property(e => e.InsertDateTime)
                .HasColumnName("insertDateTime")
                .HasColumnType("datetime");

           
            //entity.Property(e => e.quantity).HasColumnName("quantity");

            //entity.HasOne(d => d.item)
            //      .WithMany(f => f.CartProducts)
            //      .HasForeignKey(d => d.FkItemId)
            //      .OnDelete(DeleteBehavior.ClientSetNull)
            //      .HasConstraintName("FK_CartProducts_Items");


            //entity.HasOne(d => d.FkDeliveryClient)
            //    .WithMany(p => p.CartProducts)
            //    .HasForeignKey(d => d.FkDeliveryClientId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_CartProducts_DeliveryClient");


            //entity.HasOne(d => d.item)
            //    .WithMany(p => p.CartProducts)
            //    .HasForeignKey(d => d.FkTemId);


            //entity.HasOne(d => d.Fk)
            //    .WithMany(p => p.CartProducts)
            //    .HasForeignKey(d => new { d.FkItemPackageId, d.FkTemId })
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_CartProducts_ItemsPackages");
        });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ClientNameEng)
                    .HasMaxLength(250)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClientTypeId)
                    .HasColumnName("ClientTypeID")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.CommercailRegistryNo).HasMaxLength(250);

                entity.Property(e => e.ContractNotes).HasMaxLength(500);

                entity.Property(e => e.ContractPeriod).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ContractStartDate).HasMaxLength(50);

                entity.Property(e => e.CreditLimit).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreditLimitInvoice).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreditPeriod).HasMaxLength(250);
                entity.HasIndex(u => u.Email)
                 .IsUnique();
                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Fax).HasMaxLength(250);

                entity.Property(e => e.FkAccNo)
                    .HasColumnName("fkAccNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FkAgeGroupId).HasColumnName("fkAgeGroupID");

                entity.Property(e => e.FkClientCategoryId)
                    .HasColumnName("fkClientCategoryID")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FkSalesRepId)
                    .HasColumnName("fkSalesRepId")
                    .HasMaxLength(5);

                entity.Property(e => e.InsDate).HasMaxLength(8);

                entity.Property(e => e.InsUserId).HasMaxLength(250);

                entity.Property(e => e.KeyPerson).HasMaxLength(500);

                entity.Property(e => e.Mobile).HasMaxLength(250);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone1).HasMaxLength(250);

                entity.Property(e => e.PriceCatId).HasDefaultValueSql("((3))");

                entity.Property(e => e.RecId)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.TaxCardNo).HasMaxLength(250);

                entity.Property(e => e.TaxFileNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TaxRegistrationNo).HasMaxLength(250);

                entity.Property(e => e.UpdDate).HasMaxLength(8);

                entity.Property(e => e.WithholdingTax).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<DeliveryClient>(entity =>
            {
                entity.HasKey(e => e.DelClientId);

                entity.Property(e => e.DelClientId)
                .HasColumnType("numeric(18, 0)")
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.AdminNotes).HasMaxLength(1000);

                entity.Property(e => e.Apartment).HasMaxLength(50);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ClientNameEn).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FkAccNo)
                    .HasColumnName("fkAccNo")
                    .HasMaxLength(50);

                entity.Property(e => e.FkAreaId).HasColumnName("fkAreaId");

                entity.Property(e => e.FkMemberShipId).HasColumnName("fkMemberShipId");

                entity.Property(e => e.Floor).HasMaxLength(50);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.InsUserId)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(250);

                entity.Property(e => e.Phone1).HasMaxLength(50);

                entity.Property(e => e.Phone2).HasMaxLength(50);

                entity.Property(e => e.Phone3).HasMaxLength(50);

                entity.Property(e => e.PointsBalance).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.Posdiscount)
                    .HasColumnName("POSDiscount")
                    .HasColumnType("numeric(18, 3)");

                entity.Property(e => e.PosdiscountType).HasColumnName("POSDiscountType");

                entity.Property(e => e.PrintNotes).HasMaxLength(1000);

                entity.Property(e => e.RecId)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.SalesBalance).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.SpecialMark).HasMaxLength(500);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.Property(e => e.UpdUserId).HasMaxLength(250);

                entity.HasOne(d => d.FkArea)
                    .WithMany(p => p.DeliveryClient)
                    .HasForeignKey(d => d.FkAreaId)
                    .HasConstraintName("FK_DeliveryClient_DeliveryClient");
            });

            modelBuilder.Entity<ItemBarCode>(entity =>
            {
                entity.HasIndex(e => new { e.BarCode, e.FkItemPackageId, e.FkItemId })
                    .HasName("UniqueBarCode")
                    .IsUnique();

                entity.Property(e => e.ItemBarCodeId)
                    .HasColumnName("ItemBarCodeID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BarCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.BarCodeFormat).HasMaxLength(50);

                entity.Property(e => e.BarCodePrice).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.FkItemId)
                    .HasColumnName("fkItemID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FkItemPackageId)
                    .HasColumnName("fkItemPackageID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FkPackageId).HasColumnName("fkPackageID");

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.InsUserName).HasMaxLength(250);

                entity.Property(e => e.RecId)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.Property(e => e.UpdUserName).HasMaxLength(250);

                entity.HasOne(d => d.FkItem)
                    .WithMany(p => p.ItemBarCode)
                    .HasForeignKey(d => d.FkItemId)
                    .HasConstraintName("FK_ItemBarCode_Items");

                entity.HasOne(d => d.FkPackage)
                    .WithMany(p => p.ItemBarCode)
                    .HasForeignKey(d => d.FkPackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemBarCode_Package");
            });

            modelBuilder.Entity<Favourites>(entity =>
            {
                entity.ToTable("favourites");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkDeliveryClientId)
                    .HasColumnName("fk_deliveryClientID")
                    .HasColumnType("numeric(18, 0)");

                

                entity.Property(e => e.FkItemPackageId)
                    .HasColumnName("fk_itemPackageID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InsDateTime)
                    .HasColumnName("insDateTime")
                    .HasMaxLength(10);

                //entity.HasOne(d => d.Item)
                //    .WithMany(f=>f.Favourites)
                //    .HasForeignKey(d =>d.FkItemID)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_favourites_Items");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CategoryNameEng)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FkShopId).HasColumnName("fkShopID");

                entity.Property(e => e.InsDate).HasMaxLength(50);

                entity.Property(e => e.InsUserId).HasMaxLength(250);

                entity.Property(e => e.RecId)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.UpdDate).HasMaxLength(50);

                entity.Property(e => e.UpdUserId).HasMaxLength(50);
            });

            modelBuilder.Entity<ItemPriceAttribute>(entity =>
            {
                entity.HasKey(e => e.AttributeId)
                    .HasName("PK_ItemPriceAttribute_1");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.AttrebuteName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.Property(e => e.ItemTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemTypeNameEng)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK_Item");

                entity.HasIndex(e => e.FkCategoryId)
                    .HasName("idx_Item_fkCategoryId");

                entity.HasIndex(e => e.FkItemTypeId)
                    .HasName("idx_Item_fkItemTypeId");

                entity.Property(e => e.ItemId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Additions).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.AdditionsRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.AllowedExcessRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.AnnualDiscount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.AnnualDiscountRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.CashDiscount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.CashDiscountRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.DeferralDiscount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.DeferralDiscountRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.ExtraDiscount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.ExtraDiscountRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.FkCategoryId).HasColumnName("fkCategoryId");

                entity.Property(e => e.FkFixedAssetId)
                    .HasColumnName("fkFixedAssetId")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FkItemTypeId).HasColumnName("fkItemTypeId");

                entity.Property(e => e.FkVariantAid).HasColumnName("fkVariantAID");

                entity.Property(e => e.FkVariantBid).HasColumnName("fkVariantBID");

                entity.Property(e => e.FkVendorId)
                    .HasColumnName("fkVendorId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.InsUserName).HasMaxLength(250);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ItemNameEn).HasMaxLength(255);

                entity.Property(e => e.ItemTax).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.ItemTaxRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.MainImgUrl).HasMaxLength(255);

                entity.Property(e => e.MaxOrderQty).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.MaxOrderQuantity).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.MaxStockQuantity).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.MonthlyDiscount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.MonthlyDiscountRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.OnHandQty).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.PurchaseDiscount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.PurchaseDiscountRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.PurchaseNotes).HasMaxLength(500);

                entity.Property(e => e.QtyIncreaseBy).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.QuarterAnnualDiscount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.QuarterAnnualDiscountRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.RecId)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.ReorderQuantity)
                    .HasColumnType("numeric(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnDiscount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.ReturnDiscountRate).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.SalesNotes).HasMaxLength(500);

                entity.Property(e => e.SearchItemName).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.Property(e => e.UpdUserName).HasMaxLength(250);

                entity.Property(e => e.VendorDiscount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.VendorDiscountRate).HasColumnType("numeric(6, 3)");

                entity.HasOne(d => d.FkCategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.FkCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ref_Items_ItemCategory1");

                entity.HasOne(d => d.FkItemType)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.FkItemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ref_Items_ItemType");

                entity.HasOne(d => d.FkVendor)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.FkVendorId)
                    .HasConstraintName("FK_Items_Client");
            });

            modelBuilder.Entity<ItemsPackages>(entity =>
            {
                entity.HasKey(e => new { e.ItemPackageId, e.FkItemId });

                entity.Property(e => e.ItemPackageId)
                    .HasColumnName("ItemPackageID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FkItemId)
                    .HasColumnName("fkItemID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CustomerPrice).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.FkPackageId).HasColumnName("fkPackageID");

                entity.Property(e => e.FkPriceAttributeValA).HasColumnName("fkPriceAttributeValA");

                entity.Property(e => e.FkPriceAttributeValB).HasColumnName("fkPriceAttributeValB");

                entity.Property(e => e.HalfWholeSalePrice).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.HalfWholeSaleProfit).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.InsUserName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ItemCost).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.PurchasePrice).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.QtyPerPackage)
                    .HasColumnType("numeric(18, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RecId)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.SaleProfit).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.Property(e => e.UpdUserName).HasMaxLength(250);

                entity.Property(e => e.WholeSalePrice).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.WholeSaleProfit).HasColumnType("numeric(18, 3)");

                entity.HasOne(d => d.FkItem)
                    .WithMany(p => p.ItemsPackages)
                    .HasForeignKey(d => d.FkItemId)
                    .HasConstraintName("FK_ItemsPackages_Items");

                entity.HasOne(d => d.FkPackage)
                    .WithMany(p => p.ItemsPackages)
                    .HasForeignKey(d => d.FkPackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsPackages_Package");
            });

            modelBuilder.Entity<ItemsVendors>(entity =>
            {
                entity.HasKey(e => e.ItemVendorId);

                entity.Property(e => e.ItemVendorId).HasColumnName("ItemVendorID");

                entity.Property(e => e.FkItemId).HasColumnName("fkItemID");

                entity.Property(e => e.FkVendorId).HasColumnName("fkVendorID");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.InsUser).HasMaxLength(250);

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PackageNameEn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RecId)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.Property(e => e.UpdUser).HasMaxLength(250);
            });

            modelBuilder.Entity<PoscurrentDailyTransDetails>(entity =>
            {
                entity.HasKey(e => new { e.DetailId, e.FkBrId, e.HeaderId, e.FktransTypeId });

                entity.ToTable("POSCurrentDailyTransDetails");

                entity.Property(e => e.DetailId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FkBrId).HasColumnName("fkBrId");

                entity.Property(e => e.HeaderId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FktransTypeId).HasColumnName("fktransTypeID");

                entity.Property(e => e.AffectedPieces).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.BarcodeDescription).HasMaxLength(255);

                entity.Property(e => e.CustPrice).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.DiscHeader).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.DiscMember).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.DiscPromo).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.DiscSeason).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.FkItemBarcodeId)
                    .HasColumnName("fkItemBarcodeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FkParentItemId).HasColumnName("fkParentItemId");

                entity.Property(e => e.FkStoreId).HasColumnName("fkStoreId");

                entity.Property(e => e.HalfWholeSalePrice).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.ItemCost).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.ItemId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PurchasePrice).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.Qty).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.ReturnedQty)
                    .HasColumnType("numeric(18, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SalePrice).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.TaxRate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.TransDate)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.VendDiscount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.VendDiscountRate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.WholeSalePrice).HasColumnType("numeric(18, 3)");

                entity.HasOne(d => d.PoscurrentDailyTransHeader)
                    .WithMany(p => p.PoscurrentDailyTransDetails)
                    .HasForeignKey(d => new { d.HeaderId, d.FkBrId, d.FktransTypeId })
                    .HasConstraintName("FK_POSCurrentDailyTransDetails_POSCurrentDailyTransHeader");
            });

            modelBuilder.Entity<PoscurrentDailyTransHeader>(entity =>
            {
                entity.HasKey(e => new { e.HeaderId, e.FkBrId, e.FkTransTypeId })
                    .HasName("PK_POSCurrentDailyTransHeader_1");

                entity.ToTable("POSCurrentDailyTransHeader");

                entity.Property(e => e.HeaderId).HasColumnType("numeric(18, 0)").ValueGeneratedOnAdd();

                entity.Property(e => e.FkBrId).HasColumnName("fkBrId");

                entity.Property(e => e.FkTransTypeId).HasColumnName("fkTransTypeID");

                entity.Property(e => e.Addition).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.AdditionRate).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.CallerPhone).HasMaxLength(15);

                entity.Property(e => e.CashierName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ClientId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ClientName).HasMaxLength(255);

                entity.Property(e => e.DeliveryAmount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.Discount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.DiscountRate).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.DueDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FkClientTypeId).HasColumnName("fkClientTypeID");

                entity.Property(e => e.FkDeliveryStatusId).HasColumnName("fkDeliveryStatusId");

                entity.Property(e => e.FkEmpId).HasColumnName("fkEmpId");

                entity.Property(e => e.FkInvoiceStatusId)
                    .HasColumnName("fkInvoiceStatusID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FkPaymentTypeId).HasColumnName("fkPaymentTypeId");

                entity.Property(e => e.FkPosCloseId)
                    .HasColumnName("fkPosCloseId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FkVisaCardId)
                    .HasColumnName("fkVisaCardId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FkVisaMachineId).HasColumnName("fkVisaMachineId");

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.InsDeliveryClosed).HasMaxLength(50);

                entity.Property(e => e.InsDeliverySent).HasMaxLength(50);

                entity.Property(e => e.InsUserId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InsUserName).HasMaxLength(255);

                entity.Property(e => e.ManualNo).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Notes).HasMaxLength(100);

                entity.Property(e => e.OrgheaderRef)
                    .HasColumnName("ORGHeaderRef")
                    .HasMaxLength(255);

                entity.Property(e => e.Paid).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.PicupDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.RecId).IsRowVersion();

                entity.Property(e => e.RefNo).HasMaxLength(255);

                entity.Property(e => e.Remain).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.SalesRepId).HasMaxLength(5);

                entity.Property(e => e.SalesRepName).HasMaxLength(255);

                entity.Property(e => e.StoreName).HasMaxLength(255);

                entity.Property(e => e.SubTotal)
                    .HasColumnName("subTotal")
                    .HasColumnType("numeric(18, 3)");

                entity.Property(e => e.Tax).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.TaxRate).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.TransDate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.TransNumber).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UpdDate).HasMaxLength(8);

                entity.Property(e => e.UpdUserId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VisaAmount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.VisaCardDeduct).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.VisaCardDeductAmount).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.VisaCardInfo).HasMaxLength(200);
            });
           

        }
    }
}