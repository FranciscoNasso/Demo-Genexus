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
   [XmlRoot(ElementName = "Cliente" )]
   [XmlType(TypeName =  "Cliente" , Namespace = "MiPrimeraDemo" )]
   [Serializable]
   public class SdtCliente : GxSilentTrnSdt
   {
      public SdtCliente( )
      {
      }

      public SdtCliente( IGxContext context )
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

      public void Load( short AV8CustomerID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV8CustomerID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CustomerID", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "General\\Cliente");
         metadata.Set("BT", "Cliente");
         metadata.Set("PK", "[ \"CustomerID\" ]");
         metadata.Set("PKAssigned", "[ \"CustomerID\" ]");
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
         state.Add("gxTpr_Customerid_Z");
         state.Add("gxTpr_Customername_Z");
         state.Add("gxTpr_Customeraddress_Z");
         state.Add("gxTpr_Customeremail_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.general.SdtCliente sdt;
         sdt = (GeneXus.Programs.general.SdtCliente)(source);
         gxTv_SdtCliente_Customerid = sdt.gxTv_SdtCliente_Customerid ;
         gxTv_SdtCliente_Customername = sdt.gxTv_SdtCliente_Customername ;
         gxTv_SdtCliente_Customeraddress = sdt.gxTv_SdtCliente_Customeraddress ;
         gxTv_SdtCliente_Customeremail = sdt.gxTv_SdtCliente_Customeremail ;
         gxTv_SdtCliente_Mode = sdt.gxTv_SdtCliente_Mode ;
         gxTv_SdtCliente_Initialized = sdt.gxTv_SdtCliente_Initialized ;
         gxTv_SdtCliente_Customerid_Z = sdt.gxTv_SdtCliente_Customerid_Z ;
         gxTv_SdtCliente_Customername_Z = sdt.gxTv_SdtCliente_Customername_Z ;
         gxTv_SdtCliente_Customeraddress_Z = sdt.gxTv_SdtCliente_Customeraddress_Z ;
         gxTv_SdtCliente_Customeremail_Z = sdt.gxTv_SdtCliente_Customeremail_Z ;
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
         AddObjectProperty("CustomerID", gxTv_SdtCliente_Customerid, false, includeNonInitialized);
         AddObjectProperty("CustomerName", gxTv_SdtCliente_Customername, false, includeNonInitialized);
         AddObjectProperty("CustomerAddress", gxTv_SdtCliente_Customeraddress, false, includeNonInitialized);
         AddObjectProperty("CustomerEmail", gxTv_SdtCliente_Customeremail, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCliente_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCliente_Initialized, false, includeNonInitialized);
            AddObjectProperty("CustomerID_Z", gxTv_SdtCliente_Customerid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerName_Z", gxTv_SdtCliente_Customername_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerAddress_Z", gxTv_SdtCliente_Customeraddress_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerEmail_Z", gxTv_SdtCliente_Customeremail_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.general.SdtCliente sdt )
      {
         if ( sdt.IsDirty("CustomerID") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Customerid = sdt.gxTv_SdtCliente_Customerid ;
         }
         if ( sdt.IsDirty("CustomerName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Customername = sdt.gxTv_SdtCliente_Customername ;
         }
         if ( sdt.IsDirty("CustomerAddress") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Customeraddress = sdt.gxTv_SdtCliente_Customeraddress ;
         }
         if ( sdt.IsDirty("CustomerEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtCliente_Customeremail = sdt.gxTv_SdtCliente_Customeremail ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CustomerID" )]
      [  XmlElement( ElementName = "CustomerID"   )]
      public short gxTpr_Customerid
      {
         get {
            return gxTv_SdtCliente_Customerid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCliente_Customerid != value )
            {
               gxTv_SdtCliente_Mode = "INS";
               this.gxTv_SdtCliente_Customerid_Z_SetNull( );
               this.gxTv_SdtCliente_Customername_Z_SetNull( );
               this.gxTv_SdtCliente_Customeraddress_Z_SetNull( );
               this.gxTv_SdtCliente_Customeremail_Z_SetNull( );
            }
            gxTv_SdtCliente_Customerid = value;
            SetDirty("Customerid");
         }

      }

      [  SoapElement( ElementName = "CustomerName" )]
      [  XmlElement( ElementName = "CustomerName"   )]
      public string gxTpr_Customername
      {
         get {
            return gxTv_SdtCliente_Customername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Customername = value;
            SetDirty("Customername");
         }

      }

      [  SoapElement( ElementName = "CustomerAddress" )]
      [  XmlElement( ElementName = "CustomerAddress"   )]
      public string gxTpr_Customeraddress
      {
         get {
            return gxTv_SdtCliente_Customeraddress ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Customeraddress = value;
            SetDirty("Customeraddress");
         }

      }

      [  SoapElement( ElementName = "CustomerEmail" )]
      [  XmlElement( ElementName = "CustomerEmail"   )]
      public string gxTpr_Customeremail
      {
         get {
            return gxTv_SdtCliente_Customeremail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Customeremail = value;
            SetDirty("Customeremail");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCliente_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCliente_Mode_SetNull( )
      {
         gxTv_SdtCliente_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCliente_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCliente_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCliente_Initialized_SetNull( )
      {
         gxTv_SdtCliente_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCliente_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerID_Z" )]
      [  XmlElement( ElementName = "CustomerID_Z"   )]
      public short gxTpr_Customerid_Z
      {
         get {
            return gxTv_SdtCliente_Customerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Customerid_Z = value;
            SetDirty("Customerid_Z");
         }

      }

      public void gxTv_SdtCliente_Customerid_Z_SetNull( )
      {
         gxTv_SdtCliente_Customerid_Z = 0;
         SetDirty("Customerid_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Customerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerName_Z" )]
      [  XmlElement( ElementName = "CustomerName_Z"   )]
      public string gxTpr_Customername_Z
      {
         get {
            return gxTv_SdtCliente_Customername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Customername_Z = value;
            SetDirty("Customername_Z");
         }

      }

      public void gxTv_SdtCliente_Customername_Z_SetNull( )
      {
         gxTv_SdtCliente_Customername_Z = "";
         SetDirty("Customername_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Customername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerAddress_Z" )]
      [  XmlElement( ElementName = "CustomerAddress_Z"   )]
      public string gxTpr_Customeraddress_Z
      {
         get {
            return gxTv_SdtCliente_Customeraddress_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Customeraddress_Z = value;
            SetDirty("Customeraddress_Z");
         }

      }

      public void gxTv_SdtCliente_Customeraddress_Z_SetNull( )
      {
         gxTv_SdtCliente_Customeraddress_Z = "";
         SetDirty("Customeraddress_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Customeraddress_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerEmail_Z" )]
      [  XmlElement( ElementName = "CustomerEmail_Z"   )]
      public string gxTpr_Customeremail_Z
      {
         get {
            return gxTv_SdtCliente_Customeremail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCliente_Customeremail_Z = value;
            SetDirty("Customeremail_Z");
         }

      }

      public void gxTv_SdtCliente_Customeremail_Z_SetNull( )
      {
         gxTv_SdtCliente_Customeremail_Z = "";
         SetDirty("Customeremail_Z");
         return  ;
      }

      public bool gxTv_SdtCliente_Customeremail_Z_IsNull( )
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
         gxTv_SdtCliente_Customername = "";
         gxTv_SdtCliente_Customeraddress = "";
         gxTv_SdtCliente_Customeremail = "";
         gxTv_SdtCliente_Mode = "";
         gxTv_SdtCliente_Customername_Z = "";
         gxTv_SdtCliente_Customeraddress_Z = "";
         gxTv_SdtCliente_Customeremail_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "general.cliente", "GeneXus.Programs.general.cliente_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtCliente_Customerid ;
      private short sdtIsNull ;
      private short gxTv_SdtCliente_Initialized ;
      private short gxTv_SdtCliente_Customerid_Z ;
      private string gxTv_SdtCliente_Customername ;
      private string gxTv_SdtCliente_Mode ;
      private string gxTv_SdtCliente_Customername_Z ;
      private string gxTv_SdtCliente_Customeraddress ;
      private string gxTv_SdtCliente_Customeremail ;
      private string gxTv_SdtCliente_Customeraddress_Z ;
      private string gxTv_SdtCliente_Customeremail_Z ;
   }

   [DataContract(Name = @"General\Cliente", Namespace = "MiPrimeraDemo")]
   [GxJsonSerialization("default")]
   public class SdtCliente_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.general.SdtCliente>
   {
      public SdtCliente_RESTInterface( ) : base()
      {
      }

      public SdtCliente_RESTInterface( GeneXus.Programs.general.SdtCliente psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CustomerID" , Order = 0 )]
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

      [DataMember( Name = "CustomerName" , Order = 1 )]
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

      [DataMember( Name = "CustomerAddress" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Customeraddress
      {
         get {
            return sdt.gxTpr_Customeraddress ;
         }

         set {
            sdt.gxTpr_Customeraddress = value;
         }

      }

      [DataMember( Name = "CustomerEmail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Customeremail
      {
         get {
            return sdt.gxTpr_Customeremail ;
         }

         set {
            sdt.gxTpr_Customeremail = value;
         }

      }

      public GeneXus.Programs.general.SdtCliente sdt
      {
         get {
            return (GeneXus.Programs.general.SdtCliente)Sdt ;
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
            sdt = new GeneXus.Programs.general.SdtCliente() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 4 )]
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

   [DataContract(Name = @"General\Cliente", Namespace = "MiPrimeraDemo")]
   [GxJsonSerialization("default")]
   public class SdtCliente_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.general.SdtCliente>
   {
      public SdtCliente_RESTLInterface( ) : base()
      {
      }

      public SdtCliente_RESTLInterface( GeneXus.Programs.general.SdtCliente psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CustomerName" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.general.SdtCliente sdt
      {
         get {
            return (GeneXus.Programs.general.SdtCliente)Sdt ;
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
            sdt = new GeneXus.Programs.general.SdtCliente() ;
         }
      }

   }

}
