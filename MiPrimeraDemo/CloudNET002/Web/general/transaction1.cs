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
   public class transaction1 : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxSuggest"+"_"+"CUSTOMERID") == 0 )
         {
            A9CustomerName = GetPar( "CustomerName");
            AssignAttri("", false, "A9CustomerName", A9CustomerName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXSGACUSTOMERID020( A9CustomerName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxSuggest"+"_"+"CUSTOMERID") == 0 )
         {
            A9CustomerName = GetPar( "CustomerName");
            AssignAttri("", false, "A9CustomerName", A9CustomerName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXSGACUSTOMERID020( A9CustomerName) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxHideCode"+"_"+"CUSTOMERID") == 0 )
         {
            h8CustomerID = GetPar( "h8CustomerID");
            A9CustomerName = GetPar( "CustomerName");
            AssignAttri("", false, "A9CustomerName", A9CustomerName);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXHCACUSTOMERID021( h8CustomerID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A6InvoiceID = (short)(Math.Round(NumberUtil.Val( GetPar( "InvoiceID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A6InvoiceID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A8CustomerID = (short)(Math.Round(NumberUtil.Val( GetPar( "CustomerID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A8CustomerID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridtransaction1_product") == 0 )
         {
            gxnrGridtransaction1_product_newrow_invoke( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7InvoiceID = (short)(Math.Round(NumberUtil.Val( GetPar( "InvoiceID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7InvoiceID", StringUtil.LTrimStr( (decimal)(AV7InvoiceID), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINVOICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvoiceID), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Transaction1", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtInvoiceDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("MiPrimeraDemo", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridtransaction1_product_newrow_invoke( )
      {
         nRC_GXsfl_53 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_53"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_53_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_53_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_53_idx = GetPar( "sGXsfl_53_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridtransaction1_product_newrow( ) ;
         /* End function gxnrGridtransaction1_product_newrow_invoke */
      }

      public transaction1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("MiPrimeraDemo", true);
      }

      public transaction1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_InvoiceID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7InvoiceID = aP1_InvoiceID;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Transaction1", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtInvoiceID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInvoiceID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6InvoiceID), 4, 0, ".", "")), StringUtil.LTrim( ((edtInvoiceID_Enabled!=0) ? context.localUtil.Format( (decimal)(A6InvoiceID), "ZZZ9") : context.localUtil.Format( (decimal)(A6InvoiceID), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceID_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtInvoiceDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceDate_Internalname, "Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtInvoiceDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtInvoiceDate_Internalname, context.localUtil.Format(A7InvoiceDate, "99/99/99"), context.localUtil.Format( A7InvoiceDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_General/Transaction1.htm");
         GxWebStd.gx_bitmap( context, edtInvoiceDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtInvoiceDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_General/Transaction1.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCustomerID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCustomerID_Internalname, "Customer Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCustomerID_Internalname, StringUtil.RTrim( h8CustomerID), StringUtil.RTrim( context.localUtil.Format( h8CustomerID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCustomerID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCustomerID_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, 0, 0, true, "", "start", true, "", "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divProducttable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleproduct_Internalname, "Product", "", "", lblTitleproduct_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridtransaction1_product( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtInvoiceSubtotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceSubtotal_Internalname, "Subtotal", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInvoiceSubtotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A15InvoiceSubtotal, 8, 2, ".", "")), StringUtil.LTrim( ((edtInvoiceSubtotal_Enabled!=0) ? context.localUtil.Format( A15InvoiceSubtotal, "ZZZZ9.99") : context.localUtil.Format( A15InvoiceSubtotal, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceSubtotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceSubtotal_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtInvoiceTax_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceTax_Internalname, "Tax", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInvoiceTax_Internalname, StringUtil.LTrim( StringUtil.NToC( A16InvoiceTax, 8, 2, ".", "")), StringUtil.LTrim( ((edtInvoiceTax_Enabled!=0) ? context.localUtil.Format( A16InvoiceTax, "ZZZZ9.99") : context.localUtil.Format( A16InvoiceTax, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceTax_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceTax_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtInvoiceTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceTotal_Internalname, "Total", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInvoiceTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A17InvoiceTotal, 8, 2, ".", "")), StringUtil.LTrim( ((edtInvoiceTotal_Enabled!=0) ? context.localUtil.Format( A17InvoiceTotal, "ZZZZ9.99") : context.localUtil.Format( A17InvoiceTotal, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceTotal_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_General/Transaction1.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridtransaction1_product( )
      {
         /*  Grid Control  */
         StartGridControl53( ) ;
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount2 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_2 = 1;
               ScanStart022( ) ;
               while ( RcdFound2 != 0 )
               {
                  init_level_properties2( ) ;
                  getByPrimaryKey022( ) ;
                  AddRow022( ) ;
                  ScanNext022( ) ;
               }
               ScanEnd022( ) ;
               nBlankRcdCount2 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B15InvoiceSubtotal = A15InvoiceSubtotal;
            n15InvoiceSubtotal = false;
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            standaloneNotModal022( ) ;
            standaloneModal022( ) ;
            sMode2 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow022( ) ;
               edtProductID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductID_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtProductPrice_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtInvoiceProductQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPRODUCTQUANTITY_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoiceProductQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceProductQuantity_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtInvoiceProductTotal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPRODUCTTOTAL_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoiceProductTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceProductTotal_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               if ( ( nRcdExists_2 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal022( ) ;
               }
               SendRow022( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A15InvoiceSubtotal = B15InvoiceSubtotal;
            n15InvoiceSubtotal = false;
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount2 = 5;
            nRcdExists_2 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart022( ) ;
               while ( RcdFound2 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_532( ) ;
                  init_level_properties2( ) ;
                  standaloneNotModal022( ) ;
                  getByPrimaryKey022( ) ;
                  standaloneModal022( ) ;
                  AddRow022( ) ;
                  ScanNext022( ) ;
               }
               ScanEnd022( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode2 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
            SubsflControlProps_532( ) ;
            InitAll022( ) ;
            init_level_properties2( ) ;
            B15InvoiceSubtotal = A15InvoiceSubtotal;
            n15InvoiceSubtotal = false;
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            nRcdExists_2 = 0;
            nIsMod_2 = 0;
            nRcdDeleted_2 = 0;
            nBlankRcdCount2 = (short)(nBlankRcdUsr2+nBlankRcdCount2);
            fRowAdded = 0;
            while ( nBlankRcdCount2 > 0 )
            {
               standaloneNotModal022( ) ;
               standaloneModal022( ) ;
               AddRow022( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProductID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount2 = (short)(nBlankRcdCount2-1);
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A15InvoiceSubtotal = B15InvoiceSubtotal;
            n15InvoiceSubtotal = false;
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridtransaction1_productContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridtransaction1_product", Gridtransaction1_productContainer, subGridtransaction1_product_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtransaction1_productContainerData", Gridtransaction1_productContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtransaction1_productContainerData"+"V", Gridtransaction1_productContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridtransaction1_productContainerData"+"V"+"\" value='"+Gridtransaction1_productContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z6InvoiceID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z6InvoiceID"), ".", ","), 18, MidpointRounding.ToEven));
               Z7InvoiceDate = context.localUtil.CToD( cgiGet( "Z7InvoiceDate"), 0);
               Z8CustomerID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z8CustomerID"), ".", ","), 18, MidpointRounding.ToEven));
               O15InvoiceSubtotal = context.localUtil.CToN( cgiGet( "O15InvoiceSubtotal"), ".", ",");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_53 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), ".", ","), 18, MidpointRounding.ToEven));
               N8CustomerID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N8CustomerID"), ".", ","), 18, MidpointRounding.ToEven));
               AV7InvoiceID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINVOICEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_CustomerID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CUSTOMERID"), ".", ","), 18, MidpointRounding.ToEven));
               A8CustomerID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GXHCCUSTOMERID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV15Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A6InvoiceID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
               if ( context.localUtil.VCDate( cgiGet( edtInvoiceDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Invoice Date"}), 1, "INVOICEDATE");
                  AnyError = 1;
                  GX_FocusControl = edtInvoiceDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A7InvoiceDate = DateTime.MinValue;
                  AssignAttri("", false, "A7InvoiceDate", context.localUtil.Format(A7InvoiceDate, "99/99/99"));
               }
               else
               {
                  A7InvoiceDate = context.localUtil.CToD( cgiGet( edtInvoiceDate_Internalname), 1);
                  AssignAttri("", false, "A7InvoiceDate", context.localUtil.Format(A7InvoiceDate, "99/99/99"));
               }
               h8CustomerID = cgiGet( edtCustomerID_Internalname);
               A15InvoiceSubtotal = context.localUtil.CToN( cgiGet( edtInvoiceSubtotal_Internalname), ".", ",");
               n15InvoiceSubtotal = false;
               AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
               A16InvoiceTax = context.localUtil.CToN( cgiGet( edtInvoiceTax_Internalname), ".", ",");
               AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
               A17InvoiceTotal = context.localUtil.CToN( cgiGet( edtInvoiceTotal_Internalname), ".", ",");
               AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Transaction1");
               A6InvoiceID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
               forbiddenHiddens.Add("InvoiceID", context.localUtil.Format( (decimal)(A6InvoiceID), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A6InvoiceID != Z6InvoiceID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("general\\transaction1:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A6InvoiceID = (short)(Math.Round(NumberUtil.Val( GetPar( "InvoiceID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "INVOICEID");
                        AnyError = 1;
                        GX_FocusControl = edtInvoiceID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "AFTER TRN") == 0 ) )
                        {
                           nGXsfl_53_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
                           SubsflControlProps_532( ) ;
                           if ( ( ( context.localUtil.CToN( cgiGet( edtProductID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductID_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
                           {
                              GXCCtl = "PRODUCTID_" + sGXsfl_53_idx;
                              GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtProductID_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                              wbErr = true;
                              A10ProductID = 0;
                           }
                           else
                           {
                              A10ProductID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                           }
                           A11ProductName = cgiGet( edtProductName_Internalname);
                           if ( ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",") > 99999.99m ) ) )
                           {
                              GXCCtl = "PRODUCTPRICE_" + sGXsfl_53_idx;
                              GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtProductPrice_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                              wbErr = true;
                              A12ProductPrice = 0;
                           }
                           else
                           {
                              A12ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",");
                           }
                           if ( ( ( context.localUtil.CToN( cgiGet( edtInvoiceProductQuantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoiceProductQuantity_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
                           {
                              GXCCtl = "INVOICEPRODUCTQUANTITY_" + sGXsfl_53_idx;
                              GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
                              AnyError = 1;
                              GX_FocusControl = edtInvoiceProductQuantity_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                              wbErr = true;
                              A13InvoiceProductQuantity = 0;
                           }
                           else
                           {
                              A13InvoiceProductQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceProductQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                           }
                           A14InvoiceProductTotal = context.localUtil.CToN( cgiGet( edtInvoiceProductTotal_Internalname), ".", ",");
                           GXCCtl = "Z10ProductID_" + sGXsfl_53_idx;
                           Z10ProductID = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
                           GXCCtl = "Z11ProductName_" + sGXsfl_53_idx;
                           Z11ProductName = cgiGet( GXCCtl);
                           GXCCtl = "Z12ProductPrice_" + sGXsfl_53_idx;
                           Z12ProductPrice = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
                           GXCCtl = "Z13InvoiceProductQuantity_" + sGXsfl_53_idx;
                           Z13InvoiceProductQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
                           GXCCtl = "O14InvoiceProductTotal_" + sGXsfl_53_idx;
                           O14InvoiceProductTotal = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
                           GXCCtl = "nRcdDeleted_2_" + sGXsfl_53_idx;
                           nRcdDeleted_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
                           GXCCtl = "nRcdExists_2_" + sGXsfl_53_idx;
                           nRcdExists_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
                           GXCCtl = "nIsMod_2_" + sGXsfl_53_idx;
                           nIsMod_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E11022 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: After Trn */
                                 E12022 ();
                              }
                           }
                           else
                           {
                           }
                        }
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll021( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes021( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
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
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_022( )
      {
         s15InvoiceSubtotal = O15InvoiceSubtotal;
         n15InvoiceSubtotal = false;
         AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         s16InvoiceTax = O16InvoiceTax;
         AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
         s17InvoiceTotal = O17InvoiceTotal;
         AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow022( ) ;
            if ( ( nRcdExists_2 != 0 ) || ( nIsMod_2 != 0 ) )
            {
               GetKey022( ) ;
               if ( ( nRcdExists_2 == 0 ) && ( nRcdDeleted_2 == 0 ) )
               {
                  if ( RcdFound2 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate022( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable022( ) ;
                        CloseExtendedTableCursors022( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O15InvoiceSubtotal = A15InvoiceSubtotal;
                        n15InvoiceSubtotal = false;
                        AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
                        O16InvoiceTax = A16InvoiceTax;
                        AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
                        O17InvoiceTotal = A17InvoiceTotal;
                        AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUCTID_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProductID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound2 != 0 )
                  {
                     if ( nRcdDeleted_2 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey022( ) ;
                        Load022( ) ;
                        BeforeValidate022( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls022( ) ;
                           O15InvoiceSubtotal = A15InvoiceSubtotal;
                           n15InvoiceSubtotal = false;
                           AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
                           O16InvoiceTax = A16InvoiceTax;
                           AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
                           O17InvoiceTotal = A17InvoiceTotal;
                           AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
                        }
                     }
                     else
                     {
                        if ( nIsMod_2 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate022( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable022( ) ;
                              CloseExtendedTableCursors022( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O15InvoiceSubtotal = A15InvoiceSubtotal;
                              n15InvoiceSubtotal = false;
                              AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
                              O16InvoiceTax = A16InvoiceTax;
                              AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
                              O17InvoiceTotal = A17InvoiceTotal;
                              AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_2 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProductID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductID), 4, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, StringUtil.RTrim( A11ProductName)) ;
            ChangePostValue( edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A12ProductPrice, 8, 2, ".", ""))) ;
            ChangePostValue( edtInvoiceProductQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13InvoiceProductQuantity), 4, 0, ".", ""))) ;
            ChangePostValue( edtInvoiceProductTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A14InvoiceProductTotal, 8, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z10ProductID_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductID), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z11ProductName_"+sGXsfl_53_idx, StringUtil.RTrim( Z11ProductName)) ;
            ChangePostValue( "ZT_"+"Z12ProductPrice_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( Z12ProductPrice, 8, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z13InvoiceProductQuantity_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13InvoiceProductQuantity), 4, 0, ".", ""))) ;
            ChangePostValue( "T14InvoiceProductTotal_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( O14InvoiceProductTotal, 8, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_2), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_2), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_2), 4, 0, ".", ""))) ;
            if ( nIsMod_2 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEPRODUCTQUANTITY_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceProductQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEPRODUCTTOTAL_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceProductTotal_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O15InvoiceSubtotal = s15InvoiceSubtotal;
         n15InvoiceSubtotal = false;
         AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         O16InvoiceTax = s16InvoiceTax;
         AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
         O17InvoiceTotal = s17InvoiceTotal;
         AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_CustomerID = 0;
         AssignAttri("", false, "AV11Insert_CustomerID", StringUtil.LTrimStr( (decimal)(AV11Insert_CustomerID), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "CustomerID") == 0 )
               {
                  AV11Insert_CustomerID = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_CustomerID", StringUtil.LTrimStr( (decimal)(AV11Insert_CustomerID), 4, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("general.wwtransaction1.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM021( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z7InvoiceDate = T00025_A7InvoiceDate[0];
               Z8CustomerID = T00025_A8CustomerID[0];
            }
            else
            {
               Z7InvoiceDate = A7InvoiceDate;
               Z8CustomerID = A8CustomerID;
            }
         }
         if ( GX_JID == -18 )
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
         edtInvoiceID_Enabled = 0;
         AssignProp("", false, edtInvoiceID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtInvoiceID_Enabled = 0;
         AssignProp("", false, edtInvoiceID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceID_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7InvoiceID) )
         {
            A6InvoiceID = AV7InvoiceID;
            AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CustomerID) )
         {
            edtCustomerID_Enabled = 0;
            AssignProp("", false, edtCustomerID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerID_Enabled), 5, 0), true);
         }
         else
         {
            edtCustomerID_Enabled = 1;
            AssignProp("", false, edtCustomerID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_CustomerID) )
         {
            A8CustomerID = AV11Insert_CustomerID;
            AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
            /* Using cursor T00029 */
            pr_default.execute(6, new Object[] {A8CustomerID});
            h8CustomerID = "";
            while ( (pr_default.getStatus(6) != 101) )
            {
               h8CustomerID = T00029_A9CustomerName[0];
               if (true) break;
            }
            pr_default.close(6);
            AssignAttri("", false, "h8CustomerID", h8CustomerID);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( IsIns( )  && (DateTime.MinValue==A7InvoiceDate) && ( Gx_BScreen == 0 ) )
         {
            A7InvoiceDate = Gx_date;
            AssignAttri("", false, "A7InvoiceDate", context.localUtil.Format(A7InvoiceDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00028 */
            pr_default.execute(5, new Object[] {A6InvoiceID});
            if ( (pr_default.getStatus(5) != 101) )
            {
               A15InvoiceSubtotal = T00028_A15InvoiceSubtotal[0];
               n15InvoiceSubtotal = T00028_n15InvoiceSubtotal[0];
               AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            }
            else
            {
               A15InvoiceSubtotal = 0;
               n15InvoiceSubtotal = false;
               AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            }
            O15InvoiceSubtotal = A15InvoiceSubtotal;
            n15InvoiceSubtotal = false;
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            pr_default.close(5);
            A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
            AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
            A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
            AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
            AV15Pgmname = "General.Transaction1";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T00026 */
            pr_default.execute(4, new Object[] {A8CustomerID});
            A9CustomerName = T00026_A9CustomerName[0];
            pr_default.close(4);
         }
      }

      protected void Load021( )
      {
         /* Using cursor T000211 */
         pr_default.execute(7, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound1 = 1;
            A7InvoiceDate = T000211_A7InvoiceDate[0];
            AssignAttri("", false, "A7InvoiceDate", context.localUtil.Format(A7InvoiceDate, "99/99/99"));
            A9CustomerName = T000211_A9CustomerName[0];
            A8CustomerID = T000211_A8CustomerID[0];
            AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
            A15InvoiceSubtotal = T000211_A15InvoiceSubtotal[0];
            n15InvoiceSubtotal = T000211_n15InvoiceSubtotal[0];
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            ZM021( -18) ;
         }
         pr_default.close(7);
         OnLoadActions021( ) ;
      }

      protected void OnLoadActions021( )
      {
         O15InvoiceSubtotal = A15InvoiceSubtotal;
         n15InvoiceSubtotal = false;
         AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         AV15Pgmname = "General.Transaction1";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
         AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
         A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
         AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
         h8CustomerID = A9CustomerName;
         AssignAttri("", false, "h8CustomerID", h8CustomerID);
      }

      protected void CheckExtendedTable021( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( h8CustomerID)) )
         {
            A8CustomerID = 0;
            AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
         }
         else
         {
            A9CustomerName = h8CustomerID;
            AssignAttri("", false, "A9CustomerName", A9CustomerName);
            /* Using cursor T000212 */
            pr_default.execute(8, new Object[] {A9CustomerName});
            A8CustomerID = T000212_A8CustomerID[0];
            AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
            A8CustomerID = T000212_A8CustomerID[0];
            AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
            if ( ! ( (pr_default.getStatus(8) == 101) ) )
            {
               pr_default.readNext(8);
               if ( ! ( (pr_default.getStatus(8) == 101) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_ambiguousck", new   object[]  {"Customer Name"}), 1, "CUSTOMERID");
                  AnyError = 1;
                  GX_FocusControl = edtCustomerID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
            }
            pr_default.close(8);
         }
         AV15Pgmname = "General.Transaction1";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T00028 */
         pr_default.execute(5, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A15InvoiceSubtotal = T00028_A15InvoiceSubtotal[0];
            n15InvoiceSubtotal = T00028_n15InvoiceSubtotal[0];
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         }
         else
         {
            A15InvoiceSubtotal = 0;
            n15InvoiceSubtotal = false;
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         }
         pr_default.close(5);
         A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
         AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
         A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
         AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
         if ( ! ( (DateTime.MinValue==A7InvoiceDate) || ( DateTimeUtil.ResetTime ( A7InvoiceDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Invoice Date is out of range", "OutOfRange", 1, "INVOICEDATE");
            AnyError = 1;
            GX_FocusControl = edtInvoiceDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( h8CustomerID)) )
         {
            A8CustomerID = 0;
            AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
         }
         else
         {
            A9CustomerName = h8CustomerID;
            AssignAttri("", false, "A9CustomerName", A9CustomerName);
            /* Using cursor T000213 */
            pr_default.execute(9, new Object[] {A9CustomerName});
            A8CustomerID = T000213_A8CustomerID[0];
            AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
            A8CustomerID = T000213_A8CustomerID[0];
            AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
            if ( ! ( (pr_default.getStatus(9) == 101) ) )
            {
               pr_default.readNext(9);
               if ( ! ( (pr_default.getStatus(9) == 101) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_ambiguousck", new   object[]  {"Customer Name"}), 1, "CUSTOMERID");
                  AnyError = 1;
                  GX_FocusControl = edtCustomerID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
            }
            pr_default.close(9);
         }
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A8CustomerID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9CustomerName = T00026_A9CustomerName[0];
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

      protected void gxLoad_20( short A6InvoiceID )
      {
         /* Using cursor T000215 */
         pr_default.execute(10, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A15InvoiceSubtotal = T000215_A15InvoiceSubtotal[0];
            n15InvoiceSubtotal = T000215_n15InvoiceSubtotal[0];
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         }
         else
         {
            A15InvoiceSubtotal = 0;
            n15InvoiceSubtotal = false;
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A15InvoiceSubtotal, 8, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_19( short A8CustomerID )
      {
         /* Using cursor T000216 */
         pr_default.execute(11, new Object[] {A8CustomerID});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9CustomerName = T000216_A9CustomerName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A9CustomerName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void GetKey021( )
      {
         /* Using cursor T000217 */
         pr_default.execute(12, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM021( 18) ;
            RcdFound1 = 1;
            A6InvoiceID = T00025_A6InvoiceID[0];
            AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
            A7InvoiceDate = T00025_A7InvoiceDate[0];
            AssignAttri("", false, "A7InvoiceDate", context.localUtil.Format(A7InvoiceDate, "99/99/99"));
            A8CustomerID = T00025_A8CustomerID[0];
            AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
            Z6InvoiceID = A6InvoiceID;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load021( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey021( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey021( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey021( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T000218 */
         pr_default.execute(13, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000218_A6InvoiceID[0] < A6InvoiceID ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000218_A6InvoiceID[0] > A6InvoiceID ) ) )
            {
               A6InvoiceID = T000218_A6InvoiceID[0];
               AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T000219 */
         pr_default.execute(14, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000219_A6InvoiceID[0] > A6InvoiceID ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000219_A6InvoiceID[0] < A6InvoiceID ) ) )
            {
               A6InvoiceID = T000219_A6InvoiceID[0];
               AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey021( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A15InvoiceSubtotal = O15InvoiceSubtotal;
            n15InvoiceSubtotal = false;
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            A16InvoiceTax = O16InvoiceTax;
            AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
            A17InvoiceTotal = O17InvoiceTotal;
            AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
            GX_FocusControl = edtInvoiceDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert021( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A6InvoiceID != Z6InvoiceID )
               {
                  A6InvoiceID = Z6InvoiceID;
                  AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "INVOICEID");
                  AnyError = 1;
                  GX_FocusControl = edtInvoiceID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A15InvoiceSubtotal = O15InvoiceSubtotal;
                  n15InvoiceSubtotal = false;
                  AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
                  A16InvoiceTax = O16InvoiceTax;
                  AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
                  A17InvoiceTotal = O17InvoiceTotal;
                  AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtInvoiceDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A15InvoiceSubtotal = O15InvoiceSubtotal;
                  n15InvoiceSubtotal = false;
                  AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
                  A16InvoiceTax = O16InvoiceTax;
                  AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
                  A17InvoiceTotal = O17InvoiceTotal;
                  AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
                  Update021( ) ;
                  GX_FocusControl = edtInvoiceDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A6InvoiceID != Z6InvoiceID )
               {
                  /* Insert record */
                  A15InvoiceSubtotal = O15InvoiceSubtotal;
                  n15InvoiceSubtotal = false;
                  AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
                  A16InvoiceTax = O16InvoiceTax;
                  AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
                  A17InvoiceTotal = O17InvoiceTotal;
                  AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
                  GX_FocusControl = edtInvoiceDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert021( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "INVOICEID");
                     AnyError = 1;
                     GX_FocusControl = edtInvoiceID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A15InvoiceSubtotal = O15InvoiceSubtotal;
                     n15InvoiceSubtotal = false;
                     AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
                     A16InvoiceTax = O16InvoiceTax;
                     AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
                     A17InvoiceTotal = O17InvoiceTotal;
                     AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
                     GX_FocusControl = edtInvoiceDate_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert021( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A6InvoiceID != Z6InvoiceID )
         {
            A6InvoiceID = Z6InvoiceID;
            AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "INVOICEID");
            AnyError = 1;
            GX_FocusControl = edtInvoiceID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A15InvoiceSubtotal = O15InvoiceSubtotal;
            n15InvoiceSubtotal = false;
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            A16InvoiceTax = O16InvoiceTax;
            AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
            A17InvoiceTotal = O17InvoiceTotal;
            AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtInvoiceDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency021( )
      {
         if ( IsDlt( ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( h8CustomerID)) )
            {
               A8CustomerID = 0;
               AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
            }
            else
            {
               A9CustomerName = h8CustomerID;
               AssignAttri("", false, "A9CustomerName", A9CustomerName);
               /* Using cursor T000220 */
               pr_default.execute(15, new Object[] {A9CustomerName});
               A8CustomerID = T000220_A8CustomerID[0];
               AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
               A8CustomerID = T000220_A8CustomerID[0];
               AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
               if ( ! ( (pr_default.getStatus(15) == 101) ) )
               {
                  pr_default.readNext(15);
                  if ( ! ( (pr_default.getStatus(15) == 101) ) )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_ambiguousck", new   object[]  {"Customer Name"}), 1, "CUSTOMERID");
                     AnyError = 1;
                     GX_FocusControl = edtCustomerID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
               }
               pr_default.close(15);
            }
         }
         if ( ! IsIns( ) )
         {
            /* Using cursor T00024 */
            pr_default.execute(2, new Object[] {A6InvoiceID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Transaction1"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( DateTimeUtil.ResetTime ( Z7InvoiceDate ) != DateTimeUtil.ResetTime ( T00024_A7InvoiceDate[0] ) ) || ( Z8CustomerID != T00024_A8CustomerID[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z7InvoiceDate ) != DateTimeUtil.ResetTime ( T00024_A7InvoiceDate[0] ) )
               {
                  GXUtil.WriteLog("general.transaction1:[seudo value changed for attri]"+"InvoiceDate");
                  GXUtil.WriteLogRaw("Old: ",Z7InvoiceDate);
                  GXUtil.WriteLogRaw("Current: ",T00024_A7InvoiceDate[0]);
               }
               if ( Z8CustomerID != T00024_A8CustomerID[0] )
               {
                  GXUtil.WriteLog("general.transaction1:[seudo value changed for attri]"+"CustomerID");
                  GXUtil.WriteLogRaw("Old: ",Z8CustomerID);
                  GXUtil.WriteLogRaw("Current: ",T00024_A8CustomerID[0]);
               }
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
                     /* Using cursor T000221 */
                     pr_default.execute(16, new Object[] {A7InvoiceDate, A8CustomerID});
                     A6InvoiceID = T000221_A6InvoiceID[0];
                     AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
                     pr_default.close(16);
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
                              ResetCaption020( ) ;
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
                     /* Using cursor T000222 */
                     pr_default.execute(17, new Object[] {A7InvoiceDate, A8CustomerID, A6InvoiceID});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("Transaction1");
                     if ( (pr_default.getStatus(17) == 103) )
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
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
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
                  AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
                  A16InvoiceTax = O16InvoiceTax;
                  AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
                  A17InvoiceTotal = O17InvoiceTotal;
                  AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
                  ScanStart022( ) ;
                  while ( RcdFound2 != 0 )
                  {
                     getByPrimaryKey022( ) ;
                     Delete022( ) ;
                     ScanNext022( ) ;
                     O15InvoiceSubtotal = A15InvoiceSubtotal;
                     n15InvoiceSubtotal = false;
                     AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
                     O16InvoiceTax = A16InvoiceTax;
                     AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
                     O17InvoiceTotal = A17InvoiceTotal;
                     AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
                  }
                  ScanEnd022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000223 */
                     pr_default.execute(18, new Object[] {A6InvoiceID});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("Transaction1");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
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
            }
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel021( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls021( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "General.Transaction1";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000225 */
            pr_default.execute(19, new Object[] {A6InvoiceID});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A15InvoiceSubtotal = T000225_A15InvoiceSubtotal[0];
               n15InvoiceSubtotal = T000225_n15InvoiceSubtotal[0];
               AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            }
            else
            {
               A15InvoiceSubtotal = 0;
               n15InvoiceSubtotal = false;
               AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            }
            pr_default.close(19);
            A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
            AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
            A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
            AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
            /* Using cursor T000226 */
            pr_default.execute(20, new Object[] {A8CustomerID});
            A9CustomerName = T000226_A9CustomerName[0];
            pr_default.close(20);
         }
      }

      protected void ProcessNestedLevel022( )
      {
         s15InvoiceSubtotal = O15InvoiceSubtotal;
         n15InvoiceSubtotal = false;
         AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         s16InvoiceTax = O16InvoiceTax;
         AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
         s17InvoiceTotal = O17InvoiceTotal;
         AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow022( ) ;
            if ( ( nRcdExists_2 != 0 ) || ( nIsMod_2 != 0 ) )
            {
               standaloneNotModal022( ) ;
               GetKey022( ) ;
               if ( ( nRcdExists_2 == 0 ) && ( nRcdDeleted_2 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert022( ) ;
               }
               else
               {
                  if ( RcdFound2 != 0 )
                  {
                     if ( ( nRcdDeleted_2 != 0 ) && ( nRcdExists_2 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete022( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_2 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update022( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_2 == 0 )
                     {
                        GXCCtl = "PRODUCTID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProductID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O15InvoiceSubtotal = A15InvoiceSubtotal;
               n15InvoiceSubtotal = false;
               AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
               O16InvoiceTax = A16InvoiceTax;
               AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
               O17InvoiceTotal = A17InvoiceTotal;
               AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
            }
            ChangePostValue( edtProductID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductID), 4, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, StringUtil.RTrim( A11ProductName)) ;
            ChangePostValue( edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A12ProductPrice, 8, 2, ".", ""))) ;
            ChangePostValue( edtInvoiceProductQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13InvoiceProductQuantity), 4, 0, ".", ""))) ;
            ChangePostValue( edtInvoiceProductTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A14InvoiceProductTotal, 8, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z10ProductID_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductID), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z11ProductName_"+sGXsfl_53_idx, StringUtil.RTrim( Z11ProductName)) ;
            ChangePostValue( "ZT_"+"Z12ProductPrice_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( Z12ProductPrice, 8, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z13InvoiceProductQuantity_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13InvoiceProductQuantity), 4, 0, ".", ""))) ;
            ChangePostValue( "T14InvoiceProductTotal_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( O14InvoiceProductTotal, 8, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_2), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_2), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_2), 4, 0, ".", ""))) ;
            if ( nIsMod_2 != 0 )
            {
               ChangePostValue( "PRODUCTID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTPRICE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEPRODUCTQUANTITY_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceProductQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEPRODUCTTOTAL_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceProductTotal_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll022( ) ;
         if ( AnyError != 0 )
         {
            O15InvoiceSubtotal = s15InvoiceSubtotal;
            n15InvoiceSubtotal = false;
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            O16InvoiceTax = s16InvoiceTax;
            AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
            O17InvoiceTotal = s17InvoiceTotal;
            AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
         }
         nRcdExists_2 = 0;
         nIsMod_2 = 0;
         nRcdDeleted_2 = 0;
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
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            O16InvoiceTax = s16InvoiceTax;
            AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
            O17InvoiceTotal = s17InvoiceTotal;
            AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
         }
         /* Restore parent mode. */
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(19);
            context.CommitDataStores("general.transaction1",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(19);
            context.RollbackDataStores("general.transaction1",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart021( )
      {
         /* Scan By routine */
         /* Using cursor T000227 */
         pr_default.execute(21);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound1 = 1;
            A6InvoiceID = T000227_A6InvoiceID[0];
            AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext021( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound1 = 1;
            A6InvoiceID = T000227_A6InvoiceID[0];
            AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
         }
      }

      protected void ScanEnd021( )
      {
         pr_default.close(21);
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
         edtInvoiceID_Enabled = 0;
         AssignProp("", false, edtInvoiceID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceID_Enabled), 5, 0), true);
         edtInvoiceDate_Enabled = 0;
         AssignProp("", false, edtInvoiceDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDate_Enabled), 5, 0), true);
         edtCustomerID_Enabled = 0;
         AssignProp("", false, edtCustomerID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCustomerID_Enabled), 5, 0), true);
         edtInvoiceSubtotal_Enabled = 0;
         AssignProp("", false, edtInvoiceSubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceSubtotal_Enabled), 5, 0), true);
         edtInvoiceTax_Enabled = 0;
         AssignProp("", false, edtInvoiceTax_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceTax_Enabled), 5, 0), true);
         edtInvoiceTotal_Enabled = 0;
         AssignProp("", false, edtInvoiceTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceTotal_Enabled), 5, 0), true);
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z11ProductName = T00023_A11ProductName[0];
               Z12ProductPrice = T00023_A12ProductPrice[0];
               Z13InvoiceProductQuantity = T00023_A13InvoiceProductQuantity[0];
            }
            else
            {
               Z11ProductName = A11ProductName;
               Z12ProductPrice = A12ProductPrice;
               Z13InvoiceProductQuantity = A13InvoiceProductQuantity;
            }
         }
         if ( GX_JID == -21 )
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
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProductID_Enabled = 0;
            AssignProp("", false, edtProductID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductID_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            edtProductID_Enabled = 1;
            AssignProp("", false, edtProductID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductID_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T000228 */
         pr_default.execute(22, new Object[] {A6InvoiceID, A10ProductID});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound2 = 1;
            A11ProductName = T000228_A11ProductName[0];
            A12ProductPrice = T000228_A12ProductPrice[0];
            A13InvoiceProductQuantity = T000228_A13InvoiceProductQuantity[0];
            ZM022( -21) ;
         }
         pr_default.close(22);
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
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal+A14InvoiceProductTotal-O14InvoiceProductTotal);
               n15InvoiceSubtotal = false;
               AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal-O14InvoiceProductTotal);
                  n15InvoiceSubtotal = false;
                  AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
               }
            }
         }
         A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
         AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
         A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
         AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal022( ) ;
         nIsDirty_2 = 1;
         A14InvoiceProductTotal = (decimal)(A12ProductPrice*A13InvoiceProductQuantity);
         if ( IsIns( )  )
         {
            nIsDirty_2 = 1;
            A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal+A14InvoiceProductTotal);
            n15InvoiceSubtotal = false;
            AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_2 = 1;
               A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal+A14InvoiceProductTotal-O14InvoiceProductTotal);
               n15InvoiceSubtotal = false;
               AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_2 = 1;
                  A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal-O14InvoiceProductTotal);
                  n15InvoiceSubtotal = false;
                  AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
               }
            }
         }
         nIsDirty_2 = 1;
         A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
         AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
         nIsDirty_2 = 1;
         A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
         AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
         if ( (0==A13InvoiceProductQuantity) )
         {
            GXCCtl = "INVOICEPRODUCTQUANTITY_" + sGXsfl_53_idx;
            GX_msglist.addItem("The Product Quantity cannot be empty", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoiceProductQuantity_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         /* Using cursor T000229 */
         pr_default.execute(23, new Object[] {A6InvoiceID, A10ProductID});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(23);
      }

      protected void getByPrimaryKey022( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A6InvoiceID, A10ProductID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 21) ;
            RcdFound2 = 1;
            InitializeNonKey022( ) ;
            A10ProductID = T00023_A10ProductID[0];
            A11ProductName = T00023_A11ProductName[0];
            A12ProductPrice = T00023_A12ProductPrice[0];
            A13InvoiceProductQuantity = T00023_A13InvoiceProductQuantity[0];
            Z6InvoiceID = A6InvoiceID;
            Z10ProductID = A10ProductID;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal022( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
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
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A6InvoiceID, A10ProductID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Transaction1Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z11ProductName, T00022_A11ProductName[0]) != 0 ) || ( Z12ProductPrice != T00022_A12ProductPrice[0] ) || ( Z13InvoiceProductQuantity != T00022_A13InvoiceProductQuantity[0] ) )
            {
               if ( StringUtil.StrCmp(Z11ProductName, T00022_A11ProductName[0]) != 0 )
               {
                  GXUtil.WriteLog("general.transaction1:[seudo value changed for attri]"+"ProductName");
                  GXUtil.WriteLogRaw("Old: ",Z11ProductName);
                  GXUtil.WriteLogRaw("Current: ",T00022_A11ProductName[0]);
               }
               if ( Z12ProductPrice != T00022_A12ProductPrice[0] )
               {
                  GXUtil.WriteLog("general.transaction1:[seudo value changed for attri]"+"ProductPrice");
                  GXUtil.WriteLogRaw("Old: ",Z12ProductPrice);
                  GXUtil.WriteLogRaw("Current: ",T00022_A12ProductPrice[0]);
               }
               if ( Z13InvoiceProductQuantity != T00022_A13InvoiceProductQuantity[0] )
               {
                  GXUtil.WriteLog("general.transaction1:[seudo value changed for attri]"+"InvoiceProductQuantity");
                  GXUtil.WriteLogRaw("Old: ",Z13InvoiceProductQuantity);
                  GXUtil.WriteLogRaw("Current: ",T00022_A13InvoiceProductQuantity[0]);
               }
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
                     /* Using cursor T000230 */
                     pr_default.execute(24, new Object[] {A6InvoiceID, A10ProductID, A11ProductName, A12ProductPrice, A13InvoiceProductQuantity});
                     pr_default.close(24);
                     pr_default.SmartCacheProvider.SetUpdated("Transaction1Product");
                     if ( (pr_default.getStatus(24) == 1) )
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
         if ( ( nIsMod_2 != 0 ) || ( nIsDirty_2 != 0 ) )
         {
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
                        /* Using cursor T000231 */
                        pr_default.execute(25, new Object[] {A11ProductName, A12ProductPrice, A13InvoiceProductQuantity, A6InvoiceID, A10ProductID});
                        pr_default.close(25);
                        pr_default.SmartCacheProvider.SetUpdated("Transaction1Product");
                        if ( (pr_default.getStatus(25) == 103) )
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
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void Delete022( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
                  /* Using cursor T000232 */
                  pr_default.execute(26, new Object[] {A6InvoiceID, A10ProductID});
                  pr_default.close(26);
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
               AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal+A14InvoiceProductTotal-O14InvoiceProductTotal);
                  n15InvoiceSubtotal = false;
                  AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A15InvoiceSubtotal = (decimal)(O15InvoiceSubtotal-O14InvoiceProductTotal);
                     n15InvoiceSubtotal = false;
                     AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
                  }
               }
            }
            A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
            AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
            A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
            AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
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

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000233 */
         pr_default.execute(27, new Object[] {A6InvoiceID});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound2 = 1;
            A10ProductID = T000233_A10ProductID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound2 = 1;
            A10ProductID = T000233_A10ProductID[0];
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(27);
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
         edtProductID_Enabled = 0;
         AssignProp("", false, edtProductID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductID_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtProductPrice_Enabled = 0;
         AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtInvoiceProductQuantity_Enabled = 0;
         AssignProp("", false, edtInvoiceProductQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceProductQuantity_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtInvoiceProductTotal_Enabled = 0;
         AssignProp("", false, edtInvoiceProductTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceProductTotal_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void send_integrity_lvl_hashes021( )
      {
      }

      protected void SubsflControlProps_532( )
      {
         edtProductID_Internalname = "PRODUCTID_"+sGXsfl_53_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_53_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_53_idx;
         edtInvoiceProductQuantity_Internalname = "INVOICEPRODUCTQUANTITY_"+sGXsfl_53_idx;
         edtInvoiceProductTotal_Internalname = "INVOICEPRODUCTTOTAL_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_532( )
      {
         edtProductID_Internalname = "PRODUCTID_"+sGXsfl_53_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_53_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_53_fel_idx;
         edtInvoiceProductQuantity_Internalname = "INVOICEPRODUCTQUANTITY_"+sGXsfl_53_fel_idx;
         edtInvoiceProductTotal_Internalname = "INVOICEPRODUCTTOTAL_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow022( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_532( ) ;
         SendRow022( ) ;
      }

      protected void SendRow022( )
      {
         Gridtransaction1_productRow = GXWebRow.GetNew(context);
         if ( subGridtransaction1_product_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridtransaction1_product_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridtransaction1_product_Class, "") != 0 )
            {
               subGridtransaction1_product_Linesclass = subGridtransaction1_product_Class+"Odd";
            }
         }
         else if ( subGridtransaction1_product_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridtransaction1_product_Backstyle = 0;
            subGridtransaction1_product_Backcolor = subGridtransaction1_product_Allbackcolor;
            if ( StringUtil.StrCmp(subGridtransaction1_product_Class, "") != 0 )
            {
               subGridtransaction1_product_Linesclass = subGridtransaction1_product_Class+"Uniform";
            }
         }
         else if ( subGridtransaction1_product_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridtransaction1_product_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridtransaction1_product_Class, "") != 0 )
            {
               subGridtransaction1_product_Linesclass = subGridtransaction1_product_Class+"Odd";
            }
            subGridtransaction1_product_Backcolor = (int)(0x0);
         }
         else if ( subGridtransaction1_product_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridtransaction1_product_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridtransaction1_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtransaction1_product_Class, "") != 0 )
               {
                  subGridtransaction1_product_Linesclass = subGridtransaction1_product_Class+"Even";
               }
            }
            else
            {
               subGridtransaction1_product_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtransaction1_product_Class, "") != 0 )
               {
                  subGridtransaction1_product_Linesclass = subGridtransaction1_product_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtransaction1_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductID), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10ProductID), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductID_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtransaction1_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,StringUtil.RTrim( A11ProductName),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtransaction1_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A12ProductPrice, 8, 2, ".", "")),StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A12ProductPrice, "ZZZZ9.99") : context.localUtil.Format( A12ProductPrice, "ZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductPrice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtransaction1_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceProductQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13InvoiceProductQuantity), 4, 0, ".", "")),StringUtil.LTrim( ((edtInvoiceProductQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A13InvoiceProductQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A13InvoiceProductQuantity), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceProductQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoiceProductQuantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtransaction1_productRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceProductTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A14InvoiceProductTotal, 8, 2, ".", "")),StringUtil.LTrim( ((edtInvoiceProductTotal_Enabled!=0) ? context.localUtil.Format( A14InvoiceProductTotal, "ZZZZ9.99") : context.localUtil.Format( A14InvoiceProductTotal, "ZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,58);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceProductTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoiceProductTotal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         ajax_sending_grid_row(Gridtransaction1_productRow);
         send_integrity_lvl_hashes022( ) ;
         GXCCtl = "Z10ProductID_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ProductID), 4, 0, ".", "")));
         GXCCtl = "Z11ProductName_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z11ProductName));
         GXCCtl = "Z12ProductPrice_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z12ProductPrice, 8, 2, ".", "")));
         GXCCtl = "Z13InvoiceProductQuantity_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13InvoiceProductQuantity), 4, 0, ".", "")));
         GXCCtl = "O14InvoiceProductTotal_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( O14InvoiceProductTotal, 8, 2, ".", "")));
         GXCCtl = "nRcdDeleted_2_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_2), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_2_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_2), 4, 0, ".", "")));
         GXCCtl = "nIsMod_2_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_2), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_53_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vINVOICEID_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7InvoiceID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTPRICE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEPRODUCTQUANTITY_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceProductQuantity_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEPRODUCTTOTAL_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceProductTotal_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridtransaction1_productContainer.AddRow(Gridtransaction1_productRow);
      }

      protected void ReadRow022( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_532( ) ;
         edtProductID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductPrice_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTPRICE_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtInvoiceProductQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPRODUCTQUANTITY_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtInvoiceProductTotal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPRODUCTTOTAL_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductID_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductID_Internalname;
            wbErr = true;
            A10ProductID = 0;
         }
         else
         {
            A10ProductID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductID_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         A11ProductName = cgiGet( edtProductName_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",") > 99999.99m ) ) )
         {
            GXCCtl = "PRODUCTPRICE_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductPrice_Internalname;
            wbErr = true;
            A12ProductPrice = 0;
         }
         else
         {
            A12ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvoiceProductQuantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoiceProductQuantity_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "INVOICEPRODUCTQUANTITY_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoiceProductQuantity_Internalname;
            wbErr = true;
            A13InvoiceProductQuantity = 0;
         }
         else
         {
            A13InvoiceProductQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceProductQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         A14InvoiceProductTotal = context.localUtil.CToN( cgiGet( edtInvoiceProductTotal_Internalname), ".", ",");
         GXCCtl = "Z10ProductID_" + sGXsfl_53_idx;
         Z10ProductID = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z11ProductName_" + sGXsfl_53_idx;
         Z11ProductName = cgiGet( GXCCtl);
         GXCCtl = "Z12ProductPrice_" + sGXsfl_53_idx;
         Z12ProductPrice = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z13InvoiceProductQuantity_" + sGXsfl_53_idx;
         Z13InvoiceProductQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "O14InvoiceProductTotal_" + sGXsfl_53_idx;
         O14InvoiceProductTotal = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "nRcdDeleted_2_" + sGXsfl_53_idx;
         nRcdDeleted_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_2_" + sGXsfl_53_idx;
         nRcdExists_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_2_" + sGXsfl_53_idx;
         nIsMod_2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtProductID_Enabled = edtProductID_Enabled;
      }

      protected void ConfirmValues020( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_532( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_532( ) ;
            ChangePostValue( "Z10ProductID_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z10ProductID_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z10ProductID_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z11ProductName_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z11ProductName_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z11ProductName_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z12ProductPrice_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z12ProductPrice_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z12ProductPrice_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z13InvoiceProductQuantity_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z13InvoiceProductQuantity_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z13InvoiceProductQuantity_"+sGXsfl_53_idx) ;
         }
         ChangePostValue( "O14InvoiceProductTotal", cgiGet( "T14InvoiceProductTotal")) ;
         DeletePostValue( "T14InvoiceProductTotal") ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 239440), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("general.transaction1.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvoiceID,4,0))}, new string[] {"Gx_mode","InvoiceID"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Transaction1");
         forbiddenHiddens.Add("InvoiceID", context.localUtil.Format( (decimal)(A6InvoiceID), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("general\\transaction1:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z6InvoiceID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6InvoiceID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z7InvoiceDate", context.localUtil.DToC( Z7InvoiceDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z8CustomerID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8CustomerID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O15InvoiceSubtotal", StringUtil.LTrim( StringUtil.NToC( O15InvoiceSubtotal, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_53_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N8CustomerID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CustomerID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vINVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7InvoiceID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINVOICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvoiceID), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_CustomerID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXHCCUSTOMERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CustomerID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CUSTOMERNAME", StringUtil.RTrim( A9CustomerName));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("general.transaction1.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvoiceID,4,0))}, new string[] {"Gx_mode","InvoiceID"})  ;
      }

      public override string GetPgmname( )
      {
         return "General.Transaction1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Transaction1" ;
      }

      protected void InitializeNonKey021( )
      {
         h8CustomerID = "";
         A16InvoiceTax = 0;
         AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrimStr( A16InvoiceTax, 8, 2));
         A17InvoiceTotal = 0;
         AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrimStr( A17InvoiceTotal, 8, 2));
         A15InvoiceSubtotal = 0;
         n15InvoiceSubtotal = false;
         AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         A7InvoiceDate = Gx_date;
         AssignAttri("", false, "A7InvoiceDate", context.localUtil.Format(A7InvoiceDate, "99/99/99"));
         O15InvoiceSubtotal = A15InvoiceSubtotal;
         n15InvoiceSubtotal = false;
         AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrimStr( A15InvoiceSubtotal, 8, 2));
         Z7InvoiceDate = DateTime.MinValue;
         Z8CustomerID = 0;
      }

      protected void InitAll021( )
      {
         A6InvoiceID = 0;
         AssignAttri("", false, "A6InvoiceID", StringUtil.LTrimStr( (decimal)(A6InvoiceID), 4, 0));
         InitializeNonKey021( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A7InvoiceDate = i7InvoiceDate;
         AssignAttri("", false, "A7InvoiceDate", context.localUtil.Format(A7InvoiceDate, "99/99/99"));
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

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024102819195511", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("general/transaction1.js", "?2024102819195511", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties2( )
      {
         edtProductID_Enabled = defedtProductID_Enabled;
         AssignProp("", false, edtProductID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductID_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void StartGridControl53( )
      {
         Gridtransaction1_productContainer.AddObjectProperty("GridName", "Gridtransaction1_product");
         Gridtransaction1_productContainer.AddObjectProperty("Header", subGridtransaction1_product_Header);
         Gridtransaction1_productContainer.AddObjectProperty("Class", "Grid");
         Gridtransaction1_productContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridtransaction1_productContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridtransaction1_productContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtransaction1_product_Backcolorstyle), 1, 0, ".", "")));
         Gridtransaction1_productContainer.AddObjectProperty("CmpContext", "");
         Gridtransaction1_productContainer.AddObjectProperty("InMasterPage", "false");
         Gridtransaction1_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtransaction1_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ProductID), 4, 0, ".", ""))));
         Gridtransaction1_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductID_Enabled), 5, 0, ".", "")));
         Gridtransaction1_productContainer.AddColumnProperties(Gridtransaction1_productColumn);
         Gridtransaction1_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtransaction1_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A11ProductName)));
         Gridtransaction1_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         Gridtransaction1_productContainer.AddColumnProperties(Gridtransaction1_productColumn);
         Gridtransaction1_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtransaction1_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A12ProductPrice, 8, 2, ".", ""))));
         Gridtransaction1_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductPrice_Enabled), 5, 0, ".", "")));
         Gridtransaction1_productContainer.AddColumnProperties(Gridtransaction1_productColumn);
         Gridtransaction1_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtransaction1_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A13InvoiceProductQuantity), 4, 0, ".", ""))));
         Gridtransaction1_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceProductQuantity_Enabled), 5, 0, ".", "")));
         Gridtransaction1_productContainer.AddColumnProperties(Gridtransaction1_productColumn);
         Gridtransaction1_productColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtransaction1_productColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A14InvoiceProductTotal, 8, 2, ".", ""))));
         Gridtransaction1_productColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceProductTotal_Enabled), 5, 0, ".", "")));
         Gridtransaction1_productContainer.AddColumnProperties(Gridtransaction1_productColumn);
         Gridtransaction1_productContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtransaction1_product_Selectedindex), 4, 0, ".", "")));
         Gridtransaction1_productContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtransaction1_product_Allowselection), 1, 0, ".", "")));
         Gridtransaction1_productContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtransaction1_product_Selectioncolor), 9, 0, ".", "")));
         Gridtransaction1_productContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtransaction1_product_Allowhovering), 1, 0, ".", "")));
         Gridtransaction1_productContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtransaction1_product_Hoveringcolor), 9, 0, ".", "")));
         Gridtransaction1_productContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtransaction1_product_Allowcollapsing), 1, 0, ".", "")));
         Gridtransaction1_productContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtransaction1_product_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtInvoiceID_Internalname = "INVOICEID";
         edtInvoiceDate_Internalname = "INVOICEDATE";
         edtCustomerID_Internalname = "CUSTOMERID";
         lblTitleproduct_Internalname = "TITLEPRODUCT";
         edtProductID_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         edtInvoiceProductQuantity_Internalname = "INVOICEPRODUCTQUANTITY";
         edtInvoiceProductTotal_Internalname = "INVOICEPRODUCTTOTAL";
         divProducttable_Internalname = "PRODUCTTABLE";
         edtInvoiceSubtotal_Internalname = "INVOICESUBTOTAL";
         edtInvoiceTax_Internalname = "INVOICETAX";
         edtInvoiceTotal_Internalname = "INVOICETOTAL";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridtransaction1_product_Internalname = "GRIDTRANSACTION1_PRODUCT";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("MiPrimeraDemo", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridtransaction1_product_Allowcollapsing = 0;
         subGridtransaction1_product_Allowselection = 0;
         subGridtransaction1_product_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Transaction1";
         edtInvoiceProductTotal_Jsonclick = "";
         edtInvoiceProductQuantity_Jsonclick = "";
         edtProductPrice_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductID_Jsonclick = "";
         subGridtransaction1_product_Class = "Grid";
         subGridtransaction1_product_Backcolorstyle = 0;
         edtInvoiceProductTotal_Enabled = 0;
         edtInvoiceProductQuantity_Enabled = 1;
         edtProductPrice_Enabled = 1;
         edtProductName_Enabled = 1;
         edtProductID_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtInvoiceTotal_Jsonclick = "";
         edtInvoiceTotal_Enabled = 0;
         edtInvoiceTax_Jsonclick = "";
         edtInvoiceTax_Enabled = 0;
         edtInvoiceSubtotal_Jsonclick = "";
         edtInvoiceSubtotal_Enabled = 0;
         edtCustomerID_Jsonclick = "";
         edtCustomerID_Enabled = 1;
         edtInvoiceDate_Jsonclick = "";
         edtInvoiceDate_Enabled = 1;
         edtInvoiceID_Jsonclick = "";
         edtInvoiceID_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXSGACUSTOMERID020( string A9CustomerName )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXSGACUSTOMERID_data020( A9CustomerName) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXSGACUSTOMERID_data020( string A9CustomerName )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         l9CustomerName = StringUtil.PadR( StringUtil.RTrim( A9CustomerName), 20, "%");
         /* Using cursor T000234 */
         pr_default.execute(28, new Object[] {l9CustomerName});
         while ( (pr_default.getStatus(28) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.RTrim( T000234_A9CustomerName[0]));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( T000234_A9CustomerName[0]));
            pr_default.readNext(28);
         }
         pr_default.close(28);
      }

      protected void GXHCACUSTOMERID021( string A9CustomerName )
      {
         /* Using cursor T000235 */
         pr_default.execute(29, new Object[] {A9CustomerName});
         gxhchits = 0;
         while ( (pr_default.getStatus(29) != 101) )
         {
            gxhchits = (short)(gxhchits+1);
            if ( gxhchits > 1 )
            {
               if (true) break;
            }
            A9CustomerName = T000235_A9CustomerName[0];
            A8CustomerID = T000235_A8CustomerID[0];
            AssignAttri("", false, "A8CustomerID", StringUtil.LTrimStr( (decimal)(A8CustomerID), 4, 0));
            pr_default.readNext(29);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CustomerID), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( gxhchits > 1 )
         {
            AddString( ",") ;
            AddString( "\"ambiguousck\"") ;
         }
         if ( gxhchits == 0 )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(29);
      }

      protected void gxnrGridtransaction1_product_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_532( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal022( ) ;
            standaloneModal022( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow022( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_532( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridtransaction1_productContainer)) ;
         /* End function gxnrGridtransaction1_product_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
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

      public void Valid_Invoiceid( )
      {
         n15InvoiceSubtotal = false;
         /* Using cursor T000237 */
         pr_default.execute(30, new Object[] {A6InvoiceID});
         if ( (pr_default.getStatus(30) != 101) )
         {
            A15InvoiceSubtotal = T000237_A15InvoiceSubtotal[0];
            n15InvoiceSubtotal = T000237_n15InvoiceSubtotal[0];
         }
         else
         {
            A15InvoiceSubtotal = 0;
            n15InvoiceSubtotal = false;
         }
         pr_default.close(30);
         A16InvoiceTax = (decimal)(A15InvoiceSubtotal*0.11m);
         A17InvoiceTotal = (decimal)(A15InvoiceSubtotal+A16InvoiceTax);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A15InvoiceSubtotal", StringUtil.LTrim( StringUtil.NToC( A15InvoiceSubtotal, 8, 2, ".", "")));
         AssignAttri("", false, "A16InvoiceTax", StringUtil.LTrim( StringUtil.NToC( A16InvoiceTax, 8, 2, ".", "")));
         AssignAttri("", false, "A17InvoiceTotal", StringUtil.LTrim( StringUtil.NToC( A17InvoiceTotal, 8, 2, ".", "")));
      }

      public void Valid_Customerid( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( h8CustomerID)) )
         {
            A8CustomerID = 0;
         }
         else
         {
            A9CustomerName = h8CustomerID;
            /* Using cursor T000238 */
            pr_default.execute(31, new Object[] {A9CustomerName});
            A8CustomerID = T000238_A8CustomerID[0];
            A8CustomerID = T000238_A8CustomerID[0];
            if ( ! ( (pr_default.getStatus(31) == 101) ) )
            {
               pr_default.readNext(31);
               if ( ! ( (pr_default.getStatus(31) == 101) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_ambiguousck", new   object[]  {"Customer Name"}), 1, "CUSTOMERID");
                  AnyError = 1;
                  GX_FocusControl = edtCustomerID_Internalname;
               }
            }
            else
            {
            }
            pr_default.close(31);
         }
         /* Using cursor T000239 */
         pr_default.execute(32, new Object[] {A8CustomerID});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
            GX_FocusControl = edtCustomerID_Internalname;
         }
         A9CustomerName = T000239_A9CustomerName[0];
         pr_default.close(32);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8CustomerID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CustomerID), 4, 0, ".", "")));
         AssignAttri("", false, "A9CustomerName", StringUtil.RTrim( A9CustomerName));
         AssignAttri("", false, "h8CustomerID", StringUtil.RTrim( h8CustomerID));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7InvoiceID","fld":"vINVOICEID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7InvoiceID","fld":"vINVOICEID","pic":"ZZZ9","hsh":true},{"av":"A6InvoiceID","fld":"INVOICEID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12022","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_INVOICEID","""{"handler":"Valid_Invoiceid","iparms":[{"av":"A6InvoiceID","fld":"INVOICEID","pic":"ZZZ9"},{"av":"A15InvoiceSubtotal","fld":"INVOICESUBTOTAL","pic":"ZZZZ9.99"},{"av":"A16InvoiceTax","fld":"INVOICETAX","pic":"ZZZZ9.99"},{"av":"A17InvoiceTotal","fld":"INVOICETOTAL","pic":"ZZZZ9.99"}]""");
         setEventMetadata("VALID_INVOICEID",""","oparms":[{"av":"A15InvoiceSubtotal","fld":"INVOICESUBTOTAL","pic":"ZZZZ9.99"},{"av":"A16InvoiceTax","fld":"INVOICETAX","pic":"ZZZZ9.99"},{"av":"A17InvoiceTotal","fld":"INVOICETOTAL","pic":"ZZZZ9.99"}]}""");
         setEventMetadata("VALID_INVOICEDATE","""{"handler":"Valid_Invoicedate","iparms":[]}""");
         setEventMetadata("VALID_CUSTOMERID","""{"handler":"Valid_Customerid","iparms":[{"av":"h8CustomerID"},{"av":"A8CustomerID","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"A9CustomerName","fld":"CUSTOMERNAME"}]""");
         setEventMetadata("VALID_CUSTOMERID",""","oparms":[{"av":"A8CustomerID","fld":"CUSTOMERID","pic":"ZZZ9"},{"av":"A9CustomerName","fld":"CUSTOMERNAME"},{"av":"h8CustomerID"}]}""");
         setEventMetadata("VALID_INVOICESUBTOTAL","""{"handler":"Valid_Invoicesubtotal","iparms":[]}""");
         setEventMetadata("VALID_INVOICETAX","""{"handler":"Valid_Invoicetax","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTID","""{"handler":"Valid_Productid","iparms":[]}""");
         setEventMetadata("VALID_PRODUCTPRICE","""{"handler":"Valid_Productprice","iparms":[]}""");
         setEventMetadata("VALID_INVOICEPRODUCTQUANTITY","""{"handler":"Valid_Invoiceproductquantity","iparms":[]}""");
         setEventMetadata("VALID_INVOICEPRODUCTTOTAL","""{"handler":"Valid_Invoiceproducttotal","iparms":[]}""");
         return  ;
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
         pr_default.close(32);
         pr_default.close(20);
         pr_default.close(30);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z7InvoiceDate = DateTime.MinValue;
         Z11ProductName = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A9CustomerName = "";
         h8CustomerID = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A7InvoiceDate = DateTime.MinValue;
         lblTitleproduct_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridtransaction1_productContainer = new GXWebGrid( context);
         sMode2 = "";
         sStyleString = "";
         Gx_date = DateTime.MinValue;
         AV15Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         A11ProductName = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z9CustomerName = "";
         T00029_A9CustomerName = new string[] {""} ;
         T00029_A8CustomerID = new short[1] ;
         T00028_A15InvoiceSubtotal = new decimal[1] ;
         T00028_n15InvoiceSubtotal = new bool[] {false} ;
         T00026_A9CustomerName = new string[] {""} ;
         T000211_A6InvoiceID = new short[1] ;
         T000211_A7InvoiceDate = new DateTime[] {DateTime.MinValue} ;
         T000211_A9CustomerName = new string[] {""} ;
         T000211_A8CustomerID = new short[1] ;
         T000211_A15InvoiceSubtotal = new decimal[1] ;
         T000211_n15InvoiceSubtotal = new bool[] {false} ;
         T000212_A9CustomerName = new string[] {""} ;
         T000212_A8CustomerID = new short[1] ;
         T000213_A9CustomerName = new string[] {""} ;
         T000213_A8CustomerID = new short[1] ;
         T000215_A15InvoiceSubtotal = new decimal[1] ;
         T000215_n15InvoiceSubtotal = new bool[] {false} ;
         T000216_A9CustomerName = new string[] {""} ;
         T000217_A6InvoiceID = new short[1] ;
         T00025_A6InvoiceID = new short[1] ;
         T00025_A7InvoiceDate = new DateTime[] {DateTime.MinValue} ;
         T00025_A8CustomerID = new short[1] ;
         T000218_A6InvoiceID = new short[1] ;
         T000219_A6InvoiceID = new short[1] ;
         T000220_A9CustomerName = new string[] {""} ;
         T000220_A8CustomerID = new short[1] ;
         T00024_A6InvoiceID = new short[1] ;
         T00024_A7InvoiceDate = new DateTime[] {DateTime.MinValue} ;
         T00024_A8CustomerID = new short[1] ;
         T000221_A6InvoiceID = new short[1] ;
         T000225_A15InvoiceSubtotal = new decimal[1] ;
         T000225_n15InvoiceSubtotal = new bool[] {false} ;
         T000226_A9CustomerName = new string[] {""} ;
         T000227_A6InvoiceID = new short[1] ;
         T000228_A6InvoiceID = new short[1] ;
         T000228_A10ProductID = new short[1] ;
         T000228_A11ProductName = new string[] {""} ;
         T000228_A12ProductPrice = new decimal[1] ;
         T000228_A13InvoiceProductQuantity = new short[1] ;
         T000229_A6InvoiceID = new short[1] ;
         T000229_A10ProductID = new short[1] ;
         T00023_A6InvoiceID = new short[1] ;
         T00023_A10ProductID = new short[1] ;
         T00023_A11ProductName = new string[] {""} ;
         T00023_A12ProductPrice = new decimal[1] ;
         T00023_A13InvoiceProductQuantity = new short[1] ;
         T00022_A6InvoiceID = new short[1] ;
         T00022_A10ProductID = new short[1] ;
         T00022_A11ProductName = new string[] {""} ;
         T00022_A12ProductPrice = new decimal[1] ;
         T00022_A13InvoiceProductQuantity = new short[1] ;
         T000233_A6InvoiceID = new short[1] ;
         T000233_A10ProductID = new short[1] ;
         Gridtransaction1_productRow = new GXWebRow();
         subGridtransaction1_product_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i7InvoiceDate = DateTime.MinValue;
         Gridtransaction1_productColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         l9CustomerName = "";
         T000234_A9CustomerName = new string[] {""} ;
         T000235_A9CustomerName = new string[] {""} ;
         T000235_A8CustomerID = new short[1] ;
         T000237_A15InvoiceSubtotal = new decimal[1] ;
         T000237_n15InvoiceSubtotal = new bool[] {false} ;
         T000238_A9CustomerName = new string[] {""} ;
         T000238_A8CustomerID = new short[1] ;
         T000239_A9CustomerName = new string[] {""} ;
         Zh8CustomerID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.general.transaction1__default(),
            new Object[][] {
                new Object[] {
               T00022_A6InvoiceID, T00022_A10ProductID, T00022_A11ProductName, T00022_A12ProductPrice, T00022_A13InvoiceProductQuantity
               }
               , new Object[] {
               T00023_A6InvoiceID, T00023_A10ProductID, T00023_A11ProductName, T00023_A12ProductPrice, T00023_A13InvoiceProductQuantity
               }
               , new Object[] {
               T00024_A6InvoiceID, T00024_A7InvoiceDate, T00024_A8CustomerID
               }
               , new Object[] {
               T00025_A6InvoiceID, T00025_A7InvoiceDate, T00025_A8CustomerID
               }
               , new Object[] {
               T00026_A9CustomerName
               }
               , new Object[] {
               T00028_A15InvoiceSubtotal, T00028_n15InvoiceSubtotal
               }
               , new Object[] {
               T00029_A9CustomerName, T00029_A8CustomerID
               }
               , new Object[] {
               T000211_A6InvoiceID, T000211_A7InvoiceDate, T000211_A9CustomerName, T000211_A8CustomerID, T000211_A15InvoiceSubtotal, T000211_n15InvoiceSubtotal
               }
               , new Object[] {
               T000212_A9CustomerName, T000212_A8CustomerID
               }
               , new Object[] {
               T000213_A9CustomerName, T000213_A8CustomerID
               }
               , new Object[] {
               T000215_A15InvoiceSubtotal, T000215_n15InvoiceSubtotal
               }
               , new Object[] {
               T000216_A9CustomerName
               }
               , new Object[] {
               T000217_A6InvoiceID
               }
               , new Object[] {
               T000218_A6InvoiceID
               }
               , new Object[] {
               T000219_A6InvoiceID
               }
               , new Object[] {
               T000220_A9CustomerName, T000220_A8CustomerID
               }
               , new Object[] {
               T000221_A6InvoiceID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000225_A15InvoiceSubtotal, T000225_n15InvoiceSubtotal
               }
               , new Object[] {
               T000226_A9CustomerName
               }
               , new Object[] {
               T000227_A6InvoiceID
               }
               , new Object[] {
               T000228_A6InvoiceID, T000228_A10ProductID, T000228_A11ProductName, T000228_A12ProductPrice, T000228_A13InvoiceProductQuantity
               }
               , new Object[] {
               T000229_A6InvoiceID, T000229_A10ProductID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000233_A6InvoiceID, T000233_A10ProductID
               }
               , new Object[] {
               T000234_A9CustomerName
               }
               , new Object[] {
               T000235_A9CustomerName, T000235_A8CustomerID
               }
               , new Object[] {
               T000237_A15InvoiceSubtotal, T000237_n15InvoiceSubtotal
               }
               , new Object[] {
               T000238_A9CustomerName, T000238_A8CustomerID
               }
               , new Object[] {
               T000239_A9CustomerName
               }
            }
         );
         AV15Pgmname = "General.Transaction1";
         Z7InvoiceDate = DateTime.MinValue;
         A7InvoiceDate = DateTime.MinValue;
         i7InvoiceDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short wcpOAV7InvoiceID ;
      private short Z6InvoiceID ;
      private short Z8CustomerID ;
      private short N8CustomerID ;
      private short Z10ProductID ;
      private short Z13InvoiceProductQuantity ;
      private short nRcdDeleted_2 ;
      private short nRcdExists_2 ;
      private short nIsMod_2 ;
      private short GxWebError ;
      private short A6InvoiceID ;
      private short A8CustomerID ;
      private short AV7InvoiceID ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount2 ;
      private short RcdFound2 ;
      private short nBlankRcdUsr2 ;
      private short AV11Insert_CustomerID ;
      private short Gx_BScreen ;
      private short RcdFound1 ;
      private short A10ProductID ;
      private short A13InvoiceProductQuantity ;
      private short nIsDirty_2 ;
      private short subGridtransaction1_product_Backcolorstyle ;
      private short subGridtransaction1_product_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridtransaction1_product_Allowselection ;
      private short subGridtransaction1_product_Allowhovering ;
      private short subGridtransaction1_product_Allowcollapsing ;
      private short subGridtransaction1_product_Collapsed ;
      private short gxhchits ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtInvoiceID_Enabled ;
      private int edtInvoiceDate_Enabled ;
      private int edtCustomerID_Enabled ;
      private int edtInvoiceSubtotal_Enabled ;
      private int edtInvoiceTax_Enabled ;
      private int edtInvoiceTotal_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProductID_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductPrice_Enabled ;
      private int edtInvoiceProductQuantity_Enabled ;
      private int edtInvoiceProductTotal_Enabled ;
      private int fRowAdded ;
      private int AV16GXV1 ;
      private int subGridtransaction1_product_Backcolor ;
      private int subGridtransaction1_product_Allbackcolor ;
      private int defedtProductID_Enabled ;
      private int idxLst ;
      private int subGridtransaction1_product_Selectedindex ;
      private int subGridtransaction1_product_Selectioncolor ;
      private int subGridtransaction1_product_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long GRIDTRANSACTION1_PRODUCT_nFirstRecordOnPage ;
      private decimal O15InvoiceSubtotal ;
      private decimal Z12ProductPrice ;
      private decimal O14InvoiceProductTotal ;
      private decimal A15InvoiceSubtotal ;
      private decimal A16InvoiceTax ;
      private decimal A17InvoiceTotal ;
      private decimal B15InvoiceSubtotal ;
      private decimal A12ProductPrice ;
      private decimal A14InvoiceProductTotal ;
      private decimal s15InvoiceSubtotal ;
      private decimal s16InvoiceTax ;
      private decimal O16InvoiceTax ;
      private decimal s17InvoiceTotal ;
      private decimal O17InvoiceTotal ;
      private decimal T14InvoiceProductTotal ;
      private decimal Z15InvoiceSubtotal ;
      private decimal Z16InvoiceTax ;
      private decimal Z17InvoiceTotal ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z11ProductName ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A9CustomerName ;
      private string h8CustomerID ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtInvoiceDate_Internalname ;
      private string sGXsfl_53_idx="0001" ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtInvoiceID_Internalname ;
      private string edtInvoiceID_Jsonclick ;
      private string edtInvoiceDate_Jsonclick ;
      private string edtCustomerID_Internalname ;
      private string edtCustomerID_Jsonclick ;
      private string divProducttable_Internalname ;
      private string lblTitleproduct_Internalname ;
      private string lblTitleproduct_Jsonclick ;
      private string edtInvoiceSubtotal_Internalname ;
      private string edtInvoiceSubtotal_Jsonclick ;
      private string edtInvoiceTax_Internalname ;
      private string edtInvoiceTax_Jsonclick ;
      private string edtInvoiceTotal_Internalname ;
      private string edtInvoiceTotal_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode2 ;
      private string edtProductID_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductPrice_Internalname ;
      private string edtInvoiceProductQuantity_Internalname ;
      private string edtInvoiceProductTotal_Internalname ;
      private string sStyleString ;
      private string subGridtransaction1_product_Internalname ;
      private string AV15Pgmname ;
      private string hsh ;
      private string sMode1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXCCtl ;
      private string A11ProductName ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z9CustomerName ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string subGridtransaction1_product_Class ;
      private string subGridtransaction1_product_Linesclass ;
      private string ROClassString ;
      private string edtProductID_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtProductPrice_Jsonclick ;
      private string edtInvoiceProductQuantity_Jsonclick ;
      private string edtInvoiceProductTotal_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridtransaction1_product_Header ;
      private string gxwrpcisep ;
      private string l9CustomerName ;
      private string Zh8CustomerID ;
      private DateTime Z7InvoiceDate ;
      private DateTime A7InvoiceDate ;
      private DateTime Gx_date ;
      private DateTime i7InvoiceDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n15InvoiceSubtotal ;
      private bool bGXsfl_53_Refreshing=false ;
      private bool returnInSub ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridtransaction1_productContainer ;
      private GXWebRow Gridtransaction1_productRow ;
      private GXWebColumn Gridtransaction1_productColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00029_A9CustomerName ;
      private short[] T00029_A8CustomerID ;
      private decimal[] T00028_A15InvoiceSubtotal ;
      private bool[] T00028_n15InvoiceSubtotal ;
      private string[] T00026_A9CustomerName ;
      private short[] T000211_A6InvoiceID ;
      private DateTime[] T000211_A7InvoiceDate ;
      private string[] T000211_A9CustomerName ;
      private short[] T000211_A8CustomerID ;
      private decimal[] T000211_A15InvoiceSubtotal ;
      private bool[] T000211_n15InvoiceSubtotal ;
      private string[] T000212_A9CustomerName ;
      private short[] T000212_A8CustomerID ;
      private string[] T000213_A9CustomerName ;
      private short[] T000213_A8CustomerID ;
      private decimal[] T000215_A15InvoiceSubtotal ;
      private bool[] T000215_n15InvoiceSubtotal ;
      private string[] T000216_A9CustomerName ;
      private short[] T000217_A6InvoiceID ;
      private short[] T00025_A6InvoiceID ;
      private DateTime[] T00025_A7InvoiceDate ;
      private short[] T00025_A8CustomerID ;
      private short[] T000218_A6InvoiceID ;
      private short[] T000219_A6InvoiceID ;
      private string[] T000220_A9CustomerName ;
      private short[] T000220_A8CustomerID ;
      private short[] T00024_A6InvoiceID ;
      private DateTime[] T00024_A7InvoiceDate ;
      private short[] T00024_A8CustomerID ;
      private short[] T000221_A6InvoiceID ;
      private decimal[] T000225_A15InvoiceSubtotal ;
      private bool[] T000225_n15InvoiceSubtotal ;
      private string[] T000226_A9CustomerName ;
      private short[] T000227_A6InvoiceID ;
      private short[] T000228_A6InvoiceID ;
      private short[] T000228_A10ProductID ;
      private string[] T000228_A11ProductName ;
      private decimal[] T000228_A12ProductPrice ;
      private short[] T000228_A13InvoiceProductQuantity ;
      private short[] T000229_A6InvoiceID ;
      private short[] T000229_A10ProductID ;
      private short[] T00023_A6InvoiceID ;
      private short[] T00023_A10ProductID ;
      private string[] T00023_A11ProductName ;
      private decimal[] T00023_A12ProductPrice ;
      private short[] T00023_A13InvoiceProductQuantity ;
      private short[] T00022_A6InvoiceID ;
      private short[] T00022_A10ProductID ;
      private string[] T00022_A11ProductName ;
      private decimal[] T00022_A12ProductPrice ;
      private short[] T00022_A13InvoiceProductQuantity ;
      private short[] T000233_A6InvoiceID ;
      private short[] T000233_A10ProductID ;
      private string[] T000234_A9CustomerName ;
      private string[] T000235_A9CustomerName ;
      private short[] T000235_A8CustomerID ;
      private decimal[] T000237_A15InvoiceSubtotal ;
      private bool[] T000237_n15InvoiceSubtotal ;
      private string[] T000238_A9CustomerName ;
      private short[] T000238_A8CustomerID ;
      private string[] T000239_A9CustomerName ;
   }

   public class transaction1__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@CustomerName",GXType.NChar,20,0)
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@CustomerName",GXType.NChar,20,0)
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT000220;
          prmT000220 = new Object[] {
          new ParDef("@CustomerName",GXType.NChar,20,0)
          };
          Object[] prmT000221;
          prmT000221 = new Object[] {
          new ParDef("@InvoiceDate",GXType.Date,8,0) ,
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmT000222;
          prmT000222 = new Object[] {
          new ParDef("@InvoiceDate",GXType.Date,8,0) ,
          new ParDef("@CustomerID",GXType.Int16,4,0) ,
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT000223;
          prmT000223 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT000225;
          prmT000225 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT000226;
          prmT000226 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          Object[] prmT000227;
          prmT000227 = new Object[] {
          };
          Object[] prmT000228;
          prmT000228 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmT000229;
          prmT000229 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmT000230;
          prmT000230 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0) ,
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,8,2) ,
          new ParDef("@InvoiceProductQuantity",GXType.Int16,4,0)
          };
          Object[] prmT000231;
          prmT000231 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,8,2) ,
          new ParDef("@InvoiceProductQuantity",GXType.Int16,4,0) ,
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmT000232;
          prmT000232 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0) ,
          new ParDef("@ProductID",GXType.Int16,4,0)
          };
          Object[] prmT000233;
          prmT000233 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT000234;
          prmT000234 = new Object[] {
          new ParDef("@l9CustomerName",GXType.NChar,20,0)
          };
          Object[] prmT000235;
          prmT000235 = new Object[] {
          new ParDef("@CustomerName",GXType.NChar,20,0)
          };
          Object[] prmT000237;
          prmT000237 = new Object[] {
          new ParDef("@InvoiceID",GXType.Int16,4,0)
          };
          Object[] prmT000238;
          prmT000238 = new Object[] {
          new ParDef("@CustomerName",GXType.NChar,20,0)
          };
          Object[] prmT000239;
          prmT000239 = new Object[] {
          new ParDef("@CustomerID",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [InvoiceID], [ProductID], [ProductName], [ProductPrice], [InvoiceProductQuantity] FROM [Transaction1Product] WITH (UPDLOCK) WHERE [InvoiceID] = @InvoiceID AND [ProductID] = @ProductID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [InvoiceID], [ProductID], [ProductName], [ProductPrice], [InvoiceProductQuantity] FROM [Transaction1Product] WHERE [InvoiceID] = @InvoiceID AND [ProductID] = @ProductID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT [InvoiceID], [InvoiceDate], [CustomerID] FROM [Transaction1] WITH (UPDLOCK) WHERE [InvoiceID] = @InvoiceID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT [InvoiceID], [InvoiceDate], [CustomerID] FROM [Transaction1] WHERE [InvoiceID] = @InvoiceID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT [CustomerName] FROM [Cliente] WHERE [CustomerID] = @CustomerID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT COALESCE( T1.[InvoiceSubtotal], 0) AS InvoiceSubtotal FROM (SELECT SUM([ProductPrice] * CAST([InvoiceProductQuantity] AS decimal( 18, 10))) AS InvoiceSubtotal, [InvoiceID] FROM [Transaction1Product] WITH (UPDLOCK) GROUP BY [InvoiceID] ) T1 WHERE T1.[InvoiceID] = @InvoiceID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00029", "SELECT [CustomerName], [CustomerID] FROM [Cliente] WHERE [CustomerID] = @CustomerID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000211", "SELECT TM1.[InvoiceID], TM1.[InvoiceDate], T3.[CustomerName], TM1.[CustomerID], COALESCE( T2.[InvoiceSubtotal], 0) AS InvoiceSubtotal FROM (([Transaction1] TM1 LEFT JOIN (SELECT SUM([ProductPrice] * CAST([InvoiceProductQuantity] AS decimal( 18, 10))) AS InvoiceSubtotal, [InvoiceID] FROM [Transaction1Product] GROUP BY [InvoiceID] ) T2 ON T2.[InvoiceID] = TM1.[InvoiceID]) INNER JOIN [Cliente] T3 ON T3.[CustomerID] = TM1.[CustomerID]) WHERE TM1.[InvoiceID] = @InvoiceID ORDER BY TM1.[InvoiceID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000212", "SELECT [CustomerName], [CustomerID] FROM [Cliente] WHERE [CustomerName] = @CustomerName  OPTION (FAST 0)",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000213", "SELECT [CustomerName], [CustomerID] FROM [Cliente] WHERE [CustomerName] = @CustomerName  OPTION (FAST 0)",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000215", "SELECT COALESCE( T1.[InvoiceSubtotal], 0) AS InvoiceSubtotal FROM (SELECT SUM([ProductPrice] * CAST([InvoiceProductQuantity] AS decimal( 18, 10))) AS InvoiceSubtotal, [InvoiceID] FROM [Transaction1Product] WITH (UPDLOCK) GROUP BY [InvoiceID] ) T1 WHERE T1.[InvoiceID] = @InvoiceID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000216", "SELECT [CustomerName] FROM [Cliente] WHERE [CustomerID] = @CustomerID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000217", "SELECT [InvoiceID] FROM [Transaction1] WHERE [InvoiceID] = @InvoiceID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000218", "SELECT TOP 1 [InvoiceID] FROM [Transaction1] WHERE ( [InvoiceID] > @InvoiceID) ORDER BY [InvoiceID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000219", "SELECT TOP 1 [InvoiceID] FROM [Transaction1] WHERE ( [InvoiceID] < @InvoiceID) ORDER BY [InvoiceID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000220", "SELECT [CustomerName], [CustomerID] FROM [Cliente] WHERE [CustomerName] = @CustomerName  OPTION (FAST 0)",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000221", "INSERT INTO [Transaction1]([InvoiceDate], [CustomerID]) VALUES(@InvoiceDate, @CustomerID); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000222", "UPDATE [Transaction1] SET [InvoiceDate]=@InvoiceDate, [CustomerID]=@CustomerID  WHERE [InvoiceID] = @InvoiceID", GxErrorMask.GX_NOMASK,prmT000222)
             ,new CursorDef("T000223", "DELETE FROM [Transaction1]  WHERE [InvoiceID] = @InvoiceID", GxErrorMask.GX_NOMASK,prmT000223)
             ,new CursorDef("T000225", "SELECT COALESCE( T1.[InvoiceSubtotal], 0) AS InvoiceSubtotal FROM (SELECT SUM([ProductPrice] * CAST([InvoiceProductQuantity] AS decimal( 18, 10))) AS InvoiceSubtotal, [InvoiceID] FROM [Transaction1Product] WITH (UPDLOCK) GROUP BY [InvoiceID] ) T1 WHERE T1.[InvoiceID] = @InvoiceID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000225,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000226", "SELECT [CustomerName] FROM [Cliente] WHERE [CustomerID] = @CustomerID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000226,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000227", "SELECT [InvoiceID] FROM [Transaction1] ORDER BY [InvoiceID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000227,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000228", "SELECT [InvoiceID], [ProductID], [ProductName], [ProductPrice], [InvoiceProductQuantity] FROM [Transaction1Product] WHERE [InvoiceID] = @InvoiceID and [ProductID] = @ProductID ORDER BY [InvoiceID], [ProductID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000228,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000229", "SELECT [InvoiceID], [ProductID] FROM [Transaction1Product] WHERE [InvoiceID] = @InvoiceID AND [ProductID] = @ProductID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000229,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000230", "INSERT INTO [Transaction1Product]([InvoiceID], [ProductID], [ProductName], [ProductPrice], [InvoiceProductQuantity]) VALUES(@InvoiceID, @ProductID, @ProductName, @ProductPrice, @InvoiceProductQuantity)", GxErrorMask.GX_NOMASK,prmT000230)
             ,new CursorDef("T000231", "UPDATE [Transaction1Product] SET [ProductName]=@ProductName, [ProductPrice]=@ProductPrice, [InvoiceProductQuantity]=@InvoiceProductQuantity  WHERE [InvoiceID] = @InvoiceID AND [ProductID] = @ProductID", GxErrorMask.GX_NOMASK,prmT000231)
             ,new CursorDef("T000232", "DELETE FROM [Transaction1Product]  WHERE [InvoiceID] = @InvoiceID AND [ProductID] = @ProductID", GxErrorMask.GX_NOMASK,prmT000232)
             ,new CursorDef("T000233", "SELECT [InvoiceID], [ProductID] FROM [Transaction1Product] WHERE [InvoiceID] = @InvoiceID ORDER BY [InvoiceID], [ProductID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000233,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000234", "SELECT DISTINCT TOP 5 [CustomerName] FROM [Cliente] WHERE UPPER([CustomerName]) like UPPER(@l9CustomerName) ORDER BY [CustomerName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000234,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000235", "SELECT [CustomerName], [CustomerID] FROM [Cliente] WHERE [CustomerName] = @CustomerName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000235,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000237", "SELECT COALESCE( T1.[InvoiceSubtotal], 0) AS InvoiceSubtotal FROM (SELECT SUM([ProductPrice] * CAST([InvoiceProductQuantity] AS decimal( 18, 10))) AS InvoiceSubtotal, [InvoiceID] FROM [Transaction1Product] WITH (UPDLOCK) GROUP BY [InvoiceID] ) T1 WHERE T1.[InvoiceID] = @InvoiceID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000237,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000238", "SELECT [CustomerName], [CustomerID] FROM [Cliente] WHERE [CustomerName] = @CustomerName  OPTION (FAST 0)",true, GxErrorMask.GX_NOMASK, false, this,prmT000238,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000239", "SELECT [CustomerName] FROM [Cliente] WHERE [CustomerID] = @CustomerID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000239,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 10 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 27 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 29 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 32 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
       }
    }

 }

}
