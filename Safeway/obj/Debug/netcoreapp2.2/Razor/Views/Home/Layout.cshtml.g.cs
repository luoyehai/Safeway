#pragma checksum "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02d31331ffd2c5ff3a5aff33b9d31a6b7e56a812"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Layout), @"mvc.1.0.view", @"/Views/Home/Layout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Layout.cshtml", typeof(AspNetCore.Views_Home_Layout))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\_ViewImports.cshtml"
using WalkingTec.Mvvm.TagHelpers.LayUI;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02d31331ffd2c5ff3a5aff33b9d31a6b7e56a812", @"/Views/Home/Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb6fecd289e437acbee50f7e1040b7eeb0a429e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WalkingTec.Mvvm.Core.BaseVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("url", "/Login/ChangePassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("url", "~/_CodeGen/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("url", "~/swagger", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/layuiadmin/style/res/logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-right:5px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::WalkingTec.Mvvm.TagHelpers.LayUI.LinkButtonTagHelper __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 261, true);
            WriteLiteral(@"
<div class=""layui-layout layui-layout-admin"">
  <div class=""layui-header"">

    <!-- 头部区域 -->
    <ul class=""layui-nav layui-layout-left"">
      <li class=""layui-nav-item layadmin-flexible"" lay-unselect>
        <a href=""javascript:;"" layadmin-event=""flexible""");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 296, "\"", 332, 1);
#line 9 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
WriteAttributeValue("", 304, Model.Localizer["HideShow"], 304, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(333, 233, true);
            WriteLiteral(">\n          <i class=\"layui-icon layui-icon-shrink-right\" id=\"LAY_app_flexible\"></i>\n        </a>\n      </li>\n      <li class=\"layui-nav-item layui-hide-xs\" lay-unselect>\n        <a href=\"https://wtmdoc.walkingtec.cn\" target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 566, "\"", 600, 1);
#line 14 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
WriteAttributeValue("", 574, Model.Localizer["WtmDoc"], 574, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(601, 185, true);
            WriteLiteral(">\n          <i class=\"layui-icon layui-icon-website\"></i>\n        </a>\n      </li>\n      <li class=\"layui-nav-item\" lay-unselect>\n        <a href=\"javascript:;\" layadmin-event=\"refresh\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 786, "\"", 821, 1);
#line 19 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
WriteAttributeValue("", 794, Model.Localizer["Refresh"], 794, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(822, 657, true);
            WriteLiteral(@">
          <i class=""layui-icon layui-icon-refresh-3""></i>
        </a>
      </li>
    </ul>
    <ul class=""layui-nav layui-layout-right"" lay-filter=""layadmin-layout-right"">

      <li class=""layui-nav-item layui-hide-xs"" lay-unselect>
        <a href=""javascript:;"" layadmin-event=""theme"">
          <i class=""layui-icon layui-icon-theme""></i>
        </a>
      </li>
      <li class=""layui-nav-item layui-hide-xs"" lay-unselect>
        <a href=""javascript:;"" layadmin-event=""fullscreen"">
          <i class=""layui-icon layui-icon-screen-full""></i>
        </a>
      </li>
      <li class=""layui-nav-item"" lay-unselect>
        <a href=""javascript:;"">
");
            EndContext();
#line 38 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
           if(Model.LoginUserInfo?.PhotoId != null)
          {

#line default
#line hidden
            BeginContext(1543, 36, true);
            WriteLiteral("          <img class=\"layui-nav-img\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1579, "\"", 1631, 2);
            WriteAttributeValue("", 1585, "api/_file/getfile/", 1585, 18, true);
#line 40 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
WriteAttributeValue("", 1603, Model.LoginUserInfo.PhotoId, 1603, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1632, 4, true);
            WriteLiteral(" />\n");
            EndContext();
#line 41 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
          }

#line default
#line hidden
            BeginContext(1648, 16, true);
            WriteLiteral("          <cite>");
            EndContext();
            BeginContext(1665, 24, false);
#line 42 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
           Write(Model.LoginUserInfo.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1689, 85, true);
            WriteLiteral("</cite>\n        </a>\n        <dl class=\"layui-nav-child\">\n          <dd>\n            ");
            EndContext();
            BeginContext(1774, 121, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:linkbutton", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "02d31331ffd2c5ff3a5aff33b9d31a6b7e56a8128906", async() => {
            }
            );
            __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.LinkButtonTagHelper>();
            __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper);
            __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Url = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 46 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.WindowWidth = 400;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("window-width", __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.WindowWidth, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 46 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
                                                                    WriteLiteral(Model.Localizer["ChangePassword"]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Text = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("text", __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Text, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 46 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.IsLink = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("is-link", __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.IsLink, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1895, 67, true);
            WriteLiteral("\n          </dd>\n          <dd><a href=\"javascript:;\" lay-href=\"/\">");
            EndContext();
            BeginContext(1963, 27, false);
#line 48 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
                                             Write(Model.Localizer["BackHome"]);

#line default
#line hidden
            EndContext();
            BeginContext(1990, 10, true);
            WriteLiteral("</a></dd>\n");
            EndContext();
#line 49 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
            
            if(ViewData["debug"] is bool debug && debug)
            {

#line default
#line hidden
            BeginContext(2084, 35, true);
            WriteLiteral("              <dd>\n                ");
            EndContext();
            BeginContext(2119, 187, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:linkbutton", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "02d31331ffd2c5ff3a5aff33b9d31a6b7e56a81212448", async() => {
            }
            );
            __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.LinkButtonTagHelper>();
            __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper);
            __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Url = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 53 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Target = ButtonTargetEnum.newwindow;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("target", __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Target, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 53 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.IsLink = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("is-link", __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.IsLink, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
                                                                                                   WriteLiteral(Model.Localizer["CodeGen"]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Text = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("text", __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Text, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 54 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
                    WriteLiteral(Model.Localizer["CodeGen"]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.WindowTitle = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("window-title", __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.WindowTitle, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2306, 57, true);
            WriteLiteral("\n              </dd>\n               <dd>\n                ");
            EndContext();
            BeginContext(2363, 178, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("wt:linkbutton", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "02d31331ffd2c5ff3a5aff33b9d31a6b7e56a81215936", async() => {
            }
            );
            __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper = CreateTagHelper<global::WalkingTec.Mvvm.TagHelpers.LayUI.LinkButtonTagHelper>();
            __tagHelperExecutionContext.Add(__WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper);
            __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Url = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 57 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Target = ButtonTargetEnum.newwindow;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("target", __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Target, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 57 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
__WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.IsLink = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("is-link", __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.IsLink, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 57 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
                                                                                            WriteLiteral(Model.Localizer["ApiDoc"]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Text = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("text", __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.Text, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 58 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
                    WriteLiteral(Model.Localizer["ApiDoc"]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.WindowTitle = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("window-title", __WalkingTec_Mvvm_TagHelpers_LayUI_LinkButtonTagHelper.WindowTitle, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2541, 21, true);
            WriteLiteral("\n              </dd>\n");
            EndContext();
#line 60 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
             }
        

#line default
#line hidden
            BeginContext(2587, 83, true);
            WriteLiteral("        </dl>\n      </li>\n      <li class=\"layui-nav-item\"><a href=\"/Login/Logout\">");
            EndContext();
            BeginContext(2671, 25, false);
#line 64 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
                                                    Write(Model.Localizer["LogOut"]);

#line default
#line hidden
            EndContext();
            BeginContext(2696, 527, true);
            WriteLiteral(@"</a></li>
    </ul>
  </div>

  <!-- 侧边菜单 -->
  <div class=""layui-side layui-side-menu"">
    <div class=""layui-side-scroll"">
      <!-- <script type=""text/html"" template lay-url=""./json/menu.js?v={{ layui.admin.v }}"" -->
      <script type=""text/html"" template lay-url=""/_Framework/Menu""
        lay-done=""layui.element.render('nav', 'layadmin-system-side-menu');layui.event.call(this, layui.setter.MOD_NAME, 'hash({*})', layui.router());"" id=""TPL_layout"">

            <div class=""layui-logo"" lay-href="""">
              <span>");
            EndContext();
            BeginContext(3223, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "02d31331ffd2c5ff3a5aff33b9d31a6b7e56a81220626", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3292, 3748, true);
            WriteLiteral(@"{{ layui.setter.name || 'layuiAdmin' }}</span>
            </div>

            <ul class=""layui-nav layui-nav-tree"" lay-shrink=""all"" id=""LAY-system-side-menu"" lay-filter=""layadmin-system-side-menu"">
            {{#
              var path =  layui.router().path
              ,pathURL = layui.admin.correctRouter(path.join('/'))
              ,dataName = layui.setter.response.dataName;

              layui.each(d[dataName], function(index, item){
                var hasChildren = typeof item.list === 'object' && item.list.length > 0
                ,url = (item.jump && typeof item.jump === 'string') ? item.jump : item.name;
            }}
              <li data-name=""{{ item.name || '' }}"" data-jump=""{{ item.jump || '' }}"" class=""layui-nav-item "">
                <a href=""javascript:;"" {{ hasChildren ? '' : 'lay-href=""'+ url +'""' }} lay-tips=""{{ item.title }}"" lay-direction=""2"">
                  <i class=""{{ item.icon }}""></i>
                  <cite>{{ item.title }}</cite>
                </a>
                ");
            WriteLiteral(@"{{# if(hasChildren){ }}
                  <dl class=""layui-nav-child"">
                  {{# layui.each(item.list, function(index2, item2){
                    var hasChildren2 = typeof item2.list == 'object' && item2.list.length > 0
                    ,url2 = (item2.jump && typeof item2.jump === 'string')
                      ? item2.jump
                    : [item.name, item2.name, ''].join('/');
                  }}
                    <dd  data-name=""{{ item2.name || '' }}""  data-jump=""{{ item2.jump || '' }}"">
                      <a href=""javascript:;"" {{ hasChildren2 ? '' : 'lay-href=""'+ url2 +'""' }}>
                        <i class=""{{ item2.icon }}""></i>
                        <cite>{{ item2.title }}</cite>
                      </a>
                      {{# if(hasChildren2){ }}
                        <dl class=""layui-nav-child"">
                          {{# layui.each(item2.list, function(index3, item3){
                            var url3 = (item3.jump && typeof item3.jump === 'string')
  ");
            WriteLiteral(@"                            ? item3.jump
                            : [item.name, item2.name, item3.name].join('/')
                          }}
                            <dd data-name=""{{ item3.name || '' }}""  data-jump=""{{ item3.jump || '' }}"" >
                              <a href=""javascript:;"" lay-href=""{{ url3 }}"" {{ item3.iframe ? 'lay-iframe=""true""' : '' }}>
                                <i class=""{{ item3.icon }}""></i>
                                <cite>{{ item3.title }}</cite>
                              </a>
                            </dd>
                          {{# }); }}
                        </dl>
                      {{# } }}
                    </dd>
                {{# }); }}
                </dl>
                {{# } }}
              </li>
            {{# }); }}
            </ul>
          </script>
    </div>
  </div>

  <!-- 页面标签 -->
  <script type=""text/html"" template lay-done=""layui.element.render('nav', 'layadmin-pagetabs-nav')"">
        {{# if(layui.setter.pageTabs)");
            WriteLiteral(@"{ }}
        <div class=""layadmin-pagetabs"" id=""LAY_app_tabs"">
          <div class=""layui-icon layadmin-tabs-control layui-icon-prev"" layadmin-event=""leftPage""></div>
          <div class=""layui-icon layadmin-tabs-control layui-icon-next"" layadmin-event=""rightPage""></div>
          <div class=""layui-icon layadmin-tabs-control layui-icon-down"">
            <ul class=""layui-nav layadmin-tabs-select"" lay-filter=""layadmin-pagetabs-nav"">
              <li class=""layui-nav-item"" lay-unselect>
                <a href=""javascript:;""></a>
                <dl class=""layui-nav-child layui-anim-fadein"">
                  <dd layadmin-event=""closeThisTabs""><a href=""javascript:;"">");
            EndContext();
            BeginContext(7041, 31, false);
#line 145 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
                                                                       Write(Model.Localizer["CloseThisTag"]);

#line default
#line hidden
            EndContext();
            BeginContext(7072, 87, true);
            WriteLiteral("</a></dd>\n                  <dd layadmin-event=\"closeOtherTabs\"><a href=\"javascript:;\">");
            EndContext();
            BeginContext(7160, 33, false);
#line 146 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
                                                                        Write(Model.Localizer["CloseOtherTags"]);

#line default
#line hidden
            EndContext();
            BeginContext(7193, 85, true);
            WriteLiteral("</a></dd>\n                  <dd layadmin-event=\"closeAllTabs\"><a href=\"javascript:;\">");
            EndContext();
            BeginContext(7279, 31, false);
#line 147 "C:\Users\bettyzhao\Documents\Safeway\Safeway\Views\Home\Layout.cshtml"
                                                                      Write(Model.Localizer["CloseAllTags"]);

#line default
#line hidden
            EndContext();
            BeginContext(7310, 643, true);
            WriteLiteral(@"</a></dd>
                </dl>
              </li>
            </ul>
          </div>
          <div class=""layui-tab"" lay-unauto lay-allowClose=""true"" lay-filter=""layadmin-layout-tabs"">
            <ul class=""layui-tab-title"" id=""LAY_app_tabsheader"">
              <li lay-id=""/""><i class=""layui-icon layui-icon-home""></i></li>
            </ul>
          </div>
        </div>
        {{# } }}
      </script>

  <!-- 主体内容 -->
  <div class=""layui-body"" id=""LAY_app_body"">
    <div class=""layadmin-tabsbody-item layui-show""></div>
  </div>

  <!-- 辅助元素，一般用于移动设备下遮罩 -->
  <div class=""layadmin-body-shade"" layadmin-event=""shade""></div>
</div>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WalkingTec.Mvvm.Core.BaseVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
