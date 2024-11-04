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
   public class transaction1_bc : GxSilentTrn, IGxSilentTrn
   {
      public transaction1_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("MiPrimeraDemo", true);
      }

      public transaction1_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public GXBCCollection<GeneXus.Programs.general.SdtTransaction1> GetAll( int Start ,
                                                                              int Count )
      {
         GXPagingFrom1 = Start;
         GXPagingTo1 = Count;
         /* Using cursor BC000210 */
         pr_default.execute(6, new Object[] {GXPagingFrom1, GXPagingTo1});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound1 = 1;
            A6InvoiceID = BC000210_A6InvoiceID[0];
            A7InvoiceDate = BC000210_A7InvoiceDate[0];
            A9CustomerName = BC000210_A9CustomerName[0];
            A8CustomerID = BC000210_A8CustomerID[0];
            A15InvoiceSubtotal = BC000210_A15InvoiceSubtotal[0];
            n15InvoiceSubtotal = BC000210_n15InvoiceSubtotal[0];
         }
         bcgeneral_Transaction1 = new GeneXus.Programs.general.SdtTransaction1(context);
         gx_restcollection.Clear();
         while ( RcdFound1 != 0 )
         {
            OnLoadActions021( ) ;
            AddRow021( ) ;
            gx_sdt_item = (GeneXus.Programs.general.SdtTransaction1)(bcgeneral_Transaction1.Clone());
            gx_restcollection.Add(gx_sdt_item, 0);
            pr_default.readNext(6);
            RcdFound1 = 0;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            if ( (pr_default.getStatus(6) != 101) )
            {
               RcdFound1 = 1;
               A6InvoiceID = BC000210_A6InvoiceID[0];
               A7InvoiceDate = BC000210_A7InvoiceDate[0];
               A9CustomerName = BC000210_A9CustomerName[0];
               A8CustomerID = BC000210_A8CustomerID[0];
               A15InvoiceSubtotal = BC000210_A15InvoiceSubtotal[0];
               n15InvoiceSubtotal = BC000210_n15InvoiceSubtotal[0];
            }
            Gx_mode = sMode1;
         }
         pr_default.close(6);
         /* Load Subordinate Levels */
         return gx_restcollection ;
      }

      protected void SETSEUDOVARS( )
      {
         ZM021( 0) ;
      }

      public void GetInsDefault( )
      {
         ReadRow021( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey021( ) ;
         standaloneModal( ) ;
         AddRow021( ) ;
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
            /* Execute user event: After Trn */
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z6InvoiceID = A6InvoiceID;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate021( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls021( ) ;
            }
            else
            {
               CheckExtendedTable021( ) ;
               if ( AnyError == 0 )
               {
                  ZM021( 11) ;
                  ZM021( 12) ;
               }
               CloseExtendedTableCursors021( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode1 = Gx_mode;
            CONFIRM_022( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode1;
         }
      }

      protected void CONFIRM_022( )
      {
         s15InvoiceSubtotal = O15InvoiceSubtotal;
         n15InvoiceSubtotal = false;
         s16InvoiceTax = O16InvoiceTax;
         s17InvoiceTotal = O17InvoiceTotal;
         nGXsfl_2_idx = 0;
         while ( nGXsfl_2_idx < bcgeneral_Transaction1.gxTpr_Product.Count )
         {
            ReadRow022( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound2 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_2 != 0 ) )
            {
               GetKey022( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound2 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate022( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable022( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors022( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        O15InvoiceSubtotal = A15InvoiceSubtotal;
                        n15InvoiceSubtotal = false;
                        O16InvoiceTax = A16InvoiceTax;
                        O17InvoiceTotal = A17InvoiceTotal;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound2 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey022( ) ;
                        Load022( ) ;
                        BeforeValidate022( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls022( ) ;
                           O15InvoiceSubtotal = A15InvoiceSubtotal;
                           n15InvoiceSubtotal = false;
                           O16InvoiceTax = A16InvoiceTax;
                           O17InvoiceTotal = A17InvoiceTotal;
                        }
                     }
                     else
                     {
                        if ( nIsMod_2 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate022( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable022( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors022( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              O15InvoiceSubtotal = A15InvoiceSubtotal;
                              n15InvoiceSubtotal = false;
                              O16InvoiceTax = A16InvoiceTax;
                              O17InvoiceTotal = A17InvoiceTotal;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow2( ((GeneXus.Programs.general.SdtTransaction1_Product)bcgeneral_Transaction1.gxTpr_Product.Item(nGXsfl_2_idx))) ;
            }
         }
         O15InvoiceSubtotal = s15InvoiceSubtotal;
         n15InvoiceSubtotal = false;
         O16InvoiceTax = s16InvoiceTax;
         O17InvoiceTotal = s17InvoiceTotal;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12022( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM021( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z7InvoiceDate = A7InvoiceDate;
            Z8CustomerID = A8CustomerID;
            Z15InvoiceSubtotal = A15InvoiceSubtotal;
            Z16InvoiceTax = A16InvoiceTax;
            Z17InvoiceTotal = A17InvoiceTotal;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z9CustomerName = A9CustomerName;
            Z15InvoiceSubtotal = A15InvoiceSubtotal;
            Z16InvoiceTax = A16InvoiceTax;
            Z17InvoiceTotal = A17InvoiceTotal;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z15InvoiceSubtotal = A15InvoiceSubtotal;
            Z16InvoiceTax = A16InvoiceTax;
            Z17InvoiceTotal = A17InvoiceTotal;
         }
         if ( GX_JID == -10 )
         {
            Z6InvoiceID = A6InvoiceID;
            Z7InvoiceDate = A7InvoiceDate;
            Z8CustomerID = A8CustomerID;
            Z15InvoiceSubtotal = A15InvoiceSubtotal;
            Z9CustomerName = A9CustomerName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A7InvoiceDate) && ( Gx_BScreen == 0 ) )
         {
            A7InvoiceDate = Gx_date;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load021( )
      {
         /* Using cursor BC000212 */
         pr_default.execute(7, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound1 = 1;
            A7InvoiceDate = BC000212_A7InvoiceDate[0];
            A9CustomerName = BC000212_A9CustomerName[0];
            A8CustomerID = BC000212_A8CustomerID[0];
            A15InvoiceSubtotal = BC000212_A15InvoiceSubtotal[0];
            n15InvoiceSubtotal = BC000212_n15InvoiceSubtotal[0];
            ZM021( -10) ;
         }
         pr_default.close(7);
         OnLoadActions021( ) ;
      }

      protected void OnLoadActions021( )
      {
         O15InvoiceSubtotal = A15InvoiceSubtotal;
         n15InvoiceSubtotal = false;
         A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
         A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
      }

      protected void CheckExtendedTable021( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00028 */
         pr_default.execute(5, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A15InvoiceSubtotal = BC00028_A15InvoiceSubtotal[0];
            n15InvoiceSubtotal = BC00028_n15InvoiceSubtotal[0];
         }
         else
         {
            A15InvoiceSubtotal = 0;
            n15InvoiceSubtotal = false;
         }
         pr_default.close(5);
         A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
         A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
         if ( ! ( (DateTime.MinValue==A7InvoiceDate) || ( DateTimeUtil.ResetTime ( A7InvoiceDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Invoice Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00026 */
         pr_default.execute(4, new Object[] {A8CustomerID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
         }
         A9CustomerName = BC00026_A9CustomerName[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors021( )
      {
         pr_default.close(5);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey021( )
      {
         /* Using cursor BC000213 */
         pr_default.execute(8, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM021( 10) ;
            RcdFound1 = 1;
            A6InvoiceID = BC00025_A6InvoiceID[0];
            A7InvoiceDate = BC00025_A7InvoiceDate[0];
            A8CustomerID = BC00025_A8CustomerID[0];
            Z6InvoiceID = A6InvoiceID;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load021( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey021( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey021( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey021( ) ;
         if ( RcdFound1 == 0 )
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
         CONFIRM_020( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency021( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00024 */
            pr_default.execute(2, new Object[] {A6InvoiceID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Transaction1"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( DateTimeUtil.ResetTime ( Z7InvoiceDate ) != DateTimeUtil.ResetTime ( BC00024_A7InvoiceDate[0] ) ) || ( Z8CustomerID != BC00024_A8CustomerID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Transaction1"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert021( )
      {
         BeforeValidate021( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable021( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM021( 0) ;
            CheckOptimisticConcurrency021( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm021( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert021( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000214 */
                     pr_default.execute(9, new Object[] {A7InvoiceDate, A8CustomerID});
                     A6InvoiceID = BC000214_A6InvoiceID[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Transaction1");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel021( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load021( ) ;
            }
            EndLevel021( ) ;
         }
         CloseExtendedTableCursors021( ) ;
      }

      protected void Update021( )
      {
         BeforeValidate021( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable021( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency021( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm021( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate021( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000215 */
                     pr_default.execute(10, new Object[] {A7InvoiceDate, A8CustomerID, A6InvoiceID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Transaction1");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Transaction1"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate021( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel021( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel021( ) ;
         }
         CloseExtendedTableCursors021( ) ;
      }

      protected void DeferredUpdate021( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate021( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency021( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls021( ) ;
            AfterConfirm021( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete021( ) ;
               if ( AnyError == 0 )
               {
                  A15InvoiceSubtotal = O15InvoiceSubtotal;
                  n15InvoiceSubtotal = false;
                  A16InvoiceTax = O16InvoiceTax;
                  A17InvoiceTotal = O17InvoiceTotal;
                  ScanKeyStart022( ) ;
                  while ( RcdFound2 != 0 )
                  {
                     getByPrimaryKey022( ) ;
                     Delete022( ) ;
                     ScanKeyNext022( ) ;
                     O15InvoiceSubtotal = A15InvoiceSubtotal;
                     n15InvoiceSubtotal = false;
                     O16InvoiceTax = A16InvoiceTax;
                     O17InvoiceTotal = A17InvoiceTotal;
                  }
                  ScanKeyEnd022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000216 */
                     pr_default.execute(11, new Object[] {A6InvoiceID});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Transaction1");
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
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel021( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls021( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000218 */
            pr_default.execute(12, new Object[] {A6InvoiceID});
            if ( (pr_default.getStatus(12) != 101) )
            {
               A15InvoiceSubtotal = BC000218_A15InvoiceSubtotal[0];
               n15InvoiceSubtotal = BC000218_n15InvoiceSubtotal[0];
            }
            else
            {
               A15InvoiceSubtotal = 0;
               n15InvoiceSubtotal = false;
            }
            pr_default.close(12);
            A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
            A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
            /* Using cursor BC000219 */
            pr_default.execute(13, new Object[] {A8CustomerID});
            A9CustomerName = BC000219_A9CustomerName[0];
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel022( )
      {
         s15InvoiceSubtotal = O15InvoiceSubtotal;
         n15InvoiceSubtotal = false;
         s16InvoiceTax = O16InvoiceTax;
         s17InvoiceTotal = O17InvoiceTotal;
         nGXsfl_2_idx = 0;
         while ( nGXsfl_2_idx < bcgeneral_Transaction1.gxTpr_Product.Count )
         {
            ReadRow022( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound2 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_2 != 0 ) )
            {
               standaloneNotModal022( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert022( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete022( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update022( ) ;
                  }
               }
               O15InvoiceSubtotal = A15InvoiceSubtotal;
               n15InvoiceSubtotal = false;
               O16InvoiceTax = A16InvoiceTax;
               O17InvoiceTotal = A17InvoiceTotal;
            }
            KeyVarsToRow2( ((GeneXus.Programs.general.SdtTransaction1_Product)bcgeneral_Transaction1.gxTpr_Product.Item(nGXsfl_2_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_2_idx = 0;
            while ( nGXsfl_2_idx < bcgeneral_Transaction1.gxTpr_Product.Count )
            {
               ReadRow022( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound2 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcgeneral_Transaction1.gxTpr_Product.RemoveElement(nGXsfl_2_idx);
                  nGXsfl_2_idx = (int)(nGXsfl_2_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey022( ) ;
                  VarsToRow2( ((GeneXus.Programs.general.SdtTransaction1_Product)bcgeneral_Transaction1.gxTpr_Product.Item(nGXsfl_2_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll022( ) ;
         if ( AnyError != 0 )
         {
            O15InvoiceSubtotal = s15InvoiceSubtotal;
            n15InvoiceSubtotal = false;
            O16InvoiceTax = s16InvoiceTax;
            O17InvoiceTotal = s17InvoiceTotal;
         }
         nRcdExists_2 = 0;
         nIsMod_2 = 0;
      }

      protected void ProcessLevel021( )
      {
         /* Save parent mode. */
         sMode1 = Gx_mode;
         ProcessNestedLevel022( ) ;
         if ( AnyError != 0 )
         {
            O15InvoiceSubtotal = s15InvoiceSubtotal;
            n15InvoiceSubtotal = false;
            O16InvoiceTax = s16InvoiceTax;
            O17InvoiceTotal = s17InvoiceTotal;
         }
         /* Restore parent mode. */
         Gx_mode = sMode1;
         /* ' Update level parameters */
      }

      protected void EndLevel021( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete021( ) ;
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

      public void ScanKeyStart021( )
      {
         /* Scan By routine */
         /* Using cursor BC000221 */
         pr_default.execute(14, new Object[] {A6InvoiceID});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound1 = 1;
            A6InvoiceID = BC000221_A6InvoiceID[0];
            A7InvoiceDate = BC000221_A7InvoiceDate[0];
            A9CustomerName = BC000221_A9CustomerName[0];
            A8CustomerID = BC000221_A8CustomerID[0];
            A15InvoiceSubtotal = BC000221_A15InvoiceSubtotal[0];
            n15InvoiceSubtotal = BC000221_n15InvoiceSubtotal[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext021( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound1 = 0;
         ScanKeyLoad021( ) ;
      }

      protected void ScanKeyLoad021( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound1 = 1;
            A6InvoiceID = BC000221_A6InvoiceID[0];
            A7InvoiceDate = BC000221_A7InvoiceDate[0];
            A9CustomerName = BC000221_A9CustomerName[0];
            A8CustomerID = BC000221_A8CustomerID[0];
            A15InvoiceSubtotal = BC000221_A15InvoiceSubtotal[0];
            n15InvoiceSubtotal = BC000221_n15InvoiceSubtotal[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd021( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm021( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert021( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate021( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete021( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete021( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate021( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes021( )
      {
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z11ProductName = A11ProductName;
            Z12ProductPrice = A12ProductPrice;
            Z13InvoiceProductQuantity = A13InvoiceProductQuantity;
            Z14InvoiceProductTotal = A14InvoiceProductTotal;
         }
         if ( GX_JID == -13 )
         {
            Z6InvoiceID = A6InvoiceID;
            Z10ProductID = A10ProductID;
            Z11ProductName = A11ProductName;
            Z12ProductPrice = A12ProductPrice;
            Z13InvoiceProductQuantity = A13InvoiceProductQuantity;
         }
      }

      protected void standaloneNotModal022( )
      {
      }

      protected void standaloneModal022( )
      {
      }

      protected void Load022( )
      {
         /* Using cursor BC000222 */
         pr_default.execute(15, new Object[] {A6InvoiceID, A10ProductID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound2 = 1;
            A11ProductName = BC000222_A11ProductName[0];
            A12ProductPrice = BC000222_A12ProductPrice[0];
            A13InvoiceProductQuantity = BC000222_A13InvoiceProductQuantity[0];
            ZM022( -13) ;
         }
         pr_default.close(15);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         A14InvoiceProductTotal = (decimal)(A12ProductPrice*A13InvoiceProductQuantity);
         O14InvoiceProductTotal = A14InvoiceProductTotal;
         if ( IsIns( )  )
         {
            A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal+A14InvoiceProductTotal);
            n15InvoiceSubtotal = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal+A14InvoiceProductTotal-O14InvoiceProductTotal);
               n15InvoiceSubtotal = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal-O14InvoiceProductTotal);
                  n15InvoiceSubtotal = false;
               }
            }
         }
         A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
         A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
      }

      protected void CheckExtendedTable022( )
      {
         Gx_BScreen = 1;
         standaloneModal022( ) ;
         Gx_BScreen = 0;
         A14InvoiceProductTotal = (decimal)(A12ProductPrice*A13InvoiceProductQuantity);
         if ( IsIns( )  )
         {
            A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal+A14InvoiceProductTotal);
            n15InvoiceSubtotal = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal+A14InvoiceProductTotal-O14InvoiceProductTotal);
               n15InvoiceSubtotal = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal-O14InvoiceProductTotal);
                  n15InvoiceSubtotal = false;
               }
            }
         }
         A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
         A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
         if ( (0==A13InvoiceProductQuantity) )
         {
            GX_msglist.addItem("The Product Quantity cannot be empty", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors022( )
      {
      }

      protected void enableDisable022( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC000223 */
         pr_default.execute(16, new Object[] {A6InvoiceID, A10ProductID});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey022( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A6InvoiceID, A10ProductID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 13) ;
            RcdFound2 = 1;
            InitializeNonKey022( ) ;
            A10ProductID = BC00023_A10ProductID[0];
            A11ProductName = BC00023_A11ProductName[0];
            A12ProductPrice = BC00023_A12ProductPrice[0];
            A13InvoiceProductQuantity = BC00023_A13InvoiceProductQuantity[0];
            Z6InvoiceID = A6InvoiceID;
            Z10ProductID = A10ProductID;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal022( ) ;
            Load022( ) ;
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal022( ) ;
            Gx_mode = sMode2;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes022( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A6InvoiceID, A10ProductID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Transaction1Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z11ProductName, BC00022_A11ProductName[0]) != 0 ) || ( Z12ProductPrice != BC00022_A12ProductPrice[0] ) || ( Z13InvoiceProductQuantity != BC00022_A13InvoiceProductQuantity[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Transaction1Product"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000224 */
                     pr_default.execute(17, new Object[] {A6InvoiceID, A10ProductID, A11ProductName, A12ProductPrice, A13InvoiceProductQuantity});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("Transaction1Product");
                     if ( (pr_default.getStatus(17) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000225 */
                     pr_default.execute(18, new Object[] {A11ProductName, A12ProductPrice, A13InvoiceProductQuantity, A6InvoiceID, A10ProductID});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("Transaction1Product");
                     if ( (pr_default.getStatus(18) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Transaction1Product"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void Delete022( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000226 */
                  pr_default.execute(19, new Object[] {A6InvoiceID, A10ProductID});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("Transaction1Product");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal022( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A14InvoiceProductTotal = (decimal)(A12ProductPrice*A13InvoiceProductQuantity);
            if ( IsIns( )  )
            {
               A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal+A14InvoiceProductTotal);
               n15InvoiceSubtotal = false;
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal+A14InvoiceProductTotal-O14InvoiceProductTotal);
                  n15InvoiceSubtotal = false;
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal-O14InvoiceProductTotal);
                     n15InvoiceSubtotal = false;
                  }
               }
            }
            A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
            A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart022( )
      {
         /* Scan By routine */
         /* Using cursor BC000227 */
         pr_default.execute(20, new Object[] {A6InvoiceID});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound2 = 1;
            A10ProductID = BC000227_A10ProductID[0];
            A11ProductName = BC000227_A11ProductName[0];
            A12ProductPrice = BC000227_A12ProductPrice[0];
            A13InvoiceProductQuantity = BC000227_A13InvoiceProductQuantity[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound2 = 1;
            A10ProductID = BC000227_A10ProductID[0];
            A11ProductName = BC000227_A11ProductName[0];
            A12ProductPrice = BC000227_A12ProductPrice[0];
            A13InvoiceProductQuantity = BC000227_A13InvoiceProductQuantity[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void send_integrity_lvl_hashes021( )
      {
      }

      protected void AddRow021( )
      {
         VarsToRow1( bcgeneral_Transaction1) ;
      }

      protected void ReadRow021( )
      {
         RowToVars1( bcgeneral_Transaction1, 1) ;
      }

      protected void AddRow022( )
      {
         GeneXus.Programs.general.SdtTransaction1_Product obj2;
         obj2 = new GeneXus.Programs.general.SdtTransaction1_Product(context);
         VarsToRow2( obj2) ;
         bcgeneral_Transaction1.gxTpr_Product.Add(obj2, 0);
         obj2.gxTpr_Mode = "UPD";
         obj2.gxTpr_Modified = 0;
      }

      protected void ReadRow022( )
      {
         nGXsfl_2_idx = (int)(nGXsfl_2_idx+1);
         RowToVars2( ((GeneXus.Programs.general.SdtTransaction1_Product)bcgeneral_Transaction1.gxTpr_Product.Item(nGXsfl_2_idx)), 1) ;
      }

      protected void InitializeNonKey021( )
      {
         A16InvoiceTax = 0;
         A17InvoiceTotal = 0;
         A8CustomerID = 0;
         A9CustomerName = "";
         A15InvoiceSubtotal = 0;
         n15InvoiceSubtotal = false;
         A7InvoiceDate = Gx_date;
         O15InvoiceSubtotal = A15InvoiceSubtotal;
         n15InvoiceSubtotal = false;
         Z7InvoiceDate = DateTime.MinValue;
         Z8CustomerID = 0;
      }

      protected void InitAll021( )
      {
         A6InvoiceID = 0;
         InitializeNonKey021( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A7InvoiceDate = i7InvoiceDate;
      }

      protected void InitializeNonKey022( )
      {
         A14InvoiceProductTotal = 0;
         A11ProductName = "";
         A12ProductPrice = 0;
         A13InvoiceProductQuantity = 0;
         O14InvoiceProductTotal = A14InvoiceProductTotal;
         Z11ProductName = "";
         Z12ProductPrice = 0;
         Z13InvoiceProductQuantity = 0;
      }

      protected void InitAll022( )
      {
         A10ProductID = 0;
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert022( )
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

      public void VarsToRow1( GeneXus.Programs.general.SdtTransaction1 obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Invoicetax = A16InvoiceTax;
         obj1.gxTpr_Invoicetotal = A17InvoiceTotal;
         obj1.gxTpr_Customerid = A8CustomerID;
         obj1.gxTpr_Customername = A9CustomerName;
         obj1.gxTpr_Invoicesubtotal = A15InvoiceSubtotal;
         obj1.gxTpr_Invoicedate = A7InvoiceDate;
         obj1.gxTpr_Invoiceid = A6InvoiceID;
         obj1.gxTpr_Invoiceid_Z = Z6InvoiceID;
         obj1.gxTpr_Invoicedate_Z = Z7InvoiceDate;
         obj1.gxTpr_Customerid_Z = Z8CustomerID;
         obj1.gxTpr_Customername_Z = Z9CustomerName;
         obj1.gxTpr_Invoicesubtotal_Z = Z15InvoiceSubtotal;
         obj1.gxTpr_Invoicetax_Z = Z16InvoiceTax;
         obj1.gxTpr_Invoicetotal_Z = Z17InvoiceTotal;
         obj1.gxTpr_Invoicesubtotal_N = (short)(Convert.ToInt16(n15InvoiceSubtotal));
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( GeneXus.Programs.general.SdtTransaction1 obj1 )
      {
         obj1.gxTpr_Invoiceid = A6InvoiceID;
         return  ;
      }

      public void RowToVars1( GeneXus.Programs.general.SdtTransaction1 obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A16InvoiceTax = obj1.gxTpr_Invoicetax;
         A17InvoiceTotal = obj1.gxTpr_Invoicetotal;
         A8CustomerID = obj1.gxTpr_Customerid;
         A9CustomerName = obj1.gxTpr_Customername;
         A15InvoiceSubtotal = obj1.gxTpr_Invoicesubtotal;
         n15InvoiceSubtotal = false;
         A7InvoiceDate = obj1.gxTpr_Invoicedate;
         A6InvoiceID = obj1.gxTpr_Invoiceid;
         Z6InvoiceID = obj1.gxTpr_Invoiceid_Z;
         Z7InvoiceDate = obj1.gxTpr_Invoicedate_Z;
         Z8CustomerID = obj1.gxTpr_Customerid_Z;
         Z9CustomerName = obj1.gxTpr_Customername_Z;
         Z15InvoiceSubtotal = obj1.gxTpr_Invoicesubtotal_Z;
         O15InvoiceSubtotal = obj1.gxTpr_Invoicesubtotal_Z;
         Z16InvoiceTax = obj1.gxTpr_Invoicetax_Z;
         Z17InvoiceTotal = obj1.gxTpr_Invoicetotal_Z;
         n15InvoiceSubtotal = (bool)(Convert.ToBoolean(obj1.gxTpr_Invoicesubtotal_N));
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow2( GeneXus.Programs.general.SdtTransaction1_Product obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Invoiceproducttotal = A14InvoiceProductTotal;
         obj2.gxTpr_Productname = A11ProductName;
         obj2.gxTpr_Productprice = A12ProductPrice;
         obj2.gxTpr_Invoiceproductquantity = A13InvoiceProductQuantity;
         obj2.gxTpr_Productid = A10ProductID;
         obj2.gxTpr_Productid_Z = Z10ProductID;
         obj2.gxTpr_Productname_Z = Z11ProductName;
         obj2.gxTpr_Productprice_Z = Z12ProductPrice;
         obj2.gxTpr_Invoiceproductquantity_Z = Z13InvoiceProductQuantity;
         obj2.gxTpr_Invoiceproducttotal_Z = Z14InvoiceProductTotal;
         obj2.gxTpr_Modified = nIsMod_2;
         return  ;
      }

      public void KeyVarsToRow2( GeneXus.Programs.general.SdtTransaction1_Product obj2 )
      {
         obj2.gxTpr_Productid = A10ProductID;
         return  ;
      }

      public void RowToVars2( GeneXus.Programs.general.SdtTransaction1_Product obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A14InvoiceProductTotal = obj2.gxTpr_Invoiceproducttotal;
         A11ProductName = obj2.gxTpr_Productname;
         A12ProductPrice = obj2.gxTpr_Productprice;
         A13InvoiceProductQuantity = obj2.gxTpr_Invoiceproductquantity;
         A10ProductID = obj2.gxTpr_Productid;
         Z10ProductID = obj2.gxTpr_Productid_Z;
         Z11ProductName = obj2.gxTpr_Productname_Z;
         Z12ProductPrice = obj2.gxTpr_Productprice_Z;
         Z13InvoiceProductQuantity = obj2.gxTpr_Invoiceproductquantity_Z;
         Z14InvoiceProductTotal = obj2.gxTpr_Invoiceproducttotal_Z;
         O14InvoiceProductTotal = obj2.gxTpr_Invoiceproducttotal_Z;
         nIsMod_2 = obj2.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A6InvoiceID = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey021( ) ;
         ScanKeyStart021( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z6InvoiceID = A6InvoiceID;
         }
         ZM021( -10) ;
         OnLoadActions021( ) ;
         AddRow021( ) ;
         bcgeneral_Transaction1.gxTpr_Product.ClearCollection();
         if ( RcdFound1 == 1 )
         {
            ScanKeyStart022( ) ;
            nGXsfl_2_idx = 1;
            while ( RcdFound2 != 0 )
            {
               O14InvoiceProductTotal = A14InvoiceProductTotal;
               Z6InvoiceID = A6InvoiceID;
               Z10ProductID = A10ProductID;
               ZM022( -13) ;
               OnLoadActions022( ) ;
               nRcdExists_2 = 1;
               nIsMod_2 = 0;
               Z14InvoiceProductTotal = A14InvoiceProductTotal;
               AddRow022( ) ;
               nGXsfl_2_idx = (int)(nGXsfl_2_idx+1);
               ScanKeyNext022( ) ;
            }
            ScanKeyEnd022( ) ;
         }
         ScanKeyEnd021( ) ;
         if ( RcdFound1 == 0 )
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
         RowToVars1( bcgeneral_Transaction1, 0) ;
         ScanKeyStart021( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z6InvoiceID = A6InvoiceID;
         }
         ZM021( -10) ;
         OnLoadActions021( ) ;
         AddRow021( ) ;
         bcgeneral_Transaction1.gxTpr_Product.ClearCollection();
         if ( RcdFound1 == 1 )
         {
            ScanKeyStart022( ) ;
            nGXsfl_2_idx = 1;
            while ( RcdFound2 != 0 )
            {
               O14InvoiceProductTotal = A14InvoiceProductTotal;
               Z6InvoiceID = A6InvoiceID;
               Z10ProductID = A10ProductID;
               ZM022( -13) ;
               OnLoadActions022( ) ;
               nRcdExists_2 = 1;
               nIsMod_2 = 0;
               Z14InvoiceProductTotal = A14InvoiceProductTotal;
               AddRow022( ) ;
               nGXsfl_2_idx = (int)(nGXsfl_2_idx+1);
               ScanKeyNext022( ) ;
            }
            ScanKeyEnd022( ) ;
         }
         ScanKeyEnd021( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey021( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A15InvoiceSubtotal = O15InvoiceSubtotal;
            n15InvoiceSubtotal = false;
            A16InvoiceTax = O16InvoiceTax;
            A17InvoiceTotal = O17InvoiceTotal;
            Insert021( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A6InvoiceID != Z6InvoiceID )
               {
                  A6InvoiceID = Z6InvoiceID;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A15InvoiceSubtotal = O15InvoiceSubtotal;
                  n15InvoiceSubtotal = false;
                  A16InvoiceTax = O16InvoiceTax;
                  A17InvoiceTotal = O17InvoiceTotal;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A15InvoiceSubtotal = O15InvoiceSubtotal;
                  n15InvoiceSubtotal = false;
                  A16InvoiceTax = O16InvoiceTax;
                  A17InvoiceTotal = O17InvoiceTotal;
                  Update021( ) ;
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
                  if ( A6InvoiceID != Z6InvoiceID )
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
                        A15InvoiceSubtotal = O15InvoiceSubtotal;
                        n15InvoiceSubtotal = false;
                        A16InvoiceTax = O16InvoiceTax;
                        A17InvoiceTotal = O17InvoiceTotal;
                        Insert021( ) ;
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
                        A15InvoiceSubtotal = O15InvoiceSubtotal;
                        n15InvoiceSubtotal = false;
                        A16InvoiceTax = O16InvoiceTax;
                        A17InvoiceTotal = O17InvoiceTotal;
                        Insert021( ) ;
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
         RowToVars1( bcgeneral_Transaction1, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcgeneral_Transaction1) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcgeneral_Transaction1, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A15InvoiceSubtotal = O15InvoiceSubtotal;
         n15InvoiceSubtotal = false;
         A16InvoiceTax = O16InvoiceTax;
         A17InvoiceTotal = O17InvoiceTotal;
         Insert021( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcgeneral_Transaction1) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow1( bcgeneral_Transaction1) ;
         }
         else
         {
            GeneXus.Programs.general.SdtTransaction1 auxBC = new GeneXus.Programs.general.SdtTransaction1(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A6InvoiceID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcgeneral_Transaction1);
               auxBC.Save();
               bcgeneral_Transaction1.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars1( bcgeneral_Transaction1, 1) ;
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
         RowToVars1( bcgeneral_Transaction1, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert021( ) ;
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
               VarsToRow1( bcgeneral_Transaction1) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow1( bcgeneral_Transaction1) ;
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
         RowToVars1( bcgeneral_Transaction1, 0) ;
         GetKey021( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A6InvoiceID != Z6InvoiceID )
            {
               A6InvoiceID = Z6InvoiceID;
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
            if ( A6InvoiceID != Z6InvoiceID )
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
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(13);
         pr_default.close(12);
         context.RollbackDataStores("general.transaction1_bc",pr_default);
         VarsToRow1( bcgeneral_Transaction1) ;
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
         Gx_mode = bcgeneral_Transaction1.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcgeneral_Transaction1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcgeneral_Transaction1 )
         {
            bcgeneral_Transaction1 = (GeneXus.Programs.general.SdtTransaction1)(sdt);
            if ( StringUtil.StrCmp(bcgeneral_Transaction1.gxTpr_Mode, "") == 0 )
            {
               bcgeneral_Transaction1.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcgeneral_Transaction1) ;
            }
            else
            {
               RowToVars1( bcgeneral_Transaction1, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcgeneral_Transaction1.gxTpr_Mode, "") == 0 )
            {
               bcgeneral_Transaction1.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcgeneral_Transaction1, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTransaction1 Transaction1_BC
      {
         get {
            return bcgeneral_Transaction1 ;
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
         pr_default.close(3);
         pr_default.close(13);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         BC000210_A6InvoiceID = new short[1] ;
         BC000210_A7InvoiceDate = new DateTime[] {DateTime.MinValue} ;
         BC000210_A9CustomerName = new string[] {""} ;
         BC000210_A8CustomerID = new short[1] ;
         BC000210_A15InvoiceSubtotal = new decimal[1] ;
         BC000210_n15InvoiceSubtotal = new bool[] {false} ;
         A7InvoiceDate = DateTime.MinValue;
         A9CustomerName = "";
         gx_restcollection = new GXBCCollection<GeneXus.Programs.general.SdtTransaction1>( context, "Transaction1", "MiPrimeraDemo");
         sMode1 = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z7InvoiceDate = DateTime.MinValue;
         Z9CustomerName = "";
         Gx_date = DateTime.MinValue;
         BC000212_A6InvoiceID = new short[1] ;
         BC000212_A7InvoiceDate = new DateTime[] {DateTime.MinValue} ;
         BC000212_A9CustomerName = new string[] {""} ;
         BC000212_A8CustomerID = new short[1] ;
         BC000212_A15InvoiceSubtotal = new decimal[1] ;
         BC000212_n15InvoiceSubtotal = new bool[] {false} ;
         BC00028_A15InvoiceSubtotal = new decimal[1] ;
         BC00028_n15InvoiceSubtotal = new bool[] {false} ;
         BC00026_A9CustomerName = new string[] {""} ;
         BC000213_A6InvoiceID = new short[1] ;
         BC00025_A6InvoiceID = new short[1] ;
         BC00025_A7InvoiceDate = new DateTime[] {DateTime.MinValue} ;
         BC00025_A8CustomerID = new short[1] ;
         BC00024_A6InvoiceID = new short[1] ;
         BC00024_A7InvoiceDate = new DateTime[] {DateTime.MinValue} ;
         BC00024_A8CustomerID = new short[1] ;
         BC000214_A6InvoiceID = new short[1] ;
         BC000218_A15InvoiceSubtotal = new decimal[1] ;
         BC000218_n15InvoiceSubtotal = new bool[] {false} ;
         BC000219_A9CustomerName = new string[] {""} ;
         BC000221_A6InvoiceID = new short[1] ;
         BC000221_A7InvoiceDate = new DateTime[] {DateTime.MinValue} ;
         BC000221_A9CustomerName = new string[] {""} ;
         BC000221_A8CustomerID = new short[1] ;
         BC000221_A15InvoiceSubtotal = new decimal[1] ;
         BC000221_n15InvoiceSubtotal = new bool[] {false} ;
         Z11ProductName = "";
         A11ProductName = "";
         BC000222_A6InvoiceID = new short[1] ;
         BC000222_A10ProductID = new short[1] ;
         BC000222_A11ProductName = new string[] {""} ;
         BC000222_A12ProductPrice = new decimal[1] ;
         BC000222_A13InvoiceProductQuantity = new short[1] ;
         BC000223_A6InvoiceID = new short[1] ;
         BC000223_A10ProductID = new short[1] ;
         BC00023_A6InvoiceID = new short[1] ;
         BC00023_A10ProductID = new short[1] ;
         BC00023_A11ProductName = new string[] {""} ;
         BC00023_A12ProductPrice = new decimal[1] ;
         BC00023_A13InvoiceProductQuantity = new short[1] ;
         sMode2 = "";
         BC00022_A6InvoiceID = new short[1] ;
         BC00022_A10ProductID = new short[1] ;
         BC00022_A11ProductName = new string[] {""} ;
         BC00022_A12ProductPrice = new decimal[1] ;
         BC00022_A13InvoiceProductQuantity = new short[1] ;
         BC000227_A6InvoiceID = new short[1] ;
         BC000227_A10ProductID = new short[1] ;
         BC000227_A11ProductName = new string[] {""} ;
         BC000227_A12ProductPrice = new decimal[1] ;
         BC000227_A13InvoiceProductQuantity = new short[1] ;
         i7InvoiceDate = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.general.transaction1_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A6InvoiceID, BC00022_A10ProductID, BC00022_A11ProductName, BC00022_A12ProductPrice, BC00022_A13InvoiceProductQuantity
               }
               , new Object[] {
               BC00023_A6InvoiceID, BC00023_A10ProductID, BC00023_A11ProductName, BC00023_A12ProductPrice, BC00023_A13InvoiceProductQuantity
               }
               , new Object[] {
               BC00024_A6InvoiceID, BC00024_A7InvoiceDate, BC00024_A8CustomerID
               }
               , new Object[] {
               BC00025_A6InvoiceID, BC00025_A7InvoiceDate, BC00025_A8CustomerID
               }
               , new Object[] {
               BC00026_A9CustomerName
               }
               , new Object[] {
               BC00028_A15InvoiceSubtotal, BC00028_n15InvoiceSubtotal
               }
               , new Object[] {
               BC000210_A6InvoiceID, BC000210_A7InvoiceDate, BC000210_A9CustomerName, BC000210_A8CustomerID, BC000210_A15InvoiceSubtotal, BC000210_n15InvoiceSubtotal
               }
               , new Object[] {
               BC000212_A6InvoiceID, BC000212_A7InvoiceDate, BC000212_A9CustomerName, BC000212_A8CustomerID, BC000212_A15InvoiceSubtotal, BC000212_n15InvoiceSubtotal
               }
               , new Object[] {
               BC000213_A6InvoiceID
               }
               , new Object[] {
               BC000214_A6InvoiceID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000218_A15InvoiceSubtotal, BC000218_n15InvoiceSubtotal
               }
               , new Object[] {
               BC000219_A9CustomerName
               }
               , new Object[] {
               BC000221_A6InvoiceID, BC000221_A7InvoiceDate, BC000221_A9CustomerName, BC000221_A8CustomerID, BC000221_A15InvoiceSubtotal, BC000221_n15InvoiceSubtotal
               }
               , new Object[] {
               BC000222_A6InvoiceID, BC000222_A10ProductID, BC000222_A11ProductName, BC000222_A12ProductPrice, BC000222_A13InvoiceProductQuantity
               }
               , new Object[] {
               BC000223_A6InvoiceID, BC000223_A10ProductID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000227_A6InvoiceID, BC000227_A10ProductID, BC000227_A11ProductName, BC000227_A12ProductPrice, BC000227_A13InvoiceProductQuantity
               }
            }
         );
         A7InvoiceDate = DateTime.MinValue;
         Z7InvoiceDate = DateTime.MinValue;
         i7InvoiceDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound1 ;
      private short A6InvoiceID ;
      private short A8CustomerID ;
      private short Z6InvoiceID ;
      private short nIsMod_2 ;
      private short RcdFound2 ;
      private short Z8CustomerID ;
      private short Gx_BScreen ;
      private short nRcdExists_2 ;
      private short Z13InvoiceProductQuantity ;
      private short A13InvoiceProductQuantity ;
      private short Z10ProductID ;
      private short A10ProductID ;
      private short Gxremove2 ;
      private int trnEnded ;
      private int Start ;
      private int Count ;
      private int GXPagingFrom1 ;
      private int GXPagingTo1 ;
      private int nGXsfl_2_idx=1 ;
      private decimal A15InvoiceSubtotal ;
      private decimal s15InvoiceSubtotal ;
      private decimal O15InvoiceSubtotal ;
      private decimal s16InvoiceTax ;
      private decimal O16InvoiceTax ;
      private decimal A16InvoiceTax ;
      private decimal s17InvoiceTotal ;
      private decimal O17InvoiceTotal ;
      private decimal A17InvoiceTotal ;
      private decimal Z15InvoiceSubtotal ;
      private decimal Z16InvoiceTax ;
      private decimal Z17InvoiceTotal ;
      private decimal Z12ProductPrice ;
      private decimal A12ProductPrice ;
      private decimal Z14InvoiceProductTotal ;
      private decimal A14InvoiceProductTotal ;
      private decimal O14InvoiceProductTotal ;
      private string A9CustomerName ;
      private string sMode1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z9CustomerName ;
      private string Z11ProductName ;
      private string A11ProductName ;
      private string sMode2 ;
      private DateTime A7InvoiceDate ;
      private DateTime Z7InvoiceDate ;
      private DateTime Gx_date ;
      private DateTime i7InvoiceDate ;
      private bool n15InvoiceSubtotal ;
      private bool returnInSub ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.SdtTransaction1 bcgeneral_Transaction1 ;
      private IDataStoreProvider pr_default ;
      private short[] BC000210_A6InvoiceID ;
      private DateTime[] BC000210_A7InvoiceDate ;
      private string[] BC000210_A9CustomerName ;
      private short[] BC000210_A8CustomerID ;
      private decimal[] BC000210_A15InvoiceSubtotal ;
      private bool[] BC000210_n15InvoiceSubtotal ;
      private GeneXus.Programs.general.SdtTransaction1 gx_sdt_item ;
      private GXBCCollection<GeneXus.Programs.general.SdtTransaction1> gx_restcollection ;
      private short[] BC000212_A6InvoiceID ;
      private DateTime[] BC000212_A7InvoiceDate ;
      private string[] BC000212_A9CustomerName ;
      private short[] BC000212_A8CustomerID ;
      private decimal[] BC000212_A15InvoiceSubtotal ;
      private bool[] BC000212_n15InvoiceSubtotal ;
      private decimal[] BC00028_A15InvoiceSubtotal ;
      private bool[] BC00028_n15InvoiceSubtotal ;
      private string[] BC00026_A9CustomerName ;
      private short[] BC000213_A6InvoiceID ;
      private short[] BC00025_A6InvoiceID ;
      private DateTime[] BC00025_A7InvoiceDate ;
      private short[] BC00025_A8CustomerID ;
      private short[] BC00024_A6InvoiceID ;
      private DateTime[] BC00024_A7InvoiceDate ;
      private short[] BC00024_A8CustomerID ;
      private short[] BC000214_A6InvoiceID ;
      private decimal[] BC000218_A15InvoiceSubtotal ;
      private bool[] BC000218_n15InvoiceSubtotal ;
      private string[] BC000219_A9CustomerName ;
      private short[] BC000221_A6InvoiceID ;
      private DateTime[] BC000221_A7InvoiceDate ;
      private string[] BC000221_A9CustomerName ;
      private short[] BC000221_A8CustomerID ;
      private decimal[] BC000221_A15InvoiceSubtotal ;
      private bool[] BC000221_n15InvoiceSubtotal ;
      private short[] BC000222_A6InvoiceID ;
      private short[] BC000222_A10ProductID ;
      private string[] BC000222_A11ProductName ;
      private decimal[] BC000222_A12ProductPrice ;
      private short[] BC000222_A13InvoiceProductQuantity ;
      private short[] BC000223_A6InvoiceID ;
      private short[] BC000223_A10ProductID ;
      private short[] BC00023_A6InvoiceID ;
      private short[] BC00023_A10ProductID ;
      private string[] BC00023_A11ProductName ;
      private decimal[] BC00023_A12ProductPrice ;
      private short[] BC00023_A13InvoiceProductQuantity ;
      private short[] BC00022_A6InvoiceID ;
      private short[] BC00022_A10ProductID ;
      private string[] BC00022_A11ProductName ;
      private decimal[] BC00022_A12ProductPrice ;
      private short[] BC00022_A13InvoiceProductQuantity ;
      private short[] BC000227_A6InvoiceID ;
      private short[] BC000227_A10ProductID ;
      private string[] BC000227_A11ProductName ;
      private decimal[] BC000227_A12ProductPrice ;
      private short[] BC000227_A13InvoiceProductQuantity ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class transaction1_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00022;
          prmBC00022 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmBC00023;
          prmBC00023 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmBC00024;
          prmBC00024 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmBC00025;
          prmBC00025 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmBC00026;
          prmBC00026 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmBC00028;
          prmBC00028 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmBC000210;
          prmBC000210 = new Object[] {
          new ParDef("@GXPagingFrom1",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo1",GXType.Int32,9,0)
          };
          Object[] prmBC000212;
          prmBC000212 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmBC000213;
          prmBC000213 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmBC000214;
          prmBC000214 = new Object[] {
          new ParDef("@InvoiceDate",GXType.Date,8,0) ,
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmBC000215;
          prmBC000215 = new Object[] {
          new ParDef("@InvoiceDate",GXType.Date,8,0) ,
          new ParDef("@CustomerID",GXType.Int16,4,0) ,
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmBC000216;
          prmBC000216 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmBC000218;
          prmBC000218 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmBC000219;
          prmBC000219 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmBC000221;
          prmBC000221 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmBC000222;
          prmBC000222 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmBC000223;
          prmBC000223 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmBC000224;
          prmBC000224 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0) ,
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,8,2) ,
          new ParDef("@InvoiceProductQuantity",GXType.Int16,4,0)
          };
          Object[] prmBC000225;
          prmBC000225 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,8,2) ,
          new ParDef("@InvoiceProductQuantity",GXType.Int16,4,0) ,
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmBC000226;
          prmBC000226 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmBC000227;
          prmBC000227 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00022", "SELECT [InvoiceID], [ProductID], [ProductName], [ProductPrice], [InvoiceProductQuantity] FROM [Transaction1Product] WITH (UPDLOCK) WHERE [InvoiceID] = @InvoiceID AND [ProductID] = @ProductID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00023", "SELECT [InvoiceID], [ProductID], [ProductName], [ProductPrice], [InvoiceProductQuantity] FROM [Transaction1Product] WHERE [InvoiceID] = @InvoiceID AND [ProductID] = @ProductID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00024", "SELECT [InvoiceID], [InvoiceDate], [CustomerID] FROM [Transaction1] WITH (UPDLOCK) WHERE [InvoiceID] = @InvoiceID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00025", "SELECT [InvoiceID], [InvoiceDate], [CustomerID] FROM [Transaction1] WHERE [InvoiceID] = @InvoiceID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00026", "SELECT [CustomerName] FROM [Cliente] WHERE [CustomerID] = @CustomerID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00028", "SELECT COALESCE( T1.[InvoiceSubtotal], 0) AS InvoiceSubtotal FROM (SELECT SUM([ProductPrice] * CAST([InvoiceProductQuantity] AS decimal( 18, 10))) AS InvoiceSubtotal, [InvoiceID] FROM [Transaction1Product] WITH (UPDLOCK) GROUP BY [InvoiceID] ) T1 WHERE T1.[InvoiceID] = @InvoiceID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000210", "SELECT TM1.[InvoiceID], TM1.[InvoiceDate], T3.[CustomerName], TM1.[CustomerID], COALESCE( T2.[InvoiceSubtotal], 0) AS InvoiceSubtotal FROM (([Transaction1] TM1 LEFT JOIN (SELECT SUM([ProductPrice] * CAST([InvoiceProductQuantity] AS decimal( 18, 10))) AS InvoiceSubtotal, [InvoiceID] FROM [Transaction1Product] GROUP BY [InvoiceID] ) T2 ON T2.[InvoiceID] = TM1.[InvoiceID]) INNER JOIN [Cliente] T3 ON T3.[CustomerID] = TM1.[CustomerID]) ORDER BY TM1.[InvoiceID]  OFFSET @GXPagingFrom1 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo1 > 0 THEN @GXPagingTo1 ELSE 1e9 END) AS INTEGER) ROWS ONLY",true, GxErrorMask.GX_NOMASK, false, this,prmBC000210,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000212", "SELECT TM1.[InvoiceID], TM1.[InvoiceDate], T3.[CustomerName], TM1.[CustomerID], COALESCE( T2.[InvoiceSubtotal], 0) AS InvoiceSubtotal FROM (([Transaction1] TM1 LEFT JOIN (SELECT SUM([ProductPrice] * CAST([InvoiceProductQuantity] AS decimal( 18, 10))) AS InvoiceSubtotal, [InvoiceID] FROM [Transaction1Product] GROUP BY [InvoiceID] ) T2 ON T2.[InvoiceID] = TM1.[InvoiceID]) INNER JOIN [Cliente] T3 ON T3.[CustomerID] = TM1.[CustomerID]) WHERE TM1.[InvoiceID] = @InvoiceID ORDER BY TM1.[InvoiceID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000212,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000213", "SELECT [InvoiceID] FROM [Transaction1] WHERE [InvoiceID] = @InvoiceID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000213,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000214", "INSERT INTO [Transaction1]([InvoiceDate], [CustomerID]) VALUES(@InvoiceDate, @CustomerID); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000214,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000215", "UPDATE [Transaction1] SET [InvoiceDate]=@InvoiceDate, [CustomerID]=@CustomerID  WHERE [InvoiceID] = @InvoiceID", GxErrorMask.GX_NOMASK,prmBC000215)
             ,new CursorDef("BC000216", "DELETE FROM [Transaction1]  WHERE [InvoiceID] = @InvoiceID", GxErrorMask.GX_NOMASK,prmBC000216)
             ,new CursorDef("BC000218", "SELECT COALESCE( T1.[InvoiceSubtotal], 0) AS InvoiceSubtotal FROM (SELECT SUM([ProductPrice] * CAST([InvoiceProductQuantity] AS decimal( 18, 10))) AS InvoiceSubtotal, [InvoiceID] FROM [Transaction1Product] WITH (UPDLOCK) GROUP BY [InvoiceID] ) T1 WHERE T1.[InvoiceID] = @InvoiceID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000218,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000219", "SELECT [CustomerName] FROM [Cliente] WHERE [CustomerID] = @CustomerID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000219,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000221", "SELECT TM1.[InvoiceID], TM1.[InvoiceDate], T3.[CustomerName], TM1.[CustomerID], COALESCE( T2.[InvoiceSubtotal], 0) AS InvoiceSubtotal FROM (([Transaction1] TM1 LEFT JOIN (SELECT SUM([ProductPrice] * CAST([InvoiceProductQuantity] AS decimal( 18, 10))) AS InvoiceSubtotal, [InvoiceID] FROM [Transaction1Product] GROUP BY [InvoiceID] ) T2 ON T2.[InvoiceID] = TM1.[InvoiceID]) INNER JOIN [Cliente] T3 ON T3.[CustomerID] = TM1.[CustomerID]) WHERE TM1.[InvoiceID] = @InvoiceID ORDER BY TM1.[InvoiceID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000221,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000222", "SELECT [InvoiceID], [ProductID], [ProductName], [ProductPrice], [InvoiceProductQuantity] FROM [Transaction1Product] WHERE [InvoiceID] = @InvoiceID and [ProductID] = @ProductID ORDER BY [InvoiceID], [ProductID]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000222,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000223", "SELECT [InvoiceID], [ProductID] FROM [Transaction1Product] WHERE [InvoiceID] = @InvoiceID AND [ProductID] = @ProductID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000223,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000224", "INSERT INTO [Transaction1Product]([InvoiceID], [ProductID], [ProductName], [ProductPrice], [InvoiceProductQuantity]) VALUES(@InvoiceID, @ProductID, @ProductName, @ProductPrice, @InvoiceProductQuantity)", GxErrorMask.GX_NOMASK,prmBC000224)
             ,new CursorDef("BC000225", "UPDATE [Transaction1Product] SET [ProductName]=@ProductName, [ProductPrice]=@ProductPrice, [InvoiceProductQuantity]=@InvoiceProductQuantity  WHERE [InvoiceID] = @InvoiceID AND [ProductID] = @ProductID", GxErrorMask.GX_NOMASK,prmBC000225)
             ,new CursorDef("BC000226", "DELETE FROM [Transaction1Product]  WHERE [InvoiceID] = @InvoiceID AND [ProductID] = @ProductID", GxErrorMask.GX_NOMASK,prmBC000226)
             ,new CursorDef("BC000227", "SELECT [InvoiceID], [ProductID], [ProductName], [ProductPrice], [InvoiceProductQuantity] FROM [Transaction1Product] WHERE [InvoiceID] = @InvoiceID ORDER BY [InvoiceID], [ProductID]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000227,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
