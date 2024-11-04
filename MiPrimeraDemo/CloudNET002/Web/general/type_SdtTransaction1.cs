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
   [XmlRoot(ElementName = "Transaction1" )]
   [XmlType(TypeName =  "Transaction1" , Namespace = "MiPrimeraDemo" )]
   [Serializable]
   public class SdtTransaction1 : GxSilentTrnSdt
   {
      public SdtTransaction1( )
      {
      }

      public SdtTransaction1( IGxContext context )
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

      public void Load( short AV6InvoiceID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV6InvoiceID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"InvoiceID", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "General\\Transaction1");
         metadata.Set("BT", "Transaction1");
         metadata.Set("PK", "[ \"InvoiceID\" ]");
         metadata.Set("PKAssigned", "[ \"InvoiceID\" ]");
         metadata.Set("Levels", "[ \"Product\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CustomerID\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Invoiceid_Z");
         state.Add("gxTpr_Invoicedate_Z_Nullable");
         state.Add("gxTpr_Customerid_Z");
         state.Add("gxTpr_Customername_Z");
         state.Add("gxTpr_Invoicesubtotal_Z");
         state.Add("gxTpr_Invoicetax_Z");
         state.Add("gxTpr_Invoicetotal_Z");
         state.Add("gxTpr_Invoicesubtotal_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.general.SdtTransaction1 sdt;
         sdt = (GeneXus.Programs.general.SdtTransaction1)(source);
         gxTv_SdtTransaction1_Invoiceid = sdt.gxTv_SdtTransaction1_Invoiceid ;
         gxTv_SdtTransaction1_Invoicedate = sdt.gxTv_SdtTransaction1_Invoicedate ;
         gxTv_SdtTransaction1_Customerid = sdt.gxTv_SdtTransaction1_Customerid ;
         gxTv_SdtTransaction1_Customername = sdt.gxTv_SdtTransaction1_Customername ;
         gxTv_SdtTransaction1_Product = sdt.gxTv_SdtTransaction1_Product ;
         gxTv_SdtTransaction1_Invoicesubtotal = sdt.gxTv_SdtTransaction1_Invoicesubtotal ;
         gxTv_SdtTransaction1_Invoicetax = sdt.gxTv_SdtTransaction1_Invoicetax ;
         gxTv_SdtTransaction1_Invoicetotal = sdt.gxTv_SdtTransaction1_Invoicetotal ;
         gxTv_SdtTransaction1_Mode = sdt.gxTv_SdtTransaction1_Mode ;
         gxTv_SdtTransaction1_Initialized = sdt.gxTv_SdtTransaction1_Initialized ;
         gxTv_SdtTransaction1_Invoiceid_Z = sdt.gxTv_SdtTransaction1_Invoiceid_Z ;
         gxTv_SdtTransaction1_Invoicedate_Z = sdt.gxTv_SdtTransaction1_Invoicedate_Z ;
         gxTv_SdtTransaction1_Customerid_Z = sdt.gxTv_SdtTransaction1_Customerid_Z ;
         gxTv_SdtTransaction1_Customername_Z = sdt.gxTv_SdtTransaction1_Customername_Z ;
         gxTv_SdtTransaction1_Invoicesubtotal_Z = sdt.gxTv_SdtTransaction1_Invoicesubtotal_Z ;
         gxTv_SdtTransaction1_Invoicetax_Z = sdt.gxTv_SdtTransaction1_Invoicetax_Z ;
         gxTv_SdtTransaction1_Invoicetotal_Z = sdt.gxTv_SdtTransaction1_Invoicetotal_Z ;
         gxTv_SdtTransaction1_Invoicesubtotal_N = sdt.gxTv_SdtTransaction1_Invoicesubtotal_N ;
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
         AddObjectProperty("InvoiceID", gxTv_SdtTransaction1_Invoiceid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTransaction1_Invoicedate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTransaction1_Invoicedate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTransaction1_Invoicedate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("InvoiceDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CustomerID", gxTv_SdtTransaction1_Customerid, false, includeNonInitialized);
         AddObjectProperty("CustomerName", gxTv_SdtTransaction1_Customername, false, includeNonInitialized);
         if ( gxTv_SdtTransaction1_Product != null )
         {
            AddObjectProperty("Product", gxTv_SdtTransaction1_Product, includeState, includeNonInitialized);
         }
         AddObjectProperty("InvoiceSubtotal", gxTv_SdtTransaction1_Invoicesubtotal, false, includeNonInitialized);
         AddObjectProperty("InvoiceSubtotal_N", gxTv_SdtTransaction1_Invoicesubtotal_N, false, includeNonInitialized);
         AddObjectProperty("InvoiceTax", gxTv_SdtTransaction1_Invoicetax, false, includeNonInitialized);
         AddObjectProperty("InvoiceTotal", gxTv_SdtTransaction1_Invoicetotal, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTransaction1_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTransaction1_Initialized, false, includeNonInitialized);
            AddObjectProperty("InvoiceID_Z", gxTv_SdtTransaction1_Invoiceid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTransaction1_Invoicedate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTransaction1_Invoicedate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTransaction1_Invoicedate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("InvoiceDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("CustomerID_Z", gxTv_SdtTransaction1_Customerid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerName_Z", gxTv_SdtTransaction1_Customername_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceSubtotal_Z", gxTv_SdtTransaction1_Invoicesubtotal_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceTax_Z", gxTv_SdtTransaction1_Invoicetax_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceTotal_Z", gxTv_SdtTransaction1_Invoicetotal_Z, false, includeNonInitialized);
            AddObjectProperty("InvoiceSubtotal_N", gxTv_SdtTransaction1_Invoicesubtotal_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.general.SdtTransaction1 sdt )
      {
         if ( sdt.IsDirty("InvoiceID") )
         {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoiceid = sdt.gxTv_SdtTransaction1_Invoiceid ;
         }
         if ( sdt.IsDirty("InvoiceDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicedate = sdt.gxTv_SdtTransaction1_Invoicedate ;
         }
         if ( sdt.IsDirty("CustomerID") )
         {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Customerid = sdt.gxTv_SdtTransaction1_Customerid ;
         }
         if ( sdt.IsDirty("CustomerName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Customername = sdt.gxTv_SdtTransaction1_Customername ;
         }
         if ( gxTv_SdtTransaction1_Product != null )
         {
            GXBCLevelCollection<GeneXus.Programs.general.SdtTransaction1_Product> newCollectionProduct = sdt.gxTpr_Product;
            GeneXus.Programs.general.SdtTransaction1_Product currItemProduct;
            GeneXus.Programs.general.SdtTransaction1_Product newItemProduct;
            short idx = 1;
            while ( idx <= newCollectionProduct.Count )
            {
               newItemProduct = ((GeneXus.Programs.general.SdtTransaction1_Product)newCollectionProduct.Item(idx));
               currItemProduct = gxTv_SdtTransaction1_Product.GetByKey(newItemProduct.gxTpr_Productid);
               if ( StringUtil.StrCmp(currItemProduct.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemProduct.UpdateDirties(newItemProduct);
                  if ( StringUtil.StrCmp(newItemProduct.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemProduct.gxTpr_Mode = "DLT";
                  }
                  currItemProduct.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtTransaction1_Product.Add(newItemProduct, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( sdt.IsDirty("InvoiceSubtotal") )
         {
            gxTv_SdtTransaction1_Invoicesubtotal_N = (short)(sdt.gxTv_SdtTransaction1_Invoicesubtotal_N);
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicesubtotal = sdt.gxTv_SdtTransaction1_Invoicesubtotal ;
         }
         if ( sdt.IsDirty("InvoiceTax") )
         {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicetax = sdt.gxTv_SdtTransaction1_Invoicetax ;
         }
         if ( sdt.IsDirty("InvoiceTotal") )
         {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicetotal = sdt.gxTv_SdtTransaction1_Invoicetotal ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "InvoiceID" )]
      [  XmlElement( ElementName = "InvoiceID"   )]
      public short gxTpr_Invoiceid
      {
         get {
            return gxTv_SdtTransaction1_Invoiceid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTransaction1_Invoiceid != value )
            {
               gxTv_SdtTransaction1_Mode = "INS";
               this.gxTv_SdtTransaction1_Invoiceid_Z_SetNull( );
               this.gxTv_SdtTransaction1_Invoicedate_Z_SetNull( );
               this.gxTv_SdtTransaction1_Customerid_Z_SetNull( );
               this.gxTv_SdtTransaction1_Customername_Z_SetNull( );
               this.gxTv_SdtTransaction1_Invoicesubtotal_Z_SetNull( );
               this.gxTv_SdtTransaction1_Invoicetax_Z_SetNull( );
               this.gxTv_SdtTransaction1_Invoicetotal_Z_SetNull( );
               if ( gxTv_SdtTransaction1_Product != null )
               {
                  GXBCLevelCollection<GeneXus.Programs.general.SdtTransaction1_Product> collectionProduct = gxTv_SdtTransaction1_Product;
                  GeneXus.Programs.general.SdtTransaction1_Product currItemProduct;
                  short idx = 1;
                  while ( idx <= collectionProduct.Count )
                  {
                     currItemProduct = ((GeneXus.Programs.general.SdtTransaction1_Product)collectionProduct.Item(idx));
                     currItemProduct.gxTpr_Mode = "INS";
                     currItemProduct.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtTransaction1_Invoiceid = value;
            SetDirty("Invoiceid");
         }

      }

      [  SoapElement( ElementName = "InvoiceDate" )]
      [  XmlElement( ElementName = "InvoiceDate"  , IsNullable=true )]
      public string gxTpr_Invoicedate_Nullable
      {
         get {
            if ( gxTv_SdtTransaction1_Invoicedate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTransaction1_Invoicedate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTransaction1_Invoicedate = DateTime.MinValue;
            else
               gxTv_SdtTransaction1_Invoicedate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Invoicedate
      {
         get {
            return gxTv_SdtTransaction1_Invoicedate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicedate = value;
            SetDirty("Invoicedate");
         }

      }

      [  SoapElement( ElementName = "CustomerID" )]
      [  XmlElement( ElementName = "CustomerID"   )]
      public short gxTpr_Customerid
      {
         get {
            return gxTv_SdtTransaction1_Customerid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Customerid = value;
            SetDirty("Customerid");
         }

      }

      [  SoapElement( ElementName = "CustomerName" )]
      [  XmlElement( ElementName = "CustomerName"   )]
      public string gxTpr_Customername
      {
         get {
            return gxTv_SdtTransaction1_Customername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Customername = value;
            SetDirty("Customername");
         }

      }

      [  SoapElement( ElementName = "Product" )]
      [  XmlArray( ElementName = "Product"  )]
      [  XmlArrayItemAttribute( ElementName= "Transaction1.Product"  , IsNullable=false)]
      public GXBCLevelCollection<GeneXus.Programs.general.SdtTransaction1_Product> gxTpr_Product_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtTransaction1_Product == null )
            {
               gxTv_SdtTransaction1_Product = new GXBCLevelCollection<GeneXus.Programs.general.SdtTransaction1_Product>( context, "Transaction1.Product", "MiPrimeraDemo");
            }
            return gxTv_SdtTransaction1_Product ;
         }

         set {
            if ( gxTv_SdtTransaction1_Product == null )
            {
               gxTv_SdtTransaction1_Product = new GXBCLevelCollection<GeneXus.Programs.general.SdtTransaction1_Product>( context, "Transaction1.Product", "MiPrimeraDemo");
            }
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<GeneXus.Programs.general.SdtTransaction1_Product> gxTpr_Product
      {
         get {
            if ( gxTv_SdtTransaction1_Product == null )
            {
               gxTv_SdtTransaction1_Product = new GXBCLevelCollection<GeneXus.Programs.general.SdtTransaction1_Product>( context, "Transaction1.Product", "MiPrimeraDemo");
            }
            sdtIsNull = 0;
            return gxTv_SdtTransaction1_Product ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Product = value;
            SetDirty("Product");
         }

      }

      public void gxTv_SdtTransaction1_Product_SetNull( )
      {
         gxTv_SdtTransaction1_Product = null;
         SetDirty("Product");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Product_IsNull( )
      {
         if ( gxTv_SdtTransaction1_Product == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceSubtotal" )]
      [  XmlElement( ElementName = "InvoiceSubtotal"   )]
      public decimal gxTpr_Invoicesubtotal
      {
         get {
            return gxTv_SdtTransaction1_Invoicesubtotal ;
         }

         set {
            gxTv_SdtTransaction1_Invoicesubtotal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicesubtotal = value;
            SetDirty("Invoicesubtotal");
         }

      }

      public void gxTv_SdtTransaction1_Invoicesubtotal_SetNull( )
      {
         gxTv_SdtTransaction1_Invoicesubtotal_N = 1;
         gxTv_SdtTransaction1_Invoicesubtotal = 0;
         SetDirty("Invoicesubtotal");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Invoicesubtotal_IsNull( )
      {
         return (gxTv_SdtTransaction1_Invoicesubtotal_N==1) ;
      }

      [  SoapElement( ElementName = "InvoiceTax" )]
      [  XmlElement( ElementName = "InvoiceTax"   )]
      public decimal gxTpr_Invoicetax
      {
         get {
            return gxTv_SdtTransaction1_Invoicetax ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicetax = value;
            SetDirty("Invoicetax");
         }

      }

      public void gxTv_SdtTransaction1_Invoicetax_SetNull( )
      {
         gxTv_SdtTransaction1_Invoicetax = 0;
         SetDirty("Invoicetax");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Invoicetax_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceTotal" )]
      [  XmlElement( ElementName = "InvoiceTotal"   )]
      public decimal gxTpr_Invoicetotal
      {
         get {
            return gxTv_SdtTransaction1_Invoicetotal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicetotal = value;
            SetDirty("Invoicetotal");
         }

      }

      public void gxTv_SdtTransaction1_Invoicetotal_SetNull( )
      {
         gxTv_SdtTransaction1_Invoicetotal = 0;
         SetDirty("Invoicetotal");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Invoicetotal_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTransaction1_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTransaction1_Mode_SetNull( )
      {
         gxTv_SdtTransaction1_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTransaction1_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTransaction1_Initialized_SetNull( )
      {
         gxTv_SdtTransaction1_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceID_Z" )]
      [  XmlElement( ElementName = "InvoiceID_Z"   )]
      public short gxTpr_Invoiceid_Z
      {
         get {
            return gxTv_SdtTransaction1_Invoiceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoiceid_Z = value;
            SetDirty("Invoiceid_Z");
         }

      }

      public void gxTv_SdtTransaction1_Invoiceid_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Invoiceid_Z = 0;
         SetDirty("Invoiceid_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Invoiceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceDate_Z" )]
      [  XmlElement( ElementName = "InvoiceDate_Z"  , IsNullable=true )]
      public string gxTpr_Invoicedate_Z_Nullable
      {
         get {
            if ( gxTv_SdtTransaction1_Invoicedate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTransaction1_Invoicedate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTransaction1_Invoicedate_Z = DateTime.MinValue;
            else
               gxTv_SdtTransaction1_Invoicedate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Invoicedate_Z
      {
         get {
            return gxTv_SdtTransaction1_Invoicedate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicedate_Z = value;
            SetDirty("Invoicedate_Z");
         }

      }

      public void gxTv_SdtTransaction1_Invoicedate_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Invoicedate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Invoicedate_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Invoicedate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerID_Z" )]
      [  XmlElement( ElementName = "CustomerID_Z"   )]
      public short gxTpr_Customerid_Z
      {
         get {
            return gxTv_SdtTransaction1_Customerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Customerid_Z = value;
            SetDirty("Customerid_Z");
         }

      }

      public void gxTv_SdtTransaction1_Customerid_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Customerid_Z = 0;
         SetDirty("Customerid_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Customerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerName_Z" )]
      [  XmlElement( ElementName = "CustomerName_Z"   )]
      public string gxTpr_Customername_Z
      {
         get {
            return gxTv_SdtTransaction1_Customername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Customername_Z = value;
            SetDirty("Customername_Z");
         }

      }

      public void gxTv_SdtTransaction1_Customername_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Customername_Z = "";
         SetDirty("Customername_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Customername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceSubtotal_Z" )]
      [  XmlElement( ElementName = "InvoiceSubtotal_Z"   )]
      public decimal gxTpr_Invoicesubtotal_Z
      {
         get {
            return gxTv_SdtTransaction1_Invoicesubtotal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicesubtotal_Z = value;
            SetDirty("Invoicesubtotal_Z");
         }

      }

      public void gxTv_SdtTransaction1_Invoicesubtotal_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Invoicesubtotal_Z = 0;
         SetDirty("Invoicesubtotal_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Invoicesubtotal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceTax_Z" )]
      [  XmlElement( ElementName = "InvoiceTax_Z"   )]
      public decimal gxTpr_Invoicetax_Z
      {
         get {
            return gxTv_SdtTransaction1_Invoicetax_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicetax_Z = value;
            SetDirty("Invoicetax_Z");
         }

      }

      public void gxTv_SdtTransaction1_Invoicetax_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Invoicetax_Z = 0;
         SetDirty("Invoicetax_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Invoicetax_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceTotal_Z" )]
      [  XmlElement( ElementName = "InvoiceTotal_Z"   )]
      public decimal gxTpr_Invoicetotal_Z
      {
         get {
            return gxTv_SdtTransaction1_Invoicetotal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicetotal_Z = value;
            SetDirty("Invoicetotal_Z");
         }

      }

      public void gxTv_SdtTransaction1_Invoicetotal_Z_SetNull( )
      {
         gxTv_SdtTransaction1_Invoicetotal_Z = 0;
         SetDirty("Invoicetotal_Z");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Invoicetotal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InvoiceSubtotal_N" )]
      [  XmlElement( ElementName = "InvoiceSubtotal_N"   )]
      public short gxTpr_Invoicesubtotal_N
      {
         get {
            return gxTv_SdtTransaction1_Invoicesubtotal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTransaction1_Invoicesubtotal_N = value;
            SetDirty("Invoicesubtotal_N");
         }

      }

      public void gxTv_SdtTransaction1_Invoicesubtotal_N_SetNull( )
      {
         gxTv_SdtTransaction1_Invoicesubtotal_N = 0;
         SetDirty("Invoicesubtotal_N");
         return  ;
      }

      public bool gxTv_SdtTransaction1_Invoicesubtotal_N_IsNull( )
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
         gxTv_SdtTransaction1_Invoicedate = DateTime.MinValue;
         gxTv_SdtTransaction1_Customername = "";
         gxTv_SdtTransaction1_Mode = "";
         gxTv_SdtTransaction1_Invoicedate_Z = DateTime.MinValue;
         gxTv_SdtTransaction1_Customername_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "general.transaction1", "GeneXus.Programs.general.transaction1_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtTransaction1_Invoiceid ;
      private short sdtIsNull ;
      private short gxTv_SdtTransaction1_Customerid ;
      private short gxTv_SdtTransaction1_Initialized ;
      private short gxTv_SdtTransaction1_Invoiceid_Z ;
      private short gxTv_SdtTransaction1_Customerid_Z ;
      private short gxTv_SdtTransaction1_Invoicesubtotal_N ;
      private decimal gxTv_SdtTransaction1_Invoicesubtotal ;
      private decimal gxTv_SdtTransaction1_Invoicetax ;
      private decimal gxTv_SdtTransaction1_Invoicetotal ;
      private decimal gxTv_SdtTransaction1_Invoicesubtotal_Z ;
      private decimal gxTv_SdtTransaction1_Invoicetax_Z ;
      private decimal gxTv_SdtTransaction1_Invoicetotal_Z ;
      private string gxTv_SdtTransaction1_Customername ;
      private string gxTv_SdtTransaction1_Mode ;
      private string gxTv_SdtTransaction1_Customername_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTransaction1_Invoicedate ;
      private DateTime gxTv_SdtTransaction1_Invoicedate_Z ;
      private GXBCLevelCollection<GeneXus.Programs.general.SdtTransaction1_Product> gxTv_SdtTransaction1_Product=null ;
   }

   [DataContract(Name = @"General\Transaction1", Namespace = "MiPrimeraDemo")]
   [GxJsonSerialization("default")]
   public class SdtTransaction1_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.general.SdtTransaction1>
   {
      public SdtTransaction1_RESTInterface( ) : base()
      {
      }

      public SdtTransaction1_RESTInterface( GeneXus.Programs.general.SdtTransaction1 psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InvoiceID" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Invoiceid
      {
         get {
            return sdt.gxTpr_Invoiceid ;
         }

         set {
            sdt.gxTpr_Invoiceid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "InvoiceDate" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Invoicedate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Invoicedate) ;
         }

         set {
            sdt.gxTpr_Invoicedate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "CustomerID" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customerid
      {
         get {
            return sdt.gxTpr_Customerid ;
         }

         set {
            sdt.gxTpr_Customerid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Customername
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Customername) ;
         }

         set {
            sdt.gxTpr_Customername = value;
         }

      }

      [DataMember( Name = "Product" , Order = 4 )]
      public GxGenericCollection<GeneXus.Programs.general.SdtTransaction1_Product_RESTInterface> gxTpr_Product
      {
         get {
            return new GxGenericCollection<GeneXus.Programs.general.SdtTransaction1_Product_RESTInterface>(sdt.gxTpr_Product) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Product);
         }

      }

      [DataMember( Name = "InvoiceSubtotal" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Invoicesubtotal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Invoicesubtotal, 8, 2)) ;
         }

         set {
            sdt.gxTpr_Invoicesubtotal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "InvoiceTax" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Invoicetax
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Invoicetax, 8, 2)) ;
         }

         set {
            sdt.gxTpr_Invoicetax = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "InvoiceTotal" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Invoicetotal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Invoicetotal, 8, 2)) ;
         }

         set {
            sdt.gxTpr_Invoicetotal = NumberUtil.Val( value, ".");
         }

      }

      public GeneXus.Programs.general.SdtTransaction1 sdt
      {
         get {
            return (GeneXus.Programs.general.SdtTransaction1)Sdt ;
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
            sdt = new GeneXus.Programs.general.SdtTransaction1() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 8 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"General\Transaction1", Namespace = "MiPrimeraDemo")]
   [GxJsonSerialization("default")]
   public class SdtTransaction1_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.general.SdtTransaction1>
   {
      public SdtTransaction1_RESTLInterface( ) : base()
      {
      }

      public SdtTransaction1_RESTLInterface( GeneXus.Programs.general.SdtTransaction1 psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "InvoiceDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Invoicedate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Invoicedate) ;
         }

         set {
            sdt.gxTpr_Invoicedate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.general.SdtTransaction1 sdt
      {
         get {
            return (GeneXus.Programs.general.SdtTransaction1)Sdt ;
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
            sdt = new GeneXus.Programs.general.SdtTransaction1() ;
         }
      }

   }

}
