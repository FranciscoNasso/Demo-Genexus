var __awaiter=this&&this.__awaiter||function(n,t,e,r){function i(n){return n instanceof e?n:new e((function(t){t(n)}))}return new(e||(e=Promise))((function(e,u){function o(n){try{a(r.next(n))}catch(n){u(n)}}function c(n){try{a(r["throw"](n))}catch(n){u(n)}}function a(n){n.done?e(n.value):i(n.value).then(o,c)}a((r=r.apply(n,t||[])).next())}))};var __generator=this&&this.__generator||function(n,t){var e={label:0,sent:function(){if(u[0]&1)throw u[1];return u[1]},trys:[],ops:[]},r,i,u,o;return o={next:c(0),throw:c(1),return:c(2)},typeof Symbol==="function"&&(o[Symbol.iterator]=function(){return this}),o;function c(n){return function(t){return a([n,t])}}function a(c){if(r)throw new TypeError("Generator is already executing.");while(o&&(o=0,c[0]&&(e=0)),e)try{if(r=1,i&&(u=c[0]&2?i["return"]:c[0]?i["throw"]||((u=i["return"])&&u.call(i),0):i.next)&&!(u=u.call(i,c[1])).done)return u;if(i=0,u)c=[c[0]&2,u.value];switch(c[0]){case 0:case 1:u=c;break;case 4:e.label++;return{value:c[1],done:false};case 5:e.label++;i=c[1];c=[0];continue;case 7:c=e.ops.pop();e.trys.pop();continue;default:if(!(u=e.trys,u=u.length>0&&u[u.length-1])&&(c[0]===6||c[0]===2)){e=0;continue}if(c[0]===3&&(!u||c[1]>u[0]&&c[1]<u[3])){e.label=c[1];break}if(c[0]===6&&e.label<u[1]){e.label=u[1];u=c;break}if(u&&e.label<u[2]){e.label=u[2];e.ops.push(c);break}if(u[2])e.ops.pop();e.trys.pop();continue}c=t.call(n,e)}catch(n){c=[6,n];i=0}finally{r=u=0}if(c[0]&5)throw c[1];return{value:c[0]?c[1]:void 0,done:true}}};System.register(["./p-62fc4e49.system.js","./p-3adf2593.system.js"],(function(n){"use strict";var t,e,r,i;return{setters:[function(n){t=n.r;e=n.c;r=n.g},function(n){i=n.r}],execute:function(){var u=new Map;var o=/(url\((?!\s*["']?(?:\/|https?:|data:))\s*["']?)([^'")]+)/g;var c=function(n){return n.styleSheet?!n.styleSheet.disabled:false};function a(n){var t=s(n);if(c(t)){v(n,t);_(n);return}h(n,t).then((function(n){if(n){w(t);l(t);y(t)}}))}function f(n){var t=u.get(n.name);var e=t.elements.indexOf(n);if(t&&e>=0){i(t.elements,e)}}function s(n){var t;var e=(t=u.get(n.name))!==null&&t!==void 0?t:u.set(n.name,{elements:[]}).get(n.name);e.elements.push(n);return e}function h(n,t){return __awaiter(this,void 0,void 0,(function(){var e;return __generator(this,(function(r){switch(r.label){case 0:e=false;if(!(typeof n.href==="string"&&n.href.trim()!==""&&!t.elements.some((function(t){return t!==n&&t.href===n.href}))))return[3,2];return[4,m(n.href,d(n,t),n.baseUrl)];case 1:e=r.sent();return[3,4];case 2:if(!!n.innerText.match(/^\s*$/))return[3,4];return[4,b(n.innerText,d(n,t),n.baseUrl)];case 3:e=r.sent();r.label=4;case 4:return[2,e]}}))}))}function d(n,t){t.styleSheet||(t.styleSheet=new CSSStyleSheet({disabled:true,baseURL:n.baseUrl}));return t.styleSheet}function v(n,t){var e=n.getRootNode();if(e instanceof Document||e instanceof ShadowRoot){if(!e.adoptedStyleSheets.includes(t.styleSheet)){e.adoptedStyleSheets.push(t.styleSheet)}}}function l(n){n.elements.forEach((function(t){return v(t,n)}))}function w(n){n.styleSheet.disabled=false}function _(n){n.loaded=true}function y(n){n.elements.forEach((function(n){return _(n)}))}function b(n,t,e){var r=this;return new Promise((function(i){return __awaiter(r,void 0,void 0,(function(){return __generator(this,(function(r){try{i(S(t,p(e,n)))}catch(n){i(false)}return[2]}))}))}))}function m(n,t,e){return __awaiter(this,void 0,void 0,(function(){var r=this;return __generator(this,(function(i){return[2,new Promise((function(i){return __awaiter(r,void 0,void 0,(function(){var r,u,o,c,a,f;return __generator(this,(function(s){switch(s.label){case 0:s.trys.push([0,2,,3]);r=i;u=S;o=[t];c=p;a=[e];return[4,g(n)];case 1:r.apply(void 0,[u.apply(void 0,o.concat([c.apply(void 0,a.concat([s.sent()]))]))]);return[3,3];case 2:f=s.sent();i(false);return[3,3];case 3:return[2]}}))}))}))]}))}))}function g(n){return __awaiter(this,void 0,void 0,(function(){var t,e;return __generator(this,(function(r){switch(r.label){case 0:r.trys.push([0,4,,5]);return[4,fetch(n)];case 1:t=r.sent();if(!t.ok)return[3,3];return[4,t.text()];case 2:return[2,r.sent()];case 3:throw new Error("Network response was not ok.");case 4:e=r.sent();throw e;case 5:return[2]}}))}))}function S(n,t){var e=this;return new Promise((function(r){return __awaiter(e,void 0,void 0,(function(){var e,i,u,o,c;return __generator(this,(function(a){switch(a.label){case 0:a.trys.push([0,2,,3]);return[4,new CSSStyleSheet({disabled:true}).replace(t)];case 1:e=a.sent();for(i=0,u=e.cssRules;i<u.length;i++){o=u[i];n.insertRule(o.cssText)}r(true);return[3,3];case 2:c=a.sent();r(false);return[3,3];case 3:return[2]}}))}))}))}function p(n,t){if(n){return t.replace(o,"$1".concat(n,"$2"))}return t}var k=n("ch_theme",function(){function n(n){t(this,n);this.themeLoaded=e(this,"themeLoaded",5);this.name=undefined;this.href=undefined;this.baseUrl=undefined;this.loaded=false}Object.defineProperty(n.prototype,"el",{get:function(){return r(this)},enumerable:false,configurable:true});n.prototype.loadedHandler=function(){var n;if(this.loaded){this.themeLoaded.emit({name:(n=this.name)!==null&&n!==void 0?n:""})}};n.prototype.connectedCallback=function(){this.el.hidden=true};n.prototype.componentWillLoad=function(){a(this.el)};n.prototype.disconnectedCallback=function(){f(this.el)};Object.defineProperty(n,"watchers",{get:function(){return{loaded:["loadedHandler"]}},enumerable:false,configurable:true});return n}())}}}));
//# sourceMappingURL=p-23b3a978.system.entry.js.map