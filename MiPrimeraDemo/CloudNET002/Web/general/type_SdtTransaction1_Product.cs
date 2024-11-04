using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.general {
   [XmlRoot(ElementName = "Transaction1.Product" )]
   [XmlType(TypeName =  "Transaction1.Product" , Namespace = "MiPrimeraDemo" )]
   [Serializable]
   public class SdtTransaction1_Product : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtTransaction1_Product( )
      {
      }

      public SdtTransaction1_Product( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProductID", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Product");
         metadata.Set("BT", "Transaction1Product");
         metadata.Set("PK", "[ \"ProductID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"InvoiceID\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Productid_Z");
         state.Add("gxTpr_Productname_Z");
         state.Add("gxTpr_Productprice_Z");
         state.Add("gxTpr_Invoiceproductquantity_Z");
         state.Add("gxTpr_Invoiceproducttotal_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.general.SdtTransaction1_Product sdt;
         sdt = (GeneXus.Programs.general.SdtTransaction1_Product)(source);
         gxTv_SdtTransaction1_Product_Productid = sdt.gxTv_SdtTransaction1_Product_Productid ;
         gxTv_SdtTransaction1_Product_Productname = sdt.gxTv_SdtTransaction1_Product_Productname ;
         gxTv_SdtTransaction1_Product_Productprice = sdt.gxTv_SdtTransaction1_Product_Productprice ;
         gxTv_SdtTransaction1_Product_Invoiceproductquantity = sdt.gxTv_SdtTransaction1_Product_Invoiceproductquantity ;
         gxTv_SdtTransaction1_Product_Invoiceproducttotal = sdt.gxTv_SdtTransaction1_Product_Invoiceproducttotal ;
         gxTv_SdtTransaction1_Product_Mode = sdt.gxTv_SdtTransaction1_Product_Mode ;
         gxTv_SdtTransaction1_Product_Modified = sdt.gxTv_SdtTransaction1_Product_Modified ;
         gxTv_SdtTransaction1_Product_Initialized = sdt.gxTv_SdtTransaction1_Product_Initialized ;
         gxTv_SdtTransaction1_Product_Productid_Z = sdt.gxTv_SdtTransaction1_Product_Productid_Z ;
         gxTv_SdtTransaction1_Product_Productname_Z = sdt.gxTv_SdtTransaction1_Product_Productname_Z ;
         gxTv_SdtTransaction1_Product_Productprice_Z = sdt.gxTv_SdtTransaction1_Product_Productprice_Z ;
         gxTv_SdtTransaction1_Product_Invoiceproductquantity_Z = sdt.gxTv_SdtTransaction1_Product_Invoiceproductquantity_Z ;
         gxTv_SdtTransaction1_Product_Invoiceproducttotal_Z = sdt.gxTv_SdtTransaction1_Product_Invoiceproducttotal_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("ProductID", gxTv_SdtTransaction1_Product_Productid, false, includeNonInitialized);
         AddObjectProperty("ProductName", gxTv_SdtTransaction1_Product_Productname, false, includeNonInitialized);
         AddObjectProperty("ProductPrice", gxTv_SdtTransaction1_Product_Productprice, false, includeNonInitialized);
         AddObjectProperty("InvoiceProductQuantity", gxTv_SdtTransaction1_Product_Invoiceproductquantity, false, includeNonInitialized);
         AddObjectProperty("InvoiceProductTotal", gxTv_SdtTransaction1_Product_Invoiceproducttotal, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTransaction1_Product_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtTransaction1_Product_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTransaction1_Product_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProductID_Z", gxTv_SdtTransaction1_Product_Productid_Z, false, includeNonInitialized);
            AddObjectProperty("ProductName_Z", gxTv_SdtTransaction1_Product_Productname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductPrice_Z", gxTv_SdtTransaction1_Product_Productprice_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceProductQuantity_Z", gxTv_SdtTransaction1_Product_Invoiceproductquantity_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceProductTotal_Z", gxTv_SdtTransaction1_Product_Invoiceproducttotal_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.general.SdtTransaction1_Product sdt )
      {
         if ( sdt.IsDirty("ProductID") )
         {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Productid = sdt.gxTv_SdtTransaction1_Product_Productid ;
         }
         if ( sdt.IsDirty("ProductName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Productname = sdt.gxTv_SdtTransaction1_Product_Productname ;
         }
         if ( sdt.IsDirty("ProductPrice") )
         {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Productprice = sdt.gxTv_SdtTransaction1_Product_Productprice ;
         }
         if ( sdt.IsDirty("InvoiceProductQuantity") )
         {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Invoiceproductquantity = sdt.gxTv_SdtTransaction1_Product_Invoiceproductquantity ;
         }
         if ( sdt.IsDirty("InvoiceProductTotal") )
         {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Invoiceproducttotal = sdt.gxTv_SdtTransaction1_Product_Invoiceproducttotal ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProductID" )]
      [  XmlElement( ElementName = "ProductID"   )]
      public short gxTpr_Productid
      {
         get {
            return gxTv_SdtTransaction1_Product_Productid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Productid = value;
            gxTv_SdtTransaction1_Product_Modified = 1;
            SetDirty("Productid");
         }

      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtTransaction1_Product_Productname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Productname = value;
            gxTv_SdtTransaction1_Product_Modified = 1;
            SetDirty("Productname");
         }

      }

      [  SoapElement( ElementName = "ProductPrice" )]
      [  XmlElement( ElementName = "ProductPrice"   )]
      public decimal gxTpr_Productprice
      {
         get {
            return gxTv_SdtTransaction1_Product_Productprice ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Productprice = value;
            gxTv_SdtTransaction1_Product_Modified = 1;
            SetDirty("Productprice");
         }

      }

      [  SoapElement( ElementName = "InvoiceProductQuantity" )]
      [  XmlElement( ElementName = "InvoiceProductQuantity"   )]
      public short gxTpr_Invoiceproductquantity
      {
         get {
            return gxTv_SdtTransaction1_Product_Invoiceproductquantity ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Invoiceproductquantity = value;
            gxTv_SdtTransaction1_Product_Modified = 1;
            SetDirty("Invoiceproductquantity");
         }

      }

      [  SoapElement( ElementName = "InvoiceProductTotal" )]
      [  XmlElement( ElementName = "InvoiceProductTotal"   )]
      public decimal gxTpr_Invoiceproducttotal
      {
         get {
            return gxTv_SdtTransaction1_Product_Invoiceproducttotal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Invoiceproducttotal = value;
            gxTv_SdtTransaction1_Product_Modified = 1;
            SetDirty("Invoiceproducttotal");
         }

      }

      public void gxTv_SdtTransaction1_Product_Invoiceproducttotal_SetNull( )
      {
         gxTv_SdtTransaction1_Product_Invoiceproducttotal = 0;
         SetDirty("Invoiceproducttotal");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Product_Invoiceproducttotal_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTransaction1_Product_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTransaction1_Product_Mode_SetNull( )
      {
         gxTv_SdtTransaction1_Product_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Product_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtTransaction1_Product_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtTransaction1_Product_Modified_SetNull( )
      {
         gxTv_SdtTransaction1_Product_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Product_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTransaction1_Product_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Initialized = value;
            gxTv_SdtTransaction1_Product_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTransaction1_Product_Initialized_SetNull( )
      {
         gxTv_SdtTransaction1_Product_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Product_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductID_Z" )]
      [  XmlElement( ElementName = "ProductID_Z"   )]
      public short gxTpr_Productid_Z
      {
         get {
            return gxTv_SdtTransaction1_Product_Productid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Productid_Z = value;
            gxTv_SdtTransaction1_Product_Modified = 1;
            SetDirty("Productid_Z");
         }

      }

      public void gxTv_SdtTransaction1_Product_Productid_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Product_Productid_Z = 0;
         SetDirty("Productid_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Product_Productid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductName_Z" )]
      [  XmlElement( ElementName = "ProductName_Z"   )]
      public string gxTpr_Productname_Z
      {
         get {
            return gxTv_SdtTransaction1_Product_Productname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Productname_Z = value;
            gxTv_SdtTransaction1_Product_Modified = 1;
            SetDirty("Productname_Z");
         }

      }

      public void gxTv_SdtTransaction1_Product_Productname_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Product_Productname_Z = "";
         SetDirty("Productname_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Product_Productname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductPrice_Z" )]
      [  XmlElement( ElementName = "ProductPrice_Z"   )]
      public decimal gxTpr_Productprice_Z
      {
         get {
            return gxTv_SdtTransaction1_Product_Productprice_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Productprice_Z = value;
            gxTv_SdtTransaction1_Product_Modified = 1;
            SetDirty("Productprice_Z");
         }

      }

      public void gxTv_SdtTransaction1_Product_Productprice_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Product_Productprice_Z = 0;
         SetDirty("Productprice_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Product_Productprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceProductQuantity_Z" )]
      [  XmlElement( ElementName = "InvoiceProductQuantity_Z"   )]
      public short gxTpr_Invoiceproductquantity_Z
      {
         get {
            return gxTv_SdtTransaction1_Product_Invoiceproductquantity_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Invoiceproductquantity_Z = value;
            gxTv_SdtTransaction1_Product_Modified = 1;
            SetDirty("Invoiceproductquantity_Z");
         }

      }

      public void gxTv_SdtTransaction1_Product_Invoiceproductquantity_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Product_Invoiceproductquantity_Z = 0;
         SetDirty("Invoiceproductquantity_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Product_Invoiceproductquantity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceProductTotal_Z" )]
      [  XmlElement( ElementName = "InvoiceProductTotal_Z"   )]
      public decimal gxTpr_Invoiceproducttotal_Z
      {
         get {
            return gxTv_SdtTransaction1_Product_Invoiceproducttotal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product_Invoiceproducttotal_Z = value;
            gxTv_SdtTransaction1_Product_Modified = 1;
            SetDirty("Invoiceproducttotal_Z");
         }

      }

      public void gxTv_SdtTransaction1_Product_Invoiceproducttotal_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Product_Invoiceproducttotal_Z = 0;
         SetDirty("Invoiceproducttotal_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Product_Invoiceproducttotal_Z_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtTransaction1_Product_Productname = "";
         gxTv_SdtTransaction1_Product_Mode = "";
         gxTv_SdtTransaction1_Product_Productname_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtTransaction1_Product_Productid ;
      private short sdtIsNull ;
      private short gxTv_SdtTransaction1_Product_Invoiceproductquantity ;
      private short gxTv_SdtTransaction1_Product_Modified ;
      private short gxTv_SdtTransaction1_Product_Initialized ;
      private short gxTv_SdtTransaction1_Product_Productid_Z ;
      private short gxTv_SdtTransaction1_Product_Invoiceproductquantity_Z ;
      private decimal gxTv_SdtTransaction1_Product_Productprice ;
      private decimal gxTv_SdtTransaction1_Product_Invoiceproducttotal ;
      private decimal gxTv_SdtTransaction1_Product_Productprice_Z ;
      private decimal gxTv_SdtTransaction1_Product_Invoiceproducttotal_Z ;
      private string gxTv_SdtTransaction1_Product_Productname ;
      private string gxTv_SdtTransaction1_Product_Mode ;
      private string gxTv_SdtTransaction1_Product_Productname_Z ;
   }

   [DataContract(Name = @"General\Transaction1.Product", Namespace = "MiPrimeraDemo")]
   [GxJsonSerialization("default")]
   public class SdtTransaction1_Product_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.general.SdtTransaction1_Product>
   {
      public SdtTransaction1_Product_RESTInterface( ) : base()
      {
      }

      public SdtTransaction1_Product_RESTInterface( GeneXus.Programs.general.SdtTransaction1_Product psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductID" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Productid
      {
         get {
            return sdt.gxTpr_Productid ;
         }

         set {
            sdt.gxTpr_Productid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Productname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Productname) ;
         }

         set {
            sdt.gxTpr_Productname = value;
         }

      }

      [DataMember( Name = "ProductPrice" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Productprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productprice, 8, 2)) ;
         }

         set {
            sdt.gxTpr_Productprice = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "InvoiceProductQuantity" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Invoiceproductquantity
      {
         get {
            return sdt.gxTpr_Invoiceproductquantity ;
         }

         set {
            sdt.gxTpr_Invoiceproductquantity = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "InvoiceProductTotal" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Invoiceproducttotal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Invoiceproducttotal, 8, 2)) ;
         }

         set {
            sdt.gxTpr_Invoiceproducttotal = NumberUtil.Val( value, ".");
         }

      }

      public GeneXus.Programs.general.SdtTransaction1_Product sdt
      {
         get {
            return (GeneXus.Programs.general.SdtTransaction1_Product)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.general.SdtTransaction1_Product() ;
         }
      }

   }

   [DataContract(Name = @"General\Transaction1.Product", Namespace = "MiPrimeraDemo")]
   [GxJsonSerialization("default")]
   public class SdtTransaction1_Product_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.general.SdtTransaction1_Product>
   {
      public SdtTransaction1_Product_RESTLInterface( ) : base()
      {
      }

      public SdtTransaction1_Product_RESTLInterface( GeneXus.Programs.general.SdtTransaction1_Product psdt ) : base(psdt)
      {
      }

      public GeneXus.Programs.general.SdtTransaction1_Product sdt
      {
         get {
            return (GeneXus.Programs.general.SdtTransaction1_Product)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.general.SdtTransaction1_Product() ;
         }
      }

   }

}
