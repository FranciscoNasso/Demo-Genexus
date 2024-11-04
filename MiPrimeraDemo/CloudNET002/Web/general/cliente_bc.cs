using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.general {
   public class cliente_bc : GxSilentTrn, IGxSilentTrn
   {
      public cliente_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("MiPrimeraDemo", true);
      }

      public cliente_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public GXBCCollection<GeneXus.Programs.general.SdtCliente> GetAll( int Start ,
                                                                         int Count )
      {
         GXPagingFrom3 = Start;
         GXPagingTo3 = Count;
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {GXPagingFrom3, GXPagingTo3});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound3 = 1;
            A8CustomerID = BC00034_A8CustomerID[0];
            A9CustomerName = BC00034_A9CustomerName[0];
            A18CustomerAddress = BC00034_A18CustomerAddress[0];
            A19CustomerEmail = BC00034_A19CustomerEmail[0];
         }
         bcgeneral_Cliente = new GeneXus.Programs.general.SdtCliente(context);
         gx_restcollection.Clear();
         while ( RcdFound3 != 0 )
         {
            OnLoadActions033( ) ;
            AddRow033( ) ;
            gx_sdt_item = (GeneXus.Programs.general.SdtCliente)(bcgeneral_Cliente.Clone());
            gx_restcollection.Add(gx_sdt_item, 0);
            pr_default.readNext(2);
            RcdFound3 = 0;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            if ( (pr_default.getStatus(2) != 101) )
            {
               RcdFound3 = 1;
               A8CustomerID = BC00034_A8CustomerID[0];
               A9CustomerName = BC00034_A9CustomerName[0];
               A18CustomerAddress = BC00034_A18CustomerAddress[0];
               A19CustomerEmail = BC00034_A19CustomerEmail[0];
            }
            Gx_mode = sMode3;
         }
         pr_default.close(2);
         /* Load Subordinate Levels */
         return gx_restcollection ;
      }

      protected void SETSEUDOVARS( )
      {
         ZM033( 0) ;
      }

      public void GetInsDefault( )
      {
         ReadRow033( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey033( ) ;
         standaloneModal( ) ;
         AddRow033( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z8CustomerID = A8CustomerID;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z9CustomerName = A9CustomerName;
            Z18CustomerAddress = A18CustomerAddress;
            Z19CustomerEmail = A19CustomerEmail;
         }
         if ( GX_JID == -2 )
         {
            Z8CustomerID = A8CustomerID;
            Z9CustomerName = A9CustomerName;
            Z18CustomerAddress = A18CustomerAddress;
            Z19CustomerEmail = A19CustomerEmail;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load033( )
      {
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A8CustomerID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
            A9CustomerName = BC00035_A9CustomerName[0];
            A18CustomerAddress = BC00035_A18CustomerAddress[0];
            A19CustomerEmail = BC00035_A19CustomerEmail[0];
            ZM033( -2) ;
         }
         pr_default.close(3);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
      }

      protected void CheckExtendedTable033( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A19CustomerEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Customer Email does not match the specified pattern", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor BC00036 */
         pr_default.execute(4, new Object[] {A8CustomerID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A8CustomerID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 2) ;
            RcdFound3 = 1;
            A8CustomerID = BC00033_A8CustomerID[0];
            A9CustomerName = BC00033_A9CustomerName[0];
            A18CustomerAddress = BC00033_A18CustomerAddress[0];
            A19CustomerEmail = BC00033_A19CustomerEmail[0];
            Z8CustomerID = A8CustomerID;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode3;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_030( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A8CustomerID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z9CustomerName, BC00032_A9CustomerName[0]) != 0 ) || ( StringUtil.StrCmp(Z18CustomerAddress, BC00032_A18CustomerAddress[0]) != 0 ) || ( StringUtil.StrCmp(Z19CustomerEmail, BC00032_A19CustomerEmail[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Cliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00037 */
                     pr_default.execute(5, new Object[] {A9CustomerName, A18CustomerAddress, A19CustomerEmail});
                     A8CustomerID = BC00037_A8CustomerID[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Cliente");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00038 */
                     pr_default.execute(6, new Object[] {A9CustomerName, A18CustomerAddress, A19CustomerEmail, A8CustomerID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Cliente");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00039 */
                  pr_default.execute(7, new Object[] {A8CustomerID});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Cliente");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel033( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000310 */
            pr_default.execute(8, new Object[] {A8CustomerID});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Transaction1"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart033( )
      {
         /* Using cursor BC000311 */
         pr_default.execute(9, new Object[] {A8CustomerID});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound3 = 1;
            A8CustomerID = BC000311_A8CustomerID[0];
            A9CustomerName = BC000311_A9CustomerName[0];
            A18CustomerAddress = BC000311_A18CustomerAddress[0];
            A19CustomerEmail = BC000311_A19CustomerEmail[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound3 = 0;
         ScanKeyLoad033( ) ;
      }

      protected void ScanKeyLoad033( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound3 = 1;
            A8CustomerID = BC000311_A8CustomerID[0];
            A9CustomerName = BC000311_A9CustomerName[0];
            A18CustomerAddress = BC000311_A18CustomerAddress[0];
            A19CustomerEmail = BC000311_A19CustomerEmail[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd033( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void AddRow033( )
      {
         VarsToRow3( bcgeneral_Cliente) ;
      }

      protected void ReadRow033( )
      {
         RowToVars3( bcgeneral_Cliente, 1) ;
      }

      protected void InitializeNonKey033( )
      {
         A9CustomerName = "";
         A18CustomerAddress = "";
         A19CustomerEmail = "";
         Z9CustomerName = "";
         Z18CustomerAddress = "";
         Z19CustomerEmail = "";
      }

      protected void InitAll033( )
      {
         A8CustomerID = 0;
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow3( GeneXus.Programs.general.SdtCliente obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Customername = A9CustomerName;
         obj3.gxTpr_Customeraddress = A18CustomerAddress;
         obj3.gxTpr_Customeremail = A19CustomerEmail;
         obj3.gxTpr_Customerid = A8CustomerID;
         obj3.gxTpr_Customerid_Z = Z8CustomerID;
         obj3.gxTpr_Customername_Z = Z9CustomerName;
         obj3.gxTpr_Customeraddress_Z = Z18CustomerAddress;
         obj3.gxTpr_Customeremail_Z = Z19CustomerEmail;
         obj3.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow3( GeneXus.Programs.general.SdtCliente obj3 )
      {
         obj3.gxTpr_Customerid = A8CustomerID;
         return  ;
      }

      public void RowToVars3( GeneXus.Programs.general.SdtCliente obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A9CustomerName = obj3.gxTpr_Customername;
         A18CustomerAddress = obj3.gxTpr_Customeraddress;
         A19CustomerEmail = obj3.gxTpr_Customeremail;
         A8CustomerID = obj3.gxTpr_Customerid;
         Z8CustomerID = obj3.gxTpr_Customerid_Z;
         Z9CustomerName = obj3.gxTpr_Customername_Z;
         Z18CustomerAddress = obj3.gxTpr_Customeraddress_Z;
         Z19CustomerEmail = obj3.gxTpr_Customeremail_Z;
         Gx_mode = obj3.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A8CustomerID = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey033( ) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z8CustomerID = A8CustomerID;
         }
         ZM033( -2) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars3( bcgeneral_Cliente, 0) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z8CustomerID = A8CustomerID;
         }
         ZM033( -2) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert033( ) ;
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A8CustomerID != Z8CustomerID )
               {
                  A8CustomerID = Z8CustomerID;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update033( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A8CustomerID != Z8CustomerID )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert033( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert033( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcgeneral_Cliente, 1) ;
         SaveImpl( ) ;
         VarsToRow3( bcgeneral_Cliente) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcgeneral_Cliente, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
         AfterTrn( ) ;
         VarsToRow3( bcgeneral_Cliente) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow3( bcgeneral_Cliente) ;
         }
         else
         {
            GeneXus.Programs.general.SdtCliente auxBC = new GeneXus.Programs.general.SdtCliente(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A8CustomerID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcgeneral_Cliente);
               auxBC.Save();
               bcgeneral_Cliente.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcgeneral_Cliente, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcgeneral_Cliente, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow3( bcgeneral_Cliente) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow3( bcgeneral_Cliente) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcgeneral_Cliente, 0) ;
         GetKey033( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A8CustomerID != Z8CustomerID )
            {
               A8CustomerID = Z8CustomerID;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A8CustomerID != Z8CustomerID )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("general.cliente_bc",pr_default);
         VarsToRow3( bcgeneral_Cliente) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcgeneral_Cliente.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcgeneral_Cliente.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcgeneral_Cliente )
         {
            bcgeneral_Cliente = (GeneXus.Programs.general.SdtCliente)(sdt);
            if ( StringUtil.StrCmp(bcgeneral_Cliente.gxTpr_Mode, "") == 0 )
            {
               bcgeneral_Cliente.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow3( bcgeneral_Cliente) ;
            }
            else
            {
               RowToVars3( bcgeneral_Cliente, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcgeneral_Cliente.gxTpr_Mode, "") == 0 )
            {
               bcgeneral_Cliente.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars3( bcgeneral_Cliente, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCliente Cliente_BC
      {
         get {
            return bcgeneral_Cliente ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         BC00034_A8CustomerID = new short[1] ;
         BC00034_A9CustomerName = new string[] {""} ;
         BC00034_A18CustomerAddress = new string[] {""} ;
         BC00034_A19CustomerEmail = new string[] {""} ;
         A9CustomerName = "";
         A18CustomerAddress = "";
         A19CustomerEmail = "";
         gx_restcollection = new GXBCCollection<GeneXus.Programs.general.SdtCliente>( context, "Cliente", "MiPrimeraDemo");
         sMode3 = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z9CustomerName = "";
         Z18CustomerAddress = "";
         Z19CustomerEmail = "";
         BC00035_A8CustomerID = new short[1] ;
         BC00035_A9CustomerName = new string[] {""} ;
         BC00035_A18CustomerAddress = new string[] {""} ;
         BC00035_A19CustomerEmail = new string[] {""} ;
         BC00036_A8CustomerID = new short[1] ;
         BC00033_A8CustomerID = new short[1] ;
         BC00033_A9CustomerName = new string[] {""} ;
         BC00033_A18CustomerAddress = new string[] {""} ;
         BC00033_A19CustomerEmail = new string[] {""} ;
         BC00032_A8CustomerID = new short[1] ;
         BC00032_A9CustomerName = new string[] {""} ;
         BC00032_A18CustomerAddress = new string[] {""} ;
         BC00032_A19CustomerEmail = new string[] {""} ;
         BC00037_A8CustomerID = new short[1] ;
         BC000310_A6InvoiceID = new short[1] ;
         BC000311_A8CustomerID = new short[1] ;
         BC000311_A9CustomerName = new string[] {""} ;
         BC000311_A18CustomerAddress = new string[] {""} ;
         BC000311_A19CustomerEmail = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.general.cliente_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A8CustomerID, BC00032_A9CustomerName, BC00032_A18CustomerAddress, BC00032_A19CustomerEmail
               }
               , new Object[] {
               BC00033_A8CustomerID, BC00033_A9CustomerName, BC00033_A18CustomerAddress, BC00033_A19CustomerEmail
               }
               , new Object[] {
               BC00034_A8CustomerID, BC00034_A9CustomerName, BC00034_A18CustomerAddress, BC00034_A19CustomerEmail
               }
               , new Object[] {
               BC00035_A8CustomerID, BC00035_A9CustomerName, BC00035_A18CustomerAddress, BC00035_A19CustomerEmail
               }
               , new Object[] {
               BC00036_A8CustomerID
               }
               , new Object[] {
               BC00037_A8CustomerID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000310_A6InvoiceID
               }
               , new Object[] {
               BC000311_A8CustomerID, BC000311_A9CustomerName, BC000311_A18CustomerAddress, BC000311_A19CustomerEmail
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound3 ;
      private short A8CustomerID ;
      private short Z8CustomerID ;
      private int trnEnded ;
      private int Start ;
      private int Count ;
      private int GXPagingFrom3 ;
      private int GXPagingTo3 ;
      private string A9CustomerName ;
      private string sMode3 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z9CustomerName ;
      private string A18CustomerAddress ;
      private string A19CustomerEmail ;
      private string Z18CustomerAddress ;
      private string Z19CustomerEmail ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.SdtCliente bcgeneral_Cliente ;
      private IDataStoreProvider pr_default ;
      private short[] BC00034_A8CustomerID ;
      private string[] BC00034_A9CustomerName ;
      private string[] BC00034_A18CustomerAddress ;
      private string[] BC00034_A19CustomerEmail ;
      private GeneXus.Programs.general.SdtCliente gx_sdt_item ;
      private GXBCCollection<GeneXus.Programs.general.SdtCliente> gx_restcollection ;
      private short[] BC00035_A8CustomerID ;
      private string[] BC00035_A9CustomerName ;
      private string[] BC00035_A18CustomerAddress ;
      private string[] BC00035_A19CustomerEmail ;
      private short[] BC00036_A8CustomerID ;
      private short[] BC00033_A8CustomerID ;
      private string[] BC00033_A9CustomerName ;
      private string[] BC00033_A18CustomerAddress ;
      private string[] BC00033_A19CustomerEmail ;
      private short[] BC00032_A8CustomerID ;
      private string[] BC00032_A9CustomerName ;
      private string[] BC00032_A18CustomerAddress ;
      private string[] BC00032_A19CustomerEmail ;
      private short[] BC00037_A8CustomerID ;
      private short[] BC000310_A6InvoiceID ;
      private short[] BC000311_A8CustomerID ;
      private string[] BC000311_A9CustomerName ;
      private string[] BC000311_A18CustomerAddress ;
      private string[] BC000311_A19CustomerEmail ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class cliente_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00032;
          prmBC00032 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmBC00033;
          prmBC00033 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmBC00034;
          prmBC00034 = new Object[] {
          new ParDef("@GXPagingFrom3",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo3",GXType.Int32,9,0)
          };
          Object[] prmBC00035;
          prmBC00035 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmBC00036;
          prmBC00036 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmBC00037;
          prmBC00037 = new Object[] {
          new ParDef("@CustomerName",GXType.NChar,20,0) ,
          new ParDef("@CustomerAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@CustomerEmail",GXType.NVarChar,100,0)
          };
          Object[] prmBC00038;
          prmBC00038 = new Object[] {
          new ParDef("@CustomerName",GXType.NChar,20,0) ,
          new ParDef("@CustomerAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@CustomerEmail",GXType.NVarChar,100,0) ,
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmBC00039;
          prmBC00039 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmBC000310;
          prmBC000310 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmBC000311;
          prmBC000311 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00032", "SELECT [CustomerID], [CustomerName], [CustomerAddress], [CustomerEmail] FROM [Cliente] WITH (UPDLOCK) WHERE [CustomerID] = @CustomerID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00033", "SELECT [CustomerID], [CustomerName], [CustomerAddress], [CustomerEmail] FROM [Cliente] WHERE [CustomerID] = @CustomerID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00034", "SELECT TM1.[CustomerID], TM1.[CustomerName], TM1.[CustomerAddress], TM1.[CustomerEmail] FROM [Cliente] TM1 ORDER BY TM1.[CustomerID]  OFFSET @GXPagingFrom3 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo3 > 0 THEN @GXPagingTo3 ELSE 1e9 END) AS INTEGER) ROWS ONLY",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00035", "SELECT TM1.[CustomerID], TM1.[CustomerName], TM1.[CustomerAddress], TM1.[CustomerEmail] FROM [Cliente] TM1 WHERE TM1.[CustomerID] = @CustomerID ORDER BY TM1.[CustomerID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00036", "SELECT [CustomerID] FROM [Cliente] WHERE [CustomerID] = @CustomerID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00037", "INSERT INTO [Cliente]([CustomerName], [CustomerAddress], [CustomerEmail]) VALUES(@CustomerName, @CustomerAddress, @CustomerEmail); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00037,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00038", "UPDATE [Cliente] SET [CustomerName]=@CustomerName, [CustomerAddress]=@CustomerAddress, [CustomerEmail]=@CustomerEmail  WHERE [CustomerID] = @CustomerID", GxErrorMask.GX_NOMASK,prmBC00038)
             ,new CursorDef("BC00039", "DELETE FROM [Cliente]  WHERE [CustomerID] = @CustomerID", GxErrorMask.GX_NOMASK,prmBC00039)
             ,new CursorDef("BC000310", "SELECT TOP 1 [InvoiceID] FROM [Transaction1] WHERE [CustomerID] = @CustomerID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000310,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000311", "SELECT TM1.[CustomerID], TM1.[CustomerName], TM1.[CustomerAddress], TM1.[CustomerEmail] FROM [Cliente] TM1 WHERE TM1.[CustomerID] = @CustomerID ORDER BY TM1.[CustomerID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000311,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
